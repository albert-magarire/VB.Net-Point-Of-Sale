Imports System.Data.OleDb
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Centralized data access layer for the Boss Cafe POS system
''' Provides secure database operations with proper error handling
''' </summary>
Public Class DataAccessLayer
    Private Shared ReadOnly ConnectionString As String = My.Settings.BossConnectionString
    Private Shared ReadOnly MaxRetryAttempts As Integer = 3
    Private Shared ReadOnly PasswordHashIterations As Integer = 20000
    Private Shared ReadOnly PasswordSaltSize As Integer = 16

    ''' <summary>
    ''' Creates a new database connection with proper error handling
    ''' </summary>
    ''' <returns>OleDbConnection object</returns>
    Public Shared Function CreateConnection() As OleDbConnection
        Try
            Dim connection As New OleDbConnection(ConnectionString)
            Return connection
        Catch ex As Exception
            Throw New DataAccessException("Failed to create database connection", ex)
        End Try
    End Function

    ''' <summary>
    ''' Executes a parameterized query safely
    ''' </summary>
    ''' <param name="query">SQL query with parameters</param>
    ''' <param name="parameters">Dictionary of parameter names and values</param>
    ''' <returns>DataReader with results</returns>
    Public Shared Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object)) As OleDbDataReader
        Dim connection As OleDbConnection = Nothing
        Try
            connection = CreateConnection()
            connection.Open()
            
            Dim command As New OleDbCommand(query, connection)
            
            ' Add parameters safely
            If parameters IsNot Nothing Then
                For Each param In parameters
                    command.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                Next
            End If
            
            Return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Catch ex As Exception
            If connection IsNot Nothing Then connection.Close()
            Throw New DataAccessException("Failed to execute query: " & query, ex)
        End Try
    End Function

    ''' <summary>
    ''' Executes a parameterized non-query command (INSERT, UPDATE, DELETE)
    ''' </summary>
    ''' <param name="query">SQL command with parameters</param>
    ''' <param name="parameters">Dictionary of parameter names and values</param>
    ''' <returns>Number of affected rows</returns>
    Public Shared Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object)) As Integer
        Dim connection As OleDbConnection = Nothing
        Try
            connection = CreateConnection()
            connection.Open()
            
            Dim command As New OleDbCommand(query, connection)
            
            ' Add parameters safely
            If parameters IsNot Nothing Then
                For Each param In parameters
                    command.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                Next
            End If
            
            Return command.ExecuteNonQuery()
        Catch ex As Exception
            Throw New DataAccessException("Failed to execute non-query: " & query, ex)
        Finally
            If connection IsNot Nothing Then connection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Executes a scalar query safely
    ''' </summary>
    ''' <param name="query">SQL query with parameters</param>
    ''' <param name="parameters">Dictionary of parameter names and values</param>
    ''' <returns>Single value result</returns>
    Public Shared Function ExecuteScalar(query As String, parameters As Dictionary(Of String, Object)) As Object
        Dim connection As OleDbConnection = Nothing
        Try
            connection = CreateConnection()
            connection.Open()
            
            Dim command As New OleDbCommand(query, connection)
            
            ' Add parameters safely
            If parameters IsNot Nothing Then
                For Each param In parameters
                    command.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                Next
            End If
            
            Return command.ExecuteScalar()
        Catch ex As Exception
            Throw New DataAccessException("Failed to execute scalar query: " & query, ex)
        Finally
            If connection IsNot Nothing Then connection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Validates user credentials with salted-hash (migrates plaintext to hashed format on first success)
    ''' </summary>
    Public Shared Function ValidateUser(accountType As String, password As String) As Boolean
        Try
            EnsureSecurityTables()

            Dim getPassQuery As String = "SELECT Passcode FROM Users WHERE AccType = @AccType"
            Dim passParams As New Dictionary(Of String, Object) From {
                {"@AccType", accountType}
            }

            Dim stored As Object = ExecuteScalar(getPassQuery, passParams)
            If stored Is Nothing OrElse stored Is DBNull.Value Then
                Return False
            End If

            Dim storedValue As String = stored.ToString()

            Dim isMatch As Boolean
            If storedValue.StartsWith("v1:") Then
                isMatch = VerifyPassword(storedValue, password)
            Else
                ' Legacy plaintext compare
                isMatch = String.Equals(storedValue, password)
                If isMatch Then
                    ' Migrate to salted-hash
                    Dim migrated As String = HashPasswordWithSalt(password)
                    Dim updQuery As String = "UPDATE Users SET Passcode = @Passcode WHERE AccType = @AccType"
                    Dim updParams As New Dictionary(Of String, Object) From {
                        {"@Passcode", migrated},
                        {"@AccType", accountType}
                    }
                    ExecuteNonQuery(updQuery, updParams)
                End If
            End If

            Return isMatch
        Catch ex As Exception
            Throw New DataAccessException("Failed to validate user credentials", ex)
        End Try
    End Function

    ''' <summary>
    ''' Creates salted PBKDF2 hash in storage format v1:base64salt:base64hash
    ''' </summary>
    Public Shared Function HashPasswordWithSalt(password As String) As String
        Dim salt As Byte() = CreateRandomSalt(PasswordSaltSize)
        Dim hash As Byte() = DerivePbkdf2(password, salt, PasswordHashIterations, 32)
        Return $"v1:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}"
    End Function

    Private Shared Function VerifyPassword(stored As String, password As String) As Boolean
        Try
            ' Format: v1:base64salt:base64hash
            Dim parts = stored.Split({":"c}, StringSplitOptions.None)
            If parts.Length <> 3 OrElse parts(0) <> "v1" Then Return False
            Dim salt As Byte() = Convert.FromBase64String(parts(1))
            Dim expected As Byte() = Convert.FromBase64String(parts(2))
            Dim actual As Byte() = DerivePbkdf2(password, salt, PasswordHashIterations, expected.Length)
            Return ConstantTimeEquals(expected, actual)
        Catch
            Return False
        End Try
    End Function

    Private Shared Function CreateRandomSalt(length As Integer) As Byte()
        Dim salt(length - 1) As Byte
        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            rng.GetBytes(salt)
        End Using
        Return salt
    End Function

    Private Shared Function DerivePbkdf2(password As String, salt As Byte(), iterations As Integer, length As Integer) As Byte()
        Using kdf As New Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256)
            Return kdf.GetBytes(length)
        End Using
    End Function

    Private Shared Function ConstantTimeEquals(a As Byte(), b As Byte()) As Boolean
        If a Is Nothing OrElse b Is Nothing OrElse a.Length <> b.Length Then Return False
        Dim diff As Integer = 0
        For i As Integer = 0 To a.Length - 1
            diff = diff Or (a(i) Xor b(i))
        Next
        Return diff = 0
    End Function

    ''' <summary>
    ''' Ensure security-related tables exist (AuditLog, AuthState)
    ''' </summary>
    Public Shared Sub EnsureSecurityTables()
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                ' Create AuditLog table
                Try
                    Dim createAudit As String = "CREATE TABLE AuditLog (Id COUNTER PRIMARY KEY, EventType TEXT(50), AccType TEXT(50), Details TEXT(255), CreatedAt DATETIME)"
                    Using cmd As New OleDbCommand(createAudit, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                    ' ignore if exists
                End Try

                ' Create AuthState table
                Try
                    Dim createState As String = "CREATE TABLE AuthState (AccType TEXT(50), FailedAttempts INTEGER, LockoutUntil DATETIME)"
                    Using cmd As New OleDbCommand(createState, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                    ' ignore if exists
                End Try
            End Using
        Catch
            ' ignore
        End Try
    End Sub

    Public Shared Function GetLockoutUntil(accountType As String) As Nullable(Of DateTime)
        Try
            Dim q As String = "SELECT LockoutUntil FROM AuthState WHERE AccType = @AccType"
            Dim p As New Dictionary(Of String, Object) From {{"@AccType", accountType}}
            Dim obj = ExecuteScalar(q, p)
            If obj Is Nothing OrElse obj Is DBNull.Value Then Return Nothing
            Dim dt As DateTime
            If DateTime.TryParse(obj.ToString(), dt) Then
                Return dt
            End If
            Return Nothing
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Function RegisterFailedLogin(accountType As String, maxAttempts As Integer, lockoutMinutes As Integer) As Integer
        EnsureSecurityTables()
        Dim currentAttempts As Integer = 0
        Dim exists As Boolean = False
        Using conn As New OleDbConnection(ConnectionString)
            conn.Open()
            ' Read current
            Using sel As New OleDbCommand("SELECT FailedAttempts, LockoutUntil FROM AuthState WHERE AccType = @AccType", conn)
                sel.Parameters.AddWithValue("@AccType", accountType)
                Using r = sel.ExecuteReader()
                    If r.Read() Then
                        exists = True
                        currentAttempts = If(IsDBNull(r(0)), 0, Convert.ToInt32(r(0)))
                        Dim lockUntil As DateTime = If(IsDBNull(r(1)), Date.MinValue, Convert.ToDateTime(r(1)))
                        If lockUntil > DateTime.Now Then
                            ' still locked; keep attempts as is
                        End If
                    End If
                End Using
            End Using

            currentAttempts += 1
            Dim newLockout As Object = DBNull.Value
            If currentAttempts >= maxAttempts Then
                newLockout = DateTime.Now.AddMinutes(lockoutMinutes)
            End If

            If exists Then
                Using upd As New OleDbCommand("UPDATE AuthState SET FailedAttempts = @FA, LockoutUntil = @LU WHERE AccType = @AccType", conn)
                    upd.Parameters.AddWithValue("@FA", currentAttempts)
                    If TypeOf newLockout Is DateTime Then
                        upd.Parameters.AddWithValue("@LU", CType(newLockout, DateTime))
                    Else
                        upd.Parameters.AddWithValue("@LU", DBNull.Value)
                    End If
                    upd.Parameters.AddWithValue("@AccType", accountType)
                    upd.ExecuteNonQuery()
                End Using
            Else
                Using ins As New OleDbCommand("INSERT INTO AuthState (AccType, FailedAttempts, LockoutUntil) VALUES (@AccType, @FA, @LU)", conn)
                    ins.Parameters.AddWithValue("@AccType", accountType)
                    ins.Parameters.AddWithValue("@FA", currentAttempts)
                    If TypeOf newLockout Is DateTime Then
                        ins.Parameters.AddWithValue("@LU", CType(newLockout, DateTime))
                    Else
                        ins.Parameters.AddWithValue("@LU", DBNull.Value)
                    End If
                    ins.ExecuteNonQuery()
                End Using
            End If
        End Using
        Return currentAttempts
    End Function

    Public Shared Sub RegisterSuccessfulLogin(accountType As String)
        EnsureSecurityTables()
        Using conn As New OleDbConnection(ConnectionString)
            conn.Open()
            Dim exists As Boolean = False
            Using sel As New OleDbCommand("SELECT AccType FROM AuthState WHERE AccType = @AccType", conn)
                sel.Parameters.AddWithValue("@AccType", accountType)
                Using r = sel.ExecuteReader()
                    exists = r.Read()
                End Using
            End Using
            If exists Then
                Using upd As New OleDbCommand("UPDATE AuthState SET FailedAttempts = 0, LockoutUntil = NULL WHERE AccType = @AccType", conn)
                    upd.Parameters.AddWithValue("@AccType", accountType)
                    upd.ExecuteNonQuery()
                End Using
            Else
                Using ins As New OleDbCommand("INSERT INTO AuthState (AccType, FailedAttempts, LockoutUntil) VALUES (@AccType, 0, NULL)", conn)
                    ins.Parameters.AddWithValue("@AccType", accountType)
                    ins.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Gets daily totals for a specific date
    ''' </summary>
    ''' <param name="targetDate">Date to get totals for</param>
    ''' <returns>Daily totals data</returns>
    Public Shared Function GetDailyTotals(targetDate As DateTime) As DailyTotalsData
        Try
            Dim query As String = "SELECT TDate, ZTotal, UTotal, NoR FROM DTotals WHERE TDate = @Date"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Date", targetDate.Date}
            }
            
            Using reader As OleDbDataReader = ExecuteQuery(query, parameters)
                If reader.Read() Then
                    Return New DailyTotalsData With {
                        .[Date] = Convert.ToDateTime(reader("TDate")),
                        .ZTotal = If(IsDBNull(reader("ZTotal")), 0D, Convert.ToDecimal(reader("ZTotal"))),
                        .UTotal = If(IsDBNull(reader("UTotal")), 0D, Convert.ToDecimal(reader("UTotal"))),
                        .ReceiptCount = If(IsDBNull(reader("NoR")), 0, Convert.ToInt32(reader("NoR")))
                    }
                Else
                    Return New DailyTotalsData With {
                        .[Date] = targetDate.Date,
                        .ZTotal = 0,
                        .UTotal = 0,
                        .ReceiptCount = 0
                    }
                End If
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to get daily totals", ex)
        End Try
    End Function

    ''' <summary>
    ''' Updates daily totals
    ''' </summary>
    ''' <param name="dailyTotals">Daily totals data to update</param>
    Public Shared Sub UpdateDailyTotals(dailyTotals As DailyTotalsData)
        Try
            Dim query As String = "UPDATE DTotals SET ZTotal = @ZTotal, UTotal = @UTotal, NoR = @NoR WHERE TDate = @Date"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@ZTotal", dailyTotals.ZTotal},
                {"@UTotal", dailyTotals.UTotal},
                {"@NoR", dailyTotals.ReceiptCount},
                {"@Date", dailyTotals.[Date]}
            }
            
            Dim rowsAffected As Integer = ExecuteNonQuery(query, parameters)
            If rowsAffected = 0 Then
                Dim insertQuery As String = "INSERT INTO DTotals (TDate, ZTotal, UTotal, NoR) VALUES (@Date, @ZTotal, @UTotal, @NoR)"
                Dim insertParams As New Dictionary(Of String, Object) From {
                    {"@Date", dailyTotals.[Date]},
                    {"@ZTotal", dailyTotals.ZTotal},
                    {"@UTotal", dailyTotals.UTotal},
                    {"@NoR", dailyTotals.ReceiptCount}
                }
                ExecuteNonQuery(insertQuery, insertParams)
            End If
        Catch ex As Exception
            Throw New DataAccessException("Failed to update daily totals", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Inserts a new sale record
    ''' </summary>
    ''' <param name="sale">Sale data to insert</param>
    Public Shared Sub InsertSale(sale As SaleData)
        Try
            Dim query As String = "INSERT INTO Sales (Code, Quantity, Receipt, Price, Total, Date, Waiter, Order, Currency, Description) VALUES (@Code, @Quantity, @Receipt, @Price, @Total, @Date, @Waiter, @Order, @Currency, @Description)"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Code", sale.Code},
                {"@Quantity", sale.Quantity},
                {"@Receipt", sale.Receipt},
                {"@Price", sale.Price},
                {"@Total", sale.Total},
                {"@Date", sale.[Date]},
                {"@Waiter", sale.Waiter},
                {"@Order", sale.Order},
                {"@Currency", sale.Currency},
                {"@Description", sale.Description}
            }
            
            ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Throw New DataAccessException("Failed to insert sale", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Gets products by category
    ''' </summary>
    ''' <param name="category">Product category</param>
    ''' <returns>List of products</returns>
    Public Shared Function GetProductsByCategory(category As String) As List(Of ProductData)
        Dim products As New List(Of ProductData)
        Try
            Dim query As String = "SELECT Code, Description, Category, ZWL, USD FROM Products WHERE Category = @Category"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Category", category}
            }
            
            Using reader As OleDbDataReader = ExecuteQuery(query, parameters)
                While reader.Read()
                    products.Add(New ProductData With {
                        .Code = reader("Code").ToString(),
                        .Description = If(IsDBNull(reader("Description")), "", reader("Description").ToString()),
                        .Category = If(IsDBNull(reader("Category")), "", reader("Category").ToString()),
                        .ZWL = If(IsDBNull(reader("ZWL")), 0, Convert.ToDecimal(reader("ZWL"))),
                        .USD = If(IsDBNull(reader("USD")), 0, Convert.ToDecimal(reader("USD")))
                    })
                End While
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to get products by category", ex)
        End Try
        
        Return products
    End Function
    
    ' Gets a single product by code
    Public Shared Function GetProductByCode(code As String) As ProductData
        Try
            Dim query As String = "SELECT Code, Description, Category, ZWL, USD FROM Products WHERE Code = @Code"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Code", code}
            }

            Using reader As OleDbDataReader = ExecuteQuery(query, parameters)
                If reader.Read() Then
                    Return New ProductData With {
                        .Code = reader("Code").ToString(),
                        .Description = If(IsDBNull(reader("Description")), "", reader("Description").ToString()),
                        .Category = If(IsDBNull(reader("Category")), "", reader("Category").ToString()),
                        .ZWL = If(IsDBNull(reader("ZWL")), 0D, Convert.ToDecimal(reader("ZWL"))),
                        .USD = If(IsDBNull(reader("USD")), 0D, Convert.ToDecimal(reader("USD")))
                    }
                End If
            End Using

            Return Nothing
        Catch ex As Exception
            Throw New DataAccessException("Failed to get product by code", ex)
        End Try
    End Function

    ' Sales summary for EOD
    Public Shared Function GetSalesSummary(targetDate As DateTime) As SalesSummaryData
        Dim summary As New SalesSummaryData With {
            .[Date] = targetDate.Date,
            .TotalUSD = 0D,
            .TotalZWL = 0D,
            .NumItems = 0,
            .NumReceipts = 0
        }

        Try
            Dim totalsQuery As String = "SELECT SUM(IIf(Currency='USD', Total, 0)) AS TotalUSD, SUM(IIf(Currency<>'USD', Total, 0)) AS TotalZWL, SUM(Quantity) AS NumItems FROM Sales WHERE Date = @Date"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Date", targetDate.Date}
            }

            Using reader As OleDbDataReader = ExecuteQuery(totalsQuery, parameters)
                If reader.Read() Then
                    summary.TotalUSD = If(IsDBNull(reader("TotalUSD")), 0D, Convert.ToDecimal(reader("TotalUSD")))
                    summary.TotalZWL = If(IsDBNull(reader("TotalZWL")), 0D, Convert.ToDecimal(reader("TotalZWL")))
                    summary.NumItems = If(IsDBNull(reader("NumItems")), 0, Convert.ToInt32(reader("NumItems")))
                End If
            End Using

            Dim receiptsQuery As String = "SELECT Receipt FROM Sales WHERE Date = @Date GROUP BY Receipt"
            Using reader As OleDbDataReader = ExecuteQuery(receiptsQuery, parameters)
                Dim count As Integer = 0
                While reader.Read()
                    count += 1
                End While
                summary.NumReceipts = count
            End Using

            Return summary
        Catch ex As Exception
            Throw New DataAccessException("Failed to get sales summary", ex)
        End Try
    End Function

    ' Totals per waiter for EOD
    Public Shared Function GetWaiterTotals(targetDate As DateTime) As List(Of WaiterTotalData)
        Dim results As New List(Of WaiterTotalData)
        Try
            Dim query As String = "SELECT Waiter, SUM(IIf(Currency='USD', Total, 0)) AS TotalUSD, SUM(IIf(Currency<>'USD', Total, 0)) AS TotalZWL FROM Sales WHERE Date = @Date GROUP BY Waiter"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Date", targetDate.Date}
            }

            Using reader As OleDbDataReader = ExecuteQuery(query, parameters)
                While reader.Read()
                    results.Add(New WaiterTotalData With {
                        .Waiter = If(IsDBNull(reader("Waiter")), "", reader("Waiter").ToString()),
                        .TotalUSD = If(IsDBNull(reader("TotalUSD")), 0D, Convert.ToDecimal(reader("TotalUSD"))),
                        .TotalZWL = If(IsDBNull(reader("TotalZWL")), 0D, Convert.ToDecimal(reader("TotalZWL")))
                    })
                End While
            End Using

            Return results
        Catch ex As Exception
            Throw New DataAccessException("Failed to get waiter totals", ex)
        End Try
    End Function
End Class

' Data structure for sales summary
Public Class SalesSummaryData
    Public Property [Date] As DateTime
    Public Property TotalUSD As Decimal
    Public Property TotalZWL As Decimal
    Public Property NumItems As Integer
    Public Property NumReceipts As Integer
End Class

' Data structure for waiter totals
Public Class WaiterTotalData
    Public Property Waiter As String
    Public Property TotalUSD As Decimal
    Public Property TotalZWL As Decimal
End Class

''' <summary>
''' Custom exception for data access layer errors
''' </summary>
Public Class DataAccessException
    Inherits Exception
    
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
    
    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
End Class

''' <summary>
''' Data structure for daily totals
''' </summary>
Public Class DailyTotalsData
    Public Property [Date] As DateTime
    Public Property ZTotal As Decimal
    Public Property UTotal As Decimal
    Public Property ReceiptCount As Integer
End Class

''' <summary>
''' Data structure for sale records
''' </summary>
Public Class SaleData
    Public Property Code As String
    Public Property Quantity As Integer
    Public Property Receipt As String
    Public Property Price As Decimal
    Public Property Total As Decimal
    Public Property [Date] As DateTime
    Public Property Waiter As String
    Public Property Order As String
    Public Property Currency As String
    Public Property Description As String
End Class

''' <summary>
''' Data structure for product information
''' </summary>
Public Class ProductData
    Public Property Code As String
    Public Property Description As String
    Public Property Category As String
    Public Property ZWL As Decimal
    Public Property USD As Decimal
End Class
