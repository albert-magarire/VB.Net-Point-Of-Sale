Imports System.Data.OleDb

Public Class products

    Private Sub products_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductSalesTotals()
    End Sub

    Private Sub LoadProductSalesTotals()
        Try
            ListBox1.Items.Clear()
            ListBox1.Items.Add("===== SALES BY PRODUCT - " & Today.ToShortDateString() & " =====")
            ListBox1.Items.Add("")

            Dim totals As List(Of ProductSalesTotalData) = DataAccessLayer.GetProductSalesTotals(DateTime.Today)

            If totals.Count = 0 Then
                ListBox1.Items.Add("No sales recorded for today.")
                Return
            End If

            Dim grandTotalUSD As Decimal = 0
            Dim grandTotalZWL As Decimal = 0

            ListBox1.Items.Add(String.Format("{0,-30} {1,8} {2,12} {3,6}", "Product", "Qty", "Total", "Curr"))
            ListBox1.Items.Add(New String("-"c, 60))

            For Each item In totals
                ListBox1.Items.Add(String.Format("{0,-30} {1,8} {2,12:F2} {3,6}",
                    If(item.Description.Length > 28, item.Description.Substring(0, 28) & "..", item.Description),
                    item.TotalQuantity,
                    item.TotalValue,
                    item.Currency))

                If item.Currency = "USD" Then
                    grandTotalUSD += item.TotalValue
                Else
                    grandTotalZWL += item.TotalValue
                End If
            Next

            ListBox1.Items.Add(New String("-"c, 60))
            ListBox1.Items.Add("")
            If grandTotalUSD > 0 Then
                ListBox1.Items.Add(String.Format("Grand Total (USD): {0:F2}", grandTotalUSD))
            End If
            If grandTotalZWL > 0 Then
                ListBox1.Items.Add(String.Format("Grand Total (ZWL): {0:F2}", grandTotalZWL))
            End If

        Catch ex As DataAccessException
            MessageBox.Show("Error loading product sales: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        Reports.Show()
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class
