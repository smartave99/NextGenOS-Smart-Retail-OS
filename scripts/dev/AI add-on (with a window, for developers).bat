@echo off
rem For developers: builds the AI add-on from its source and starts it, in this window. It needs the .NET SDK. A shop never uses this: the add-on's setup puts an icon on the desktop and in the Start menu.
setlocal
cd /d "%~dp0..\..\apps\pos-ai-companion"
echo Starting Smart Retail AI Side-Panel Companion...
dotnet run --project src\SmartRetail.AI.Desktop\SmartRetail.AI.Desktop.csproj
if %errorlevel% neq 0 (
    echo.
    echo Failed to start SmartRetail.AI.Desktop. Please verify the .NET SDK is installed.
    pause
)
