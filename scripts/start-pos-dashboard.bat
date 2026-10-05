@echo off
setlocal
cd /d "%~dp0..\apps\pos-dashboard-service"
echo Starting Smart Retail POS Web Dashboard & Services...
dotnet run --project src\SmartRetail.Pos.Web\SmartRetail.Pos.Web.csproj
if %errorlevel% neq 0 (
    echo.
    echo Failed to start SmartRetail.Pos.Web. Please verify .NET 8 SDK is installed.
    pause
)
