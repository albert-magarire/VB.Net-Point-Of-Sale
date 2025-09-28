Imports System.Data.OleDb

''' <summary>
''' Utility class to set up the Users table with default data
''' </summary>
Public Class DatabaseSetup
    
    ''' <summary>
    ''' Sets up the Users table with default users and password 1207
    ''' </summary>
    Public Shared Sub SetupUsersTable()
        Try
            Using connection As New OleDbConnection(My.Settings.BossConnectionString)
                connection.Open()
                
                ' Create Users table if it doesn't exist (Access doesn't support IF NOT EXISTS)
                Try
                    Dim createTableQuery As String = "CREATE TABLE Users (ID COUNTER PRIMARY KEY, AccType TEXT(50) NOT NULL, Passcode TEXT(255) NOT NULL)"
                    Using command As New OleDbCommand(createTableQuery, connection)
                        command.ExecuteNonQuery()
                    End Using
                Catch
                    ' ignore if exists
                End Try
                
                ' Clear existing users
                Dim clearQuery As String = "DELETE FROM Users"
                Using command As New OleDbCommand(clearQuery, connection)
                    command.ExecuteNonQuery()
                End Using
                
                ' Insert default users with hashed password if table is empty
                Dim count As Integer
                Using countCmd As New OleDbCommand("SELECT COUNT(*) FROM Users", connection)
                    count = Convert.ToInt32(countCmd.ExecuteScalar())
                End Using

                If count = 0 Then
                    Dim defaultHash As String = DataAccessLayer.HashPasswordWithSalt("1207")
                    Dim insertQuery As String = "INSERT INTO Users (AccType, Passcode) VALUES (?, ?)"
                    Using command As New OleDbCommand(insertQuery, connection)
                        command.Parameters.AddWithValue("@AccType", "Cashier")
                        command.Parameters.AddWithValue("@Passcode", defaultHash)
                        command.ExecuteNonQuery()
                        
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@AccType", "Manager")
                        command.Parameters.AddWithValue("@Passcode", defaultHash)
                        command.ExecuteNonQuery()
                        
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@AccType", "Supervisor")
                        command.Parameters.AddWithValue("@Passcode", defaultHash)
                        command.ExecuteNonQuery()
                    End Using
                End If
                
                MessageBox.Show("Users table setup completed successfully!", "Database Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error setting up Users table: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' Checks if the Users table exists and has data
    ''' </summary>
    Public Shared Function CheckUsersTable() As Boolean
        Try
            Using connection As New OleDbConnection(My.Settings.BossConnectionString)
                connection.Open()
                
                ' Check if table exists
                Try
                    Dim checkTableQuery As String = "SELECT COUNT(*) FROM Users"
                    Using command As New OleDbCommand(checkTableQuery, connection)
                        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                        Return count > 0
                    End Using
                Catch
                    Return False
                End Try
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
