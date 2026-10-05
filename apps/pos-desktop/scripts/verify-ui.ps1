param([string]$OutputDirectory = 'Documentation\UI_Proofs', [string]$Mode = 'rebuild-small', [string]$AssemblyPath = '')
$ErrorActionPreference = 'Stop'
if ([Environment]::Is64BitProcess) {
    & "$env:WINDIR\SysWOW64\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -STA -File $PSCommandPath -OutputDirectory $OutputDirectory -Mode $Mode -AssemblyPath $AssemblyPath
    exit $LASTEXITCODE
}
Add-Type -Path (Join-Path $PSScriptRoot 'verify-ui.cs') -ReferencedAssemblies System.Windows.Forms,System.Drawing
$renderArgs = @('Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug', $OutputDirectory, $Mode)
if ($AssemblyPath) {
    $renderArgs[0] = Split-Path -Parent (Resolve-Path -LiteralPath $AssemblyPath).Path
    $renderArgs += $AssemblyPath
}
exit [RenderUi]::Main($renderArgs)
