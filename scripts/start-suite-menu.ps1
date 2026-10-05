# Smart Retail Suite - Interactive Launcher
Clear-Host
$ScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$RepoRoot = Split-Path -Parent $ScriptRoot

function Show-Header {
    Write-Host "================================================================" -ForegroundColor Cyan
    Write-Host "           SMART RETAIL SUITE - MASTER CONTROL PANEL            " -ForegroundColor Cyan
    Write-Host "================================================================" -ForegroundColor Cyan
    Write-Host " Location: $RepoRoot" -ForegroundColor Gray
    Write-Host ""
}

function Show-Menu {
    Show-Header
    Write-Host " Select a component to launch or action to run:" -ForegroundColor White
    Write-Host ""
    Write-Host "  [1] Launch Core Desktop POS (WinForms & SQL Server)" -ForegroundColor Green
    Write-Host "  [2] Launch AI Side-Panel Companion (WPF .NET 8)" -ForegroundColor Green
    Write-Host "  [3] Launch Modern POS Dashboard & Vision API (.NET 8)" -ForegroundColor Green
    Write-Host "  [4] Launch Smart Retail POS Web Storefront (Next.js 15)" -ForegroundColor Green
    Write-Host "  [5] Launch Smart Retail POS Desktop Client (Electron)" -ForegroundColor Green
    Write-Host "  --------------------------------------------------" -ForegroundColor DarkGray
    Write-Host "  [B] Run Master Build Script (scripts\build-all.ps1)" -ForegroundColor Yellow
    Write-Host "  [V] Verify AI Provider API Keys (Groq / Lightning AI)" -ForegroundColor Yellow
    Write-Host "  [Q] Exit" -ForegroundColor Red
    Write-Host ""
}

do {
    Show-Menu
    $choice = Read-Host "Enter your choice"
    switch ($choice.ToUpper()) {
        "1" {
            Write-Host "`nLaunching Core Desktop POS..." -ForegroundColor Cyan
            Start-Process cmd.exe -ArgumentList "/c `"$ScriptRoot\start-pos-desktop.bat`""
        }
        "2" {
            Write-Host "`nLaunching AI Side-Panel Companion..." -ForegroundColor Cyan
            Start-Process cmd.exe -ArgumentList "/c `"$ScriptRoot\start-pos-ai.bat`""
        }
        "3" {
            Write-Host "`nLaunching POS Web Dashboard..." -ForegroundColor Cyan
            Start-Process cmd.exe -ArgumentList "/c `"$ScriptRoot\start-pos-dashboard.bat`""
        }
        "4" {
            Write-Host "`nLaunching Smart Retail POS Web Storefront..." -ForegroundColor Cyan
            Start-Process cmd.exe -ArgumentList "/c `"$ScriptRoot\start-storefront.bat`""
        }
        "5" {
            Write-Host "`nLaunching Smart Retail POS Desktop Client..." -ForegroundColor Cyan
            Start-Process cmd.exe -ArgumentList "/c `"$ScriptRoot\start-storefront-desktop.bat`""
        }
        "B" {
            Write-Host "`nRunning Master Build Script..." -ForegroundColor Yellow
            & "$ScriptRoot\build-all.ps1"
            Read-Host "`nPress Enter to return to menu..."
        }
        "V" {
            Write-Host "`nVerifying AI API Keys..." -ForegroundColor Yellow
            Push-Location "$RepoRoot\apps\storefront-web-mobile"
            npm run verify:ai
            Pop-Location
            Read-Host "`nPress Enter to return to menu..."
        }
        "Q" {
            Write-Host "`nExiting Control Panel. Goodbye!" -ForegroundColor Gray
            break
        }
        default {
            Write-Host "`nInvalid choice. Please try again." -ForegroundColor Red
            Start-Sleep -Seconds 1
        }
    }
} while ($choice.ToUpper() -ne "Q")
