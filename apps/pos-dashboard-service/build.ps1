<#
.SYNOPSIS
    Tests, builds and packages Smart Retail POS into dist\SmartRetailPOS.zip.
.DESCRIPTION
    Needs the .NET 10 SDK. The package is self-contained for 64-bit Windows, so the shop PC
    needs nothing else installed.
#>
param([string]$Configuration = "Release")

$ErrorActionPreference = "Stop"
Set-Location $PSScriptRoot

dotnet test SmartRetailPOS.sln -c $Configuration
if ($LASTEXITCODE -ne 0) { throw "Tests failed." }

$out = Join-Path $PSScriptRoot "dist/SmartRetailPOS"
if (Test-Path $out) { Remove-Item $out -Recurse -Force }

dotnet publish src/SmartRetail.Pos.Web/SmartRetail.Pos.Web.csproj -c $Configuration -r win-x64 --self-contained true -o $out
if ($LASTEXITCODE -ne 0) { throw "Publish failed." }

Get-ChildItem $out -Filter *.pdb | Remove-Item
Remove-Item (Join-Path $out "appsettings.Development.json") -ErrorAction SilentlyContinue
Copy-Item "packaging/Start Smart Retail POS.cmd" $out
Copy-Item "README.md" $out

$zip = Join-Path $PSScriptRoot "dist/SmartRetailPOS.zip"
if (Test-Path $zip) { Remove-Item $zip }
Compress-Archive -Path "$out/*" -DestinationPath $zip
Write-Host "Package ready: $zip"
