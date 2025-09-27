<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class products
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(products))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BossDataSet = New BOSS_CAFE.BossDataSet()
        Me.SalesTableAdapter = New BOSS_CAFE.BossDataSetTableAdapters.SalesTableAdapter()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BossDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SalesBindingSource, "Description", True))
        Me.ListBox1.DataSource = Me.SalesBindingSource
        Me.ListBox1.DisplayMember = "Description"
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(10, 10)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(400, 480)
        Me.ListBox1.TabIndex = 0
        Me.ListBox1.ValueMember = "Quantity"
        '
        'SalesBindingSource
        '
        Me.SalesBindingSource.DataMember = "Sales"
        Me.SalesBindingSource.DataSource = Me.BossDataSet
        '
        'BossDataSet
        '
        Me.BossDataSet.DataSetName = "BossDataSet"
        Me.BossDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SalesTableAdapter
        '
        Me.SalesTableAdapter.ClearBeforeFill = True
        '
        'products
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(420, 500)
        Me.Controls.Add(Me.ListBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "products"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOSS CAFE | STOCK CONTROL SHEET"
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BossDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents BossDataSet As BOSS_CAFE.BossDataSet
    Friend WithEvents SalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesTableAdapter As BOSS_CAFE.BossDataSetTableAdapters.SalesTableAdapter
End Class
