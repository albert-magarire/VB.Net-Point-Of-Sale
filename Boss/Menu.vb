Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class Menu
    Private productCategories As New List(Of String)

    Private Sub ProductsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load products data
            Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)
            
            ' Initialize form
            InitializeForm()
            
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeForm()
        ' Set up category combo box
        SetupCategoryComboBox()
        
        ' Set up validation
        SetupValidation()
        
        ' Set up data grid view
        SetupDataGridView()
    End Sub

    Private Sub SetupCategoryComboBox()
        ' Populate category combo box with predefined categories
        productCategories.AddRange({"Beverages", "Steak", "Chicken", "Breakfasts", "Sandwiches", 
                                   "Extras", "Salads", "Fish", "Desserts", "Appetizers", "Soups", 
                                   "Pasta", "Pizza", "Burgers", "Specials"})
        
        CategoryTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CategoryTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        CategoryTextBox.AutoCompleteCustomSource.AddRange(productCategories.ToArray())
    End Sub

    Private Sub SetupValidation()
        ' Set up input validation
        CodeTextBox.MaxLength = 50
        DescriptionTextBox.MaxLength = 255
        CategoryTextBox.MaxLength = 100
    End Sub

    Private Sub SetupDataGridView()
        ' Configure data grid view
        ProductsDataGridView.AllowUserToAddRows = False
        ProductsDataGridView.AllowUserToDeleteRows = False
        ProductsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ProductsDataGridView.MultiSelect = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate input
            If Not ValidateProductInput() Then
                Return
            End If

            ' Create product data
            Dim product As New ProductData With {
                .Code = CodeTextBox.Text.Trim(),
                .Description = DescriptionTextBox.Text.Trim(),
                .Category = CategoryTextBox.Text.Trim(),
                .ZWL = Convert.ToDecimal(ZWLTextBox.Text),
                .USD = Convert.ToDecimal(USDTextBox.Text)
            }

            ' Validate using business logic
            Dim validationResult = BusinessLogicLayer.ValidateProduct(product)
            If Not validationResult.IsValid Then
                MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Save using data access layer
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Code", product.Code},
                {"@Description", product.Description},
                {"@Category", product.Category},
                {"@ZWL", product.ZWL},
                {"@USD", product.USD}
            }

            DataAccessLayer.ExecuteNonQuery("INSERT INTO Products (Code, Description, Category, ZWL, USD) VALUES (@Code, @Description, @Category, @ZWL, @USD)", parameters)

            ' Refresh data
            Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)
            
            ' Clear form
            ClearForm()
            
            MessageBox.Show("Product successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As DataAccessException
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateProductInput() As Boolean
        ' Validate code
        Dim codeValidation = ValidationHelper.ValidateRequired(CodeTextBox.Text, "Product Code")
        If Not codeValidation.IsValid Then
            MessageBox.Show(codeValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CodeTextBox.Focus()
            Return False
        End If

        ' Validate description
        Dim descriptionValidation = ValidationHelper.ValidateRequired(DescriptionTextBox.Text, "Product Description")
        If Not descriptionValidation.IsValid Then
            MessageBox.Show(descriptionValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DescriptionTextBox.Focus()
            Return False
        End If

        ' Validate category
        Dim categoryValidation = ValidationHelper.ValidateRequired(CategoryTextBox.Text, "Product Category")
        If Not categoryValidation.IsValid Then
            MessageBox.Show(categoryValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CategoryTextBox.Focus()
            Return False
        End If

        ' Validate ZWL price
        Dim zwlValidation = ValidationHelper.ValidateCurrency(ZWLTextBox.Text, "ZWL Price")
        If Not zwlValidation.IsValid Then
            MessageBox.Show(zwlValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ZWLTextBox.Focus()
            Return False
        End If

        ' Validate USD price
        Dim usdValidation = ValidationHelper.ValidateCurrency(USDTextBox.Text, "USD Price")
        If Not usdValidation.IsValid Then
            MessageBox.Show(usdValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            USDTextBox.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If ProductsDataGridView.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a product to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate input
            If Not ValidateProductInput() Then
                Return
            End If

            ' Get selected product code
            Dim selectedCode As String = ProductsDataGridView.SelectedRows(0).Cells("Code").Value.ToString()

            ' Update product
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Description", DescriptionTextBox.Text.Trim()},
                {"@Category", CategoryTextBox.Text.Trim()},
                {"@ZWL", Convert.ToDecimal(ZWLTextBox.Text)},
                {"@USD", Convert.ToDecimal(USDTextBox.Text)},
                {"@Code", selectedCode}
            }

            DataAccessLayer.ExecuteNonQuery("UPDATE Products SET Description = @Description, Category = @Category, ZWL = @ZWL, USD = @USD WHERE Code = @Code", parameters)

            ' Refresh data
            Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)
            
            MessageBox.Show("Product successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As DataAccessException
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If ProductsDataGridView.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a product to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedCode As String = ProductsDataGridView.SelectedRows(0).Cells("Code").Value.ToString()
            Dim selectedDescription As String = ProductsDataGridView.SelectedRows(0).Cells("Description").Value.ToString()

            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the product '{selectedDescription}' (Code: {selectedCode})?", 
                                                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Return
            End If

            ' Delete product
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Code", selectedCode}
            }

            DataAccessLayer.ExecuteNonQuery("DELETE FROM Products WHERE Code = @Code", parameters)

            ' Refresh data
            Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)
            
            ' Clear form
            ClearForm()
            
            MessageBox.Show("Product successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As DataAccessException
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        CodeTextBox.Clear()
        DescriptionTextBox.Clear()
        CategoryTextBox.Clear()
        ZWLTextBox.Clear()
        USDTextBox.Clear()
        CodeTextBox.Focus()
    End Sub

    Private Sub ProductsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles ProductsDataGridView.SelectionChanged
        Try
            If ProductsDataGridView.SelectedRows.Count > 0 Then
                Dim selectedRow = ProductsDataGridView.SelectedRows(0)
                CodeTextBox.Text = selectedRow.Cells("Code").Value.ToString()
                DescriptionTextBox.Text = selectedRow.Cells("Description").Value.ToString()
                CategoryTextBox.Text = selectedRow.Cells("Category").Value.ToString()
                ZWLTextBox.Text = selectedRow.Cells("ZWL").Value.ToString()
                USDTextBox.Text = selectedRow.Cells("USD").Value.ToString()
            End If
        Catch ex As Exception
            ' Ignore errors during selection change
        End Try
    End Sub

    Private Sub ZWLTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ZWLTextBox.KeyPress, USDTextBox.KeyPress
        ' Allow only numbers, decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class