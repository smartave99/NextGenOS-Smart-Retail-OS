; Script generated for Smart Retail OS by NextGen OS
; Inno Setup 6 Script

#define MyAppName "Smart Retail OS"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "NextGen OS"
#define MyAppURL "https://github.com/smartave99/Smart-Retail-POS-by-NextGen-OS"
#define MyAppExeName "SmartAvenue99 POS.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".pos"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; Basic Application Info
AppId={{E58482A1-8C59-4D3B-A9FE-0A2C91D4EE52}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=..\LICENSE
OutputDir=Output
OutputBaseFilename=SmartRetailOS_v1.0.0_Setup
SetupIconFile=..\Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\SmartAvenue99 POS.ico
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\SmartAvenue99 POS.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; TrueType Barcode Fonts (Registered into Windows Fonts)
Source: "..\Fonts\code128.ttf"; DestDir: "{autofonts}"; FontInstall: "Code 128"; Flags: onlyifdoesntexist uninsneveruninstall
Source: "..\Fonts\IDAutomationHC39M.ttf"; DestDir: "{autofonts}"; FontInstall: "IDAutomationHC39M"; Flags: onlyifdoesntexist uninsneveruninstall

; Main Application Binaries & Assets
Source: "..\Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\SmartAvenue99 POS.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\SmartAvenue99 POS.ico"; Tasks: desktopicon

[Run]
; Auto-activate permanent license during installation
Filename: "powershell.exe"; Parameters: "-ExecutionPolicy Bypass -WindowStyle Hidden -File ""{app}\Activate_POS.ps1"""; StatusMsg: "Configuring system license and registration..."; Flags: runhidden
; Optional launch checkbox
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\session"
Type: filesandordirs; Name: "{app}\DawnCache"
Type: filesandordirs; Name: "{app}\GPUCache"
Type: filesandordirs; Name: "{app}\BillImg"
Type: filesandordirs; Name: "{app}\Bill_barcode"
