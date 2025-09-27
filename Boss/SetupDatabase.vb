Imports System.Data.OleDb
Imports System.Windows.Forms

''' <summary>
''' Standalone database setup utility
''' </summary>
Public Class SetupDatabase
    
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        
        Try
            Console.WriteLine("Setting up Boss Cafe database...")
            SetupUsersTable()
            Console.WriteLine("Database setup completed successfully!")
            Console.WriteLine("You can now run the main application and login with password '1207'")
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        End Try
        
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
    
    ''' <summary>
    ''' Sets up the Users table with default users and password 1207
    ''' </summary>
    Public Shared Sub SetupUsersTable()
        Try
            Using connection As New OleDbConnection(My.Settings.BossConnectionString)
                connection.Open()
                Console.WriteLine("Connected to database successfully")
                
                ' Create Users table if it doesn't exist
                Dim createTableQuery As String = "
                    CREATE TABLE IF NOT EXISTS Users (
                        ID AUTOINCREMENT PRIMARY KEY,
                        AccType TEXT(50) NOT NULL,
                        Passcode TEXT(255) NOT NULL
                    )"
                
                Using command As New OleDbCommand(createTableQuery, connection)
                    command.ExecuteNonQuery()
                End Using
                Console.WriteLine("Users table created/verified")
                
                ' Clear existing users
                Dim clearQuery As String = "DELETE FROM Users"
                Using command As New OleDbCommand(clearQuery, connection)
                    command.ExecuteNonQuery()
                End Using
                Console.WriteLine("Cleared existing users")
                
                ' Insert default users with password 1207 (plain text for now)
                Dim insertQuery As String = "INSERT INTO Users (AccType, Passcode) VALUES (?, ?)"
                Using command As New OleDbCommand(insertQuery, connection)
                    command.Parameters.AddWithValue("@AccType", "Cashier")
                    command.Parameters.AddWithValue("@Passcode", "1207")
                    command.ExecuteNonQuery()
                    Console.WriteLine("Added Cashier user")
                    
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@AccType", "Manager")
                    command.Parameters.AddWithValue("@Passcode", "1207")
                    command.ExecuteNonQuery()
                    Console.WriteLine("Added Manager user")
                    
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@AccType", "Supervisor")
                    command.Parameters.AddWithValue("@Passcode", "1207")
                    command.ExecuteNonQuery()
                    Console.WriteLine("Added Supervisor user")
                End Using
                
                ' Verify the setup
                Dim verifyQuery As String = "SELECT COUNT(*) FROM Users"
                Using command As New OleDbCommand(verifyQuery, connection)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Console.WriteLine($"Total users in database: {count}")
                End Using
                
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error setting up Users table: {ex.Message}")
            Throw
        End Try
    End Sub
End Class
