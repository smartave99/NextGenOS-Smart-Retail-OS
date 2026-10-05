# Interactive / Batch Unified Build Script for Smart Retail Suite
param (
    [switch]$DesktopPOS,
    [switch]$AiCompanion,
    [switch]$DashboardService,
    [switch]$Storefront,
    [switch]$All
)

$ErrorActionPreference = "Stop"
$ScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$RepoRoot = Split-Path -Parent $ScriptRoot

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "       SMART RETAIL SUITE - MASTER BUILD SCRIPT           " -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan

$buildAll = $All -or (-not ($DesktopPOS -or $AiCompanion -or $DashboardService -or $Storefront))

# Detect tools
$hasDotnet = [bool](Get-Command dotnet -ErrorAction SilentlyContinue)
$hasNpm = [bool](Get-Command npm -ErrorAction SilentlyContinue)

# 1. Desktop POS (.NET Framework 4.8 / MSBuild)
if ($buildAll -or $DesktopPOS) {
    Write-Host "`n[1/4] Building Core Desktop POS (WinForms & 12 Libraries)..." -ForegroundColor Yellow
    $posPath = Join-Path $RepoRoot "apps\pos-desktop\Source\SmartAvenue99_Master.sln"
    $msbuild = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe 2>$null
    if (-not $msbuild) {
        $frameworkDir = Join-Path $env:SystemRoot "Microsoft.NET\Framework\v4.0.30319"
        if (Test-Path "$frameworkDir\MSBuild.exe") {
            $msbuild = "$frameworkDir\MSBuild.exe"
        }
    }

    if ($msbuild -and (Test-Path $msbuild)) {
        Write-Host "Found MSBuild: $msbuild" -ForegroundColor Gray
        & $msbuild $posPath /p:Configuration=Release /v:minimal
        Write-Host "Desktop POS Build Complete." -ForegroundColor Green
    } else {
        Write-Host "MSBuild for .NET 4.8 not found in standard PATH. Please install VS Build Tools or compile through Visual Studio." -ForegroundColor DarkYellow
    }
}

# 2. AI Side-Panel Companion (.NET 8)
if ($buildAll -or $AiCompanion) {
    Write-Host "`n[2/4] Building AI Side-Panel Companion (WPF .NET 8)..." -ForegroundColor Yellow
    $aiSln = Join-Path $RepoRoot "apps\pos-ai-companion\SmartRetailAI.sln"
    if ($hasDotnet) {
        dotnet build $aiSln -c Release
        Write-Host "AI Companion Build Complete." -ForegroundColor Green
    } else {
        Write-Host "dotnet SDK not found on PATH. Install .NET 8 SDK to build AI Companion from CLI." -ForegroundColor DarkYellow
    }
}

# 3. Modern POS Dashboard & Vision (.NET 8)
if ($buildAll -or $DashboardService) {
    Write-Host "`n[3/4] Building POS Dashboard & Services (ASP.NET Core .NET 8)..." -ForegroundColor Yellow
    $posSln = Join-Path $RepoRoot "apps\pos-dashboard-service\SmartRetailPOS.sln"
    if ($hasDotnet) {
        dotnet build $posSln -c Release
        Write-Host "POS Dashboard & Services Build Complete." -ForegroundColor Green
    } else {
        Write-Host "dotnet SDK not found on PATH. Install .NET 8 SDK to build Dashboard from CLI." -ForegroundColor DarkYellow
    }
}

# 4. Omnichannel Storefront (Next.js 15 / Capacitor / Electron)
if ($buildAll -or $Storefront) {
    Write-Host "`n[4/4] Building Omnichannel Web/Mobile Storefront..." -ForegroundColor Yellow
    $storeDir = Join-Path $RepoRoot "apps\storefront-web-mobile"
    if ($hasNpm) {
        Push-Location $storeDir
        try {
            if (-not (Test-Path "node_modules")) {
                Write-Host "Installing npm dependencies in storefront..." -ForegroundColor Gray
                npm install
            }
            npm run build
            Write-Host "Storefront Build Complete." -ForegroundColor Green
        } finally {
            Pop-Location
        }
    } else {
        Write-Host "npm not found on PATH. Install Node.js to build storefront." -ForegroundColor DarkYellow
    }
}

Write-Host "`n==========================================================" -ForegroundColor Cyan
Write-Host "            BUILD SEQUENCE FINISHED                       " -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
