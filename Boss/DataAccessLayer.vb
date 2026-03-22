Imports System.Data.OleDb
Imports System.Configuration
Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' Centralized data access layer for the Boss Cafe POS system
''' All queries use ? positional parameters for OleDb compatibility
''' </summary>
Public Class DataAccessLayer
    Private Shared ReadOnly ConnectionString As String = My.Settings.BossConnectionString

    ''' <summary>
    ''' Returns the resolved database file path from the connection string
    ''' </summary>
    Public Shared Function GetDatabasePath() As String
        Try
            Dim builder As New OleDbConnectionStringBuilder(ConnectionString)
            Dim source As String = builder.DataSource
            ' Resolve |DataDirectory| to actual path
            If source.Contains("|DataDirectory|") Then
                Dim dataDir As String = AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString()
                If String.IsNullOrEmpty(dataDir) Then
                    dataDir = AppDomain.CurrentDomain.BaseDirectory
                End If
                source = source.Replace("|DataDirectory|", dataDir)
            End If
            Return System.IO.Path.GetFullPath(source)
        Catch ex As Exception
            Return "Could not resolve path: " & ex.Message
        End Try
    End Function

    Public Shared Function CreateConnection() As OleDbConnection
        Try
            Return New OleDbConnection(ConnectionString)
        Catch ex As Exception
            Throw New DataAccessException("Failed to create database connection", ex)
        End Try
    End Function

    ''' <summary>
    ''' Validates user credentials using plaintext comparison
    ''' </summary>
    Public Shared Function ValidateUser(accountType As String, password As String) As Boolean
        Try
            EnsureSecurityTables()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [Passcode] FROM Users WHERE [AccType] = ?", conn)
                    cmd.Parameters.AddWithValue("?", accountType)
                    Dim stored As Object = cmd.ExecuteScalar()
                    If stored Is Nothing OrElse stored Is DBNull.Value Then Return False
                    Dim storedValue As String = stored.ToString()
                    If storedValue.StartsWith("v1:") Then Return False
                    Return String.Equals(storedValue, password)
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to validate user credentials", ex)
        End Try
    End Function

    ''' <summary>
    ''' Ensure security-related tables exist (AuditLog, AuthState)
    ''' </summary>
    Public Shared Sub EnsureSecurityTables()
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New OleDbCommand("CREATE TABLE AuditLog (Id COUNTER PRIMARY KEY, EventType TEXT(50), AccType TEXT(50), Details TEXT(255), CreatedAt DATETIME)", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch : End Try
                Try
                    Using cmd As New OleDbCommand("CREATE TABLE AuthState (AccType TEXT(50), FailedAttempts INTEGER, LockoutUntil DATETIME)", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch : End Try
            End Using
        Catch : End Try
    End Sub

    Public Shared Function GetLockoutUntil(accountType As String) As Nullable(Of DateTime)
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT LockoutUntil FROM AuthState WHERE AccType = ?", conn)
                    cmd.Parameters.AddWithValue("?", accountType)
                    Dim obj = cmd.ExecuteScalar()
                    If obj Is Nothing OrElse obj Is DBNull.Value Then Return Nothing
                    Dim dt As DateTime
                    If DateTime.TryParse(obj.ToString(), dt) Then Return dt
                    Return Nothing
                End Using
            End Using
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
            Using sel As New OleDbCommand("SELECT FailedAttempts, LockoutUntil FROM AuthState WHERE AccType = ?", conn)
                sel.Parameters.AddWithValue("?", accountType)
                Using r = sel.ExecuteReader()
                    If r.Read() Then
                        exists = True
                        currentAttempts = If(IsDBNull(r(0)), CInt(0), Convert.ToInt32(r(0)))
                    End If
                End Using
            End Using

            currentAttempts += 1
            Dim newLockout As Nullable(Of DateTime) = Nothing
            If currentAttempts >= maxAttempts Then
                newLockout = DateTime.Now.AddMinutes(lockoutMinutes)
            End If

            If exists Then
                Using upd As New OleDbCommand("UPDATE AuthState SET FailedAttempts = ?, LockoutUntil = ? WHERE AccType = ?", conn)
                    upd.Parameters.AddWithValue("?", currentAttempts)
                    upd.Parameters.AddWithValue("?", If(newLockout.HasValue, CType(newLockout.Value, Object), CType(DBNull.Value, Object)))
                    upd.Parameters.AddWithValue("?", accountType)
                    upd.ExecuteNonQuery()
                End Using
            Else
                Using ins As New OleDbCommand("INSERT INTO AuthState (AccType, FailedAttempts, LockoutUntil) VALUES (?, ?, ?)", conn)
                    ins.Parameters.AddWithValue("?", accountType)
                    ins.Parameters.AddWithValue("?", currentAttempts)
                    ins.Parameters.AddWithValue("?", If(newLockout.HasValue, CType(newLockout.Value, Object), CType(DBNull.Value, Object)))
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
            Using sel As New OleDbCommand("SELECT AccType FROM AuthState WHERE AccType = ?", conn)
                sel.Parameters.AddWithValue("?", accountType)
                Using r = sel.ExecuteReader()
                    exists = r.Read()
                End Using
            End Using
            If exists Then
                Using upd As New OleDbCommand("UPDATE AuthState SET FailedAttempts = 0, LockoutUntil = NULL WHERE AccType = ?", conn)
                    upd.Parameters.AddWithValue("?", accountType)
                    upd.ExecuteNonQuery()
                End Using
            Else
                Using ins As New OleDbCommand("INSERT INTO AuthState (AccType, FailedAttempts, LockoutUntil) VALUES (?, 0, NULL)", conn)
                    ins.Parameters.AddWithValue("?", accountType)
                    ins.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    ' ===== DAILY TOTALS =====

    Public Shared Function GetDailyTotals(targetDate As DateTime) As DailyTotalsData
        Try
            EnsureDTotalsTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [TDate], [ZTotal], [UTotal], [NoR] FROM DTotals WHERE Format([TDate], 'yyyy-mm-dd') = ?", conn)
                    cmd.Parameters.AddWithValue("?", targetDate.Date.ToString("yyyy-MM-dd"))
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New DailyTotalsData With {
                                .[Date] = Convert.ToDateTime(reader("TDate")),
                                .ZTotal = If(IsDBNull(reader("ZTotal")), 0D, Convert.ToDecimal(reader("ZTotal"))),
                                .UTotal = If(IsDBNull(reader("UTotal")), 0D, Convert.ToDecimal(reader("UTotal"))),
                                .ReceiptCount = If(IsDBNull(reader("NoR")), CInt(0), Convert.ToInt32(reader("NoR")))
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
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to get daily totals", ex)
        End Try
    End Function

    Public Shared Sub UpdateDailyTotals(dailyTotals As DailyTotalsData)
        Try
            EnsureDTotalsTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                ' Try UPDATE first
                Using upd As New OleDbCommand("UPDATE DTotals SET [ZTotal] = ?, [UTotal] = ?, [NoR] = ? WHERE Format([TDate], 'yyyy-mm-dd') = ?", conn)
                    upd.Parameters.AddWithValue("?", dailyTotals.ZTotal)
                    upd.Parameters.AddWithValue("?", dailyTotals.UTotal)
                    upd.Parameters.AddWithValue("?", dailyTotals.ReceiptCount)
                    upd.Parameters.AddWithValue("?", dailyTotals.[Date].ToString("yyyy-MM-dd"))
                    Dim rowsAffected As Integer = upd.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        ' No existing row - INSERT
                        Using ins As New OleDbCommand("INSERT INTO DTotals ([TDate], [ZTotal], [UTotal], [NoR]) VALUES (?, ?, ?, ?)", conn)
                            ins.Parameters.AddWithValue("?", dailyTotals.[Date].Date)
                            ins.Parameters.AddWithValue("?", dailyTotals.ZTotal)
                            ins.Parameters.AddWithValue("?", dailyTotals.UTotal)
                            ins.Parameters.AddWithValue("?", dailyTotals.ReceiptCount)
                            ins.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to update daily totals", ex)
        End Try
    End Sub

    ' ===== TABLE SETUP =====

    Public Shared Function CheckColumnExists(tableName As String, columnName As String) As Boolean
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand($"SELECT [{columnName}] FROM [{tableName}] WHERE 1=0", conn)
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Shared Sub EnsureSalesTable()
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New OleDbCommand("CREATE TABLE Sales (ID COUNTER PRIMARY KEY, [Code] TEXT(255), [Description] TEXT(255), [Quantity] TEXT(255), [Receipt] TEXT(255), [Price] TEXT(255), [Total] TEXT(255), [Date] TEXT(255), [Waiter] TEXT(255), [Order] TEXT(255), [Currency] TEXT(255))", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                    ' Table exists - try to add Description if missing
                    Try
                        Using cmd As New OleDbCommand("SELECT [Description] FROM Sales WHERE 1=0", conn)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch
                        Try
                            Using cmd As New OleDbCommand("ALTER TABLE Sales ADD COLUMN [Description] TEXT(255)", conn)
                                cmd.ExecuteNonQuery()
                            End Using
                        Catch : End Try
                    End Try
                End Try
            End Using
        Catch : End Try
    End Sub

    Public Shared Sub EnsureDTotalsTable()
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New OleDbCommand("CREATE TABLE DTotals (ID COUNTER PRIMARY KEY, TDate DATETIME, ZTotal CURRENCY, UTotal CURRENCY, NoR INTEGER)", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch : End Try
            End Using
        Catch : End Try
    End Sub

    Public Shared Sub EnsureProductsTable()
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New OleDbCommand("CREATE TABLE Products ([Code] TEXT(255) PRIMARY KEY, [Description] TEXT(255), [Category] TEXT(255), [ZWL] CURRENCY, [USD] CURRENCY)", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch : End Try
            End Using
        Catch : End Try
    End Sub

    ' ===== SALES =====

    Public Shared Sub InsertSale(sale As SaleData)
        Try
            EnsureSalesTable()
            Dim hasDescription As Boolean = CheckColumnExists("Sales", "Description")

            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Dim query As String
                If hasDescription Then
                    query = "INSERT INTO Sales ([Code], [Description], [Quantity], [Receipt], [Price], [Total], [Date], [Waiter], [Order], [Currency]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                Else
                    query = "INSERT INTO Sales ([Code], [Quantity], [Receipt], [Price], [Total], [Date], [Waiter], [Order], [Currency]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
                End If

                Using cmd As New OleDbCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(sale.Code), CType(DBNull.Value, Object), CType(sale.Code, Object)))
                    If hasDescription Then
                        cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(sale.Description), CType(DBNull.Value, Object), CType(sale.Description, Object)))
                    End If
                    cmd.Parameters.AddWithValue("?", sale.Quantity.ToString())
                    cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(sale.Receipt), CType(DBNull.Value, Object), CType(sale.Receipt, Object)))
                    cmd.Parameters.AddWithValue("?", sale.Price.ToString())
                    cmd.Parameters.AddWithValue("?", sale.Total.ToString())
                    cmd.Parameters.AddWithValue("?", sale.[Date].ToShortDateString())
                    cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(sale.Waiter), CType(DBNull.Value, Object), CType(sale.Waiter, Object)))
                    cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(sale.Order), CType(DBNull.Value, Object), CType(sale.Order, Object)))
                    cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(sale.Currency), CType(DBNull.Value, Object), CType(sale.Currency, Object)))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to insert sale: " & ex.Message, ex)
        End Try
    End Sub

    Public Shared Function GetProductsByCategory(category As String) As List(Of ProductData)
        Dim products As New List(Of ProductData)
        Try
            EnsureProductsTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [Code], [Description], [Category], [ZWL], [USD] FROM Products WHERE [Category] = ?", conn)
                    cmd.Parameters.AddWithValue("?", category)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            products.Add(New ProductData With {
                                .Code = reader("Code").ToString(),
                                .Description = If(IsDBNull(reader("Description")), "", reader("Description").ToString()),
                                .Category = If(IsDBNull(reader("Category")), "", reader("Category").ToString()),
                                .ZWL = If(IsDBNull(reader("ZWL")), 0D, Convert.ToDecimal(reader("ZWL"))),
                                .USD = If(IsDBNull(reader("USD")), 0D, Convert.ToDecimal(reader("USD")))
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to get products by category", ex)
        End Try
        Return products
    End Function

    Public Shared Function GetProductByCode(code As String) As ProductData
        Try
            EnsureProductsTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [Code], [Description], [Category], [ZWL], [USD] FROM Products WHERE [Code] = ?", conn)
                    cmd.Parameters.AddWithValue("?", code)
                    Using reader = cmd.ExecuteReader()
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
                End Using
            End Using
            Return Nothing
        Catch ex As Exception
            Throw New DataAccessException("Failed to get product by code", ex)
        End Try
    End Function

    ' ===== SALES SUMMARY / EOD =====

    Public Shared Function GetSalesSummary(targetDate As DateTime) As SalesSummaryData
        Dim summary As New SalesSummaryData With {
            .[Date] = targetDate.Date,
            .TotalUSD = 0D, .TotalZWL = 0D, .NumItems = 0, .NumReceipts = 0
        }
        Try
            Dim dateStr As String = targetDate.Date.ToShortDateString()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT SUM(IIf([Currency]='USD', CDbl([Total]), 0)) AS TotalUSD, SUM(IIf([Currency]<>'USD', CDbl([Total]), 0)) AS TotalZWL, SUM(CInt([Quantity])) AS NumItems FROM Sales WHERE [Date] = ?", conn)
                    cmd.Parameters.AddWithValue("?", dateStr)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            summary.TotalUSD = If(IsDBNull(reader("TotalUSD")), 0D, Convert.ToDecimal(reader("TotalUSD")))
                            summary.TotalZWL = If(IsDBNull(reader("TotalZWL")), 0D, Convert.ToDecimal(reader("TotalZWL")))
                            summary.NumItems = If(IsDBNull(reader("NumItems")), CInt(0), Convert.ToInt32(reader("NumItems")))
                        End If
                    End Using
                End Using
                Using cmd As New OleDbCommand("SELECT [Receipt] FROM Sales WHERE [Date] = ? GROUP BY [Receipt]", conn)
                    cmd.Parameters.AddWithValue("?", dateStr)
                    Using reader = cmd.ExecuteReader()
                        Dim count As Integer = 0
                        While reader.Read()
                            count += 1
                        End While
                        summary.NumReceipts = count
                    End Using
                End Using
            End Using
            Return summary
        Catch ex As Exception
            Throw New DataAccessException("Failed to get sales summary", ex)
        End Try
    End Function

    Public Shared Function GetWaiterTotals(targetDate As DateTime) As List(Of WaiterTotalData)
        Dim results As New List(Of WaiterTotalData)
        Try
            Dim dateStr As String = targetDate.Date.ToShortDateString()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [Waiter], SUM(IIf([Currency]='USD', CDbl([Total]), 0)) AS TotalUSD, SUM(IIf([Currency]<>'USD', CDbl([Total]), 0)) AS TotalZWL FROM Sales WHERE [Date] = ? GROUP BY [Waiter]", conn)
                    cmd.Parameters.AddWithValue("?", dateStr)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            results.Add(New WaiterTotalData With {
                                .Waiter = If(IsDBNull(reader("Waiter")), "", reader("Waiter").ToString()),
                                .TotalUSD = If(IsDBNull(reader("TotalUSD")), 0D, Convert.ToDecimal(reader("TotalUSD"))),
                                .TotalZWL = If(IsDBNull(reader("TotalZWL")), 0D, Convert.ToDecimal(reader("TotalZWL")))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return results
        Catch ex As Exception
            Throw New DataAccessException("Failed to get waiter totals", ex)
        End Try
    End Function

    Public Shared Function GetProductSalesTotals(targetDate As DateTime) As List(Of ProductSalesTotalData)
        Dim results As New List(Of ProductSalesTotalData)
        Try
            EnsureSalesTable()
            Dim dateStr As String = targetDate.Date.ToShortDateString()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [Code], SUM(CInt([Quantity])) AS TotalQty, SUM(CDbl([Total])) AS TotalValue, [Currency] FROM Sales WHERE [Date] = ? GROUP BY [Code], [Currency] ORDER BY [Code]", conn)
                    cmd.Parameters.AddWithValue("?", dateStr)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            results.Add(New ProductSalesTotalData With {
                                .Description = If(IsDBNull(reader("Code")), "", reader("Code").ToString()),
                                .TotalQuantity = If(IsDBNull(reader("TotalQty")), 0, Convert.ToInt32(reader("TotalQty"))),
                                .TotalValue = If(IsDBNull(reader("TotalValue")), 0D, Convert.ToDecimal(reader("TotalValue"))),
                                .Currency = If(IsDBNull(reader("Currency")), "", reader("Currency").ToString())
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to get product sales totals", ex)
        End Try
        Return results
    End Function

    ' ===== WAITERS =====

    Public Shared Sub EnsureWaitersTable()
        Try
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Try
                    Using cmd As New OleDbCommand("CREATE TABLE all_waiters (ID COUNTER PRIMARY KEY, WaiterName TEXT(255))", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch : End Try
            End Using
        Catch : End Try
    End Sub

    Public Shared Function GetAllWaiters() As List(Of String)
        Dim waiters As New List(Of String)
        Try
            EnsureWaitersTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT WaiterName FROM all_waiters ORDER BY WaiterName", conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim name As String = If(IsDBNull(reader("WaiterName")), "", reader("WaiterName").ToString())
                            If Not String.IsNullOrWhiteSpace(name) Then
                                waiters.Add(name)
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to get waiters", ex)
        End Try
        Return waiters
    End Function

    Public Shared Sub AddWaiter(waiterName As String)
        Try
            EnsureWaitersTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("INSERT INTO all_waiters (WaiterName) VALUES (?)", conn)
                    cmd.Parameters.AddWithValue("?", waiterName.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to add waiter: " & ex.Message, ex)
        End Try
    End Sub

    Public Shared Sub RemoveWaiter(waiterName As String)
        Try
            EnsureWaitersTable()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("DELETE FROM all_waiters WHERE WaiterName = ?", conn)
                    cmd.Parameters.AddWithValue("?", waiterName.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New DataAccessException("Failed to remove waiter: " & ex.Message, ex)
        End Try
    End Sub

    Public Shared Function HasOpenDocketsWithPrefix(prefix As String, currentWaiterName As String) As Boolean
        Try
            EnsureSalesTable()
            Dim dateStr As String = DateTime.Today.ToShortDateString()
            Using conn As New OleDbConnection(ConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT COUNT(*) FROM Sales WHERE [Date] = ? AND [Receipt] LIKE ? AND [Waiter] <> ?", conn)
                    cmd.Parameters.AddWithValue("?", dateStr)
                    cmd.Parameters.AddWithValue("?", prefix & "-%")
                    cmd.Parameters.AddWithValue("?", currentWaiterName)
                    Dim count As Object = cmd.ExecuteScalar()
                    Return count IsNot Nothing AndAlso Not IsDBNull(count) AndAlso Convert.ToInt32(count) > 0
                End Using
            End Using
        Catch
            Return False
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

Public Class DataAccessException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
End Class

Public Class DailyTotalsData
    Public Property [Date] As DateTime
    Public Property ZTotal As Decimal
    Public Property UTotal As Decimal
    Public Property ReceiptCount As Integer
End Class

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

Public Class ProductData
    Public Property Code As String
    Public Property Description As String
    Public Property Category As String
    Public Property ZWL As Decimal
    Public Property USD As Decimal
End Class

Public Class ProductSalesTotalData
    Public Property Description As String
    Public Property TotalQuantity As Integer
    Public Property TotalValue As Decimal
    Public Property Currency As String
End Class
