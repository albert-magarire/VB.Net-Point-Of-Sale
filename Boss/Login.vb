Imports System.Data.OleDb

Public Class Login
    Private loginAttempts As Integer = 0
    Private Const MaxLoginAttempts As Integer = 3
    Private ReadOnly LockoutDuration As TimeSpan = TimeSpan.FromMinutes(15)
    Private lockoutEndTime As DateTime = DateTime.MinValue

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            ' Persistent lockout check is handled in BLL; keep local guard for UX
            Dim persistedLock = DataAccessLayer.GetLockoutUntil(cmbUser.Text)
            If persistedLock.HasValue AndAlso DateTime.Now < persistedLock.Value Then
                Dim remainingTime As TimeSpan = persistedLock.Value - DateTime.Now
                MessageBox.Show($"Account is locked out. Please try again in {remainingTime.Minutes} minutes and {remainingTime.Seconds} seconds.", 
                              "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate inputs
            Dim accountTypeValidation = ValidationHelper.ValidateRequired(cmbUser.Text, "Account Type")
            If Not accountTypeValidation.IsValid Then
                MessageBox.Show(accountTypeValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim passwordValidation = ValidationHelper.ValidatePassword(txtPassword.Text)
            If Not passwordValidation.IsValid Then
                MessageBox.Show(passwordValidation.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Authenticate user using business logic layer
            Dim authResult As AuthenticationResult = BusinessLogicLayer.AuthenticateUser(cmbUser.Text, txtPassword.Text)
            
            If authResult.IsSuccess Then
                ' Reset login attempts on successful login
                loginAttempts = 0
                AuditLogger.Log("login", cmbUser.Text, "login_success_ui")
                
                ' Show appropriate welcome message and navigate to correct form
                Select Case cmbUser.Text
                    Case "Cashier"
                        MessageBox.Show("Welcome, Cashier!", "Successful Login!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        LoggedIn.Show()
                    Case "Manager"
                        MessageBox.Show("Welcome, Manager!", "Successful Login!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        LoggedIn.Show()
                    Case "Supervisor"
                        MessageBox.Show("Welcome, Boss!", "Successful VIP Login!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        Supervisor.Show()
                    Case Else
                        MessageBox.Show("Welcome!", "Successful Login!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        LoggedIn.Show()
                End Select
            Else
                ' Handle failed authentication
                loginAttempts += 1
                
                ' Message already precise from BLL; just show it
                MessageBox.Show(authResult.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AuditLogger.Log("login", cmbUser.Text, "login_failure_ui")
                
                ' Clear password field for security
                txtPassword.Clear()
                txtPassword.Focus()
            End If

        Catch ex As BusinessLogicException
            MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
        txtPassword.UseSystemPasswordChar = True
        cmbUser.DropDownStyle = ComboBoxStyle.DropDownList
        
        ' Add account types to combo box
        cmbUser.Items.Add("Cashier")
        cmbUser.Items.Add("Manager")
        cmbUser.Items.Add("Supervisor")
        
        ' Check if database needs setup
        If Not DatabaseSetup.CheckUsersTable() Then
            btnSetup.Visible = True
            btnSetup.Text = "Setup Database First"
            MessageBox.Show("Database setup required. Please click 'Setup Database First' to initialize the Users table.", 
                          "Database Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            btnSetup.Visible = False
        End If
        
        ' Set focus to account type
        cmbUser.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        ' Allow Enter key to trigger login
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            OK_Click(sender, e)
        End If
    End Sub

    Private Sub cmbUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbUser.KeyPress
        ' Allow Enter key to move to password field
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPassword.Focus()
        End If
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        Try
            DatabaseSetup.SetupUsersTable()
            btnSetup.Visible = False
            MessageBox.Show("Database setup completed! You can now log in with password '1207' for any account type.", 
                          "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error setting up database: {ex.Message}", "Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
