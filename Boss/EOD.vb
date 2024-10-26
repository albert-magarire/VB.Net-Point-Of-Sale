Public Class EOD

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(rtfReceipt.Text, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 10, 10)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.Print()
    End Sub

    Private Sub EOD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Login.txtPassword.Text = "hebi0800" Then
            rtfReceipt.Enabled = True
        Else
            rtfReceipt.Enabled = False
        End If
    End Sub
End Class