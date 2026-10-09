; Smart Retail POS Hub (NextGenOS): the Windows setup for the Business Hub, the program every kind of shop, restaurant, library, builder or
; salon uses at its counter. build.mjs makes it from the published, protected program folder:
;   makensis -DVERSION=1.0.0 -DSOURCE=<folder> -DUNINSTALL_LIST=<uninstall-files.nsh> -DOUTFILE=<setup.exe> -DEULA=<EULA.txt> -DNOTICES=<THIRD-PARTY-NOTICES.md> SmartRetailHub.nsi
;
; It installs for everyone on the PC (needs an administrator, because the Hub runs as a Windows service so it is there when the PC starts,
; before anyone signs in). The service runs as the low-rights "Local Service" account and listens on this PC only (127.0.0.1:5280); the shop's
; data folder is readable by that account and administrators only. Uninstalling never removes the shop's data.
;
; Quiet install for a person setting up many PCs:  SmartRetailHub-Setup.exe /S   (and /D=C:\Folder\Hub for another folder, last on the line)
;
; A setup prepared for one business: NextGenOS's Setup Studio puts a folder called "profile" next to this setup file. It holds only data (setup.json, theme.json,
; brand.json and install.ini) and setup copies it beside the program, where the Hub reads it at first run. With no such folder this is the plain setup. When install.ini
; says kiosk=yes (a touch-screen till or a self-service kiosk) the Hub also opens full screen when the PC starts.

Unicode true
Target amd64-unicode
ManifestDPIAware true
SetCompressor /SOLID lzma
RequestExecutionLevel admin

!ifndef VERSION
  !error "Pass the version: -DVERSION=1.0.0"
!endif
!ifndef SOURCE
  !error "Pass the program folder: -DSOURCE=...\hub"
!endif
!ifndef UNINSTALL_LIST
  !error "Pass the list of installed files: -DUNINSTALL_LIST=...\uninstall-files.nsh"
!endif
!ifndef OUTFILE
  !error "Pass the setup file to write: -DOUTFILE=...\SmartRetailHub-Setup.exe"
!endif
!ifndef EULA
  !error "Pass the licence agreement: -DEULA=...\EULA.txt"
!endif

!define APP "Smart Retail POS Hub"
!define COMPANY "NextGenOS"
!define EXE "NextGenOS.Hub.exe"
!define SERVICE "NextGenOSHub"
!define ADDRESS "http://127.0.0.1:5280"
!define UNINSTALL_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\NextGenOS.SmartRetailPOS.Hub"
!define MENU_FOLDER "Smart Retail POS"
; The two small programs beside the Hub (made by zip-launcher.mjs, addServiceLaunchers): they wait until the Hub, which Windows starts, answers, and then open its window (full screen for a till).
!define OPENER "Open Smart Retail POS.exe"
!define OPENER_FULL "Open Smart Retail POS (full screen).exe"

!include MUI2.nsh
!include LogicLib.nsh
!include FileFunc.nsh
!include x64.nsh

Name "${APP}"
OutFile "${OUTFILE}"
BrandingText "${COMPANY}"
InstallDir "$PROGRAMFILES64\${COMPANY}\${APP}"
InstallDirRegKey HKLM "${UNINSTALL_KEY}" "InstallLocation"

VIProductVersion "${VERSION}.0"
VIAddVersionKey "ProductName" "${APP}"
VIAddVersionKey "CompanyName" "${COMPANY}"
VIAddVersionKey "FileDescription" "${APP} Setup"
VIAddVersionKey "FileVersion" "${VERSION}"
VIAddVersionKey "ProductVersion" "${VERSION}"
VIAddVersionKey "LegalCopyright" "(c) 2026 ${COMPANY}"

!define MUI_ABORTWARNING

!define MUI_WELCOMEPAGE_TITLE "Install ${APP}"
!define MUI_WELCOMEPAGE_TEXT "This installs the ${APP} on this PC.$\r$\n$\r$\nIt runs quietly in the background and starts with the PC. You open it from the Smart Retail POS icon, in a window of its own.$\r$\n$\r$\nClick Next to continue."
!insertmacro MUI_PAGE_WELCOME

!insertmacro MUI_PAGE_LICENSE "${EULA}"

!define MUI_PAGE_CUSTOMFUNCTION_LEAVE CheckFolder
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!define MUI_FINISHPAGE_TITLE "${APP} is installed"
!define MUI_FINISHPAGE_TEXT "Open it from the Smart Retail POS icon on your desktop. It opens in a window of its own. The first time, you will be asked for your licence key.$\r$\n$\r$\nRight after the PC starts, or right after this setup, it can take a minute to be ready: a small window says so and the program opens by itself.$\r$\n$\r$\nYour shop's information is kept safe in its own folder and is never removed when you uninstall."
!define MUI_FINISHPAGE_TEXT_LARGE
!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_TEXT "Open Smart Retail POS now"
!define MUI_FINISHPAGE_RUN_FUNCTION OpenHub
!insertmacro MUI_PAGE_FINISH

!define MUI_UNCONFIRMPAGE_TEXT_TOP "${APP} will be removed from this PC. Your shop's information (items, people, bills, settings and the licence) is kept, so a new installation carries on where this one left off."
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

; The Finish button: the same small program as the icon, so the program opens in a window of its own once it is ready (never in the usual web browser, never as a page that says "this site can't be reached").
Function OpenHub
  Exec '"$INSTDIR\${OPENER}"'
FunctionEnd

; Copies one file of the prepared set-up, when it is there.
!macro CopyProfileFile NAME
  ${If} ${FileExists} "$EXEDIR\profile\${NAME}"
    CopyFiles /SILENT "$EXEDIR\profile\${NAME}" "$INSTDIR\profile\${NAME}"
  ${EndIf}
!macroend

Function .onInit
  ${IfNot} ${RunningX64}
    MessageBox MB_OK|MB_ICONSTOP "${APP} needs a 64-bit version of Windows 10 or Windows 11 (or Windows Server 2019 or later)." /SD IDOK
    Abort
  ${EndIf}
  SetRegView 64
  ; A folder given with /D= (for a quiet install) wins over the earlier or the default one.
FunctionEnd

; Leaving the folder page: a folder of its own, not the top of a drive or one of Windows' own folders.
Function CheckFolder
  ${GetRoot} "$INSTDIR" $0
  ${If} "$INSTDIR" == "$0"
  ${OrIf} "$INSTDIR" == "$0\"
  ${OrIf} "$INSTDIR" == "$WINDIR"
  ${OrIf} "$INSTDIR" == "$PROGRAMFILES64"
  ${OrIf} "$INSTDIR" == "$PROGRAMFILES32"
    MessageBox MB_OK|MB_ICONEXCLAMATION "Please give ${APP} a folder of its own, for example:$\r$\n$PROGRAMFILES64\${COMPANY}\${APP}"
    Abort
  ${EndIf}
FunctionEnd

; Waits (up to about half a minute) until the service is really stopped, so its files can be replaced.
Function StopService
  nsExec::ExecToStack 'sc.exe query ${SERVICE}'
  Pop $0
  Pop $1
  ${If} $0 != 0                   ; no such service yet: nothing to stop
    Return
  ${EndIf}
  nsExec::ExecToStack 'sc.exe stop ${SERVICE}'
  Pop $0
  Pop $1
  StrCpy $2 0
  waiting:
    nsExec::ExecToStack 'cmd.exe /c sc.exe query ${SERVICE} | find "STOPPED"'
    Pop $0
    Pop $1
    ${If} $0 == 0
      Return
    ${EndIf}
    IntOp $2 $2 + 1
    ${If} $2 < 60
      Sleep 500
      Goto waiting
    ${EndIf}
FunctionEnd

Section "Smart Retail POS Hub" SecMain
  SectionIn RO
  SetRegView 64
  SetShellVarContext all

  DetailPrint "Stopping an earlier copy, if there is one..."
  Call StopService

  SetOutPath "$INSTDIR"
  File /r "${SOURCE}\*.*"
  File "${EULA}"
  !ifdef NOTICES
    File "${NOTICES}"
  !endif

  ; The prepared set-up for this business, when there is one next to this setup file. Only these five plain files are taken, never anything else in that folder.
  ${If} ${FileExists} "$EXEDIR\profile\setup.json"
  ${OrIf} ${FileExists} "$EXEDIR\profile\theme.json"
  ${OrIf} ${FileExists} "$EXEDIR\profile\brand.json"
    DetailPrint "Adding the set-up prepared for this business..."
    CreateDirectory "$INSTDIR\profile"
    !insertmacro CopyProfileFile "setup.json"
    !insertmacro CopyProfileFile "theme.json"
    !insertmacro CopyProfileFile "brand.json"
    !insertmacro CopyProfileFile "install.ini"
    !insertmacro CopyProfileFile "release.txt"
  ${EndIf}

  ; The shop's data lives in its own folder, outside the program folder, so an update or an uninstall never touches it. Only the service's
  ; account, administrators and the system may read it: the people at the PC use the Hub's own sign-in.
  CreateDirectory "$APPDATA\${COMPANY}\Hub"
  nsExec::ExecToLog 'icacls.exe "$APPDATA\${COMPANY}\Hub" /inheritance:r /grant:r "*S-1-5-19:(OI)(CI)F" "*S-1-5-18:(OI)(CI)F" "*S-1-5-32-544:(OI)(CI)F"'
  ; The licence is shared by every program of the suite on this PC: they read it, the Hub's service may also write it.
  CreateDirectory "$APPDATA\${COMPANY}\SmartRetailPOS"
  nsExec::ExecToLog 'icacls.exe "$APPDATA\${COMPANY}\SmartRetailPOS" /grant "*S-1-5-19:(OI)(CI)M"'

  DetailPrint "Setting up the Windows service..."
  nsExec::ExecToLog 'sc.exe create ${SERVICE} binPath= "\"$INSTDIR\${EXE}\"" start= delayed-auto obj= "NT AUTHORITY\LocalService" DisplayName= "${APP}"'
  Pop $0
  ${If} $0 != 0
    ; Already there (an update): bring its settings up to date.
    nsExec::ExecToLog 'sc.exe config ${SERVICE} binPath= "\"$INSTDIR\${EXE}\"" start= delayed-auto obj= "NT AUTHORITY\LocalService" DisplayName= "${APP}"'
    Pop $0
  ${EndIf}
  nsExec::ExecToLog 'sc.exe description ${SERVICE} "Smart Retail POS Hub by ${COMPANY}: the counter, stock, bills and reports of the business. Open it from the Smart Retail POS icon."'
  nsExec::ExecToLog 'sc.exe failure ${SERVICE} reset= 86400 actions= restart/5000/restart/10000/restart/30000'
  nsExec::ExecToLog 'sc.exe start ${SERVICE}'
  Pop $0

  ; The icon people use: a small program that waits until the Hub is ready (Windows starts it a minute or two after the PC starts, and the first time after this setup) and then opens
  ; it in a window of its own (Microsoft Edge in "app" mode: no address bar, no tabs; Chrome when there is no Edge). It never opens the usual web browser. The Hub is a service and keeps
  ; running in the background when that window is closed.
  CreateDirectory "$SMPROGRAMS\${MENU_FOLDER}"
  CreateShortCut "$SMPROGRAMS\${MENU_FOLDER}\Open Smart Retail POS.lnk" "$INSTDIR\${OPENER}" "" "$INSTDIR\${EXE}" 0
  CreateShortCut "$DESKTOP\Smart Retail POS.lnk" "$INSTDIR\${OPENER}" "" "$INSTDIR\${EXE}" 0

  ; A touch-screen till or a kiosk opens the Hub full screen by itself when the PC starts, once it is ready.
  ReadINIStr $0 "$EXEDIR\profile\install.ini" "install" "kiosk"
  ${If} $0 == "yes"
    CreateShortCut "$SMSTARTUP\Smart Retail POS (full screen).lnk" "$INSTDIR\${OPENER_FULL}" "" "$INSTDIR\${EXE}" 0
    CreateShortCut "$SMPROGRAMS\${MENU_FOLDER}\Smart Retail POS (full screen).lnk" "$INSTDIR\${OPENER_FULL}" "" "$INSTDIR\${EXE}" 0
  ${EndIf}

  WriteUninstaller "$INSTDIR\Uninstall.exe"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "DisplayName" "${APP}"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "DisplayVersion" "${VERSION}"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "Publisher" "${COMPANY}"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "InstallLocation" "$INSTDIR"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "UninstallString" '"$INSTDIR\Uninstall.exe"'
  WriteRegStr HKLM "${UNINSTALL_KEY}" "QuietUninstallString" '"$INSTDIR\Uninstall.exe" /S'
  WriteRegDWORD HKLM "${UNINSTALL_KEY}" "NoModify" 1
  WriteRegDWORD HKLM "${UNINSTALL_KEY}" "NoRepair" 1
  ${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
  IntFmt $0 "0x%08X" $0
  WriteRegDWORD HKLM "${UNINSTALL_KEY}" "EstimatedSize" "$0"
SectionEnd

Section "Uninstall"
  SetRegView 64
  SetShellVarContext all
  DetailPrint "Stopping and removing the Windows service..."
  nsExec::ExecToLog 'sc.exe stop ${SERVICE}'
  Sleep 3000
  nsExec::ExecToLog 'sc.exe delete ${SERVICE}'

  !include "${UNINSTALL_LIST}"

  Delete "$INSTDIR\Open Smart Retail POS.url"
  Delete "$INSTDIR\EULA.txt"
  Delete "$INSTDIR\THIRD-PARTY-NOTICES.md"
  Delete "$INSTDIR\Uninstall.exe"
  ; The prepared set-up: the five plain files setup copies, then the folder if nothing else is in it.
  Delete "$INSTDIR\profile\setup.json"
  Delete "$INSTDIR\profile\theme.json"
  Delete "$INSTDIR\profile\brand.json"
  Delete "$INSTDIR\profile\install.ini"
  Delete "$INSTDIR\profile\release.txt"
  RMDir "$INSTDIR\profile"
  RMDir "$INSTDIR"
  Delete "$SMSTARTUP\Smart Retail POS (full screen).lnk"
  Delete "$SMPROGRAMS\${MENU_FOLDER}\Smart Retail POS (full screen).lnk"
  Delete "$SMPROGRAMS\${MENU_FOLDER}\Open Smart Retail POS.lnk"
  RMDir "$SMPROGRAMS\${MENU_FOLDER}"
  Delete "$DESKTOP\Smart Retail POS.lnk"
  DeleteRegKey HKLM "${UNINSTALL_KEY}"
  ; The shop's data folder ($APPDATA\${COMPANY}\Hub) and the licence are deliberately left.
SectionEnd
