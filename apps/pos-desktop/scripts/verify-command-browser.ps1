param(
    [string]$BuildDirectory = 'Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug',
    [string]$OutputDirectory = 'scratch\command-browser-proof'
)
$ErrorActionPreference = 'Stop'
if ([Environment]::Is64BitProcess) {
    & "$env:WINDIR\SysWOW64\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -STA -File $PSCommandPath -BuildDirectory $BuildDirectory -OutputDirectory $OutputDirectory
    exit $LASTEXITCODE
}
Add-Type -Path (Join-Path $PSScriptRoot 'verify-command-browser.cs') -ReferencedAssemblies System.Windows.Forms,System.Drawing,System.Core
exit [CommandBrowserProof]::Main(@($BuildDirectory, $OutputDirectory))
