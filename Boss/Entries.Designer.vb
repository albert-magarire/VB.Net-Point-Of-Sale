<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Entries
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
        Dim CodeLabel As System.Windows.Forms.Label
        Dim QuantityLabel As System.Windows.Forms.Label
        Dim ReceiptLabel As System.Windows.Forms.Label
        Dim PriceLabel As System.Windows.Forms.Label
        Dim TotalLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim WaiterLabel As System.Windows.Forms.Label
        Dim OrderLabel As System.Windows.Forms.Label
        Dim CurrencyLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Entries))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblZTotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.payment = New System.Windows.Forms.Button()
        Me.cmborder = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbwaiter = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.quantitybx = New System.Windows.Forms.TextBox()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.rtfReceipt = New System.Windows.Forms.RichTextBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtDZTotal = New System.Windows.Forms.TextBox()
        Me.txtDtotal = New System.Windows.Forms.TextBox()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.swipe = New System.Windows.Forms.Button()
        Me.zwd = New System.Windows.Forms.Button()
        Me.usd = New System.Windows.Forms.Button()
        Me.rtfReceiptB = New System.Windows.Forms.RichTextBox()
        Me.rtfReceiptC = New System.Windows.Forms.RichTextBox()
        Me.ProductsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.ProductsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BossDataSet = New BOSS_CAFE.BossDataSet()
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
        Me.ProductsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ProductsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlProductCards = New System.Windows.Forms.Panel()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.btnAddToReceipt = New System.Windows.Forms.Button()
        Me.lblSelectedProduct = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument3 = New System.Drawing.Printing.PrintDocument()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TotalsListBox = New System.Windows.Forms.ListBox()
        Me.TotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CodeTextBox = New System.Windows.Forms.TextBox()
        Me.SalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QuantityTextBox = New System.Windows.Forms.TextBox()
        Me.ReceiptTextBox = New System.Windows.Forms.TextBox()
        Me.PriceTextBox = New System.Windows.Forms.TextBox()
        Me.TotalTextBox = New System.Windows.Forms.TextBox()
        Me.DateTextBox = New System.Windows.Forms.TextBox()
        Me.WaiterTextBox = New System.Windows.Forms.TextBox()
        Me.OrderTextBox = New System.Windows.Forms.TextBox()
        Me.CurrencyTextBox = New System.Windows.Forms.TextBox()
        Me.DTotalsListBox = New System.Windows.Forms.ListBox()
        Me.DTotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductsTableAdapter = New BOSS_CAFE.BossDataSetTableAdapters.ProductsTableAdapter()
        Me.TableAdapterManager = New BOSS_CAFE.BossDataSetTableAdapters.TableAdapterManager()
        Me.TotalsTableAdapter = New BOSS_CAFE.BossDataSetTableAdapters.TotalsTableAdapter()
        Me.SalesTableAdapter = New BOSS_CAFE.BossDataSetTableAdapters.SalesTableAdapter()
        Me.DTotalsTableAdapter = New BOSS_CAFE.BossDataSetTableAdapters.DTotalsTableAdapter()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.fish = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.remove = New System.Windows.Forms.Button()
        CodeLabel = New System.Windows.Forms.Label()
        QuantityLabel = New System.Windows.Forms.Label()
        ReceiptLabel = New System.Windows.Forms.Label()
        PriceLabel = New System.Windows.Forms.Label()
        TotalLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        WaiterLabel = New System.Windows.Forms.Label()
        OrderLabel = New System.Windows.Forms.Label()
        CurrencyLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ProductsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductsBindingNavigator.SuspendLayout()
        CType(Me.ProductsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BossDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CodeLabel
        '
        CodeLabel.AutoSize = True
        CodeLabel.Location = New System.Drawing.Point(757, 277)
        CodeLabel.Name = "CodeLabel"
        CodeLabel.Size = New System.Drawing.Size(35, 13)
        CodeLabel.TabIndex = 139
        CodeLabel.Text = "Code:"
        '
        'QuantityLabel
        '
        QuantityLabel.AutoSize = True
        QuantityLabel.Location = New System.Drawing.Point(757, 303)
        QuantityLabel.Name = "QuantityLabel"
        QuantityLabel.Size = New System.Drawing.Size(49, 13)
        QuantityLabel.TabIndex = 141
        QuantityLabel.Text = "Quantity:"
        '
        'ReceiptLabel
        '
        ReceiptLabel.AutoSize = True
        ReceiptLabel.Location = New System.Drawing.Point(757, 329)
        ReceiptLabel.Name = "ReceiptLabel"
        ReceiptLabel.Size = New System.Drawing.Size(47, 13)
        ReceiptLabel.TabIndex = 143
        ReceiptLabel.Text = "Receipt:"
        '
        'PriceLabel
        '
        PriceLabel.AutoSize = True
        PriceLabel.Location = New System.Drawing.Point(757, 355)
        PriceLabel.Name = "PriceLabel"
        PriceLabel.Size = New System.Drawing.Size(34, 13)
        PriceLabel.TabIndex = 145
        PriceLabel.Text = "Price:"
        '
        'TotalLabel
        '
        TotalLabel.AutoSize = True
        TotalLabel.Location = New System.Drawing.Point(757, 381)
        TotalLabel.Name = "TotalLabel"
        TotalLabel.Size = New System.Drawing.Size(34, 13)
        TotalLabel.TabIndex = 147
        TotalLabel.Text = "Total:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Location = New System.Drawing.Point(757, 407)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(33, 13)
        DateLabel.TabIndex = 149
        DateLabel.Text = "Date:"
        '
        'WaiterLabel
        '
        WaiterLabel.AutoSize = True
        WaiterLabel.Location = New System.Drawing.Point(757, 433)
        WaiterLabel.Name = "WaiterLabel"
        WaiterLabel.Size = New System.Drawing.Size(41, 13)
        WaiterLabel.TabIndex = 151
        WaiterLabel.Text = "Waiter:"
        '
        'OrderLabel
        '
        OrderLabel.AutoSize = True
        OrderLabel.Location = New System.Drawing.Point(757, 459)
        OrderLabel.Name = "OrderLabel"
        OrderLabel.Size = New System.Drawing.Size(36, 13)
        OrderLabel.TabIndex = 153
        OrderLabel.Text = "Order:"
        '
        'CurrencyLabel
        '
        CurrencyLabel.AutoSize = True
        CurrencyLabel.Location = New System.Drawing.Point(757, 485)
        CurrencyLabel.Name = "CurrencyLabel"
        CurrencyLabel.Size = New System.Drawing.Size(52, 13)
        CurrencyLabel.TabIndex = 155
        CurrencyLabel.Text = "Currency:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblZTotal)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.payment)
        Me.Panel1.Controls.Add(Me.cmborder)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbwaiter)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.quantitybx)
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 140)
        Me.Panel1.TabIndex = 0
        '
        'lblZTotal
        '
        Me.lblZTotal.AutoSize = True
        Me.lblZTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblZTotal.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblZTotal.Location = New System.Drawing.Point(900, 45)
        Me.lblZTotal.Name = "lblZTotal"
        Me.lblZTotal.Size = New System.Drawing.Size(120, 51)
        Me.lblZTotal.TabIndex = 62
        Me.lblZTotal.Text = "00.00"
        Me.lblZTotal.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(900, 45)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(120, 51)
        Me.lblTotal.TabIndex = 60
        Me.lblTotal.Text = "00.00"
        '
        'payment
        '
        Me.payment.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.payment.FlatAppearance.BorderSize = 0
        Me.payment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.payment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payment.ForeColor = System.Drawing.Color.White
        Me.payment.Location = New System.Drawing.Point(890, 95)
        Me.payment.Name = "payment"
        Me.payment.Size = New System.Drawing.Size(130, 40)
        Me.payment.TabIndex = 61
        Me.payment.Text = "PAYMENT"
        Me.payment.UseVisualStyleBackColor = False
        '
        'cmborder
        '
        Me.cmborder.BackColor = System.Drawing.Color.White
        Me.cmborder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmborder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmborder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmborder.FormattingEnabled = True
        Me.cmborder.Items.AddRange(New Object() {"Dine In", "Take Away", "Delivery"})
        Me.cmborder.Location = New System.Drawing.Point(570, 70)
        Me.cmborder.Name = "cmborder"
        Me.cmborder.Size = New System.Drawing.Size(200, 29)
        Me.cmborder.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(570, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Order Type:"
        '
        'cmbwaiter
        '
        Me.cmbwaiter.BackColor = System.Drawing.Color.White
        Me.cmbwaiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbwaiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbwaiter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbwaiter.FormattingEnabled = True
        Me.cmbwaiter.Items.AddRange(New Object() {"Mary", "John", "Peter", "Sarah", "Mike", "Lisa", "David"})
        Me.cmbwaiter.Location = New System.Drawing.Point(250, 70)
        Me.cmbwaiter.Name = "cmbwaiter"
        Me.cmbwaiter.Size = New System.Drawing.Size(200, 29)
        Me.cmbwaiter.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(250, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Waiter:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack
        Me.DateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimePicker1.Size = New System.Drawing.Size(1228, 26)
        Me.DateTimePicker1.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(20, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 86)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "001"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'quantitybx
        '
        Me.quantitybx.Location = New System.Drawing.Point(534, 95)
        Me.quantitybx.Name = "quantitybx"
        Me.quantitybx.Size = New System.Drawing.Size(100, 20)
        Me.quantitybx.TabIndex = 63
        Me.quantitybx.Visible = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button17.FlatAppearance.BorderSize = 0
        Me.Button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.White
        Me.Button17.Location = New System.Drawing.Point(480, 480)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(160, 70)
        Me.Button17.TabIndex = 138
        Me.Button17.Text = "FRUIT JUICE"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button16.FlatAppearance.BorderSize = 0
        Me.Button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.ForeColor = System.Drawing.Color.White
        Me.Button16.Location = New System.Drawing.Point(310, 480)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(160, 70)
        Me.Button16.TabIndex = 136
        Me.Button16.Text = "COOLERS"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button15.FlatAppearance.BorderSize = 0
        Me.Button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.ForeColor = System.Drawing.Color.White
        Me.Button15.Location = New System.Drawing.Point(140, 480)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(160, 70)
        Me.Button15.TabIndex = 135
        Me.Button15.Text = "MOCKTAILS"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.White
        Me.Button14.Location = New System.Drawing.Point(480, 400)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(160, 70)
        Me.Button14.TabIndex = 134
        Me.Button14.Text = "FRAPPES"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button13.FlatAppearance.BorderSize = 0
        Me.Button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.White
        Me.Button13.Location = New System.Drawing.Point(310, 400)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(160, 70)
        Me.Button13.TabIndex = 133
        Me.Button13.Text = "SMOOTHIES FREZZOS"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.White
        Me.Button12.Location = New System.Drawing.Point(140, 400)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(160, 70)
        Me.Button12.TabIndex = 132
        Me.Button12.Text = "MILKSHAKES"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.White
        Me.Button11.Location = New System.Drawing.Point(310, 320)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(160, 70)
        Me.Button11.TabIndex = 131
        Me.Button11.Text = "HOT BEVERAGES"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Location = New System.Drawing.Point(480, 320)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(160, 70)
        Me.Button10.TabIndex = 130
        Me.Button10.Text = "SALADS"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(140, 320)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(160, 70)
        Me.Button9.TabIndex = 129
        Me.Button9.Text = "EXTRAS"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(480, 240)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(160, 70)
        Me.Button8.TabIndex = 128
        Me.Button8.Text = "CAKES"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(310, 240)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(160, 70)
        Me.Button7.TabIndex = 127
        Me.Button7.Text = "SANDWICHES"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(140, 240)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(160, 70)
        Me.Button6.TabIndex = 126
        Me.Button6.Text = "BREAKFASTS"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(450, 160)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(180, 70)
        Me.Button5.TabIndex = 125
        Me.Button5.Text = "STEAK BOSS"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(140, 160)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 70)
        Me.Button4.TabIndex = 124
        Me.Button4.Text = "CHICKEN BOSS"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'cmbCategory
        '
        Me.cmbCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Items.AddRange(New Object() {"Chicken", "Steak", "Breakfasts", "Sandwiches", "Cakes", "Extras", "Hot Beverages", "Salads", "Milkshakes", "Smoothies & Frezzos", "Frappes", "Mocktails", "Coolers", "Fruit Juice", "Fish"})
        Me.cmbCategory.Location = New System.Drawing.Point(152, 184)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(434, 28)
        Me.cmbCategory.TabIndex = 109
        Me.cmbCategory.Text = "Select Category"
        Me.cmbCategory.Visible = False
        '
        'rtfReceipt
        '
        Me.rtfReceipt.BackColor = System.Drawing.Color.White
        Me.rtfReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfReceipt.Enabled = False
        Me.rtfReceipt.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfReceipt.Location = New System.Drawing.Point(650, 150)
        Me.rtfReceipt.Name = "rtfReceipt"
        Me.rtfReceipt.Size = New System.Drawing.Size(360, 450)
        Me.rtfReceipt.TabIndex = 119
        Me.rtfReceipt.Text = "BOSS CAFE" & Global.Microsoft.VisualBasic.ChrW(10) & "60 BEDFORD ROAD" & Global.Microsoft.VisualBasic.ChrW(10) & "AVONDALE" & Global.Microsoft.VisualBasic.ChrW(10) & "HARARE" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Tel: 0773277464" & Global.Microsoft.VisualBasic.ChrW(10) & "VAT NO: ---------" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "---" & _
    "---------------------------" & _
    "----------------------------"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(890, 105)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(120, 35)
        Me.btnReset.TabIndex = 117
        Me.btnReset.Text = "Reset Receipt"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtDZTotal)
        Me.Panel2.Controls.Add(Me.txtDtotal)
        Me.Panel2.Controls.Add(Me.Button24)
        Me.Panel2.Controls.Add(Me.Button25)
        Me.Panel2.Controls.Add(Me.Button26)
        Me.Panel2.Controls.Add(Me.Button27)
        Me.Panel2.Controls.Add(Me.Button28)
        Me.Panel2.Controls.Add(Me.btnLog)
        Me.Panel2.Location = New System.Drawing.Point(0, 610)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 110)
        Me.Panel2.TabIndex = 113
        '
        'txtDZTotal
        '
        Me.txtDZTotal.Location = New System.Drawing.Point(533, 37)
        Me.txtDZTotal.Name = "txtDZTotal"
        Me.txtDZTotal.ReadOnly = True
        Me.txtDZTotal.Size = New System.Drawing.Size(107, 20)
        Me.txtDZTotal.TabIndex = 37
        Me.txtDZTotal.Text = "0"
        Me.txtDZTotal.Visible = False
        '
        'txtDtotal
        '
        Me.txtDtotal.Location = New System.Drawing.Point(667, 37)
        Me.txtDtotal.Name = "txtDtotal"
        Me.txtDtotal.ReadOnly = True
        Me.txtDtotal.Size = New System.Drawing.Size(107, 20)
        Me.txtDtotal.TabIndex = 36
        Me.txtDtotal.Text = "0"
        Me.txtDtotal.Visible = False
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.Button24.FlatAppearance.BorderSize = 0
        Me.Button24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button24.ForeColor = System.Drawing.Color.White
        Me.Button24.Location = New System.Drawing.Point(20, 30)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(100, 50)
        Me.Button24.TabIndex = 30
        Me.Button24.Text = "New"
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Button25.FlatAppearance.BorderSize = 0
        Me.Button25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button25.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.ForeColor = System.Drawing.Color.White
        Me.Button25.Location = New System.Drawing.Point(130, 30)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(100, 50)
        Me.Button25.TabIndex = 31
        Me.Button25.Text = "Sales Person"
        Me.Button25.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button26.FlatAppearance.BorderSize = 0
        Me.Button26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button26.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.ForeColor = System.Drawing.Color.White
        Me.Button26.Location = New System.Drawing.Point(240, 30)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(100, 50)
        Me.Button26.TabIndex = 32
        Me.Button26.Text = "Z-Report"
        Me.Button26.UseVisualStyleBackColor = False
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button27.FlatAppearance.BorderSize = 0
        Me.Button27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button27.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.ForeColor = System.Drawing.Color.White
        Me.Button27.Location = New System.Drawing.Point(350, 30)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(100, 50)
        Me.Button27.TabIndex = 33
        Me.Button27.Text = "X-Report"
        Me.Button27.UseVisualStyleBackColor = False
        '
        'Button28
        '
        Me.Button28.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Button28.FlatAppearance.BorderSize = 0
        Me.Button28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button28.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button28.ForeColor = System.Drawing.Color.White
        Me.Button28.Location = New System.Drawing.Point(460, 30)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(120, 50)
        Me.Button28.TabIndex = 34
        Me.Button28.Text = "Reprint Receipt"
        Me.Button28.UseVisualStyleBackColor = False
        '
        'btnLog
        '
        Me.btnLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnLog.FlatAppearance.BorderSize = 0
        Me.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLog.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLog.ForeColor = System.Drawing.Color.White
        Me.btnLog.Location = New System.Drawing.Point(850, 30)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(120, 50)
        Me.btnLog.TabIndex = 35
        Me.btnLog.Text = "Log Off"
        Me.btnLog.UseVisualStyleBackColor = False
        '
        'swipe
        '
        Me.swipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.swipe.FlatAppearance.BorderSize = 0
        Me.swipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.swipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.swipe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swipe.ForeColor = System.Drawing.Color.White
        Me.swipe.Location = New System.Drawing.Point(20, 270)
        Me.swipe.Name = "swipe"
        Me.swipe.Size = New System.Drawing.Size(100, 50)
        Me.swipe.TabIndex = 112
        Me.swipe.Text = "SWIPE"
        Me.swipe.UseVisualStyleBackColor = False
        '
        'zwd
        '
        Me.zwd.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.zwd.FlatAppearance.BorderSize = 0
        Me.zwd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.zwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.zwd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zwd.ForeColor = System.Drawing.Color.White
        Me.zwd.Location = New System.Drawing.Point(20, 210)
        Me.zwd.Name = "zwd"
        Me.zwd.Size = New System.Drawing.Size(100, 50)
        Me.zwd.TabIndex = 111
        Me.zwd.Text = "ZWD"
        Me.zwd.UseVisualStyleBackColor = False
        '
        'usd
        '
        Me.usd.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.usd.FlatAppearance.BorderSize = 0
        Me.usd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.usd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.usd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usd.ForeColor = System.Drawing.Color.White
        Me.usd.Location = New System.Drawing.Point(20, 150)
        Me.usd.Name = "usd"
        Me.usd.Size = New System.Drawing.Size(100, 50)
        Me.usd.TabIndex = 110
        Me.usd.Text = "USD"
        Me.usd.UseVisualStyleBackColor = False
        '
        'rtfReceiptB
        '
        Me.rtfReceiptB.Location = New System.Drawing.Point(315, 349)
        Me.rtfReceiptB.Name = "rtfReceiptB"
        Me.rtfReceiptB.Size = New System.Drawing.Size(301, 324)
        Me.rtfReceiptB.TabIndex = 122
        Me.rtfReceiptB.Text = "BEVERAGES"
        Me.rtfReceiptB.Visible = False
        '
        'rtfReceiptC
        '
        Me.rtfReceiptC.Location = New System.Drawing.Point(9, 349)
        Me.rtfReceiptC.Name = "rtfReceiptC"
        Me.rtfReceiptC.Size = New System.Drawing.Size(308, 324)
        Me.rtfReceiptC.TabIndex = 123
        Me.rtfReceiptC.Text = "KITCHEN"
        Me.rtfReceiptC.Visible = False
        '
        'ProductsBindingNavigator
        '
        Me.ProductsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ProductsBindingNavigator.BindingSource = Me.ProductsBindingSource
        Me.ProductsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ProductsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ProductsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ProductsBindingNavigatorSaveItem})
        Me.ProductsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ProductsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ProductsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ProductsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ProductsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ProductsBindingNavigator.Name = "ProductsBindingNavigator"
        Me.ProductsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ProductsBindingNavigator.Size = New System.Drawing.Size(1021, 25)
        Me.ProductsBindingNavigator.TabIndex = 139
        Me.ProductsBindingNavigator.Text = "BindingNavigator1"
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
        'ProductsBindingSource
        '
        Me.ProductsBindingSource.DataMember = "Products"
        Me.ProductsBindingSource.DataSource = Me.BossDataSet
        '
        'BossDataSet
        '
        Me.BossDataSet.DataSetName = "BossDataSet"
        Me.BossDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'ProductsBindingNavigatorSaveItem
        '
        Me.ProductsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProductsBindingNavigatorSaveItem.Image = CType(resources.GetObject("ProductsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ProductsBindingNavigatorSaveItem.Name = "ProductsBindingNavigatorSaveItem"
        Me.ProductsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProductsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ProductsDataGridView
        '
        Me.ProductsDataGridView.AllowUserToAddRows = False
        Me.ProductsDataGridView.AllowUserToDeleteRows = False
        Me.ProductsDataGridView.AllowUserToResizeColumns = False
        Me.ProductsDataGridView.AllowUserToResizeRows = False
        Me.ProductsDataGridView.AutoGenerateColumns = False
        Me.ProductsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.ProductsDataGridView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ProductsDataGridView.DataSource = Me.ProductsBindingSource
        Me.ProductsDataGridView.GridColor = System.Drawing.Color.White
        Me.ProductsDataGridView.Location = New System.Drawing.Point(9, 137)
        Me.ProductsDataGridView.Name = "ProductsDataGridView"
        Me.ProductsDataGridView.ReadOnly = True
        Me.ProductsDataGridView.ShowCellErrors = False
        Me.ProductsDataGridView.ShowEditingIcon = False
        Me.ProductsDataGridView.Size = New System.Drawing.Size(618, 438)
        Me.ProductsDataGridView.TabIndex = 139
        Me.ProductsDataGridView.Visible = False
        '
        'pnlProductCards
        '
        Me.pnlProductCards.AutoScroll = True
        Me.pnlProductCards.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlProductCards.Location = New System.Drawing.Point(9, 137)
        Me.pnlProductCards.Name = "pnlProductCards"
        Me.pnlProductCards.Size = New System.Drawing.Size(618, 438)
        Me.pnlProductCards.TabIndex = 159
        Me.pnlProductCards.Visible = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(140, 590)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(120, 32)
        Me.txtQuantity.TabIndex = 160
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQuantity.Visible = False
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblQuantity.Location = New System.Drawing.Point(20, 595)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(75, 21)
        Me.lblQuantity.TabIndex = 161
        Me.lblQuantity.Text = "Quantity:"
        Me.lblQuantity.Visible = False
        '
        'btnAddToReceipt
        '
        Me.btnAddToReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnAddToReceipt.FlatAppearance.BorderSize = 0
        Me.btnAddToReceipt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAddToReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddToReceipt.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToReceipt.ForeColor = System.Drawing.Color.White
        Me.btnAddToReceipt.Location = New System.Drawing.Point(260, 585)
        Me.btnAddToReceipt.Name = "btnAddToReceipt"
        Me.btnAddToReceipt.Size = New System.Drawing.Size(120, 40)
        Me.btnAddToReceipt.TabIndex = 162
        Me.btnAddToReceipt.Text = "Add to Receipt"
        Me.btnAddToReceipt.UseVisualStyleBackColor = False
        Me.btnAddToReceipt.Visible = False
        '
        'lblSelectedProduct
        '
        Me.lblSelectedProduct.AutoSize = True
        Me.lblSelectedProduct.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedProduct.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblSelectedProduct.Location = New System.Drawing.Point(400, 595)
        Me.lblSelectedProduct.Name = "lblSelectedProduct"
        Me.lblSelectedProduct.Size = New System.Drawing.Size(0, 20)
        Me.lblSelectedProduct.TabIndex = 163
        Me.lblSelectedProduct.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 230
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Category"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Category"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 130
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ZWL"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ZWL"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "USD"
        Me.DataGridViewTextBoxColumn5.HeaderText = "USD"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'PrintDocument1
        '
        '
        'PrintDocument2
        '
        '
        'PrintDocument3
        '
        '
        'Timer2
        '
        '
        'TotalsListBox
        '
        Me.TotalsListBox.DataSource = Me.TotalsBindingSource
        Me.TotalsListBox.DisplayMember = "Total"
        Me.TotalsListBox.FormattingEnabled = True
        Me.TotalsListBox.Location = New System.Drawing.Point(653, 203)
        Me.TotalsListBox.Name = "TotalsListBox"
        Me.TotalsListBox.Size = New System.Drawing.Size(10, 4)
        Me.TotalsListBox.TabIndex = 139
        Me.TotalsListBox.ValueMember = "Receipt"
        Me.TotalsListBox.Visible = False
        '
        'TotalsBindingSource
        '
        Me.TotalsBindingSource.DataMember = "Totals"
        Me.TotalsBindingSource.DataSource = Me.BossDataSet
        '
        'CodeTextBox
        '
        Me.CodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Code", True))
        Me.CodeTextBox.Location = New System.Drawing.Point(815, 274)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeTextBox.TabIndex = 140
        '
        'SalesBindingSource
        '
        Me.SalesBindingSource.DataMember = "Sales"
        Me.SalesBindingSource.DataSource = Me.BossDataSet
        '
        'QuantityTextBox
        '
        Me.QuantityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Quantity", True))
        Me.QuantityTextBox.Location = New System.Drawing.Point(815, 300)
        Me.QuantityTextBox.Name = "QuantityTextBox"
        Me.QuantityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.QuantityTextBox.TabIndex = 142
        '
        'ReceiptTextBox
        '
        Me.ReceiptTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Receipt", True))
        Me.ReceiptTextBox.Location = New System.Drawing.Point(815, 326)
        Me.ReceiptTextBox.Name = "ReceiptTextBox"
        Me.ReceiptTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ReceiptTextBox.TabIndex = 144
        '
        'PriceTextBox
        '
        Me.PriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Price", True))
        Me.PriceTextBox.Location = New System.Drawing.Point(815, 352)
        Me.PriceTextBox.Name = "PriceTextBox"
        Me.PriceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PriceTextBox.TabIndex = 146
        '
        'TotalTextBox
        '
        Me.TotalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Total", True))
        Me.TotalTextBox.Location = New System.Drawing.Point(815, 378)
        Me.TotalTextBox.Name = "TotalTextBox"
        Me.TotalTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TotalTextBox.TabIndex = 148
        '
        'DateTextBox
        '
        Me.DateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Date", True))
        Me.DateTextBox.Location = New System.Drawing.Point(815, 404)
        Me.DateTextBox.Name = "DateTextBox"
        Me.DateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DateTextBox.TabIndex = 150
        '
        'WaiterTextBox
        '
        Me.WaiterTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Waiter", True))
        Me.WaiterTextBox.Location = New System.Drawing.Point(815, 430)
        Me.WaiterTextBox.Name = "WaiterTextBox"
        Me.WaiterTextBox.Size = New System.Drawing.Size(100, 20)
        Me.WaiterTextBox.TabIndex = 152
        '
        'OrderTextBox
        '
        Me.OrderTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Order", True))
        Me.OrderTextBox.Location = New System.Drawing.Point(815, 456)
        Me.OrderTextBox.Name = "OrderTextBox"
        Me.OrderTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderTextBox.TabIndex = 154
        '
        'CurrencyTextBox
        '
        Me.CurrencyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SalesBindingSource, "Currency", True))
        Me.CurrencyTextBox.Location = New System.Drawing.Point(815, 482)
        Me.CurrencyTextBox.Name = "CurrencyTextBox"
        Me.CurrencyTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrencyTextBox.TabIndex = 156
        '
        'DTotalsListBox
        '
        Me.DTotalsListBox.DataSource = Me.DTotalsBindingSource
        Me.DTotalsListBox.DisplayMember = "TDate"
        Me.DTotalsListBox.FormattingEnabled = True
        Me.DTotalsListBox.Location = New System.Drawing.Point(653, 218)
        Me.DTotalsListBox.Name = "DTotalsListBox"
        Me.DTotalsListBox.Size = New System.Drawing.Size(10, 4)
        Me.DTotalsListBox.TabIndex = 156
        Me.DTotalsListBox.ValueMember = "TDate"
        Me.DTotalsListBox.Visible = False
        '
        'DTotalsBindingSource
        '
        Me.DTotalsBindingSource.DataMember = "DTotals"
        Me.DTotalsBindingSource.DataSource = Me.BossDataSet
        '
        'ProductsTableAdapter
        '
        Me.ProductsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DTotalsTableAdapter = Nothing
        Me.TableAdapterManager.ProductsTableAdapter = Me.ProductsTableAdapter
        Me.TableAdapterManager.SalesTableAdapter = Nothing
        Me.TableAdapterManager.TotalsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = BOSS_CAFE.BossDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsersTableAdapter = Nothing
        Me.TableAdapterManager.WaitersTableAdapter = Nothing
        '
        'TotalsTableAdapter
        '
        Me.TotalsTableAdapter.ClearBeforeFill = True
        '
        'SalesTableAdapter
        '
        Me.SalesTableAdapter.ClearBeforeFill = True
        '
        'DTotalsTableAdapter
        '
        Me.DTotalsTableAdapter.ClearBeforeFill = True
        '
        'Timer3
        '
        '
        'fish
        '
        Me.fish.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.fish.FlatAppearance.BorderSize = 0
        Me.fish.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.fish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fish.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fish.ForeColor = System.Drawing.Color.White
        Me.fish.Location = New System.Drawing.Point(310, 160)
        Me.fish.Name = "fish"
        Me.fish.Size = New System.Drawing.Size(160, 70)
        Me.fish.TabIndex = 157
        Me.fish.Text = "FISH"
        Me.fish.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(550, 560)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 35)
        Me.btnClose.TabIndex = 158
        Me.btnClose.Text = "Back"
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.Visible = False
        '
        'remove
        '
        Me.remove.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.remove.FlatAppearance.BorderSize = 0
        Me.remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.remove.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remove.ForeColor = System.Drawing.Color.White
        Me.remove.Location = New System.Drawing.Point(890, 105)
        Me.remove.Name = "remove"
        Me.remove.Size = New System.Drawing.Size(120, 35)
        Me.remove.TabIndex = 118
        Me.remove.Text = "Remove Item"
        Me.remove.UseVisualStyleBackColor = False
        Me.remove.Visible = False
        '
        'Entries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 720)
        Me.Controls.Add(Me.lblSelectedProduct)
        Me.Controls.Add(Me.btnAddToReceipt)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.pnlProductCards)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.fish)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.rtfReceipt)
        Me.Controls.Add(Me.DTotalsListBox)
        Me.Controls.Add(Me.TotalsListBox)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.swipe)
        Me.Controls.Add(Me.zwd)
        Me.Controls.Add(Me.usd)
        Me.Controls.Add(Me.rtfReceiptB)
        Me.Controls.Add(Me.rtfReceiptC)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(CodeLabel)
        Me.Controls.Add(Me.CodeTextBox)
        Me.Controls.Add(QuantityLabel)
        Me.Controls.Add(Me.QuantityTextBox)
        Me.Controls.Add(ReceiptLabel)
        Me.Controls.Add(Me.ReceiptTextBox)
        Me.Controls.Add(PriceLabel)
        Me.Controls.Add(Me.PriceTextBox)
        Me.Controls.Add(TotalLabel)
        Me.Controls.Add(Me.TotalTextBox)
        Me.Controls.Add(DateLabel)
        Me.Controls.Add(Me.DateTextBox)
        Me.Controls.Add(WaiterLabel)
        Me.Controls.Add(Me.WaiterTextBox)
        Me.Controls.Add(OrderLabel)
        Me.Controls.Add(Me.OrderTextBox)
        Me.Controls.Add(CurrencyLabel)
        Me.Controls.Add(Me.CurrencyTextBox)
        Me.Controls.Add(Me.ProductsBindingNavigator)
        Me.Controls.Add(Me.ProductsDataGridView)
        Me.Controls.Add(Me.remove)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Entries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Boss Cafe | Bill Creator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ProductsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductsBindingNavigator.ResumeLayout(False)
        Me.ProductsBindingNavigator.PerformLayout()
        CType(Me.ProductsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BossDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmborder As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbwaiter As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblZTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents payment As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents rtfReceipt As System.Windows.Forms.RichTextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtDZTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDtotal As System.Windows.Forms.TextBox
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents btnLog As System.Windows.Forms.Button
    Friend WithEvents swipe As System.Windows.Forms.Button
    Friend WithEvents zwd As System.Windows.Forms.Button
    Friend WithEvents usd As System.Windows.Forms.Button
    Friend WithEvents rtfReceiptB As System.Windows.Forms.RichTextBox
    Friend WithEvents rtfReceiptC As System.Windows.Forms.RichTextBox
    Friend WithEvents BossDataSet As BOSS_CAFE.BossDataSet
    Friend WithEvents ProductsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProductsTableAdapter As BOSS_CAFE.BossDataSetTableAdapters.ProductsTableAdapter
    Friend WithEvents TableAdapterManager As BOSS_CAFE.BossDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProductsBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents ProductsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProductsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocument3 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents TotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TotalsTableAdapter As BOSS_CAFE.BossDataSetTableAdapters.TotalsTableAdapter
    Friend WithEvents TotalsListBox As System.Windows.Forms.ListBox
    Friend WithEvents SalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesTableAdapter As BOSS_CAFE.BossDataSetTableAdapters.SalesTableAdapter
    Friend WithEvents CodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuantityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReceiptTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TotalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WaiterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DTotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DTotalsTableAdapter As BOSS_CAFE.BossDataSetTableAdapters.DTotalsTableAdapter
    Friend WithEvents DTotalsListBox As System.Windows.Forms.ListBox
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents fish As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents quantitybx As System.Windows.Forms.TextBox
    Friend WithEvents remove As System.Windows.Forms.Button
    Friend WithEvents pnlProductCards As System.Windows.Forms.Panel
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents btnAddToReceipt As System.Windows.Forms.Button
    Friend WithEvents lblSelectedProduct As System.Windows.Forms.Label
End Class
