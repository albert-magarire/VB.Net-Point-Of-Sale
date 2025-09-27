Imports System.Text.RegularExpressions
Imports System.Globalization

''' <summary>
''' Utility class for input validation and data validation
''' </summary>
Public Class ValidationHelper
    
    ''' <summary>
    ''' Validates if a string is not null or empty
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateRequired(value As String, fieldName As String) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates if a string is a valid email address
    ''' </summary>
    ''' <param name="email">Email to validate</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateEmail(email As String) As ValidationResult
        If String.IsNullOrWhiteSpace(email) Then
            Return New ValidationResult(False, "Email is required.")
        End If
        
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        If Not Regex.IsMatch(email, emailPattern) Then
            Return New ValidationResult(False, "Invalid email format.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates if a string is a valid decimal number
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <param name="minValue">Minimum allowed value</param>
    ''' <param name="maxValue">Maximum allowed value</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateDecimal(value As String, fieldName As String, Optional minValue As Decimal = 0, Optional maxValue As Decimal = Decimal.MaxValue) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        
        Dim decimalValue As Decimal
        If Not Decimal.TryParse(value, decimalValue) Then
            Return New ValidationResult(False, $"{fieldName} must be a valid number.")
        End If
        
        If decimalValue < minValue Then
            Return New ValidationResult(False, $"{fieldName} must be at least {minValue}.")
        End If
        
        If decimalValue > maxValue Then
            Return New ValidationResult(False, $"{fieldName} must not exceed {maxValue}.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates if a string is a valid integer
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <param name="minValue">Minimum allowed value</param>
    ''' <param name="maxValue">Maximum allowed value</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateInteger(value As String, fieldName As String, Optional minValue As Integer = Integer.MinValue, Optional maxValue As Integer = Integer.MaxValue) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        
        Dim intValue As Integer
        If Not Integer.TryParse(value, intValue) Then
            Return New ValidationResult(False, $"{fieldName} must be a valid whole number.")
        End If
        
        If intValue < minValue Then
            Return New ValidationResult(False, $"{fieldName} must be at least {minValue}.")
        End If
        
        If intValue > maxValue Then
            Return New ValidationResult(False, $"{fieldName} must not exceed {maxValue}.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates if a string is a valid date
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateDate(value As String, fieldName As String) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        
        Dim dateValue As DateTime
        If Not DateTime.TryParse(value, dateValue) Then
            Return New ValidationResult(False, $"{fieldName} must be a valid date.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates password strength
    ''' </summary>
    ''' <param name="password">Password to validate</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidatePassword(password As String) As ValidationResult
        If String.IsNullOrWhiteSpace(password) Then
            Return New ValidationResult(False, "Password is required.")
        End If
        
        If password.Length < 2 Then
            Return New ValidationResult(False, "Password must be at least 2 characters long.")
        End If
        
        If password.Length > 50 Then
            Return New ValidationResult(False, "Password must not exceed 50 characters.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates if a string contains only alphanumeric characters
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateAlphanumeric(value As String, fieldName As String) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        
        If Not Regex.IsMatch(value, "^[a-zA-Z0-9\s]+$") Then
            Return New ValidationResult(False, $"{fieldName} can only contain letters, numbers, and spaces.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Validates if a string length is within specified range
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <param name="minLength">Minimum length</param>
    ''' <param name="maxLength">Maximum length</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateLength(value As String, fieldName As String, minLength As Integer, maxLength As Integer) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        
        If value.Length < minLength Then
            Return New ValidationResult(False, $"{fieldName} must be at least {minLength} characters long.")
        End If
        
        If value.Length > maxLength Then
            Return New ValidationResult(False, $"{fieldName} must not exceed {maxLength} characters.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Sanitizes input to prevent SQL injection
    ''' </summary>
    ''' <param name="input">Input to sanitize</param>
    ''' <returns>Sanitized input</returns>
    Public Shared Function SanitizeInput(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return String.Empty
        End If
        
        ' Remove potentially dangerous characters
        Return input.Replace("'", "''").Replace(";", "").Replace("--", "").Replace("/*", "").Replace("*/", "")
    End Function
    
    ''' <summary>
    ''' Validates currency amount
    ''' </summary>
    ''' <param name="value">Value to validate</param>
    ''' <param name="fieldName">Name of the field for error message</param>
    ''' <returns>True if valid</returns>
    Public Shared Function ValidateCurrency(value As String, fieldName As String) As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return New ValidationResult(False, $"{fieldName} is required.")
        End If
        
        ' Remove currency symbols and spaces
        Dim cleanValue As String = value.Replace("$", "").Replace(",", "").Trim()
        
        Dim decimalValue As Decimal
        If Not Decimal.TryParse(cleanValue, NumberStyles.Currency, CultureInfo.InvariantCulture, decimalValue) Then
            Return New ValidationResult(False, $"{fieldName} must be a valid currency amount.")
        End If
        
        If decimalValue < 0 Then
            Return New ValidationResult(False, $"{fieldName} cannot be negative.")
        End If
        
        If decimalValue > 999999.99D Then
            Return New ValidationResult(False, $"{fieldName} cannot exceed $999,999.99.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
End Class

''' <summary>
''' Represents the result of a validation operation
''' </summary>
Public Class ValidationResult
    Public Property IsValid As Boolean
    Public Property ErrorMessage As String
    
    Public Sub New(isValid As Boolean, errorMessage As String)
        Me.IsValid = isValid
        Me.ErrorMessage = errorMessage
    End Sub
End Class
