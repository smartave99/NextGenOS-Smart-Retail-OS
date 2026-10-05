; Smart Retail POS AI (NextGenOS): the Windows installer for the AI side panel and its sales dashboard.
;
; build.ps1 -Installer builds it with NSIS (makensis) from the package folder, dist\SmartRetailAI:
;   makensis -DVERSION=1.1.0 -DSOURCE=<dist\SmartRetailAI> -DUNINSTALL_LIST=<dist\uninstall-files.nsh>
;            -DOUTFILE=<dist\SmartRetailAI-Setup.exe> SmartRetailAI.nsi
; UNINSTALL_LIST names every installed file and folder, so the uninstaller removes exactly those, from any folder.
;
; It installs for everyone on the PC (Program Files, needs an administrator) or only for the current user (no
; administrator), in any folder. Uninstalling keeps the shop's settings, photos and plans. Codex, the AI tool, is not
; installed here: the app's Get started page installs it and signs it in as the Windows user who will use it.
;
; An update the app starts itself runs quietly: SmartRetailAI-Setup-x.y.z.exe /S /UPDATE /AllUsers (or /CurrentUser). It waits
; for the app, which is quitting, instead of asking someone to close it, and keeps what the owner chose: no desktop shortcut or
; start with Windows comes back if they were taken away. The app starts itself again afterwards (UpdateInstaller.cs).
;
; The app shows its windows with Microsoft Edge WebView2. With -DWEBVIEW2_BOOTSTRAPPER=<MicrosoftEdgeWebview2Setup.exe>
; setup carries Microsoft's bootstrapper and runs it on a PC without WebView2 (never under Wine, where tests run, nor
; with /NOWEBVIEW2).

Unicode true
Target amd64-unicode
ManifestDPIAware true
SetCompressor /SOLID lzma

!ifndef VERSION
  !error "Pass the version: -DVERSION=1.1.0"
!endif
!ifndef SOURCE
  !error "Pass the package folder: -DSOURCE=...\dist\SmartRetailAI"
!endif
!ifndef UNINSTALL_LIST
  !error "Pass the list of installed files: -DUNINSTALL_LIST=...\dist\uninstall-files.nsh"
!endif
!ifndef OUTFILE
  !error "Pass the setup file to write: -DOUTFILE=...\SmartRetailAI-Setup.exe"
!endif

; How long an update waits for the app to quit before it gives up (-DUPDATE_WAIT_SECONDS=3 makes it quick to test).
!ifndef UPDATE_WAIT_SECONDS
  !define UPDATE_WAIT_SECONDS 60
!endif
!define /math UPDATE_WAIT_TICKS ${UPDATE_WAIT_SECONDS} * 2

!define APP "Smart Retail POS AI"
!define COMPANY "NextGenOS"
!define EXE "SmartRetailAI.exe"
!define DASHBOARD_EXE "SmartRetail.Pos.Web.exe"
!define UNINSTALL_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\NextGenOS.SmartRetailPOS.AI"
!define RUN_KEY "Software\Microsoft\Windows\CurrentVersion\Run"
; Windows' list of start-up apps (Task Manager, Settings > Apps > Startup) keeps a value of the same name here when someone switched an entry off.
!define APPROVED_KEY "Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run"
; The value the app's own "Start with Windows" setting uses (StartupRegistration.cs), so the two always agree.
!define RUN_VALUE "SmartRetailPOS-AI-Assistant"
; The app's single-instance mutex (Program.cs): it exists while the app runs.
!define MUTEX "NextGenOS.SmartRetailPOS.AIAssistant"
!define NET48_RELEASE 528040
; The Evergreen WebView2 Runtime's EdgeUpdate client.
!define WEBVIEW2_CLIENT "{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}"

; Everyone on this PC (Program Files) or only me (the user's own programs folder); an update keeps the earlier choice.
!define MULTIUSER_EXECUTIONLEVEL Highest
!define MULTIUSER_MUI
!define MULTIUSER_INSTALLMODE_COMMANDLINE
!define MULTIUSER_USE_PROGRAMFILES64
!define MULTIUSER_INSTALLMODE_INSTDIR "${COMPANY}\${APP}"
!define MULTIUSER_INSTALLMODE_INSTDIR_REGISTRY_KEY "${UNINSTALL_KEY}"
!define MULTIUSER_INSTALLMODE_INSTDIR_REGISTRY_VALUENAME "InstallLocation"
!define MULTIUSER_INSTALLMODE_DEFAULT_REGISTRY_KEY "${UNINSTALL_KEY}"
!define MULTIUSER_INSTALLMODE_DEFAULT_REGISTRY_VALUENAME "InstallLocation"

!include MultiUser.nsh
!include MUI2.nsh
!include LogicLib.nsh
!include FileFunc.nsh

; 1 when the app started this setup to install an update (/UPDATE).
Var UpdateMode

Name "${APP}"
OutFile "${OUTFILE}"
BrandingText "${COMPANY}"

VIProductVersion "${VERSION}.0"
VIAddVersionKey "ProductName" "${APP}"
VIAddVersionKey "CompanyName" "${COMPANY}"
VIAddVersionKey "FileDescription" "${APP} Setup"
VIAddVersionKey "FileVersion" "${VERSION}"
VIAddVersionKey "ProductVersion" "${VERSION}"
VIAddVersionKey "LegalCopyright" "(c) 2026 ${COMPANY}"

!define MUI_ICON "..\src\SmartRetail.AI.Desktop\app.ico"
!define MUI_UNICON "..\src\SmartRetail.AI.Desktop\app.ico"
; The picture beside the welcome and finish pages (164 x 314, 24-bit BMP).
!define MUI_WELCOMEFINISHPAGE_BITMAP "wizard.bmp"
!define MUI_ABORTWARNING

!define MUI_WELCOMEPAGE_TITLE "Install ${APP}"
!define MUI_WELCOMEPAGE_TEXT "This installs ${APP}: the app with its sales dashboard and Ask AI, and the side panel beside the POS.$\r$\n$\r$\nIt only reads the POS database. The POS itself is not changed.$\r$\n$\r$\nClick Next to continue."
!insertmacro MUI_PAGE_WELCOME

!insertmacro MULTIUSER_PAGE_INSTALLMODE

!define MUI_DIRECTORYPAGE_TEXT_TOP "Setup will install ${APP} in the folder below. To use another folder or drive, click Browse and choose it."
!define MUI_PAGE_CUSTOMFUNCTION_LEAVE CheckFolder
!insertmacro MUI_PAGE_DIRECTORY

!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_INSTFILES

!define MUI_FINISHPAGE_TITLE "${APP} is installed"
!define MUI_FINISHPAGE_TEXT "It opens in its own window. Its Get started page installs Codex, the AI tool, and helps you sign in with ChatGPT.$\r$\n$\r$\nBeside the POS, click the AI tab on the edge of the screen, or press Ctrl+Shift+Space."
!define MUI_FINISHPAGE_TEXT_LARGE
!define MUI_FINISHPAGE_RUN "$INSTDIR\${EXE}"
!define MUI_FINISHPAGE_RUN_TEXT "Start ${APP} now"
!insertmacro MUI_PAGE_FINISH

!define MUI_UNCONFIRMPAGE_TEXT_TOP "${APP} will be removed from this PC. Its settings, product photos and growth plans are kept, so a new installation carries on where this one left off."
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

!macro CLOSE_RUNNING_APP UN
  ; Files in use cannot be replaced or removed, so the app must be closed first.
  Function ${UN}CloseRunningApp
    retry:
      System::Call 'kernel32::OpenMutexW(i 0x00100000, i 0, w "${MUTEX}") p .r0'
      ${If} $0 != 0
        System::Call 'kernel32::CloseHandle(p r0)'
        MessageBox MB_RETRYCANCEL|MB_ICONEXCLAMATION "${APP} is running.$\r$\n$\r$\nClose it first: right-click its icon near the clock and choose Exit. Then click Retry." /SD IDCANCEL IDRETRY retry
        Abort
      ${EndIf}
  FunctionEnd
!macroend
!insertmacro CLOSE_RUNNING_APP ""
!insertmacro CLOSE_RUNNING_APP "un."

Function .onInit
  ; The side panel runs on .NET Framework 4.8, which Windows 10 (May 2019 update or later) and Windows 11 include.
  SetRegView 64
  ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Release"
  ${If} $0 < ${NET48_RELEASE}
    MessageBox MB_YESNO|MB_ICONEXCLAMATION "${APP} needs Microsoft .NET Framework 4.8, which this PC does not have.$\r$\n$\r$\nOpen the download page now? Install it, then run this setup again." /SD IDNO IDNO +2
      ExecShell "open" "https://dotnet.microsoft.com/download/dotnet-framework/net48"
    Abort
  ${EndIf}
  ; A folder given with /D= (e.g. for a silent install) wins over the default for the install mode.
  StrCpy $R9 $INSTDIR
  !insertmacro MULTIUSER_INIT
  ${If} $R9 != ""
    StrCpy $INSTDIR $R9
  ${EndIf}
  ${GetParameters} $1
  StrCpy $UpdateMode 0
  ClearErrors
  ${GetOptions} $1 "/UPDATE" $2
  ${IfNot} ${Errors}
    StrCpy $UpdateMode 1
  ${EndIf}
  ClearErrors
  ${If} $UpdateMode == 1
    ; Before anything is removed: the earlier copy's shortcut and start-with-Windows entry are read now.
    Call KeepOptionalPartsAsTheyWere
    Call WaitForAppToQuit
  ${EndIf}
  Call CloseRunningApp
FunctionEnd

; An update the app started: the app is quitting, so give it time, instead of asking someone to close it (nobody is
; there in a quiet setup). After the time is up CloseRunningApp stops the setup as it always does.
Function WaitForAppToQuit
  StrCpy $3 0
  waiting:
    System::Call 'kernel32::OpenMutexW(i 0x00100000, i 0, w "${MUTEX}") p .r0'
    ${If} $0 == 0
      Return
    ${EndIf}
    System::Call 'kernel32::CloseHandle(p r0)'
    IntOp $3 $3 + 1
    ${If} $3 < ${UPDATE_WAIT_TICKS}
      Sleep 500
      Goto waiting
    ${EndIf}
FunctionEnd

; Leaving the folder page: any folder of the owner's choice, as long as setup can write there and it is not the
; top of a drive or one of Windows' own folders.
Function CheckFolder
  ${GetRoot} "$INSTDIR" $0
  ${If} "$INSTDIR" == "$0"
  ${OrIf} "$INSTDIR" == "$0\"
  ${OrIf} "$INSTDIR" == "$WINDIR"
  ${OrIf} "$INSTDIR" == "$PROGRAMFILES64"
  ${OrIf} "$INSTDIR" == "$PROGRAMFILES32"
    MessageBox MB_OK|MB_ICONEXCLAMATION "Please give ${APP} a folder of its own, for example:$\r$\n$INSTDIR\${APP}"
    Abort
  ${EndIf}

  ${DirState} "$INSTDIR" $0
  ${If} $0 == 1
  ${AndIfNot} ${FileExists} "$INSTDIR\${EXE}"
    MessageBox MB_YESNO|MB_ICONQUESTION "The folder $INSTDIR already has other files in it.$\r$\n$\r$\nInstall into a new folder inside it instead, so the two stay apart?$\r$\n$INSTDIR\${APP}" /SD IDYES IDNO keep
      ; The page copies its folder box back into $INSTDIR, so the box itself is changed; the owner sees the new
      ; folder and clicks Next again.
      StrCpy $INSTDIR "$INSTDIR\${APP}"
      FindWindow $0 "#32770" "" $HWNDPARENT
      GetDlgItem $0 $0 1019
      SendMessage $0 ${WM_SETTEXT} 0 "STR:$INSTDIR"
      Abort
    keep:
  ${EndIf}

  ClearErrors
  CreateDirectory "$INSTDIR"
  FileOpen $1 "$INSTDIR\.setup-write-test" w
  ${If} ${Errors}
    MessageBox MB_OK|MB_ICONEXCLAMATION "Setup cannot write to this folder:$\r$\n$INSTDIR$\r$\n$\r$\nChoose another folder, or click Back and choose to install for anyone who uses this computer, which asks for administrator rights."
    Abort
  ${EndIf}
  FileClose $1
  Delete "$INSTDIR\.setup-write-test"
FunctionEnd

; An earlier copy is removed before the new one is copied, so no old file stays behind and the app never exists twice.
Function RemoveEarlierCopies
  ; Version 1.0 installed only for the current user; a copy in another folder is replaced by this one.
  ${ForEach} $2 0 1 + 1
    ${If} $2 == 0
      ReadRegStr $0 HKCU "${UNINSTALL_KEY}" "InstallLocation"
    ${Else}
      ReadRegStr $0 HKLM "${UNINSTALL_KEY}" "InstallLocation"
    ${EndIf}
    ${If} $0 != ""
    ${AndIf} $0 != "$INSTDIR"
    ${AndIf} ${FileExists} "$0\Uninstall.exe"
    ${AndIf} ${FileExists} "$0\${EXE}"
      DetailPrint "Removing the earlier copy in $0"
      ExecWait '"$0\Uninstall.exe" /S _?=$0'
      Delete "$0\Uninstall.exe"
      RMDir "$0"
      ${GetParent} "$0" $1
      ${GetFileName} "$1" $3
      ${If} $3 == "${COMPANY}"
        RMDir "$1"
      ${EndIf}
    ${EndIf}
  ${Next}

  ; The same folder: its own uninstaller removes exactly what it installed.
  ${If} ${FileExists} "$INSTDIR\Uninstall.exe"
  ${AndIf} ${FileExists} "$INSTDIR\${EXE}"
    DetailPrint "Removing the earlier version"
    ExecWait '"$INSTDIR\Uninstall.exe" /S _?=$INSTDIR'
  ${EndIf}
FunctionEnd

!ifdef WEBVIEW2_BOOTSTRAPPER
; Windows 11 has WebView2, and so do most Windows 10 PCs (it comes with Edge). Where it is missing, Microsoft's
; bootstrapper downloads and installs it: for everyone when setup runs as administrator, else for this user.
Function InstallWebView2
  ReadRegStr $0 HKLM "SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients\${WEBVIEW2_CLIENT}" "pv"
  ${If} $0 == ""
  ${OrIf} $0 == "0.0.0.0"
    ReadRegStr $0 HKCU "Software\Microsoft\EdgeUpdate\Clients\${WEBVIEW2_CLIENT}" "pv"
  ${EndIf}
  ${If} $0 != ""
  ${AndIf} $0 != "0.0.0.0"
    DetailPrint "Microsoft Edge WebView2 Runtime $0 is installed"
    Return
  ${EndIf}

  ${GetParameters} $1
  ClearErrors
  ${GetOptions} $1 "/NOWEBVIEW2" $2
  ${IfNot} ${Errors}
    DetailPrint "Skipping the WebView2 Runtime (/NOWEBVIEW2)"
    Return
  ${EndIf}
  ClearErrors
  EnumRegKey $2 HKCU "Software\Wine" 0
  ${IfNot} ${Errors}
    DetailPrint "Skipping the WebView2 Runtime under Wine"
    Return
  ${EndIf}

  DetailPrint "Installing Microsoft Edge WebView2 Runtime (it needs the internet for a minute)"
  InitPluginsDir
  File "/oname=$PLUGINSDIR\MicrosoftEdgeWebview2Setup.exe" "${WEBVIEW2_BOOTSTRAPPER}"
  ExecWait '"$PLUGINSDIR\MicrosoftEdgeWebview2Setup.exe" /silent /install' $3
  ${If} $3 != 0
    DetailPrint "WebView2 could not be installed now (code $3). Until it is, the app shows its screens in the browser."
  ${EndIf}
FunctionEnd
!endif

Section "Program (required)" SecApp
  SectionIn RO

  ; A dashboard left running would keep its files open.
  nsExec::Exec '"$SYSDIR\taskkill.exe" /F /IM ${DASHBOARD_EXE}'
  Pop $0
  Call RemoveEarlierCopies

  SetOutPath "$INSTDIR"
  File /r "${SOURCE}\*.*"
!ifdef WEBVIEW2_BOOTSTRAPPER
  Call InstallWebView2
!endif

  WriteUninstaller "$INSTDIR\Uninstall.exe"
  CreateShortcut "$SMPROGRAMS\${APP}.lnk" "$INSTDIR\${EXE}" "" "$INSTDIR\${EXE}" 0 SW_SHOWNORMAL "" "The AI assistant beside the POS"

  WriteRegStr SHCTX "${UNINSTALL_KEY}" "DisplayName" "${APP}"
  WriteRegStr SHCTX "${UNINSTALL_KEY}" "DisplayVersion" "${VERSION}"
  WriteRegStr SHCTX "${UNINSTALL_KEY}" "Publisher" "${COMPANY}"
  WriteRegStr SHCTX "${UNINSTALL_KEY}" "DisplayIcon" "$INSTDIR\${EXE}"
  WriteRegStr SHCTX "${UNINSTALL_KEY}" "InstallLocation" "$INSTDIR"
  WriteRegStr SHCTX "${UNINSTALL_KEY}" "UninstallString" '"$INSTDIR\Uninstall.exe" /$MultiUser.InstallMode'
  WriteRegStr SHCTX "${UNINSTALL_KEY}" "QuietUninstallString" '"$INSTDIR\Uninstall.exe" /$MultiUser.InstallMode /S'
  WriteRegDWORD SHCTX "${UNINSTALL_KEY}" "NoModify" 1
  WriteRegDWORD SHCTX "${UNINSTALL_KEY}" "NoRepair" 1
  ${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
  IntFmt $0 "0x%08X" $0
  WriteRegDWORD SHCTX "${UNINSTALL_KEY}" "EstimatedSize" "$0"
SectionEnd

Section "Desktop shortcut" SecDesktop
  CreateShortcut "$DESKTOP\${APP}.lnk" "$INSTDIR\${EXE}" "" "$INSTDIR\${EXE}" 0 SW_SHOWNORMAL "" "The AI assistant beside the POS"
SectionEnd

Section "Start with Windows" SecStartup
  WriteRegStr HKCU "${RUN_KEY}" "${RUN_VALUE}" '"$INSTDIR\${EXE}" --background'
  ; Someone may have switched an earlier copy off in Windows' list of start-up apps, which would keep this one from starting:
  ; ticking this part is the owner asking for it. An update leaves that choice as it was, and so does removing a copy (an update
  ; removes the earlier copy first), which is why the uninstaller does not touch Windows' list either.
  ${If} $UpdateMode != 1
    DeleteRegValue HKCU "${APPROVED_KEY}" "${RUN_VALUE}"
  ${EndIf}
SectionEnd

; An update keeps the owner's choices: a shortcut they deleted, or start with Windows they turned off, is not made again.
Function KeepOptionalPartsAsTheyWere
  ${IfNot} ${FileExists} "$DESKTOP\${APP}.lnk"
    SectionSetFlags ${SecDesktop} 0
  ${EndIf}
  ReadRegStr $0 HKCU "${RUN_KEY}" "${RUN_VALUE}"
  ${If} $0 == ""
    SectionSetFlags ${SecStartup} 0
  ${EndIf}
FunctionEnd

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SecApp} "The AI side panel, the sales dashboard and the read-only SQL login script."
  !insertmacro MUI_DESCRIPTION_TEXT ${SecDesktop} "A shortcut on the desktop."
  !insertmacro MUI_DESCRIPTION_TEXT ${SecStartup} "Recommended. Starts Smart Retail POS by itself when you sign in to Windows, waiting as the AI tab beside the POS. It can be turned off later in Settings."
!insertmacro MUI_FUNCTION_DESCRIPTION_END

Function un.onInit
  !insertmacro MULTIUSER_UNINIT
  Call un.CloseRunningApp
FunctionEnd

Section "Uninstall"
  nsExec::Exec '"$SYSDIR\taskkill.exe" /F /IM ${DASHBOARD_EXE}'
  Pop $0

  Delete "$SMPROGRAMS\${APP}.lnk"
  Delete "$DESKTOP\${APP}.lnk"
  DeleteRegValue HKCU "${RUN_KEY}" "${RUN_VALUE}"
  DeleteRegKey SHCTX "${UNINSTALL_KEY}"

  ; Exactly the files and folders setup installed, wherever the owner put them; nothing else in the folder.
  !include /CHARSET=UTF8 "${UNINSTALL_LIST}"
  Delete "$INSTDIR\Uninstall.exe"
  RMDir "$INSTDIR"
  ; The "NextGenOS" folder around the default place, if nothing else is in it.
  ${GetParent} "$INSTDIR" $0
  ${GetFileName} "$0" $1
  ${If} $1 == "${COMPANY}"
    RMDir "$0"
  ${EndIf}
SectionEnd
