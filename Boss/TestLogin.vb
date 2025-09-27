Imports System.Data.OleDb

''' <summary>
''' Simple test class to verify login functionality
''' </summary>
Public Class TestLogin
    
    Public Shared Sub TestDatabaseConnection()
        Try
            Using connection As New OleDbConnection(My.Settings.BossConnectionString)
                connection.Open()
                Console.WriteLine("Database connection successful!")
                
                ' Check if Users table exists
                Dim checkTableQuery As String = "SELECT COUNT(*) FROM Users"
                Using command As New OleDbCommand(checkTableQuery, connection)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Console.WriteLine($"Users table has {count} records")
                End Using
                
                ' List all users
                Dim listUsersQuery As String = "SELECT AccType, Passcode FROM Users"
                Using command As New OleDbCommand(listUsersQuery, connection)
                    Using reader As OleDbDataReader = command.ExecuteReader()
                        Console.WriteLine("Users in database:")
                        While reader.Read()
                            Console.WriteLine($"  {reader("AccType")} - {reader("Passcode")}")
                        End While
                    End Using
                End Using
                
            End Using
        Catch ex As Exception
            Console.WriteLine($"Database error: {ex.Message}")
        End Try
    End Sub
    
    Public Shared Sub TestLoginValidation()
        Try
            ' Test each account type with password 1207
            Dim accountTypes() As String = {"Cashier", "Manager", "Supervisor"}
            
            For Each accountType As String In accountTypes
                Dim isValid As Boolean = DataAccessLayer.ValidateUser(accountType, "1207")
                Console.WriteLine($"Login test for {accountType}: {(If(isValid, "SUCCESS", "FAILED"))}")
            Next
            
        Catch ex As Exception
            Console.WriteLine($"Login validation error: {ex.Message}")
        End Try
    End Sub
End Class
