<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports))
        Me.btnLog = New System.Windows.Forms.Button()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnEOD = New System.Windows.Forms.Button()
        Me.btnProducts = New System.Windows.Forms.Button()
        Me.btnInvoice = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLog
        '
        Me.btnLog.Location = New System.Drawing.Point(328, 79)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(75, 23)
        Me.btnLog.TabIndex = 9
        Me.btnLog.Text = "Log Out"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(227, 79)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(95, 23)
        Me.btnMenu.TabIndex = 8
        Me.btnMenu.Text = "Back to Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'btnEOD
        '
        Me.btnEOD.Location = New System.Drawing.Point(285, 36)
        Me.btnEOD.Name = "btnEOD"
        Me.btnEOD.Size = New System.Drawing.Size(118, 23)
        Me.btnEOD.TabIndex = 7
        Me.btnEOD.Text = "End Of Day Cash Up"
        Me.btnEOD.UseVisualStyleBackColor = True
        '
        'btnProducts
        '
        Me.btnProducts.Location = New System.Drawing.Point(150, 36)
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(117, 23)
        Me.btnProducts.TabIndex = 6
        Me.btnProducts.Text = "Sales By Product"
        Me.btnProducts.UseVisualStyleBackColor = True
        '
        'btnInvoice
        '
        Me.btnInvoice.Location = New System.Drawing.Point(35, 36)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(109, 23)
        Me.btnInvoice.TabIndex = 5
        Me.btnInvoice.Text = "Sales By Invoice"
        Me.btnInvoice.UseVisualStyleBackColor = True
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(437, 135)
        Me.Controls.Add(Me.btnLog)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnEOD)
        Me.Controls.Add(Me.btnProducts)
        Me.Controls.Add(Me.btnInvoice)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Reports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Boss Cafe | Reports Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLog As System.Windows.Forms.Button
    Friend WithEvents btnMenu As System.Windows.Forms.Button
    Friend WithEvents btnEOD As System.Windows.Forms.Button
    Friend WithEvents btnProducts As System.Windows.Forms.Button
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
End Class
