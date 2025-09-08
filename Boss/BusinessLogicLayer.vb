Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' Business logic layer for the Boss Cafe POS system
''' Contains business rules and validation logic
''' </summary>
Public Class BusinessLogicLayer
    
    ''' <summary>
    ''' Authenticates a user with proper validation
    ''' </summary>
    ''' <param name="accountType">User account type</param>
    ''' <param name="password">User password</param>
    ''' <returns>Authentication result</returns>
    Public Shared Function AuthenticateUser(accountType As String, password As String) As AuthenticationResult
        Try
            ' Validate inputs
            Dim accountValidation = ValidationHelper.ValidateRequired(accountType, "Account Type")
            If Not accountValidation.IsValid Then
                Return New AuthenticationResult(False, accountValidation.ErrorMessage, Nothing)
            End If
            
            Dim passwordValidation = ValidationHelper.ValidatePassword(password)
            If Not passwordValidation.IsValid Then
                Return New AuthenticationResult(False, passwordValidation.ErrorMessage, Nothing)
            End If
            
            ' Validate credentials against database
            If DataAccessLayer.ValidateUser(accountType, password) Then
                Dim userInfo As New UserInfo With {
                    .AccountType = accountType,
                    .LoginTime = DateTime.Now
                }
                Return New AuthenticationResult(True, "Authentication successful", userInfo)
            Else
                Return New AuthenticationResult(False, "Invalid credentials", Nothing)
            End If
            
        Catch ex As DataAccessException
            Return New AuthenticationResult(False, "Database error: " & ex.Message, Nothing)
        Catch ex As Exception
            Return New AuthenticationResult(False, "Unexpected error: " & ex.Message, Nothing)
        End Try
    End Function
    
    ''' <summary>
    ''' Processes a new sale with validation and business rules
    ''' </summary>
    ''' <param name="saleData">Sale data to process</param>
    ''' <returns>Processing result</returns>
    Public Shared Function ProcessSale(saleData As SaleData) As ProcessingResult
        Try
            ' Validate sale data
            Dim validationResult = ValidateSaleData(saleData)
            If Not validationResult.IsValid Then
                Return New ProcessingResult(False, validationResult.ErrorMessage, Nothing)
            End If
            
            ' Apply business rules
            Dim businessRulesResult = ApplySaleBusinessRules(saleData)
            If Not businessRulesResult.IsValid Then
                Return New ProcessingResult(False, businessRulesResult.ErrorMessage, Nothing)
            End If
            
            ' Save to database
            DataAccessLayer.InsertSale(saleData)
            
            Return New ProcessingResult(True, "Sale processed successfully", saleData)
            
        Catch ex As DataAccessException
            Return New ProcessingResult(False, "Database error: " & ex.Message, Nothing)
        Catch ex As Exception
            Return New ProcessingResult(False, "Unexpected error: " & ex.Message, Nothing)
        End Try
    End Function
    
    ''' <summary>
    ''' Validates sale data according to business rules
    ''' </summary>
    ''' <param name="saleData">Sale data to validate</param>
    ''' <returns>Validation result</returns>
    Private Shared Function ValidateSaleData(saleData As SaleData) As ValidationResult
        ' Validate required fields
        If String.IsNullOrWhiteSpace(saleData.Code) Then
            Return New ValidationResult(False, "Product code is required.")
        End If
        
        If saleData.Quantity <= 0 Then
            Return New ValidationResult(False, "Quantity must be greater than zero.")
        End If
        
        If String.IsNullOrWhiteSpace(saleData.Waiter) Then
            Return New ValidationResult(False, "Waiter name is required.")
        End If
        
        If String.IsNullOrWhiteSpace(saleData.Order) Then
            Return New ValidationResult(False, "Order type is required.")
        End If
        
        If saleData.Price < 0 Then
            Return New ValidationResult(False, "Price cannot be negative.")
        End If
        
        If saleData.Total < 0 Then
            Return New ValidationResult(False, "Total cannot be negative.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Applies business rules to sale data
    ''' </summary>
    ''' <param name="saleData">Sale data to process</param>
    ''' <returns>Validation result</returns>
    Private Shared Function ApplySaleBusinessRules(saleData As SaleData) As ValidationResult
        ' Business rule: Total should equal quantity * price
        Dim expectedTotal As Decimal = saleData.Quantity * saleData.Price
        If Math.Abs(saleData.Total - expectedTotal) > 0.01D Then
            Return New ValidationResult(False, "Total amount does not match quantity × price.")
        End If
        
        ' Business rule: Maximum quantity per item
        If saleData.Quantity > 100 Then
            Return New ValidationResult(False, "Maximum quantity per item is 100.")
        End If
        
        ' Business rule: Maximum total per sale
        If saleData.Total > 10000 Then
            Return New ValidationResult(False, "Maximum total per sale is $10,000.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
    
    ''' <summary>
    ''' Gets products by category with caching
    ''' </summary>
    ''' <param name="category">Product category</param>
    ''' <returns>List of products</returns>
    Public Shared Function GetProductsByCategory(category As String) As List(Of ProductData)
        Try
            If String.IsNullOrWhiteSpace(category) Then
                Return New List(Of ProductData)()
            End If
            
            Return DataAccessLayer.GetProductsByCategory(category)
        Catch ex As DataAccessException
            Throw New BusinessLogicException("Failed to retrieve products: " & ex.Message, ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Calculates daily totals with proper validation
    ''' </summary>
    ''' <param name="date">Date to calculate totals for</param>
    ''' <returns>Daily totals</returns>
    Public Shared Function CalculateDailyTotals(date As DateTime) As DailyTotalsData
        Try
            Return DataAccessLayer.GetDailyTotals(date)
        Catch ex As DataAccessException
            Throw New BusinessLogicException("Failed to calculate daily totals: " & ex.Message, ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Updates daily totals with validation
    ''' </summary>
    ''' <param name="dailyTotals">Daily totals to update</param>
    Public Shared Sub UpdateDailyTotals(dailyTotals As DailyTotalsData)
        Try
            ' Validate daily totals
            If dailyTotals.ZTotal < 0 OrElse dailyTotals.UTotal < 0 Then
                Throw New BusinessLogicException("Daily totals cannot be negative.")
            End If
            
            If dailyTotals.ReceiptCount < 0 Then
                Throw New BusinessLogicException("Receipt count cannot be negative.")
            End If
            
            DataAccessLayer.UpdateDailyTotals(dailyTotals)
        Catch ex As DataAccessException
            Throw New BusinessLogicException("Failed to update daily totals: " & ex.Message, ex)
        End Try
    End Sub
    
    ''' <summary>
    ''' Generates a unique receipt number
    ''' </summary>
    ''' <param name="date">Date for the receipt</param>
    ''' <returns>Unique receipt number</returns>
    Public Shared Function GenerateReceiptNumber(date As DateTime) As String
        Try
            Dim dailyTotals = DataAccessLayer.GetDailyTotals(date)
            Dim nextReceiptNumber = dailyTotals.ReceiptCount + 1
            Return nextReceiptNumber.ToString("D3") ' Format as 3-digit number with leading zeros
        Catch ex As DataAccessException
            Throw New BusinessLogicException("Failed to generate receipt number: " & ex.Message, ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Validates product data
    ''' </summary>
    ''' <param name="product">Product data to validate</param>
    ''' <returns>Validation result</returns>
    Public Shared Function ValidateProduct(product As ProductData) As ValidationResult
        ' Validate required fields
        If String.IsNullOrWhiteSpace(product.Code) Then
            Return New ValidationResult(False, "Product code is required.")
        End If
        
        If String.IsNullOrWhiteSpace(product.Description) Then
            Return New ValidationResult(False, "Product description is required.")
        End If
        
        If String.IsNullOrWhiteSpace(product.Category) Then
            Return New ValidationResult(False, "Product category is required.")
        End If
        
        ' Validate prices
        If product.USD < 0 Then
            Return New ValidationResult(False, "USD price cannot be negative.")
        End If
        
        If product.ZWL < 0 Then
            Return New ValidationResult(False, "ZWL price cannot be negative.")
        End If
        
        ' Validate code format (alphanumeric)
        If Not ValidationHelper.ValidateAlphanumeric(product.Code, "Product Code").IsValid Then
            Return New ValidationResult(False, "Product code can only contain letters and numbers.")
        End If
        
        Return New ValidationResult(True, "")
    End Function
End Class

''' <summary>
''' Custom exception for business logic errors
''' </summary>
Public Class BusinessLogicException
    Inherits Exception
    
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
    
    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
End Class

''' <summary>
''' Represents the result of an authentication operation
''' </summary>
Public Class AuthenticationResult
    Public Property IsSuccess As Boolean
    Public Property Message As String
    Public Property UserInfo As UserInfo
    
    Public Sub New(isSuccess As Boolean, message As String, userInfo As UserInfo)
        Me.IsSuccess = isSuccess
        Me.Message = message
        Me.UserInfo = userInfo
    End Sub
End Class

''' <summary>
''' Represents the result of a processing operation
''' </summary>
Public Class ProcessingResult
    Public Property IsSuccess As Boolean
    Public Property Message As String
    Public Property Data As Object
    
    Public Sub New(isSuccess As Boolean, message As String, data As Object)
        Me.IsSuccess = isSuccess
        Me.Message = message
        Me.Data = data
    End Sub
End Class

''' <summary>
''' Contains user information
''' </summary>
Public Class UserInfo
    Public Property AccountType As String
    Public Property LoginTime As DateTime
End Class
