Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class Entries
    Private isUSD As Boolean = True
    Private dailyTotal As Decimal = 0
    Private runningTotal As Decimal = 0
    Private currentItemTotal, currentItemZWDTotal As Decimal
    Private chickenType, steakType, breakfastType As String
    Private productCount As Integer = 0
    Private currentReceiptNumber As String = "001"
    Private currentSale As New List(Of SaleData)
    Private dailyTotals As DailyTotalsData
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
        Try
            ' Initialize timers
            Timer3.Start()
            
            ' Load daily totals using business logic layer
            dailyTotals = BusinessLogicLayer.CalculateDailyTotals(DateTime.Today)
            
            ' Set up receipt number
            currentReceiptNumber = BusinessLogicLayer.GenerateReceiptNumber(DateTime.Today)
            Label2.Text = currentReceiptNumber.PadLeft(3, "0"c)
            
            ' Update daily totals display
            txtDtotal.Text = dailyTotals.UTotal.ToString("F2")
            txtDZTotal.Text = dailyTotals.ZTotal.ToString("F2")
            
            ' Load data using table adapters
            Me.DTotalsTableAdapter.Fill(Me.BossDataSet.DTotals)
            Me.SalesTableAdapter.Fill(Me.BossDataSet.Sales)
            Me.TotalsTableAdapter.Fill(Me.BossDataSet.Totals)
            Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)
            
            ' Initialize receipt display
            InitializeReceiptDisplay()
            
            ' Start timers
            Timer1.Start()
            Timer2.Start()
            
            ' Initialize form controls
            InitializeFormControls()
            
        Catch ex As BusinessLogicException
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub InitializeReceiptDisplay()
        rtfReceipt.Clear()
        rtfReceipt.AppendText("BOSS CAFE" & vbCrLf)
        rtfReceipt.AppendText("60 BEDFORD ROAD" & vbCrLf)
        rtfReceipt.AppendText("AVONDALE" & vbCrLf)
        rtfReceipt.AppendText("HARARE" & vbCrLf & vbCrLf)
        rtfReceipt.AppendText("Tel: 0773277464" & vbCrLf)
        rtfReceipt.AppendText("VAT NO: ---------" & vbCrLf)
        rtfReceipt.AppendText("---------------------------------------------------------------------------------------------------------------" & vbCrLf)
        rtfReceipt.AppendText("Date: " & DateTimePicker1.Value.ToLongDateString & vbCrLf)
        rtfReceipt.AppendText("Number: " & currentReceiptNumber.PadLeft(3, "0"c) & vbCrLf)
    End Sub
    
    Private Sub InitializeFormControls()
        ' Set up currency display
        UpdateCurrencyDisplay()
        
        ' Initialize category buttons
        SetupCategoryButtons()
        
        ' Set up order types
        SetupOrderTypes()
        
        ' Set up waiter list
        SetupWaiterList()
    End Sub
    
    Private Sub SetupCategoryButtons()
        ' This would be populated from database in a real implementation
        ' For now, we'll use the existing button setup
    End Sub
    
    Private Sub SetupOrderTypes()
        cmborder.Items.Clear()
        cmborder.Items.Add("Dine In")
        cmborder.Items.Add("Take Away")
        cmborder.Items.Add("Delivery")
    End Sub
    
    Private Sub SetupWaiterList()
        cmbwaiter.Items.Clear()
        ' This would be populated from database in a real implementation
        cmbwaiter.Items.Add("John")
        cmbwaiter.Items.Add("Mary")
        cmbwaiter.Items.Add("Peter")
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
        Try
            ' Validate required fields
            If String.IsNullOrWhiteSpace(cmbwaiter.Text) Then
                MessageBox.Show("Please select a waiter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            If String.IsNullOrWhiteSpace(cmborder.Text) Then
                MessageBox.Show("Please select an order type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Get product information
            Dim productCode As String = ProductsDataGridView.CurrentRow.Cells(0).Value.ToString()
            Dim productDescription As String = ProductsDataGridView.CurrentRow.Cells(1).Value.ToString()
            Dim productCategory As String = ProductsDataGridView.CurrentRow.Cells(2).Value.ToString()
            Dim productZWL As Decimal = Convert.ToDecimal(ProductsDataGridView.CurrentRow.Cells(3).Value)
            Dim productUSD As Decimal = Convert.ToDecimal(ProductsDataGridView.CurrentRow.Cells(4).Value)
            
            ' Get quantity
            Dim quantity As Integer
            Using quantityForm As New Quantity()
                If quantityForm.ShowDialog() = DialogResult.OK Then
                    quantity = Convert.ToInt32(quantityForm.quantitybx.Text)
                Else
                    Return ' User cancelled
                End If
            End Using
            
            ' Validate quantity
            If quantity <= 0 Then
                MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Get special preparation instructions
            Dim specialInstructions As String = GetSpecialInstructions(productCategory)
            
            ' Calculate totals
            Dim price As Decimal = If(isUSD, productUSD, productZWL)
            currentItemTotal = quantity * price
            
            ' Create sale data
            Dim saleData As New SaleData With {
                .Code = productCode,
                .Description = productDescription & If(String.IsNullOrWhiteSpace(specialInstructions), "", " (" & specialInstructions & ")"),
                .Quantity = quantity,
                .Receipt = currentReceiptNumber,
                .Price = price,
                .Total = currentItemTotal,
                .Date = DateTimePicker1.Value,
                .Waiter = cmbwaiter.Text,
                .Order = cmborder.Text,
                .Currency = If(isUSD, "USD", "ZWD")
            }
            
            ' Add to current sale
            currentSale.Add(saleData)
            
            ' Update running totals
            runningTotal += currentItemTotal
            productCount += quantity
            
            ' Update receipt display
            UpdateReceiptDisplay(saleData)
            
            ' Update totals display
            UpdateTotalsDisplay()
            
            ' Hide product grid
            ProductsDataGridView.SendToBack()
            ProductsDataGridView.Visible = False
            btnClose.SendToBack()
            btnClose.Visible = False
            
            ' Clear special instruction variables
            chickenType = ""
            steakType = ""
            breakfastType = ""
            
        Catch ex As Exception
            MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Function GetSpecialInstructions(category As String) As String
        Select Case category.ToLower()
            Case "steak"
                steakType = InputBox("Enter preparation:" & vbCrLf & "W for Well Done" & vbCrLf & "M for Medium" & vbCrLf & "R for Rare" & vbCrLf & "MW for Medium Well", "Steak Preparation")
                Return steakType
            Case "chicken"
                chickenType = InputBox("Enter preparation:" & vbCrLf & "L for Lemon & Herb" & vbCrLf & "M for Mild" & vbCrLf & "H for Hot", "Chicken Preparation")
                Return chickenType
            Case "breakfasts"
                breakfastType = InputBox("Enter preparation:" & vbCrLf & "S for Scrambled" & vbCrLf & "M for Medium" & vbCrLf & "W for Well Done", "Breakfast Preparation")
                Return breakfastType
            Case Else
                Return ""
        End Select
    End Function
    
    Private Sub UpdateReceiptDisplay(saleData As SaleData)
        ' Update main receipt
        rtfReceipt.AppendText(vbCrLf & saleData.Description & vbCrLf)
        rtfReceipt.AppendText(saleData.Code & vbTab & saleData.Quantity.ToString("F0") & vbTab & saleData.Price.ToString("F2") & vbTab & saleData.Total.ToString("F2"))
        
        ' Update kitchen receipt
        If IsKitchenItem(saleData.Description) Then
            rtfReceiptC.AppendText(vbCrLf & saleData.Quantity.ToString("F0") & "  " & saleData.Description)
        Else
            rtfReceiptB.AppendText(vbCrLf & saleData.Quantity.ToString("F0") & "  " & saleData.Description)
        End If
        
        ' Update EOD receipt
        EOD.rtfReceipt.AppendText(vbCrLf & saleData.Description & vbCrLf)
        EOD.rtfReceipt.AppendText(saleData.Code & vbTab & saleData.Quantity.ToString("F0") & vbTab & saleData.Price.ToString("F2") & vbTab & saleData.Total.ToString("F2"))
    End Sub
    
    Private Function IsKitchenItem(description As String) As Boolean
        Dim kitchenCategories As String() = {"Chicken", "Steak", "Breakfasts", "Sandwiches", "Extras", "Salads", "Fish"}
        Return kitchenCategories.Any(Function(cat) description.ToLower().Contains(cat.ToLower()))
    End Function
    
    Private Sub UpdateTotalsDisplay()
        If isUSD Then
            lblTotal.Text = runningTotal.ToString("F2")
            lblZTotal.Visible = False
            lblTotal.Visible = True
        Else
            lblZTotal.Text = runningTotal.ToString("F2")
            lblTotal.Visible = False
            lblZTotal.Visible = True
        End If
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub payment_Click(sender As Object, e As EventArgs) Handles payment.Click
        Try
            ' Validate that there are items to process
            If currentSale.Count = 0 Then
                MessageBox.Show("No items to process. Please add items to the sale.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Process each sale item
            For Each saleItem As SaleData In currentSale
                Dim result As ProcessingResult = BusinessLogicLayer.ProcessSale(saleItem)
                If Not result.IsSuccess Then
                    MessageBox.Show($"Failed to process sale item: {result.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next
            
            ' Complete the receipt
            CompleteReceipt()
            
            ' Print receipts
            PrintReceipts()
            
            ' Update daily totals
            UpdateDailyTotals()
            
            ' Reset for next sale
            ResetForNextSale()
            
            MessageBox.Show($"Sales Invoice number {currentReceiptNumber} successfully processed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            
        Catch ex As BusinessLogicException
            MessageBox.Show($"Payment processing error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub CompleteReceipt()
        ' Add totals to receipt
        rtfReceipt.AppendText(vbCrLf & vbCrLf & "---------------------------------------------------------------------------------------------------------------")
        rtfReceipt.AppendText(vbCrLf & "Number of items: " & productCount.ToString())
        
        If isUSD Then
            rtfReceipt.AppendText(vbCrLf & "USD Total: " & runningTotal.ToString("F2"))
        Else
            rtfReceipt.AppendText(vbCrLf & "ZWD Total: " & runningTotal.ToString("F2"))
        End If
        
        rtfReceipt.AppendText(vbCrLf & vbCrLf & "Waiter: " & cmbwaiter.Text)
        
        ' Update kitchen and beverage receipts
        rtfReceiptC.AppendText(vbCrLf & vbCrLf & "---")
        rtfReceiptB.AppendText(vbCrLf & vbCrLf & "---")
        
        ' Update EOD receipt
        EOD.rtfReceipt.AppendText(vbCrLf & vbCrLf & "Number of items: " & productCount.ToString())
        EOD.rtfReceipt.AppendText(vbCrLf & "Total: " & runningTotal.ToString("F2"))
        EOD.rtfReceipt.AppendText(vbCrLf & "---------------------------------------------------------------------------------------------------------------")
    End Sub
    
    Private Sub PrintReceipts()
        Try
            ' Print all receipt types
            PrintDocument3.Print() ' Kitchen receipt
            PrintDocument2.Print() ' Beverage receipt
            PrintDocument1.Print() ' Customer receipt
            PrintDocument1.Print() ' Duplicate for records
        Catch ex As Exception
            MessageBox.Show($"Printing error: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    
    Private Sub UpdateDailyTotals()
        Try
            ' Update daily totals
            If isUSD Then
                dailyTotals.UTotal += runningTotal
            Else
                dailyTotals.ZTotal += runningTotal
            End If
            
            dailyTotals.ReceiptCount = Convert.ToInt32(currentReceiptNumber)
            BusinessLogicLayer.UpdateDailyTotals(dailyTotals)
            
            ' Update display
            txtDtotal.Text = dailyTotals.UTotal.ToString("F2")
            txtDZTotal.Text = dailyTotals.ZTotal.ToString("F2")
            
        Catch ex As BusinessLogicException
            MessageBox.Show($"Failed to update daily totals: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub ResetForNextSale()
        ' Generate new receipt number
        currentReceiptNumber = BusinessLogicLayer.GenerateReceiptNumber(DateTime.Today)
        Label2.Text = currentReceiptNumber.PadLeft(3, "0"c)
        
        ' Reset totals
        runningTotal = 0
        productCount = 0
        currentSale.Clear()
        
        ' Reset displays
        lblTotal.Text = "0.00"
        lblZTotal.Text = "0.00"
        
        ' Reset receipt displays
        InitializeReceiptDisplay()
        rtfReceiptB.Text = "BEVERAGES"
        rtfReceiptC.Text = "KITCHEN"
        
        ' Reset form controls
        cmborder.ResetText()
        cmbwaiter.ResetText()
        
        ' Reset currency to USD
        isUSD = True
        UpdateCurrencyDisplay()
        
        ' Start timer for next sale
        Timer2.Start()
    End Sub
    
    Private Sub UpdateCurrencyDisplay()
        If isUSD Then
            lblTotal.Visible = True
            lblZTotal.Visible = False
        Else
            lblTotal.Visible = False
            lblZTotal.Visible = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If cmbwaiter.Text <> "" And cmborder.Text <> "" Then
            rtfReceipt.AppendText(vbCrLf + "---------------------------------------------------------------------------------------------------------------" + vbTab)
            rtfReceipt.AppendText(vbCrLf + "CODE     QTY       PRICE    TOTAL" + vbTab)
            Timer2.Stop()
        End If
    End Sub

    Private Sub zwd_Click(sender As Object, e As EventArgs) Handles zwd.Click
        Try
            If currentSale.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("Switching currency will recalculate all items in the current sale. Continue?", 
                                                           "Currency Conversion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    Return
                End If
            End If
            
            isUSD = False
            UpdateCurrencyDisplay()
            RecalculateCurrentSale()
            
            MessageBox.Show("Currency switched to Zimbabwean Dollar (ZWD). All prices have been converted.", 
                          "Currency Conversion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error switching currency: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub swipe_Click(sender As Object, e As EventArgs) Handles swipe.Click
        Try
            If currentSale.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("Switching currency will recalculate all items in the current sale. Continue?", 
                                                           "Currency Conversion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    Return
                End If
            End If
            
            isUSD = False
            UpdateCurrencyDisplay()
            RecalculateCurrentSale()
            
            MessageBox.Show("Currency switched to Zimbabwean Dollar (ZWD). All prices have been converted.", 
                          "Currency Conversion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error switching currency: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub RecalculateCurrentSale()
        If currentSale.Count = 0 Then Return
        
        runningTotal = 0
        
        For Each saleItem As SaleData In currentSale
            ' Get the product from database to get both USD and ZWD prices
            Dim products = BusinessLogicLayer.GetProductsByCategory("") ' Get all products
            Dim product = products.FirstOrDefault(Function(p) p.Code = saleItem.Code)
            
            If product IsNot Nothing Then
                saleItem.Price = If(isUSD, product.USD, product.ZWL)
                saleItem.Total = saleItem.Quantity * saleItem.Price
                saleItem.Currency = If(isUSD, "USD", "ZWD")
            End If
            
            runningTotal += saleItem.Total
        Next
        
        UpdateTotalsDisplay()
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