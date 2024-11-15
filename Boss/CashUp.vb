Imports System.Data.OleDb
Public Class CashUp

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(rtfCashUp.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 10, 10)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.Print()
    End Sub

    Private Sub CashUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BossDataSet.Totals' table. You can move, or remove it, as needed.
        Me.TotalsTableAdapter.Fill(Me.BossDataSet.Totals)
        If Login.txtPassword.Text = "hebi0800" Then 'Access to change the new file
            rtfCashUp.Enabled = True
            btnReset.Visible = True
        Else
            rtfCashUp.Enabled = False
            btnReset.Visible = False
        End If
    End Sub

    'Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
    '   Me.TotalsBindingSource.Clear()
    'End Sub

    Private Sub TotalsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TotalsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TotalsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BossDataSet)

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "DELETE * FROM Totals"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.ExecuteNonQuery()
            MsgBox("Receipt Totals Cleared")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "DELETE * FROM Sales"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.ExecuteNonQuery()
            MsgBox("Sales By Invoice Cleared")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "DELETE * FROM Waiters"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Waiters Table not cleared!")

        End Try
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim connstring, command As String
            connstring = My.Settings.BossConnectionString
            sqlconn.ConnectionString = connstring
            sqlconn.Open()
            command = "DELETE * FROM DTotals WHERE TDate = '" & Today & "'"
            Dim sql As OleDbCommand = New OleDbCommand(command, sqlconn)
            sql.ExecuteNonQuery()
            MsgBox("Daily Total Reset")
            Me.Controls.Clear()
            InitializeComponent()
            CashUp_Load(e, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class
