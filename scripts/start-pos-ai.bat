@echo off
setlocal
cd /d "%~dp0..\apps\pos-ai-companion"
echo Starting Smart Retail AI Side-Panel Companion...
dotnet run --project src\SmartRetail.AI.Desktop\SmartRetail.AI.Desktop.csproj
if %errorlevel% neq 0 (
    echo.
    echo Failed to start SmartRetail.AI.Desktop. Please verify .NET 8 SDK is installed.
    pause
)
