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
    Private selectedProduct As ProductData
    Private productCards As New List(Of Button)

    ' Additional variables for compatibility
    Private cusd As Boolean = True
    Private rtotal As Decimal = 0
    Private total As Decimal = 0
    Private zwdtotal As Decimal = 0
    Private pcount As Integer = 0
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
            Timer3.Stop()

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
        rtfReceipt.AppendText("BOSS BRANDS (PVT) LTD" & vbCrLf)
        rtfReceipt.AppendText("60 BEDFORD ROAD" & vbCrLf)
        rtfReceipt.AppendText("AVONDALE" & vbCrLf)
        rtfReceipt.AppendText("HARARE" & vbCrLf & vbCrLf)
        rtfReceipt.AppendText("Tel: 0773277464" & vbCrLf)
        rtfReceipt.AppendText("VAT NO: 220372929" & vbCrLf)
        rtfReceipt.AppendText("TIN NO: 2001506620" & vbCrLf)
        rtfReceipt.AppendText(" " & vbCrLf)
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

    Private Sub ShowProductCards(category As String)
        Try
            ' Clear existing cards
            ClearProductCards()

            ' Get products for the category
            Dim products = BusinessLogicLayer.GetProductsByCategory(category)

            If products IsNot Nothing AndAlso products.Count > 0 Then
                ' Show the product cards panel
                pnlProductCards.Visible = True
                pnlProductCards.BringToFront()
                btnClose.Visible = True
                btnClose.BringToFront()

                ' Create product cards
                CreateProductCards(products)
            Else
                MessageBox.Show("No products found for the selected category.", "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearProductCards()
        ' Remove all existing product cards
        For Each card As Button In productCards
            pnlProductCards.Controls.Remove(card)
            card.Dispose()
        Next
        productCards.Clear()
    End Sub

    Private Sub CreateProductCards(products As List(Of ProductData))
        Dim cardWidth As Integer = 190
        Dim cardHeight As Integer = 140
        Dim cardsPerRow As Integer = 3
        Dim spacing As Integer = 15
        Dim startX As Integer = 15
        Dim startY As Integer = 15

        For i As Integer = 0 To products.Count - 1
            Dim product As ProductData = products(i)

            ' Calculate position
            Dim row As Integer = i \ cardsPerRow
            Dim col As Integer = i Mod cardsPerRow
            Dim x As Integer = startX + col * (cardWidth + spacing)
            Dim y As Integer = startY + row * (cardHeight + spacing)

            ' Create product card button
            Dim card As New Button()
            card.Name = $"ProductCard_{product.Code}"
            card.Text = $"{product.Description}{vbCrLf}{vbCrLf}Code: {product.Code}{vbCrLf}Price: ${If(isUSD, product.USD, product.ZWL):F2}"
            card.Size = New Size(cardWidth, cardHeight)
            card.Location = New Point(x, y)
            card.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            card.TextAlign = ContentAlignment.TopLeft
            card.BackColor = Color.White
            card.FlatStyle = FlatStyle.Flat
            card.FlatAppearance.BorderSize = 0
            card.Cursor = Cursors.Hand

            ' Add modern styling with shadow effect
            card.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 204, 113)
            card.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 174, 96)

            ' Add rounded corners effect (simulated with border)
            card.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220)
            card.FlatAppearance.BorderSize = 1

            ' Add hover effects
            AddHandler card.MouseEnter, AddressOf ProductCard_MouseEnter
            AddHandler card.MouseLeave, AddressOf ProductCard_MouseLeave
            AddHandler card.Click, AddressOf ProductCard_Click

            ' Store product data in tag
            card.Tag = product

            ' Add to panel and list
            pnlProductCards.Controls.Add(card)
            productCards.Add(card)
        Next
    End Sub

    Private Sub ProductCard_MouseEnter(sender As Object, e As EventArgs)
        Dim card As Button = DirectCast(sender, Button)
        card.BackColor = Color.FromArgb(46, 204, 113)
        card.ForeColor = Color.White
        card.FlatAppearance.BorderColor = Color.FromArgb(39, 174, 96)
        card.FlatAppearance.BorderSize = 2
    End Sub

    Private Sub ProductCard_MouseLeave(sender As Object, e As EventArgs)
        Dim card As Button = DirectCast(sender, Button)
        card.BackColor = Color.White
        card.ForeColor = Color.Black
        card.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220)
        card.FlatAppearance.BorderSize = 1
    End Sub

    Private Sub ProductCard_Click(sender As Object, e As EventArgs)
        Try
            Dim card As Button = DirectCast(sender, Button)
            selectedProduct = DirectCast(card.Tag, ProductData)

            ' Show quantity input
            lblSelectedProduct.Text = $"Selected: {selectedProduct.Description}"
            lblSelectedProduct.Visible = True
            lblQuantity.Visible = True
            txtQuantity.Visible = True
            txtQuantity.Focus()
            btnAddToReceipt.Visible = True

        Catch ex As Exception
            MessageBox.Show($"Error selecting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        cmbwaiter.Items.Add("Mary")
        cmbwaiter.Items.Add("John")
        cmbwaiter.Items.Add("Peter")
        cmbwaiter.Items.Add("Sarah")
        cmbwaiter.Items.Add("Mike")
        cmbwaiter.Items.Add("Lisa")
        cmbwaiter.Items.Add("David")
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
                    quantity = Convert.ToInt32(quantityForm.RichTextBox1.Text)
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
            AuditLogger.Log("sale", "Cashier", $"receipt={currentReceiptNumber}; items={productCount}; total={runningTotal}")

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

            dailyTotals.ReceiptCount += 1
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
            Dim product = BusinessLogicLayer.GetProductByCode(saleItem.Code)
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
        ShowProductCards("Chicken")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ShowProductCards("Steak")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ShowProductCards("Breakfasts")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ShowProductCards("Sandwiches")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ShowProductCards("Cakes")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ShowProductCards("Extras")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ShowProductCards("Hot Beverages")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ShowProductCards("Salads")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ShowProductCards("Milkshakes")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ShowProductCards("Smoothies & Frezzos")
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ShowProductCards("Frappes")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ShowProductCards("Mocktails")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ShowProductCards("Coolers")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        ShowProductCards("Fruit Juice")
    End Sub

    Private Shadows Sub remove_Click(sender As Object, e As EventArgs) Handles remove.Click
        ' Visually undo last text entry
        rtfReceipt.Undo()
        rtfReceiptB.Undo()
        rtfReceiptC.Undo()
        EOD.rtfReceipt.Undo()

        ' Remove last item from the current sale and recompute totals
        If currentSale.Count > 0 Then
            Dim last As SaleData = currentSale(currentSale.Count - 1)
            currentSale.RemoveAt(currentSale.Count - 1)
            productCount = Math.Max(0, productCount - last.Quantity)

            runningTotal = 0
            For Each s In currentSale
                runningTotal += s.Total
            Next
            UpdateTotalsDisplay()
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
        Timer3.Stop()
    End Sub

    Private Sub fish_Click(sender As Object, e As EventArgs) Handles fish.Click
        ShowProductCards("Fish")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ProductsDataGridView.SendToBack()
        ProductsDataGridView.Visible = False
        pnlProductCards.Visible = False
        pnlProductCards.SendToBack()
        btnClose.Visible = False
        btnClose.SendToBack()
        HideQuantityInput()
    End Sub

    Private Sub HideQuantityInput()
        lblSelectedProduct.Visible = False
        lblQuantity.Visible = False
        txtQuantity.Visible = False
        txtQuantity.Clear()
        btnAddToReceipt.Visible = False
        selectedProduct = Nothing
    End Sub

    Private Sub ShowSuccessMessage(message As String)
        ' Create a temporary label to show success message
        Dim successLabel As New Label()
        successLabel.Text = message
        successLabel.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        successLabel.ForeColor = Color.FromArgb(46, 204, 113)
        successLabel.BackColor = Color.FromArgb(236, 240, 241)
        successLabel.AutoSize = True
        successLabel.Location = New Point(400, 620)
        successLabel.BringToFront()

        ' Add to form
        Me.Controls.Add(successLabel)

        ' Remove after 3 seconds
        Dim timer As New Timer()
        timer.Interval = 3000
        AddHandler timer.Tick, Sub()
                                   Me.Controls.Remove(successLabel)
                                   successLabel.Dispose()
                                   timer.Stop()
                                   timer.Dispose()
                               End Sub
        timer.Start()
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        ' Allow only numbers and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        ' Handle Enter key
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            AddSelectedProductToReceipt()
        End If
    End Sub

    Private Sub btnAddToReceipt_Click(sender As Object, e As EventArgs) Handles btnAddToReceipt.Click
        AddSelectedProductToReceipt()
    End Sub

    Private Sub AddSelectedProductToReceipt()
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

            If selectedProduct Is Nothing Then
                MessageBox.Show("Please select a product first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get quantity
            Dim quantity As Integer
            If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity <= 0 Then
                MessageBox.Show("Please enter a valid quantity greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQuantity.Focus()
                Return
            End If

            ' Get special preparation instructions
            Dim specialInstructions As String = GetSpecialInstructions(selectedProduct.Category)

            ' Calculate totals
            Dim price As Decimal = If(isUSD, selectedProduct.USD, selectedProduct.ZWL)
            currentItemTotal = quantity * price

            ' Create sale data
            Dim saleData As New SaleData With {
                .Code = selectedProduct.Code,
                .Description = selectedProduct.Description & If(String.IsNullOrWhiteSpace(specialInstructions), "", " (" & specialInstructions & ")"),
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

            ' Store product info for success message before clearing
            Dim productDescription As String = selectedProduct.Description

            ' Hide quantity input
            HideQuantityInput()

            ' Show success feedback
            ShowSuccessMessage($"Added {quantity}x {productDescription} to receipt")

            ' Clear special instruction variables
            chickenType = ""
            steakType = ""
            breakfastType = ""

        Catch ex As Exception
            MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtotal = 0
        pcount = 0
        Me.Controls.Clear()
        InitializeComponent()
        Entries_Load(e, e)
    End Sub
End Class