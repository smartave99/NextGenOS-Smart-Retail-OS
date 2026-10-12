; Smart Retail POS Hub (NextGenOS): the Windows setup for the Business Hub, the program every kind of shop, restaurant, library, builder or
; salon uses at its counter. build.mjs makes it from the published, protected program folder:
;   makensis -DVERSION=1.0.0 -DSOURCE=<folder> -DUNINSTALL_LIST=<uninstall-files.nsh> -DOUTFILE=<setup.exe> -DEULA=<EULA.txt> -DNOTICES=<THIRD-PARTY-NOTICES.md> SmartRetailHub.nsi
;
; It installs for everyone on the PC (needs an administrator, because the Hub runs as a Windows service so it is there when the PC starts,
; before anyone signs in). The service runs as the low-rights "Local Service" account and listens on this PC only (127.0.0.1:5280); the shop's
; data folder is readable by that account and administrators only. Uninstalling never removes the shop's data.
;
; Quiet install for a person setting up many PCs:  SmartRetailHub-Setup.exe /S   (and /D=C:\Folder\Hub for another folder, last on the line)
; A quiet install ends with code 0 when the program is on and answers, and with code 3 when it was installed but does not answer within about a minute and a half (a note of what Windows
; knows is then left in %LOCALAPPDATA%\NextGenOS\problem-note.txt of the account that ran it).
;
; The service starts with the PC (automatic start, not "delayed": a till must be ready as early as the PC is), is restarted by Windows if it stops, and the people at the PC may switch it
; on (not off, not change it): the icon that opens the program does so when it finds it switched off. The setup does not finish well until the program ANSWERS, and says in one plain sentence
; what is wrong when it does not (scripts/launcher/HubProblemNote.nsh, the same words the icon uses).
;
; A setup prepared for one business: NextGenOS's Setup Studio puts a folder called "profile" next to this setup file. It holds only data (setup.json, theme.json,
; brand.json and install.ini) and setup copies it beside the program, where the Hub reads it at first run. With no such folder this is the plain setup. When install.ini
; says kiosk=yes (a touch-screen till or a self-service kiosk) the Hub also opens full screen when the PC starts.

Unicode true
Target amd64-unicode
ManifestDPIAware true
SetCompressor /SOLID lzma
RequestExecutionLevel admin
; Without this Windows tells the setup it is on Windows 8, and the version check below could not tell Windows 10 from 8.
ManifestSupportedOS Win10

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
; The port the Hub listens on (the same as in ADDRESS) and the room the setup asks the disk for (the program, its updates and the shop's own backups).
!define PORT "5280"
!define NEED_MB 1024
!define UNINSTALL_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\NextGenOS.SmartRetailPOS.Hub"
!define MENU_FOLDER "Smart Retail POS"
; The two small programs beside the Hub (made by zip-launcher.mjs, addServiceLaunchers): they wait until the Hub, which Windows starts, answers, and then open its window (full screen for a till).
!define OPENER "Open Smart Retail POS.exe"
!define OPENER_FULL "Open Smart Retail POS (full screen).exe"

!include MUI2.nsh
!include LogicLib.nsh
!include FileFunc.nsh
!include x64.nsh
!include WinVer.nsh

; The same two helpers as the icon that opens the program (scripts/launcher): "does it answer?" and "say in one sentence what is wrong, and write a note for the person who looks after the PC".
!define ANSWER_HOST "127.0.0.1"
!define ANSWER_PORT "${PORT}"
!define HUB_SERVICE "${SERVICE}"
!define HUB_PORT "${PORT}"
!include "../../../scripts/launcher/TcpAnswers.nsh"
!include "../../../scripts/launcher/HubProblemNote.nsh"

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
  ; Windows 10 version 1809 (build 17763) is also Windows Server 2019, the oldest the program runs on.
  ${IfNot} ${AtLeastBuild} 17763
    MessageBox MB_OK|MB_ICONSTOP "${APP} needs Windows 10 (version 1809 or later), Windows 11 or Windows Server 2019 or later. This PC has an older Windows.$\r$\n$\r$\nRun Windows Update, or use a newer PC." /SD IDOK
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
  Call CheckSpace
FunctionEnd

; Is there room on the drive of the install folder? (Asked when leaving the folder page, and again at the start of the install, which is the only time a quiet install asks.)
Function CheckSpace
  ${GetRoot} "$INSTDIR" $0
  ${DriveSpace} "$0\" "/D=F /S=M" $1
  ${If} $1 < ${NEED_MB}
    MessageBox MB_OK|MB_ICONSTOP "There is not enough free room on drive $0 for ${APP}: it needs about ${NEED_MB} MB and this drive has $1 MB free.$\r$\n$\r$\nFree some space (empty the Recycle Bin, remove programs you do not use) or choose another drive, then run this setup again." /SD IDOK
    Abort
  ${EndIf}
FunctionEnd

; Is Microsoft Edge or Google Chrome on this PC? The program opens in a window of its own and that window is one of them (never the usual web browser). Leaves 1 in $R0 when there is one.
!macro TryBrowser BASE RELATIVE
  ${If} $R0 == 0
  ${AndIf} "${BASE}" != ""
  ${AndIf} ${FileExists} "${BASE}\${RELATIVE}"
    StrCpy $R0 1
  ${EndIf}
!macroend
Function FindBrowser
  StrCpy $R0 0
  ReadEnvStr $R1 "ProgramFiles(x86)"
  ReadEnvStr $R2 "ProgramFiles"
  ReadEnvStr $R3 "ProgramW6432"
  ReadEnvStr $R4 "LOCALAPPDATA"
  !insertmacro TryBrowser $R1 "Microsoft\Edge\Application\msedge.exe"
  !insertmacro TryBrowser $R2 "Microsoft\Edge\Application\msedge.exe"
  !insertmacro TryBrowser $R3 "Microsoft\Edge\Application\msedge.exe"
  !insertmacro TryBrowser $R4 "Microsoft\Edge\Application\msedge.exe"
  !insertmacro TryBrowser $R1 "Google\Chrome\Application\chrome.exe"
  !insertmacro TryBrowser $R2 "Google\Chrome\Application\chrome.exe"
  !insertmacro TryBrowser $R3 "Google\Chrome\Application\chrome.exe"
  !insertmacro TryBrowser $R4 "Google\Chrome\Application\chrome.exe"
FunctionEnd

; Is something already listening on the Hub's port? Leaves 1 in $0 when so. (Asked after an earlier copy of the Hub was stopped, so it is not that.)
Function PortInUse
  nsExec::ExecToStack 'cmd.exe /c netstat -ano -p tcp | find ":${PORT} " | find "LISTENING"'
  Pop $0
  Pop $1
  ${If} $0 == 0
    StrCpy $0 1
  ${Else}
    StrCpy $0 0
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

; After "start" ($0 is what it answered): leaves 1 in $0 when Windows has the service running or on its way within ten seconds, otherwise 0. Windows answers at once when it cannot start the
; service at all ($0 is not 0), or the service is up for a moment and stops again. A service that is merely slow is not a fault: WaitForHub waits for it.
Function CheckStarted
  ${If} $0 != 0
    StrCpy $0 0
    Return
  ${EndIf}
  StrCpy $2 0
  looking:
    nsExec::ExecToStack 'cmd.exe /c sc.exe query ${SERVICE} | find "RUNNING"'
    Pop $0
    Pop $1
    ${If} $0 == 0
      StrCpy $0 1
      Return
    ${EndIf}
    nsExec::ExecToStack 'cmd.exe /c sc.exe query ${SERVICE} | find "START_PENDING"'
    Pop $0
    Pop $1
    ${If} $0 == 0
      StrCpy $0 1
      Return
    ${EndIf}
    IntOp $2 $2 + 1
    ${If} $2 < 20
      Sleep 500
      Goto looking
    ${EndIf}
  StrCpy $0 0
FunctionEnd

; Waits (up to about a minute and a half) until the program answers on this PC's own address. Leaves 1 in $0 when it does. Gives up sooner when Windows keeps saying that the service is
; switched off (it is asked to start again each time).
Function WaitForHub
  Push $5
  Push $6
  Push $7
  System::Call 'kernel32::GetTickCount() i .r6'
  StrCpy $3 0
  StrCpy $4 $6
  asking:
    Call Answers
    ${If} $0 == 1
      Goto waited
    ${EndIf}
    ; By the clock, not by counting turns of this loop: Windows takes a second or two to refuse a connection, so a turn is not half a second ($6 is when the waiting began, $4 the last look at the service).
    System::Call 'kernel32::GetTickCount() i .r7'
    IntOp $2 $7 - $6
    ${If} $2 > 90000
      StrCpy $0 0
      Goto waited
    ${EndIf}
    IntOp $5 $7 - $4
    ${If} $5 >= 10000
      StrCpy $4 $7
      Call HubServiceStopped
      ${If} $0 == 1
        IntOp $3 $3 + 1
        ${If} $3 >= 4
          StrCpy $0 0
          Goto waited
        ${EndIf}
        Call HubServiceStart
      ${EndIf}
    ${EndIf}
    Sleep 500
    Goto asking
  waited:
  Pop $7
  Pop $6
  Pop $5
FunctionEnd

; After "start": the service must be on its way, and then the program must answer. When it does not, say so now, in one plain sentence, and leave a note of what Windows knows (HubProblemNote.nsh):
; the person at the counter should not be the first to find out. A quiet install ends with code 3 then.
Function VerifyStarted
  Call CheckStarted
  ${If} $0 == 1
    DetailPrint "Waiting for ${APP} to answer (the first start can take a minute)..."
    Call WaitForHub
    ${If} $0 == 1
      DetailPrint "${APP} is on and answers."
      Return
    ${EndIf}
    StrCpy $R9 "answer"
  ${Else}
    StrCpy $R9 "start"
  ${EndIf}
  Call HubWriteNote
  DetailPrint "${APP} is not working yet. A note of what Windows knows is in $R8"
  ${IfNot} ${Silent}
    Call HubOpenNote
  ${Else}
    SetErrorLevel 3
  ${EndIf}
  ${If} $R9 == "start"
    MessageBox MB_OK|MB_ICONEXCLAMATION "${APP} is installed, but Windows could not start it just now.$\r$\n$\r$\n$R7$\r$\n$\r$\nRestart this PC, then open Smart Retail POS from its icon. If it is still not ready, an anti-virus program may be stopping it: allow the folder $INSTDIR in the anti-virus program and restart the PC.$\r$\n$\r$\nA note with the details has opened in another window. Please send it, or a picture of it, to the person who looks after your computers." /SD IDOK
  ${Else}
    MessageBox MB_OK|MB_ICONEXCLAMATION "${APP} is installed, but it does not answer yet.$\r$\n$\r$\n$R7$\r$\n$\r$\nA note with the details has opened in another window. Please send it, or a picture of it, to the person who looks after your computers." /SD IDOK
  ${EndIf}
FunctionEnd

Section "Smart Retail POS Hub" SecMain
  SectionIn RO
  SetRegView 64
  SetShellVarContext all

  ; The machine is checked first, in plain words (a quiet install asks too, and takes the answer shown after "/SD").
  DetailPrint "Checking this PC..."
  Call CheckSpace
  Call FindBrowser
  ${If} $R0 == 0
    MessageBox MB_YESNO|MB_ICONEXCLAMATION "Neither Microsoft Edge nor Google Chrome was found on this PC. ${APP} opens in a window of its own, and that needs one of them.$\r$\n$\r$\nMicrosoft Edge is free and comes with Windows 10 and 11 (run Windows Update), or it can be installed from microsoft.com/edge.$\r$\n$\r$\nInstall ${APP} anyway? (Other counters can still use this PC as the main PC, but its own window will not open until a browser is there.)" /SD IDYES IDYES browserlater
    Abort
    browserlater:
  ${EndIf}

  DetailPrint "Stopping an earlier copy, if there is one..."
  Call StopService

  ; Windows keeps some places (ports) for itself (Hyper-V, Docker and WSL do): a program cannot use one, and the Hub could not start, with nothing to say why. Say it now.
  Call PortBind
  ${If} $0 == 10013
    MessageBox MB_OK|MB_ICONSTOP "Windows is keeping the place (port ${PORT}) that ${APP} needs for itself on this PC, so it could not start.$\r$\n$\r$\nRestart the PC and run this setup again first. If this message comes back, tell the person who looks after your PCs that Windows keeps port ${PORT} for itself (Hyper-V, Docker or WSL do this)." /SD IDOK
    Abort
  ${EndIf}

  ; Something else on the PC already holds the Hub's port: the Hub could not start, and nothing would say why. Say it now.
  Call PortInUse
  ${If} $0 == 1
    MessageBox MB_OK|MB_ICONSTOP "Another program on this PC is already using the place (port ${PORT}) that ${APP} needs, so it could not start.$\r$\n$\r$\nRestart the PC and run this setup again first. If this message comes back, close the other program that uses port ${PORT} (the person who looks after your PCs can tell which one it is)." /SD IDOK
    Abort
  ${EndIf}

  SetOutPath "$INSTDIR"
  File /r "${SOURCE}\*.*"
  File "${EULA}"
  !ifdef NOTICES
    File "${NOTICES}"
  !endif

  ; An anti-virus program can remove a new program the moment it is written. Say so, rather than leaving a program that is not there.
  ${IfNot} ${FileExists} "$INSTDIR\${EXE}"
    MessageBox MB_OK|MB_ICONSTOP "The program file was removed right after it was copied. This is usually an anti-virus program that does not know ${APP} yet.$\r$\n$\r$\nAllow the folder $INSTDIR in the anti-virus program (or turn it off for a few minutes), then run this setup again." /SD IDOK
    Abort
  ${EndIf}

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
  ; Files that an earlier copy of the Hub (started by a person from the zip, or by another version) left there may carry rights that keep the service out: they take the folder's rights again.
  nsExec::ExecToLog 'icacls.exe "$APPDATA\${COMPANY}\Hub\*" /reset /T /C /Q'
  ; The licence is shared by every program of the suite on this PC: they read it, the Hub's service may also write it.
  CreateDirectory "$APPDATA\${COMPANY}\SmartRetailPOS"
  nsExec::ExecToLog 'icacls.exe "$APPDATA\${COMPANY}\SmartRetailPOS" /grant "*S-1-5-19:(OI)(CI)M"'

  ; The notes the program keeps about how it started (Diagnostics/StartupLog.cs): the service writes them, the people at the PC may read them (the icon's note quotes them).
  CreateDirectory "$APPDATA\${COMPANY}\Logs"
  nsExec::ExecToLog 'icacls.exe "$APPDATA\${COMPANY}\Logs" /grant "*S-1-5-19:(OI)(CI)M" "*S-1-5-32-545:(OI)(CI)RX"'

  DetailPrint "Setting up the Windows service..."
  nsExec::ExecToLog 'sc.exe create ${SERVICE} binPath= "\"$INSTDIR\${EXE}\"" start= auto obj= "NT AUTHORITY\LocalService" DisplayName= "${APP}"'
  Pop $0
  ${If} $0 != 0
    ; Already there (an update): bring its settings up to date.
    nsExec::ExecToLog 'sc.exe config ${SERVICE} binPath= "\"$INSTDIR\${EXE}\"" start= auto obj= "NT AUTHORITY\LocalService" DisplayName= "${APP}"'
    Pop $0
  ${EndIf}
  nsExec::ExecToLog 'sc.exe description ${SERVICE} "Smart Retail POS Hub by ${COMPANY}: the counter, stock, bills and reports of the business. Open it from the Smart Retail POS icon."'
  nsExec::ExecToLog 'sc.exe failure ${SERVICE} reset= 86400 actions= restart/5000/restart/10000/restart/30000'
  ; Windows restarts it also when it stops by itself with an error, not only when it crashes.
  nsExec::ExecToLog 'sc.exe failureflag ${SERVICE} 1'
  ; Who may do what with the service: the system and administrators everything; the people at the PC may see it and switch it ON (the icon does, when it finds it switched off), nothing more;
  ; other service accounts may only look.
  nsExec::ExecToLog 'sc.exe sdset ${SERVICE} "D:(A;;CCLCSWRPWPDTLOCRRC;;;SY)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCLCSWRPLOCRRC;;;IU)(A;;CCLCSWLOCRRC;;;SU)"'
  nsExec::ExecToLog 'sc.exe start ${SERVICE}'
  Pop $0
  Call VerifyStarted

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
