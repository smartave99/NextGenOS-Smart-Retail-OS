<#
.SYNOPSIS
    Tests, builds and packages Smart Retail POS into dist\SmartRetailPOS.zip.
.DESCRIPTION
    Needs the .NET 10 SDK. The package is self-contained for 64-bit Windows, so the shop PC
    needs nothing else installed.

    The package opens like a program, with no black window: "Start Smart Retail POS.exe" is a small launcher
    (made by scripts/make-launcher.mjs, which needs Node.js 22 and NSIS on the PC that builds the package; see
    nsis.sourceforge.io, or "apt-get install nsis" on Linux) that starts the dashboard in the background, once, and
    opens it in a window of its own. "Start Smart Retail POS (with a window, for problems).cmd" shows a window, for
    finding a problem.
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
Copy-Item "README.md" $out

# The icon a person double-clicks: it starts the dashboard hidden (only when it is not running yet), waits for it and opens it in a window of its own. The dashboard is a background
# program of the shop: closing that window does not stop it. The .cmd beside it is for finding a problem and shows a window.
$helper = "Start Smart Retail POS (with a window, for problems)"
Copy-Item "packaging/$helper.cmd" $out
$version = ([xml](Get-Content (Join-Path $PSScriptRoot "Directory.Build.props"))).Project.PropertyGroup.Version
$launcherTool = Join-Path $PSScriptRoot "../../scripts/make-launcher.mjs"
node $launcherTool --out (Join-Path $out "Start Smart Retail POS.exe") --name "Smart Retail POS" --program SmartRetail.Pos.Web.exe --open "http://127.0.0.1:5080" --wait 90 --profile "smart-retail-pos-dashboard-window" --helper $helper --version $version
if ($LASTEXITCODE -ne 0) { throw "The launcher could not be made. It needs Node.js 22 (nodejs.org) and NSIS (nsis.sourceforge.io)." }

$zip = Join-Path $PSScriptRoot "dist/SmartRetailPOS.zip"
if (Test-Path $zip) { Remove-Item $zip }
Compress-Archive -Path "$out/*" -DestinationPath $zip
Write-Host "Package ready: $zip"
