Imports System.Data.OleDb
Public Class Login

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim conn As New OleDbConnection
        conn.ConnectionString = My.Settings.BossConnectionString
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As New OleDbCommand("select * from Users where [AccType]='" & cmbUser.Text & "' and [PassCode]='" & txtPassword.Text & "'", conn)
        Dim loginrd As OleDbDataReader = cmd.ExecuteReader
        If (loginrd.read() = True) Then
            If cmbUser.Text = "Cashier" Then
                MsgBox("Welcome, Cashier!", MsgBoxStyle.Information, "Successful Login!")
                Me.Hide()
                LoggedIn.Show()
            ElseIf cmbUser.Text = "Manager" Then
                MsgBox("Welcome, Manager!", MsgBoxStyle.Information, "Successful Login!")
                Me.Hide()
                LoggedIn.Show()
            ElseIf cmbUser.Text = "Supervisor" Then
                MsgBox("Welcome, Boss!", MsgBoxStyle.Information, "Successful VIP Login!")
                Me.Hide()
                Supervisor.Show()
            End If
            conn.Close()
        Else
            MsgBox("Invalid Login Details!", MsgBoxStyle.Critical, "Invalid User Login Credentials!")
            conn.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

End Class
