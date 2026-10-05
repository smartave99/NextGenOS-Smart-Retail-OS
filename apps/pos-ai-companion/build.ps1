<#
.SYNOPSIS
    Tests, builds and packages the Smart Retail POS AI add-on into dist\SmartRetailAI.zip: the side panel,
    and the sales dashboard in a Dashboard folder beside it (where the panel's "Sales dashboard" button looks).
.DESCRIPTION
    Needs the .NET 10 SDK, because the dashboard is a .NET 10 app. With -SkipDashboard the .NET 8 SDK is enough
    and only the side panel is packaged. The shop PC needs nothing extra: the side panel runs on .NET Framework
    4.8, which the POS already requires, and the dashboard is published with its own runtime.

    -UpdateFeed builds the app with the online folder it looks for automatic updates in (a public Supabase folder, e.g.
    https://<project>.supabase.co/storage/v1/object/public/app-updates/), and the ids of the repository and its owner
    whose release workflow makes the updates (the release workflow gives its own): the app installs only an update
    that GitHub signed as made by that workflow. Without -UpdateFeed the app never looks for updates.

    -Installer also builds dist\SmartRetailAI-Setup.exe from installer\SmartRetailAI.nsi. It needs NSIS 3:
    https://nsis.sourceforge.io on Windows, or "apt-get install nsis" on Linux. It puts Microsoft's WebView2 Runtime
    bootstrapper in the setup (downloaded once into dist), for PCs that do not have WebView2 yet.
#>
param(
    [string]$Configuration = "Release",
    [switch]$SkipDashboard,
    [switch]$Installer,
    [string]$UpdateFeed = "",
    [string]$ReleaseRepositoryId = "",
    [string]$ReleaseOwnerId = ""
)

$ErrorActionPreference = "Stop"
Set-Location $PSScriptRoot

dotnet test tests/SmartRetail.AI.Tests/SmartRetail.AI.Tests.csproj -c $Configuration
if ($LASTEXITCODE -ne 0) { throw "Tests failed." }

# The online folder for automatic updates and whose release workflow is trusted are kept in the app by the build.
$update = @()
if ($UpdateFeed) {
    if ($ReleaseRepositoryId -notmatch '^\d+$' -or $ReleaseOwnerId -notmatch '^\d+$') {
        throw "-UpdateFeed needs -ReleaseRepositoryId and -ReleaseOwnerId: the numbers GitHub gives the repository and its owner (github.repository_id and github.repository_owner_id in a workflow)."
    }
    $update = @("-p:UpdateFeed=$UpdateFeed", "-p:ReleaseRepositoryId=$ReleaseRepositoryId", "-p:ReleaseOwnerId=$ReleaseOwnerId")
}

dotnet build src/SmartRetail.AI.Desktop/SmartRetail.AI.Desktop.csproj -c $Configuration @update
if ($LASTEXITCODE -ne 0) { throw "Build failed." }

$out = Join-Path $PSScriptRoot "dist/SmartRetailAI"
if (Test-Path $out) { Remove-Item $out -Recurse -Force }
New-Item -ItemType Directory -Path $out | Out-Null

# Recurse: WebView2's loader is in runtimes\win-*\native. WPF is not used.
Copy-Item "src/SmartRetail.AI.Desktop/bin/$Configuration/net48/*" $out -Recurse -Exclude "*.pdb", "Dashboard", "Microsoft.Web.WebView2.Wpf.*"
Copy-Item "sql" (Join-Path $out "sql") -Recurse
Copy-Item "README.md" $out

# The licence agreement (EULA) of this software and the notices of the software inside it travel with every copy, as their licences ask.
foreach ($licence in @("../../EULA.txt", "../../THIRD-PARTY-NOTICES.md", "../../licenses")) {
    if (-not (Test-Path $licence)) { throw "$licence is missing: every package carries the licence agreement and the third-party notices." }
}
Copy-Item "../../EULA.txt" (Join-Path $out "EULA.txt")
Copy-Item "../../THIRD-PARTY-NOTICES.md" $out
Copy-Item "../../licenses" (Join-Path $out "licenses") -Recurse

if (-not $SkipDashboard) {
    # From the dashboard's own folder, so its global.json picks the SDK.
    Push-Location (Join-Path $PSScriptRoot "../SmartRetailPOS")
    try {
        dotnet test SmartRetailPOS.sln -c $Configuration
        if ($LASTEXITCODE -ne 0) { throw "Dashboard tests failed." }

        $dashboard = Join-Path $out "Dashboard"
        dotnet publish src/SmartRetail.Pos.Web/SmartRetail.Pos.Web.csproj -c $Configuration -r win-x64 --self-contained true -o $dashboard
        if ($LASTEXITCODE -ne 0) { throw "Dashboard publish failed." }

        Get-ChildItem $dashboard -Filter *.pdb | Remove-Item
        Remove-Item (Join-Path $dashboard "appsettings.Development.json") -ErrorAction SilentlyContinue
    }
    finally {
        Pop-Location
    }
}

$zip = Join-Path $PSScriptRoot "dist/SmartRetailAI.zip"
if (Test-Path $zip) { Remove-Item $zip }
Compress-Archive -Path "$out/*" -DestinationPath $zip
Write-Host "Package ready: $zip"

if ($Installer) {
    $makensis = $null
    $found = Get-Command makensis -ErrorAction SilentlyContinue
    if ($found) { $makensis = $found.Source }
    foreach ($candidate in @("${env:ProgramFiles(x86)}\NSIS\makensis.exe", "$env:ProgramFiles\NSIS\makensis.exe")) {
        if (-not $makensis -and $candidate -and (Test-Path $candidate)) { $makensis = $candidate }
    }
    if (-not $makensis) { throw "-Installer needs NSIS 3: https://nsis.sourceforge.io on Windows, or 'apt-get install nsis' on Linux." }

    # Every installed file and folder (deepest folders first), so the uninstaller removes exactly those.
    $root = (Resolve-Path $out).Path
    $relative = { param($path) $path.Substring($root.Length).TrimStart('\', '/').Replace('/', '\').Replace('$', '$$') }
    $lines = @(Get-ChildItem $root -Recurse -File | ForEach-Object { 'Delete "$INSTDIR\' + (& $relative $_.FullName) + '"' })
    $lines += @(Get-ChildItem $root -Recurse -Directory | Sort-Object { $_.FullName.Length } -Descending |
        ForEach-Object { 'RMDir "$INSTDIR\' + (& $relative $_.FullName) + '"' })
    $list = Join-Path $PSScriptRoot "dist/uninstall-files.nsh"
    [System.IO.File]::WriteAllLines($list, [string[]]$lines, (New-Object System.Text.UTF8Encoding $false))

    # Microsoft's WebView2 Runtime bootstrapper: setup runs it only on a PC without WebView2 (the app shows its
    # windows with it). Without it, setup is built anyway and the app falls back to the browser on such PCs.
    $bootstrapper = Join-Path $PSScriptRoot "dist/MicrosoftEdgeWebview2Setup.exe"
    if (-not (Test-Path $bootstrapper)) {
        try {
            Invoke-WebRequest "https://go.microsoft.com/fwlink/p/?LinkId=2124703" -OutFile $bootstrapper -UseBasicParsing
        }
        catch {
            Write-Warning "Could not download the WebView2 Runtime bootstrapper ($_); setup is built without it."
        }
    }
    $webView2 = @()
    if (Test-Path $bootstrapper) { $webView2 = @("-DWEBVIEW2_BOOTSTRAPPER=$((Resolve-Path $bootstrapper).Path)") }

    $version = ([xml](Get-Content (Join-Path $PSScriptRoot "Directory.Build.props"))).Project.PropertyGroup.Version
    $setup = Join-Path $PSScriptRoot "dist/SmartRetailAI-Setup.exe"
    & $makensis -V2 "-DVERSION=$version" "-DSOURCE=$out" "-DUNINSTALL_LIST=$list" "-DOUTFILE=$setup" @webView2 (Join-Path $PSScriptRoot "installer/SmartRetailAI.nsi")
    if ($LASTEXITCODE -ne 0) { throw "Installer build failed." }
    Write-Host "Installer ready: $setup"
}
