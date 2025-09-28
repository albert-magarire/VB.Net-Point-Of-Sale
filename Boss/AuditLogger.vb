Imports System.Data.OleDb

Public Class AuditLogger
    Public Shared Sub Log(eventType As String, accountType As String, details As String)
        Try
            DataAccessLayer.EnsureSecurityTables()
            Using conn As OleDbConnection = DataAccessLayer.CreateConnection()
                conn.Open()
                Dim q As String = "INSERT INTO AuditLog (EventType, AccType, Details, CreatedAt) VALUES (@EventType, @AccType, @Details, @CreatedAt)"
                Using cmd As New OleDbCommand(q, conn)
                    cmd.Parameters.AddWithValue("@EventType", eventType)
                    cmd.Parameters.AddWithValue("@AccType", If(accountType, ""))
                    cmd.Parameters.AddWithValue("@Details", If(details, ""))
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Non-fatal: never break user flow on logging failure
        End Try
    End Sub
End Class

