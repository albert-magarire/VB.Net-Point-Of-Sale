<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashUp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashUp))
        Me.btnBack = New System.Windows.Forms.Button()
        Me.rtfCashUp = New System.Windows.Forms.RichTextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.BossDataSet = New BOSS_CAFE.BossDataSet()
        Me.TotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TotalsTableAdapter = New BOSS_CAFE.BossDataSetTableAdapters.TotalsTableAdapter()
        Me.TableAdapterManager = New BOSS_CAFE.BossDataSetTableAdapters.TableAdapterManager()
        Me.TotalsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TotalsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.TotalsListBox = New System.Windows.Forms.ListBox()
        CType(Me.BossDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TotalsBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(285, 432)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'rtfCashUp
        '
        Me.rtfCashUp.Location = New System.Drawing.Point(1, 1)
        Me.rtfCashUp.Name = "rtfCashUp"
        Me.rtfCashUp.Size = New System.Drawing.Size(359, 454)
        Me.rtfCashUp.TabIndex = 4
        Me.rtfCashUp.Text = "BOSS CAFE" & Global.Microsoft.VisualBasic.ChrW(10) & "60 BEDFORD ROAD" & Global.Microsoft.VisualBasic.ChrW(10) & "AVONDALE" & Global.Microsoft.VisualBasic.ChrW(10) & "HARARE" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Tel: 0773277464" & Global.Microsoft.VisualBasic.ChrW(10) & "VAT NO: ---------" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "---" & _
    "--------------------------------------------------------------------------------" & _
    "----------------------------"
        '
        'PrintDocument1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(204, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "PRINT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(123, 432)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'BossDataSet
        '
        Me.BossDataSet.DataSetName = "BossDataSet"
        Me.BossDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TotalsBindingSource
        '
        Me.TotalsBindingSource.DataMember = "Totals"
        Me.TotalsBindingSource.DataSource = Me.BossDataSet
        '
        'TotalsTableAdapter
        '
        Me.TotalsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DTotalsTableAdapter = Nothing
        Me.TableAdapterManager.ProductsTableAdapter = Nothing
        Me.TableAdapterManager.SalesTableAdapter = Nothing
        Me.TableAdapterManager.TotalsTableAdapter = Me.TotalsTableAdapter
        Me.TableAdapterManager.UpdateOrder = BOSS_CAFE.BossDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsersTableAdapter = Nothing
        Me.TableAdapterManager.WaitersTableAdapter = Nothing
        '
        'TotalsBindingNavigator
        '
        Me.TotalsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.TotalsBindingNavigator.BindingSource = Me.TotalsBindingSource
        Me.TotalsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TotalsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TotalsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TotalsBindingNavigatorSaveItem})
        Me.TotalsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TotalsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TotalsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TotalsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TotalsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TotalsBindingNavigator.Name = "TotalsBindingNavigator"
        Me.TotalsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TotalsBindingNavigator.Size = New System.Drawing.Size(361, 25)
        Me.TotalsBindingNavigator.TabIndex = 8
        Me.TotalsBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TotalsBindingNavigatorSaveItem
        '
        Me.TotalsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TotalsBindingNavigatorSaveItem.Image = CType(resources.GetObject("TotalsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.TotalsBindingNavigatorSaveItem.Name = "TotalsBindingNavigatorSaveItem"
        Me.TotalsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.TotalsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'TotalsListBox
        '
        Me.TotalsListBox.DataSource = Me.TotalsBindingSource
        Me.TotalsListBox.DisplayMember = "Total"
        Me.TotalsListBox.FormattingEnabled = True
        Me.TotalsListBox.Location = New System.Drawing.Point(12, 167)
        Me.TotalsListBox.Name = "TotalsListBox"
        Me.TotalsListBox.Size = New System.Drawing.Size(300, 212)
        Me.TotalsListBox.TabIndex = 8
        Me.TotalsListBox.ValueMember = "Receipt"
        '
        'CashUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(361, 456)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.rtfCashUp)
        Me.Controls.Add(Me.TotalsListBox)
        Me.Controls.Add(Me.TotalsBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CashUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Boss Cafe | End Of Day Cashup Report"
        CType(Me.BossDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TotalsBindingNavigator.ResumeLayout(False)
        Me.TotalsBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents rtfCashUp As System.Windows.Forms.RichTextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents BossDataSet As BOSS_CAFE.BossDataSet
    Friend WithEvents TotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TotalsTableAdapter As BOSS_CAFE.BossDataSetTableAdapters.TotalsTableAdapter
    Friend WithEvents TableAdapterManager As BOSS_CAFE.BossDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TotalsBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TotalsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TotalsListBox As System.Windows.Forms.ListBox
End Class
