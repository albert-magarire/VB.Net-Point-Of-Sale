Imports System.Data.OleDb
Public Class Reports

    Private Sub btnEOD_Click(sender As Object, e As EventArgs) Handles btnEOD.Click
        CashUpDate.ShowDialog()
        CashUp.rtfCashUp.AppendText(vbCrLf & "End Of Day Cash Up Report" & vbCrLf & CashUpDate.DateTimePicker1.Value)
        Dim conn As New OleDbConnection
        conn.ConnectionString = My.Settings.BossConnectionString
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As New OleDbCommand("select * from DTotals where [TDate]='" & CashUpDate.DateTimePicker1.Value.ToShortDateString & "'", conn)
        Dim data As OleDbDataReader = cmd.ExecuteReader
        If data.HasRows Then
            Do While data.Read()
                If data("NoR").ToString = "" Then
                    MsgBox("No entries were made!")
                Else
                    CashUp.rtfCashUp.AppendText(vbCrLf & "Number of receipts generated: " & data("NoR").ToString)
                    CashUp.rtfCashUp.AppendText(vbCrLf & "Total  USD Received: " & vbTab & data("UTotal").ToString)
                    CashUp.rtfCashUp.AppendText(vbCrLf & "Total  ZWD Received: " & vbTab & data("ZTotal").ToString)
                End If
            Loop
        Else
            MsgBox("Error! Could not load report!")
        End If
        
        CashUp.rtfCashUp.AppendText(vbCrLf + vbCrLf + "---------------------------------------------------------------------------------------------------------------" + vbTab)
        CashUp.rtfCashUp.AppendText(vbCrLf + "End Of Report" + vbTab)
        Me.Hide()
        CashUp.Show()
    End Sub

    Private Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click
        EOD.rtfReceipt.AppendText(vbCrLf & "Sales By Invoice Report for:" & vbCrLf & Today)
        Me.Hide()
        EOD.Show()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Me.Hide()
        products.Show()
    End Sub
End Class