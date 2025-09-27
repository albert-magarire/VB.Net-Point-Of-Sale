<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoggedIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoggedIn))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSupervisor = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(150, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(300, 60)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "You need to login as Supervisor " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to update the date after running " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the End Of D" & _
    "ay Report"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(60, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Is this date correct?"
        '
        'btnSupervisor
        '
        Me.btnSupervisor.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnSupervisor.FlatAppearance.BorderSize = 0
        Me.btnSupervisor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSupervisor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupervisor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupervisor.ForeColor = System.Drawing.Color.White
        Me.btnSupervisor.Location = New System.Drawing.Point(80, 150)
        Me.btnSupervisor.Name = "btnSupervisor"
        Me.btnSupervisor.Size = New System.Drawing.Size(200, 70)
        Me.btnSupervisor.TabIndex = 12
        Me.btnSupervisor.Text = "Run EOD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(You need to login as Supervisor)"
        Me.btnSupervisor.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(300, 150)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(150, 70)
        Me.btnNext.TabIndex = 11
        Me.btnNext.Text = "CONTINUE"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(250, 40)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(250, 29)
        Me.DateTimePicker1.TabIndex = 10
        '
        'LoggedIn
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(550, 250)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSupervisor)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoggedIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome | Boss Cafe POS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSupervisor As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class
