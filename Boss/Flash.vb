Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class Flash
    Private splashTimer As Timer
    Private loadingTimer As Timer
    Private loadingDots As Integer = 0
    Private fadeInTimer As Timer
    Private fadeOpacity As Double = 0.0

    Private Sub Flash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(15, 15, 15) ' Darker background
        Me.Size = New Size(800, 500) ' Larger size for better proportions
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        
        ' Center the form on screen
        Me.CenterToScreen()
        
        ' Set up splash screen content
        SetupSplashContent()
        
        ' Start fade-in animation
        StartFadeIn()
        
        ' Start timer to show splash for 4 seconds
        splashTimer = New Timer()
        AddHandler splashTimer.Tick, AddressOf SplashTimer_Tick
        splashTimer.Interval = 4000 ' 4 seconds
        splashTimer.Enabled = True
        
        ' Start loading animation
        StartLoadingAnimation()
    End Sub

    Private Sub SetupSplashContent()
        ' Create main container panel with gradient background
        Dim mainPanel As New Panel()
        mainPanel.Dock = DockStyle.Fill
        mainPanel.BackColor = Color.Transparent
        Me.Controls.Add(mainPanel)
        
        ' Create logo container panel
        Dim logoPanel As New Panel()
        logoPanel.Size = New Size(250, 250)
        logoPanel.Location = New Point(50, 125)
        logoPanel.BackColor = Color.Transparent
        mainPanel.Controls.Add(logoPanel)
        
        ' Create circular logo background
        Dim logoBackground As New Panel()
        logoBackground.Size = New Size(200, 200)
        logoBackground.Location = New Point(25, 25)
        logoBackground.BackColor = Color.FromArgb(30, 30, 30)
        AddHandler logoBackground.Paint, AddressOf LogoBackground_Paint
        logoPanel.Controls.Add(logoBackground)

        ' Create and configure logo picture box
        Dim logoPictureBox As New PictureBox()
        Try
            logoPictureBox.Image = My.Resources._281143259_1043322533288007_5617556930608310033_n
        Catch
            ' If resource loading fails, create a text-based logo
            AddHandler logoPictureBox.Paint, AddressOf LogoPictureBox_Paint
        End Try
        logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        logoPictureBox.Location = New Point(10, 10)
        logoPictureBox.Size = New Size(180, 180)
        logoPictureBox.BackColor = Color.Transparent
        logoBackground.Controls.Add(logoPictureBox)

        ' Create right side content panel
        Dim contentPanel As New Panel()
        contentPanel.Size = New Size(450, 350)
        contentPanel.Location = New Point(320, 75)
        contentPanel.BackColor = Color.Transparent
        mainPanel.Controls.Add(contentPanel)

        ' Create title label with modern styling
        Dim titleLabel As New Label()
        titleLabel.Text = "BOSS CAFE"
        titleLabel.Font = New Font("Segoe UI", 42, FontStyle.Bold)
        titleLabel.ForeColor = Color.White
        titleLabel.BackColor = Color.Transparent
        titleLabel.AutoSize = True
        titleLabel.Location = New Point(0, 20)
        AddHandler titleLabel.Paint, AddressOf TitleLabel_Paint
        contentPanel.Controls.Add(titleLabel)

        ' Create subtitle label
        Dim subtitleLabel As New Label()
        subtitleLabel.Text = "Point of Sale System"
        subtitleLabel.Font = New Font("Segoe UI", 20, FontStyle.Regular)
        subtitleLabel.ForeColor = Color.FromArgb(200, 200, 200)
        subtitleLabel.BackColor = Color.Transparent
        subtitleLabel.AutoSize = True
        subtitleLabel.Location = New Point(0, 80)
        contentPanel.Controls.Add(subtitleLabel)

        ' Create version label with modern styling
        Dim versionLabel As New Label()
        versionLabel.Text = "Version 1.0.0.2"
        versionLabel.Font = New Font("Segoe UI", 14, FontStyle.Regular)
        versionLabel.ForeColor = Color.FromArgb(150, 150, 150)
        versionLabel.BackColor = Color.Transparent
        versionLabel.AutoSize = True
        versionLabel.Location = New Point(0, 120)
        contentPanel.Controls.Add(versionLabel)

        ' Create loading container
        Dim loadingContainer As New Panel()
        loadingContainer.Size = New Size(300, 50)
        loadingContainer.Location = New Point(0, 180)
        loadingContainer.BackColor = Color.Transparent
        contentPanel.Controls.Add(loadingContainer)

        ' Create loading label with animation
        Dim loadingLabel As New Label()
        loadingLabel.Name = "LoadingLabel"
        loadingLabel.Text = "Loading"
        loadingLabel.Font = New Font("Segoe UI", 16, FontStyle.Regular)
        loadingLabel.ForeColor = Color.FromArgb(0, 255, 100)
        loadingLabel.BackColor = Color.Transparent
        loadingLabel.AutoSize = True
        loadingLabel.Location = New Point(0, 15)
        loadingContainer.Controls.Add(loadingLabel)

        ' Create progress bar
        Dim progressBar As New ProgressBar()
        progressBar.Size = New Size(280, 8)
        progressBar.Location = New Point(0, 35)
        progressBar.Style = ProgressBarStyle.Marquee
        progressBar.MarqueeAnimationSpeed = 30
        progressBar.BackColor = Color.FromArgb(40, 40, 40)
        loadingContainer.Controls.Add(progressBar)

        ' Create company label
        Dim companyLabel As New Label()
        companyLabel.Text = "© 2023 Spacetime Softwares"
        companyLabel.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        companyLabel.ForeColor = Color.FromArgb(100, 100, 100)
        companyLabel.BackColor = Color.Transparent
        companyLabel.AutoSize = True
        companyLabel.Location = New Point(0, 280)
        contentPanel.Controls.Add(companyLabel)

        ' Create decorative elements
        CreateDecorativeElements(mainPanel)
    End Sub

    Private Sub StartFadeIn()
        Me.Opacity = 0
        fadeInTimer = New Timer()
        AddHandler fadeInTimer.Tick, AddressOf FadeInTimer_Tick
        fadeInTimer.Interval = 20
        fadeInTimer.Enabled = True
    End Sub

    Private Sub FadeInTimer_Tick(sender As Object, e As EventArgs)
        fadeOpacity += 0.05
        Me.Opacity = fadeOpacity

        If fadeOpacity >= 1.0 Then
            fadeInTimer.Enabled = False
            fadeInTimer.Dispose()
        End If
    End Sub

    Private Sub StartLoadingAnimation()
        loadingTimer = New Timer()
        AddHandler loadingTimer.Tick, AddressOf LoadingTimer_Tick
        loadingTimer.Interval = 500
        loadingTimer.Enabled = True
    End Sub

    Private Sub LoadingTimer_Tick(sender As Object, e As EventArgs)
        loadingDots = (loadingDots + 1) Mod 4
        Dim loadingLabel As Label = TryCast(Me.Controls.Find("LoadingLabel", True).FirstOrDefault(), Label)
        If loadingLabel IsNot Nothing Then
            loadingLabel.Text = "Loading" & New String("."c, loadingDots)
        End If
    End Sub

    Private Sub CreateDecorativeElements(parentPanel As Panel)
        ' Create decorative circles
        For i As Integer = 0 To 2
            Dim circle As New Panel()
            circle.Size = New Size(20 + i * 10, 20 + i * 10)
            circle.Location = New Point(50 + i * 100, 50 + i * 30)
            circle.BackColor = Color.Transparent
            AddHandler circle.Paint, AddressOf DecorativeCircle_Paint
            parentPanel.Controls.Add(circle)
        Next
    End Sub

    Private Sub LogoBackground_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As New Rectangle(0, 0, panel.Width - 1, panel.Height - 1)
        
        ' Create gradient brush
        Using brush As New LinearGradientBrush(rect, Color.FromArgb(50, 50, 50), Color.FromArgb(20, 20, 20), 45.0F)
            e.Graphics.FillEllipse(brush, rect)
        End Using
        
        ' Draw border
        Using pen As New Pen(Color.FromArgb(100, 100, 100), 2)
            e.Graphics.DrawEllipse(pen, rect)
        End Using
    End Sub

    Private Sub LogoPictureBox_Paint(sender As Object, e As PaintEventArgs)
        Dim pictureBox As PictureBox = DirectCast(sender, PictureBox)
        Dim rect As New Rectangle(0, 0, pictureBox.Width - 1, pictureBox.Height - 1)
        
        ' Draw "BOSS CAFE" text as fallback logo
        Using font As New Font("Segoe UI", 16, FontStyle.Bold)
            Using brush As New SolidBrush(Color.FromArgb(255, 215, 0)) ' Gold color
                Dim text As String = "BOSS CAFE"
                Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
                Dim x As Single = (pictureBox.Width - textSize.Width) / 2
                Dim y As Single = (pictureBox.Height - textSize.Height) / 2
                e.Graphics.DrawString(text, font, brush, x, y)
            End Using
        End Using
    End Sub

    Private Sub TitleLabel_Paint(sender As Object, e As PaintEventArgs)
        Dim label As Label = DirectCast(sender, Label)
        
        ' Draw text with shadow effect
        Using shadowFont As New Font("Segoe UI", 42, FontStyle.Bold)
            Using shadowBrush As New SolidBrush(Color.FromArgb(50, 50, 50))
                e.Graphics.DrawString(label.Text, shadowFont, shadowBrush, 2, 2)
            End Using
        End Using
        
        ' Draw main text
        Using mainFont As New Font("Segoe UI", 42, FontStyle.Bold)
            Using mainBrush As New SolidBrush(Color.White)
                e.Graphics.DrawString(label.Text, mainFont, mainBrush, 0, 0)
            End Using
        End Using
    End Sub

    Private Sub DecorativeCircle_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As New Rectangle(0, 0, panel.Width - 1, panel.Height - 1)
        
        ' Create gradient brush for decorative circles
        Using brush As New LinearGradientBrush(rect, Color.FromArgb(100, 100, 100, 50), Color.FromArgb(50, 50, 50, 20), 45.0F)
            e.Graphics.FillEllipse(brush, rect)
        End Using
    End Sub

    Private Sub Flash_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Create gradient background
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Using brush As New LinearGradientBrush(rect, Color.FromArgb(25, 25, 25), Color.FromArgb(10, 10, 10), 135.0F)
            e.Graphics.FillRectangle(brush, rect)
        End Using
        
        ' Add subtle pattern overlay
        Using pen As New Pen(Color.FromArgb(30, 30, 30), 1)
            For i As Integer = 0 To Me.Width Step 50
                e.Graphics.DrawLine(pen, i, 0, i, Me.Height)
            Next
            For i As Integer = 0 To Me.Height Step 50
                e.Graphics.DrawLine(pen, 0, i, Me.Width, i)
            Next
        End Using
    End Sub

    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs)
        ' Stop all timers
        If splashTimer IsNot Nothing Then
            splashTimer.Enabled = False
            splashTimer.Dispose()
        End If
        If loadingTimer IsNot Nothing Then
            loadingTimer.Enabled = False
            loadingTimer.Dispose()
        End If
        
        ' Hide splash screen and show login form
        Me.Hide()
        Dim loginForm As New Login()
        loginForm.Show()
    End Sub

    Private Sub Flash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ' Allow user to skip splash screen by pressing any key
        If splashTimer IsNot Nothing Then
            splashTimer.Enabled = False
            splashTimer.Dispose()
        End If
        If loadingTimer IsNot Nothing Then
            loadingTimer.Enabled = False
            loadingTimer.Dispose()
        End If
        Me.Hide()
        Dim loginForm As New Login()
        loginForm.Show()
    End Sub

    Private Sub Flash_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        ' Allow user to skip splash screen by clicking
        If splashTimer IsNot Nothing Then
            splashTimer.Enabled = False
            splashTimer.Dispose()
        End If
        If loadingTimer IsNot Nothing Then
            loadingTimer.Enabled = False
            loadingTimer.Dispose()
        End If
        Me.Hide()
        Dim loginForm As New Login()
        loginForm.Show()
    End Sub
End Class