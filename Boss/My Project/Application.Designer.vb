<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyApplication
    Inherits Global.Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase

    <Global.System.Diagnostics.DebuggerStepThrough()>
    Public Sub New()
        MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
        Me.IsSingleInstance = False
        Me.EnableVisualStyles = True
        Me.SaveMySettingsOnExit = True
        Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
    End Sub

    <Global.System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub OnCreateMainForm()
        Try
            Me.MainForm = New Global.BOSS_CAFE.Login()
        Catch ex As Exception
            ' Fallback to a simple form if Login fails
            Me.MainForm = New System.Windows.Forms.Form()
            Me.MainForm.Text = "Boss Cafe POS"
        End Try
    End Sub

    <Global.System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub OnCreateSplashScreen()
        Try
            Me.SplashScreen = New Global.BOSS_CAFE.Flash()
        Catch ex As Exception
            ' No splash screen if Flash fails
            Me.SplashScreen = Nothing
        End Try
    End Sub
End Class
