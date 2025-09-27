# Boss Cafe Database Setup Script
Write-Host "Setting up Boss Cafe Database..." -ForegroundColor Green
Write-Host ""

# Database file path
$dbPath = ".\bin\Debug\Boss.accdb"
$connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$dbPath"

try {
    # Create connection
    $connection = New-Object -ComObject ADODB.Connection
    $connection.Open($connectionString)
    Write-Host "Connected to database successfully" -ForegroundColor Green
    
    # Create Users table if it doesn't exist
    $createTableSQL = @"
        CREATE TABLE Users (
            ID AUTOINCREMENT PRIMARY KEY,
            AccType TEXT(50) NOT NULL,
            Passcode TEXT(255) NOT NULL
        )
"@
    
    try {
        $connection.Execute($createTableSQL)
        Write-Host "Users table created" -ForegroundColor Green
    } catch {
        Write-Host "Users table already exists or creation failed: $($_.Exception.Message)" -ForegroundColor Yellow
    }
    
    # Clear existing users
    $clearSQL = "DELETE FROM Users"
    $connection.Execute($clearSQL)
    Write-Host "Cleared existing users" -ForegroundColor Yellow
    
    # Insert default users
    $users = @("Cashier", "Manager", "Supervisor")
    foreach ($user in $users) {
        $insertSQL = "INSERT INTO Users (AccType, Passcode) VALUES ('$user', '1207')"
        $connection.Execute($insertSQL)
        Write-Host "Added $user user" -ForegroundColor Green
    }
    
    # Verify setup
    $verifySQL = "SELECT COUNT(*) FROM Users"
    $result = $connection.Execute($verifySQL)
    $count = $result.Fields(0).Value
    Write-Host "Total users in database: $count" -ForegroundColor Cyan
    
    $connection.Close()
    Write-Host ""
    Write-Host "Database setup completed successfully!" -ForegroundColor Green
    Write-Host "You can now run the main application and login with password '1207'" -ForegroundColor Cyan
    
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""
Write-Host "Press any key to exit..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
