Imports System.Data.OleDb
Public Class Entries
    Dim cusd As Boolean = True
    Dim DTotal As Integer = 0
    Dim rtotal As Integer = 0
    Dim total, zwdtotal As Integer
    Dim cype, sype, bype As String
    Dim pcount As Integer = 0
    Private Sub ProductsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(rtfReceipt.Text, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 7, 7)
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        e.Graphics.DrawString(rtfReceiptC.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 7, 7)
    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        e.Graphics.DrawString(rtfReceiptB.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 7, 7)
    End Sub

    Private Sub Entries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Start()
        Dim conn As New OleDbConnection
        conn.ConnectionString = My.Settings.BossConnectionString
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As New OleDbCommand("select * from DTotals where [TDate]='" & Today & "'", conn)
        Dim data As OleDbDataReader = cmd.ExecuteReader
        If data.HasRows Then
            Do While data.Read()
                If data("NoR").ToString = "" Then
                    Label2.Text = "01"
                Else
                    Label2.Text = "0" & data("NoR").ToString + 1
                    txtDtotal.Text = data("UTotal").ToString
                    txtDZTotal.Text = data("ZTotal").ToString
                End If
            Loop
        Else
            Try
                Dim sqlconn As New OleDb.OleDbConnection
                Dim connstring, command As String
                connstring = My.Settings.BossConnectionString
                sqlconn.ConnectionString = connstring
                sqlconn.Open()
                command = "INSERT INTO DTotals([TDate],[UTotal],[ZTotal],[NoR])VALUES('" & Today & "','0','0','0')"
                Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
                sql.ExecuteNonQuery()
                MsgBox("Database set for the day! You can start entering today's sales!", MsgBoxStyle.Information, "Database Ready!")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Failed to Connect to Database! Please reboot computer!")
            End Try
        End If
        'TODO: This line of code loads data into the 'BossDataSet.DTotals' table. You can move, or remove it, as needed.
        Me.DTotalsTableAdapter.Fill(Me.BossDataSet.DTotals)
        'TODO: This line of code loads data into the 'BossDataSet.Sales' table. You can move, or remove it, as needed.
        Me.SalesTableAdapter.Fill(Me.BossDataSet.Sales)
        'TODO: This line of code loads data into the 'BossDataSet.Totals' table. You can move, or remove it, as needed.
        Me.TotalsTableAdapter.Fill(Me.BossDataSet.Totals)
        'TODO: This line of code loads data into the 'BossDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)
        rtfReceipt.AppendText(vbCrLf + "Date:       " & DateTimePicker1.Value.ToLongDateString)
        rtfReceipt.AppendText(vbCrLf + "Number     :                       " & "00" + Label2.Text)
        Timer1.Start()
        Timer2.Start()

    End Sub

    Private Sub cmbwaiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbwaiter.SelectedIndexChanged
        rtfReceipt.AppendText(vbCrLf + "Waiter:" + vbTab + cmbwaiter.Text + vbTab)
        rtfReceiptB.AppendText(vbCrLf + "Waiter:" + vbTab + cmbwaiter.Text & " Inv No: " & Label2.Text)
        WaiterTextBox.Text = cmbwaiter.Text
        rtfReceiptB.AppendText(vbCrLf + "Time:" & DateTimePicker1.Value.ToLocalTime)
        rtfReceiptC.AppendText(vbCrLf + "Waiter:" + vbTab + cmbwaiter.Text & " Inv No: " & Label2.Text)
        rtfReceiptC.AppendText(vbCrLf + "Time:" & DateTimePicker1.Value.ToLocalTime)

    End Sub

    Private Sub cmborder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmborder.SelectedIndexChanged
        rtfReceipt.AppendText(vbCrLf + "Order:" + vbTab + cmborder.Text + vbTab)
        OrderTextBox.Text = cmborder.Text
        rtfReceiptB.AppendText(vbCrLf + "Order:" + vbTab + cmborder.Text + vbCrLf)
        rtfReceiptC.AppendText(vbCrLf + "Order:" + vbTab + cmborder.Text + vbCrLf)
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        ProductsBindingSource.Filter = "(Category = '" & cmbCategory.Text & "')"
        If ProductsBindingSource.Count <> 0 Then
            With ProductsDataGridView
                .DataSource = ProductsBindingSource
            End With
        Else
            MsgBox("The selected category does not yet have products loaded into the database")
            ProductsBindingSource.Filter = Nothing
            btnClose.Visible = True
        End If
    End Sub

    Private Sub ProductsDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsDataGridView.CellDoubleClick
        If cmbwaiter.Text = "" Then
            MsgBox("Please enter the name of the waiter serving!")
        ElseIf cmborder.Text = "" Then
            MsgBox("You did not specify what type of order this is!")
        Else
            ReceiptTextBox.Text = Label2.Text
            Dim quantity As Integer
            BOSS_CAFE.Quantity.ShowDialog()
            quantity = Val(quantitybx.Text)
            'quantity = InputBox("Enter quantity", "Quantity Ordered", "1")
            QuantityTextBox.Text = quantity
            total = quantity * Int(ProductsDataGridView.CurrentRow.Cells(4).Value)
            zwdtotal = quantity * Int(ProductsDataGridView.CurrentRow.Cells(3).Value)
            pcount = pcount + quantity
            If ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Steak" Then
                sype = InputBox("Enter:" & vbCrLf & "W for well done" & vbCrLf & "M for Medium" & vbCrLf & "R for Rare" & vbCrLf & "MW for Medium to Well", "Steak Category")
            ElseIf ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Chicken" Then
                cype = InputBox("Enter:" & vbCrLf & "L for Lemon & Herb" & vbCrLf & "M for Mild" & vbCrLf & "H for Hot", "Chicken Category")
            ElseIf ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Breakfasts" Then
                bype = InputBox("Enter:" & vbCrLf & "S for Scrambled" & vbCrLf & "M for Medium" & vbCrLf & "W for Well", "Breakfast Category")
            End If

            If cusd = True Then
                rtfReceipt.AppendText(vbCrLf + ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & vbLf + ProductsDataGridView.CurrentRow.Cells(0).Value.ToString + vbTab & quantity & ".00" & vbTab + ProductsDataGridView.CurrentRow.Cells(4).Value.ToString & ".00" + vbTab & total & ".00")
                EOD.rtfReceipt.AppendText(vbCrLf + ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & vbLf + ProductsDataGridView.CurrentRow.Cells(0).Value.ToString + vbTab & quantity & vbTab + ProductsDataGridView.CurrentRow.Cells(4).Value.ToString + vbTab & total)
                If ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Chicken" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Steak" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Breakfasts" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Sandwiches" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Extras" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Salads" Then
                    rtfReceiptC.AppendText(vbCrLf & quantity & "  " & ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & " " & cype & bype & sype)
                Else
                    rtfReceiptB.AppendText(vbCrLf & quantity & "  " & ProductsDataGridView.CurrentRow.Cells(1).Value.ToString)
                End If
                rtotal = rtotal + total
                PriceTextBox.Text = ProductsDataGridView.CurrentRow.Cells(4).Value
                TotalTextBox.Text = lblTotal.Text
                CurrencyTextBox.Text = "USD"
            Else
                rtfReceipt.AppendText(vbCrLf + ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & vbLf + ProductsDataGridView.CurrentRow.Cells(0).Value.ToString + vbTab & quantity & ".00" & vbTab + ProductsDataGridView.CurrentRow.Cells(3).Value.ToString & ".00" + vbTab & zwdtotal)
                EOD.rtfReceipt.AppendText(vbCrLf + ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & vbLf + ProductsDataGridView.CurrentRow.Cells(0).Value.ToString + vbTab & quantity & vbTab + ProductsDataGridView.CurrentRow.Cells(3).Value.ToString + vbTab & zwdtotal)
                If ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Chicken" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Steak" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Breakfasts" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Sandwiches" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Extras" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Salads" Or ProductsDataGridView.CurrentRow.Cells(2).Value.ToString = "Fish" Then
                    rtfReceiptC.AppendText(vbCrLf & quantity & "  " & ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & "-" & cype & bype & sype)
                Else
                    rtfReceiptB.AppendText(vbCrLf & quantity & "  " & ProductsDataGridView.CurrentRow.Cells(1).Value.ToString)
                End If
                rtotal = rtotal + zwdtotal
                PriceTextBox.Text = ProductsDataGridView.CurrentRow.Cells(3).Value
                TotalTextBox.Text = lblZTotal.Text
                CurrencyTextBox.Text = "ZWD"
            End If
            CodeTextBox.Text = ProductsDataGridView.CurrentRow.Cells(0).Value.ToString
            DateTextBox.Text = DateTimePicker1.Value
            ProductsDataGridView.SendToBack()
            ProductsDataGridView.Visible = False
            btnClose.SendToBack()
            btnClose.Visible = False
            cype = ""
            bype = ""
            sype = ""

            Try
                Dim sqlconn As New OleDb.OleDbConnection
                Dim connstring, command As String
                connstring = My.Settings.BossConnectionString
                sqlconn.ConnectionString = connstring
                sqlconn.Open()
                command = "INSERT INTO Sales([Code],[Quantity],[Receipt],[Price],[Total],[Date],[Waiter],[Order],[Currency],[Description])VALUES('" & CodeTextBox.Text & "','" & QuantityTextBox.Text & "','" & Label2.Text & "','" & PriceTextBox.Text & "','" & TotalTextBox.Text & "','" & DateTextBox.Text & "','" & cmbwaiter.Text & "','" & cmborder.Text & "','" & CurrencyTextBox.Text & "', '" & ProductsDataGridView.CurrentRow.Cells(1).Value.ToString & "')"
                Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
                sql.Parameters.Add(New OleDbParameter("Code", CType(CodeTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Quantity", CType(QuantityTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Receipt", CType(ReceiptTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Price", CType(PriceTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Total", CType(TotalTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Date", CType(DateTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Waiter", CType(WaiterTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Order", CType(OrderTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Currency", CType(CurrencyTextBox.Text, String)))
                sql.Parameters.Add(New OleDbParameter("Description", CType(ProductsDataGridView.CurrentRow.Cells(1).Value, String)))
                sql.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Sales Record Saving Failed!")

            End Try
        End If
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub payment_Click(sender As Object, e As EventArgs) Handles payment.Click
        rtfReceipt.AppendText(vbCrLf + vbCrLf + "---------------------------------------------------------------------------------------------------------------" + vbTab)
        rtfReceipt.AppendText(vbCrLf + "Number of items bought:         " & pcount)
        If cusd = True Then
            rtfReceipt.AppendText(vbCrLf + "USD Total:                                " & lblTotal.Text.ToString)
            txtDtotal.Text = Val(txtDtotal.Text) + rtotal
        Else
            rtfReceipt.AppendText(vbCrLf + "ZWD Total:                                " & lblZTotal.Text.ToString)
            txtDZTotal.Text = Val(txtDZTotal.Text) + rtotal
        End If
        rtfReceipt.AppendText(vbCrLf + vbCrLf + "...                ...                          " & cmbwaiter.Text)
        rtfReceiptC.AppendText(vbCrLf + vbCrLf + "-" + vbTab)
        rtfReceiptB.AppendText(vbCrLf + vbCrLf + "-" + vbTab)

        EOD.rtfReceipt.AppendText(vbCrLf + vbCrLf + "Number of items bought:         " & pcount)
        If cusd = True Then
            EOD.rtfReceipt.AppendText(vbCrLf + "Total:                                " & lblTotal.Text.ToString)
        Else
            EOD.rtfReceipt.AppendText(vbCrLf + "Total:                                " & lblZTotal.Text.ToString)
        End If
        EOD.rtfReceipt.AppendText(vbCrLf + "---------------------------------------------------------------------------------------------------------------" + vbTab)

        PrintDocument3.Print()
        PrintDocument2.Print()
        PrintDocument1.Print()
        PrintDocument1.Print()

        Me.Validate()
        Me.TotalsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "INSERT INTO Totals([Receipt],[Total])VALUES('" & Label2.Text & "','" & lblTotal.Text & "')"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.Parameters.Add(New OleDbParameter("Receipt", CType(Label2.Text, String)))
            sql.Parameters.Add(New OleDbParameter("Total", CType(lblTotal.Text, String)))
            sql.ExecuteNonQuery()
            MsgBox("Sales Invoice number " & Label2.Text & " successfully saved!")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Receipt Total Not Saved!")

        End Try
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "INSERT INTO Waiters([Receipt],[Waiter])VALUES('" & Label2.Text & "','" & cmbwaiter.Text & "')"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.Parameters.Add(New OleDbParameter("Receipt", CType(Label2.Text, String)))
            sql.Parameters.Add(New OleDbParameter("Waiter", CType(WaiterTextBox.Text, String)))
            sql.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Waiter Not Saved!")
        End Try
        Me.Validate()
        Me.DTotalsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "UPDATE DTotals SET ZTotal = '" & txtDZTotal.Text & "', UTotal = '" & txtDtotal.Text & "', NoR = '" & Label2.Text & "', TDate = '" & Today & "' WHERE TDate = '" & Today & "'"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.Parameters.Add(New OleDbParameter("TDate", Today))
            sql.Parameters.Add(New OleDbParameter("ZTotal", CType(txtDZTotal.Text, String)))
            sql.Parameters.Add(New OleDbParameter("NoR", CType(Label2.Text, String)))
            sql.Parameters.Add(New OleDbParameter("UTotal", CType(txtDtotal.Text, String)))
            sql.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to update daily total!")

        End Try

        Label2.Text = "0" & Val(Label2.Text) + 1
        lblTotal.Text = "00.00"
        lblZTotal.Text = "00.00"

        rtfReceipt.Text = "BOSS CAFE " & vbCrLf & "60 BEDFORD ROAD" & vbCrLf & "AVONDALE" & vbCrLf & "HARARE" & vbCrLf & vbCrLf & "Tel: 0773277464" & vbCrLf & "VAT NO: ---------" & vbCrLf & "---------------------------------------------------------------------------------------------------------------"
        rtfReceipt.AppendText(vbCrLf + "Number     :                       " & "00" + Label2.Text)
        rtfReceipt.AppendText(vbCrLf + "Date:" & DateTimePicker1.Value.ToLongDateString)
        rtfReceiptB.Text = "BEVERAGES"
        rtfReceiptC.Text = "KITCHEN"
        cmborder.ResetText()
        cmbwaiter.ResetText()
        pcount = 0
        total = 0
        zwdtotal = 0
        Timer2.Start()
        cusd = True
        rtotal = 0
        lblZTotal.Visible = False
        lblTotal.Visible = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If cmbwaiter.Text <> "" And cmborder.Text <> "" Then
            rtfReceipt.AppendText(vbCrLf + "---------------------------------------------------------------------------------------------------------------" + vbTab)
            rtfReceipt.AppendText(vbCrLf + "CODE     QTY       PRICE    TOTAL" + vbTab)
            Timer2.Stop()
        End If
    End Sub

    Private Sub zwd_Click(sender As Object, e As EventArgs) Handles zwd.Click
        MsgBox("This will now convert the prices on the current invoice to Zimbabwean Dollar!", MsgBoxStyle.Information, "Price Conversion")
        cusd = False
        lblTotal.Visible = False
        lblZTotal.Visible = True
    End Sub

    Private Sub swipe_Click(sender As Object, e As EventArgs) Handles swipe.Click
        MsgBox("This will now convert the prices on the current invoice to Zimbabwean Dollar!", MsgBoxStyle.Information, "Price Conversion")
        cusd = False
        lblTotal.Visible = False
        lblZTotal.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cmbCategory.SelectedIndex = 0
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cmbCategory.SelectedIndex = 1
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        cmbCategory.SelectedIndex = 2
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        cmbCategory.SelectedIndex = 3
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        cmbCategory.SelectedIndex = 4
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        cmbCategory.SelectedIndex = 5
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        cmbCategory.SelectedIndex = 6
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        cmbCategory.SelectedIndex = 7
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        cmbCategory.SelectedIndex = 8
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        cmbCategory.SelectedIndex = 9
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        cmbCategory.SelectedIndex = 10
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        cmbCategory.SelectedIndex = 11
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        cmbCategory.SelectedIndex = 12
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        cmbCategory.SelectedIndex = 13
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub remove_Click(sender As Object, e As EventArgs) Handles remove.Click
        rtfReceipt.Undo()
        rtfReceiptB.Undo()
        rtfReceiptC.Undo()
        EOD.rtfReceipt.Undo()
        If cusd = True Then
            rtotal = rtotal - total
        Else
            rtotal = rtotal - zwdtotal
        End If
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        If Login.txtPassword.Text = "1207" Or Login.txtPassword.Text = "1206" Then
            txtDtotal.Visible = True
        Else
            MsgBox("Not Authorised to view report!")
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        lblZTotal.Text = rtotal
        lblTotal.Text = rtotal & ".00"
    End Sub

    Private Sub fish_Click(sender As Object, e As EventArgs) Handles fish.Click
        cmbCategory.SelectedIndex = 14
        ProductsDataGridView.BringToFront()
        ProductsDataGridView.Visible = True
        btnClose.Visible = True
        btnClose.BringToFront()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ProductsDataGridView.SendToBack()
        ProductsDataGridView.Visible = False
        btnClose.Visible = False
        btnClose.SendToBack()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtotal = 0
        pcount = 0
        Me.Controls.Clear()
        InitializeComponent()
        Entries_Load(e, e)
    End Sub
End Class