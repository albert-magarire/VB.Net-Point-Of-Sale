Public Class Supervisor

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        BOSS_CAFE.Menu.Show()
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        Me.Hide()
        Users.Show()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Me.Hide()
        Reports.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        waiters.Show()
    End Sub

End Class