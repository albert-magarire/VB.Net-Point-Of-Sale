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
        rtfReceipt.Enabled = (Login.txtPassword.Text = "hebi0800")

        ' Auto-generate today's EOD report
        Try
            Dim reportText As String = BusinessLogicLayer.GenerateEODReport(DateTime.Today)
            rtfReceipt.Text = reportText
        Catch ex As Exception
            rtfReceipt.Text = "Failed to generate EOD report: " & ex.Message
        End Try
    End Sub
End Class