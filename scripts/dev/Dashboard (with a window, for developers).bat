@echo off
rem For developers: builds the dashboard from its source and starts it, in this window. It needs the .NET SDK. A shop never uses this: the package has "Start Smart Retail POS", which has no black window.
setlocal
cd /d "%~dp0..\..\apps\pos-dashboard-service"
echo Starting Smart Retail POS Web Dashboard and Services...
dotnet run --project src\SmartRetail.Pos.Web\SmartRetail.Pos.Web.csproj
if %errorlevel% neq 0 (
    echo.
    echo Failed to start SmartRetail.Pos.Web. Please verify the .NET SDK is installed.
    pause
)
