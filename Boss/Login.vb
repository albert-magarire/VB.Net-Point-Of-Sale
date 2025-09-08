Imports System.Data.OleDb

Public Class Login
    Private loginAttempts As Integer = 0
    Private Const MaxLoginAttempts As Integer = 3
    Private Const LockoutDuration As TimeSpan = TimeSpan.FromMinutes(15)
    Private lockoutEndTime As DateTime = DateTime.MinValue

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            ' Check if account is locked out
            If DateTime.Now < lockoutEndTime Then
                Dim remainingTime As TimeSpan = lockoutEndTime - DateTime.Now
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
                
                ' Show appropriate welcome message and navigate to correct form
                Select Case cmbUser.Text.ToLower()
                    Case "cashier"
                        MessageBox.Show("Welcome, Cashier!", "Successful Login!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        LoggedIn.Show()
                    Case "manager"
                        MessageBox.Show("Welcome, Manager!", "Successful Login!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        LoggedIn.Show()
                    Case "supervisor"
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
                
                If loginAttempts >= MaxLoginAttempts Then
                    lockoutEndTime = DateTime.Now.Add(LockoutDuration)
                    MessageBox.Show($"Too many failed login attempts. Account locked for {LockoutDuration.Minutes} minutes.", 
                                  "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim remainingAttempts As Integer = MaxLoginAttempts - loginAttempts
                    MessageBox.Show($"Invalid login credentials. {remainingAttempts} attempts remaining.", 
                                  "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                
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
End Class
