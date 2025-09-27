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
            
            Return command.ExecuteReader()
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
    ''' Validates user credentials securely
    ''' </summary>
    ''' <param name="accountType">User account type</param>
    ''' <param name="password">Plain text password</param>
    ''' <returns>True if credentials are valid</returns>
    Public Shared Function ValidateUser(accountType As String, password As String) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM Users WHERE AccType = @AccType AND Passcode = @Passcode"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@AccType", accountType},
                {"@Passcode", password} ' Using plain text password for now
            }
            
            Dim result As Object = ExecuteScalar(query, parameters)
            Return Convert.ToInt32(result) > 0
        Catch ex As Exception
            Throw New DataAccessException("Failed to validate user credentials", ex)
        End Try
    End Function

    ''' <summary>
    ''' Hashes a password using SHA256
    ''' </summary>
    ''' <param name="password">Plain text password</param>
    ''' <returns>Hashed password</returns>
    Public Shared Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim hashedBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return Convert.ToBase64String(hashedBytes)
        End Using
    End Function

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
                        .ZTotal = If(IsDBNull(reader("ZTotal")), 0, Convert.ToInt32(reader("ZTotal"))),
                        .UTotal = If(IsDBNull(reader("UTotal")), 0, Convert.ToInt32(reader("UTotal"))),
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
            
            ExecuteNonQuery(query, parameters)
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
