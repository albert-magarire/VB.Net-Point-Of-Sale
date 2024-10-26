Public Class LoggedIn

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Me.Hide()
        Entries.Show()
    End Sub

    Private Sub btnSupervisor_Click(sender As Object, e As EventArgs) Handles btnSupervisor.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class