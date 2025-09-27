Public Class CashUpDate

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Hide() 'Use the Hide() method to close the current form
        CashUp.Show()
    End Sub
End Class
