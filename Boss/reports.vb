Imports System.Data.OleDb
Public Class Reports

    Private Sub btnEOD_Click(sender As Object, e As EventArgs) Handles btnEOD.Click
        Try
            CashUpDate.ShowDialog()
            Dim selectedDate As DateTime = CashUpDate.DateTimePicker1.Value.Date

            CashUp.rtfCashUp.Clear()
            CashUp.rtfCashUp.AppendText("End Of Day Cash Up Report" & vbCrLf & selectedDate.ToLongDateString())

            ' Use parameterized query with Format() for date comparison
            Using conn As New OleDbConnection(My.Settings.BossConnectionString)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [NoR], [UTotal], [ZTotal] FROM DTotals WHERE Format([TDate], 'yyyy-mm-dd') = ?", conn)
                    cmd.Parameters.AddWithValue("?", selectedDate.ToString("yyyy-MM-dd"))
                    Using data = cmd.ExecuteReader()
                        If data.HasRows Then
                            Do While data.Read()
                                If IsDBNull(data("NoR")) OrElse data("NoR").ToString() = "" Then
                                    CashUp.rtfCashUp.AppendText(vbCrLf & vbCrLf & "No entries were made for this date.")
                                Else
                                    CashUp.rtfCashUp.AppendText(vbCrLf & vbCrLf & "Number of dockets generated: " & data("NoR").ToString())
                                    CashUp.rtfCashUp.AppendText(vbCrLf & "Total USD Received: " & vbTab & data("UTotal").ToString())
                                    CashUp.rtfCashUp.AppendText(vbCrLf & "Total ZWD Received: " & vbTab & data("ZTotal").ToString())
                                End If
                            Loop
                        Else
                            CashUp.rtfCashUp.AppendText(vbCrLf & vbCrLf & "No report data found for this date.")
                        End If
                    End Using
                End Using
            End Using

            CashUp.rtfCashUp.AppendText(vbCrLf & vbCrLf & "---------------------------------------------------------------------------------------------------------------")
            CashUp.rtfCashUp.AppendText(vbCrLf & "End Of Report")
            Me.Hide()
            CashUp.Show()
        Catch ex As Exception
            MessageBox.Show("Error generating report: " & ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click
        EOD.rtfReceipt.AppendText(vbCrLf & "Sales By Docket Report for:" & vbCrLf & Today)
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
