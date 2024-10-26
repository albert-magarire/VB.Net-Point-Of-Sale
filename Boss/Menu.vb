Imports System.Data.OleDb
Public Class Menu

    Private Sub ProductsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)

    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BossDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.BossDataSet.Products)

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)

        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "INSERT INTO Products([Code],[Description],[Category],[ZWL],[USD])VALUES('" & CodeTextBox.Text & "','" & DescriptionTextBox.Text & "','" & CategoryTextBox.Text & "','" & ZWLTextBox.Text & "','" & USDTextBox.Text & "')"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.Parameters.Add(New OleDbParameter("Code", CType(CodeTextBox.Text, String)))
            sql.Parameters.Add(New OleDbParameter("Description", CType(DescriptionTextBox.Text, String)))
            sql.Parameters.Add(New OleDbParameter("Category", CType(CategoryTextBox.Text, String)))
            sql.Parameters.Add(New OleDbParameter("ZWL", CType(ZWLTextBox.Text, String)))
            sql.Parameters.Add(New OleDbParameter("USD", CType(USDTextBox.Text, String)))
            MsgBox("New product successfully saved!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Me.Validate()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Validate()
        Me.ProductsBindingSource.RemoveCurrent()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)
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
        Me.Validate()
        Me.ProductsBindingSource.AddNew()
    End Sub
End Class