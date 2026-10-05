param(
    [string]$BuildDirectory = 'Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug',
    [string]$OutputDirectory = 'scratch\workspace-proof',
    [string]$Filter = ''
)
$ErrorActionPreference = 'Stop'
if ([Environment]::Is64BitProcess) {
    & "$env:WINDIR\SysWOW64\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -STA -File $PSCommandPath -BuildDirectory $BuildDirectory -OutputDirectory $OutputDirectory -Filter $Filter
    exit $LASTEXITCODE
}
Add-Type -Path (Join-Path $PSScriptRoot 'verify-workspaces.cs') -ReferencedAssemblies System.Windows.Forms,System.Drawing,System.Core,System.Data,System.Xml,Accessibility
exit [WorkspaceProof]::Main(@($BuildDirectory, $OutputDirectory, $Filter))
