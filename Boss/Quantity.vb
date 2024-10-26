Public Class Quantity

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        RichTextBox1.AppendText("0")
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        RichTextBox1.AppendText("1")
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        RichTextBox1.AppendText("2")
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        RichTextBox1.AppendText("3")
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        RichTextBox1.AppendText("4")
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        RichTextBox1.AppendText("5")
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        RichTextBox1.AppendText("6")
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        RichTextBox1.AppendText("7")
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        RichTextBox1.AppendText("8")
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        RichTextBox1.AppendText("9")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Entries.Show()
    End Sub

    Public Sub btnpm_Click(sender As Object, e As EventArgs) Handles btnpm.Click
        If RichTextBox1.Text = "" Or RichTextBox1.Text = "0" Then
            MsgBox("Please enter quantity", MsgBoxStyle.Exclamation, "No amount entered")
        Else
            Entries.quantitybx.Text = RichTextBox1.Text
            RichTextBox1.Clear()
            Me.Hide()
            Entries.Show()
        End If
    End Sub

    Private Sub btndot_Click(sender As Object, e As EventArgs) Handles btndot.Click
        RichTextBox1.Undo()
    End Sub
End Class