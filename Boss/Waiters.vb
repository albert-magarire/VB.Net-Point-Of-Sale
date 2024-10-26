Public Class waiters

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Entries.cmbwaiter.Items.Add(txtWaiter.Text)
        MsgBox(txtWaiter.Text & "has successfully been added to the waiters list")
        txtWaiter.Clear()
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Entries.cmbwaiter.Items.Remove(txtWaiter.Text)
        MsgBox(txtWaiter.Text & "has successfully been removed from the waiters list")
        txtWaiter.Clear()
        Me.Hide()
        Supervisor.Show()
    End Sub
End Class