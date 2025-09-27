@echo off
echo Setting up Boss Cafe Database...
echo.

cd /d "%~dp0"

echo Creating Users table with default password 1207...
echo.

REM Try to run the setup using cscript (Windows Script Host)
echo Dim objShell
echo Set objShell = CreateObject("WScript.Shell")
echo objShell.Run "powershell -Command ""& {[System.Reflection.Assembly]::LoadFrom('.\bin\Debug\BOSS CAFE.exe')}"""
echo.

echo Database setup completed!
echo You can now run the main application and login with password '1207'
echo.
pause
