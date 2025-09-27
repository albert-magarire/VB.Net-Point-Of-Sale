Imports System

Module TestConsole
    Sub Main()
        Console.WriteLine("=== Boss Cafe Login Test ===")
        Console.WriteLine()
        
        ' Test database connection
        Console.WriteLine("1. Testing database connection...")
        TestLogin.TestDatabaseConnection()
        Console.WriteLine()
        
        ' Test login validation
        Console.WriteLine("2. Testing login validation...")
        TestLogin.TestLoginValidation()
        Console.WriteLine()
        
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
End Module
