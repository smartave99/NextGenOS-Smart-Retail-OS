; A small Windows program that opens one of our programs with no black terminal window: the icon a person double-clicks ("Setup Studio.exe", "Start Website.exe", ...).
; It holds no secret and no licence. Made by scripts/lib/build-launcher.mjs. Every path is relative to the folder the launcher is in. Two kinds:
;
; 1. A program that opens its own window (the Setup Studio, the website: their Node.js shows a window of its own, see scripts/lib/app-window.mjs). The launcher only starts the
;    program, hidden:
;      makensis -DOUTFILE=... -DNAME="NextGenOS Setup Studio" -DPROGRAM="tools\setup-studio\node\node.exe" -DWORKDIR="tools\setup-studio" -DCHECK="tools\setup-studio\studio.mjs"
;               -DARGS="studio.mjs serve --app" [-DICON=...\x.ico] [-DVERSION=0.1.0] [-DCOMPANY=NextGenOS] AppLauncher.nsi
;
; 2. A background program of the shop that has no window of its own and is used in a browser window (the Business Hub, the dashboard). Add -DOPEN_URL: the launcher starts
;    the program hidden only when nothing answers at that address yet (so there is one copy of it), waits until it answers, and opens the address in a window of its own
;    (Microsoft Edge in "app" mode: no address bar, no tabs; Chrome when there is no Edge). The program keeps running when that window is closed: it is a background program,
;    on purpose. Starting the launcher twice at once starts the program once. THE USUAL WEB BROWSER IS NEVER USED: the owner's rule is that our programs open in a window of their
;    own, like any program on the PC. When there is neither Edge nor Chrome the launcher says so in plain words and tells the person what to do.
;      ... -DOPEN_URL="http://127.0.0.1:5280" -DOPEN_HOST=127.0.0.1 -DOPEN_PORT=5280 [-DOPEN_WAIT=60] [-DOPEN_PROFILE=smart-retail-pos-window] [-DOPEN_HELPER="Start Business Hub (with a window, for problems)"]
;    NEXTGENOS_APP_BROWSER names a Chromium-based browser by hand (the same setting scripts/lib/app-window.mjs reads).
;
;    Two more settings for a program that Windows itself starts (the Business Hub is a Windows service that starts with the PC, a minute or two after it, and the launcher must not
;    start a second copy of it, which would run without the service's rights to the shop's data):
;      -DWAIT_ONLY=1        never start the program; only wait for it. While it has not answered, a small window says that it is starting (-DSTARTING_TEXT="..."), and when the time is
;                           up a plain message says what to do. The window of the program opens the moment it answers.
;      -DKIOSK=1            open the program full screen with nothing else on the screen (a touch till), instead of in a window.
Unicode true
!ifndef OUTFILE
  !error "Pass the file to write: -DOUTFILE=..."
!endif
!ifndef NAME
  !error "Pass the name shown in messages: -DNAME=..."
!endif
!ifndef PROGRAM
  !error "Pass the program to start, relative to the launcher: -DPROGRAM=node\node.exe"
!endif
!ifndef ARGS
  !define ARGS ""
!endif
!ifndef WORKDIR
  !define WORKDIR "."
!endif
!ifndef CHECK
  !define CHECK "${PROGRAM}"
!endif
!ifndef VERSION
  !define VERSION "1.0.0"
!endif
!ifndef COMPANY
  !define COMPANY "NextGenOS"
!endif
!ifdef OPEN_URL
  !include LogicLib.nsh
  !ifndef OPEN_HOST
    !define OPEN_HOST "127.0.0.1"
  !endif
  !ifndef OPEN_PORT
    !error "Pass the port the program answers on: -DOPEN_PORT=5280"
  !endif
  !ifndef OPEN_WAIT
    !define OPEN_WAIT 60
  !endif
  !define /math OPEN_WAIT_MS ${OPEN_WAIT} * 1000
  !ifndef OPEN_PROFILE
    !define OPEN_PROFILE "app-window"
  !endif
  !ifndef STARTING_TEXT
    !define STARTING_TEXT "${NAME} is starting."
  !endif
!endif

Name "${NAME}"
OutFile "${OUTFILE}"
!ifdef ICON
  Icon "${ICON}"
!endif
RequestExecutionLevel user
SilentInstall silent
ShowInstDetails nevershow
XPStyle on
BrandingText " "
; Nothing in this program is worth compressing, and a program whose few words can be read is easier to trust and to check.
SetCompress off

VIProductVersion "${VERSION}.0"
VIAddVersionKey "ProductName" "${NAME}"
VIAddVersionKey "CompanyName" "${COMPANY}"
VIAddVersionKey "FileDescription" "Opens ${NAME}"
VIAddVersionKey "FileVersion" "${VERSION}"
VIAddVersionKey "LegalCopyright" "(c) 2026 ${COMPANY}. All rights reserved."

!ifdef OPEN_URL
; Leaves 1 in $0 when something accepts a connection at ${OPEN_HOST}:${OPEN_PORT}, otherwise 0. A plain connection is made and closed at once; nothing is sent.
Function Answers
  Push $1
  Push $2
  Push $3
  Push $4
  Push $5
  StrCpy $0 0
  System::Alloc 512
  Pop $1
  System::Call 'ws2_32::WSAStartup(i 0x0202, p r1) i .r5'
  ${If} $5 == 0
    System::Call 'ws2_32::inet_addr(m "${OPEN_HOST}") i .r3'
    System::Call 'ws2_32::htons(i ${OPEN_PORT}) i .r4'
    System::Alloc 16
    Pop $2
    ; struct sockaddr_in: the family (2 = internet), the port and the address; the rest stays zero.
    System::Call '*$2(&i2 2, &i2 r4, &i4 r3)'
    System::Call 'ws2_32::socket(i 2, i 1, i 6) p .r5'
    System::Call 'ws2_32::connect(p r5, p r2, i 16) i .r3'
    ${If} $3 == 0
      StrCpy $0 1
    ${EndIf}
    System::Call 'ws2_32::closesocket(p r5)'
    System::Free $2
    System::Call 'ws2_32::WSACleanup()'
  ${EndIf}
  System::Free $1
  Pop $5
  Pop $4
  Pop $3
  Pop $2
  Pop $1
FunctionEnd

; Tries one place for a browser that can show a page as an app window; leaves the path in $R0 when it is there.
!macro TryBrowser BASE RELATIVE
  ${If} $R0 == ""
  ${AndIf} ${BASE} != ""
  ${AndIf} ${FileExists} "${BASE}\${RELATIVE}"
    StrCpy $R0 "${BASE}\${RELATIVE}"
  ${EndIf}
!macroend

; The browser for the program's own window, in the path $R0 (empty when there is none): the one named by hand, then Microsoft Edge (every Windows 10 and 11 has it, in the
; 32-bit Program Files folder), then Google Chrome.
Function FindBrowser
  StrCpy $R0 ""
  ReadEnvStr $R1 "NEXTGENOS_APP_BROWSER"
  ${If} $R1 != ""
  ${AndIf} ${FileExists} "$R1"
    StrCpy $R0 "$R1"
    Return
  ${EndIf}
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
!endif

Section
  SetOutPath "$EXEDIR\${WORKDIR}"
  IfFileExists "$EXEDIR\${PROGRAM}" 0 missing
  IfFileExists "$EXEDIR\${CHECK}" 0 missing
!ifndef OPEN_URL
  ; ShellExecute with a hidden window: the program runs and no console window is shown.
  ExecShell "open" "$EXEDIR\${PROGRAM}" "${ARGS}" SW_HIDE
  Quit
!else
  ; Another copy of this launcher is busy starting the program (a double-click twice): it will open the window, this one has nothing to add.
  System::Call 'kernel32::CreateMutexW(p 0, i 0, w "NextGenOS.Launcher.${OPEN_PORT}") p .r1 ?e'
  Pop $2
  ${If} $2 == 183
    Quit
  ${EndIf}
  StrCpy $9 0
  Call Answers
  ${If} $0 == 0
!ifndef WAIT_ONLY
    ClearErrors
    ExecShell "open" "$EXEDIR\${PROGRAM}" "${ARGS}" SW_HIDE
    IfErrors notstarted
!else
    ; Windows starts the program (a service): this launcher only shows that it is on its way.
    Banner::show /NOUNLOAD /set 76 "${STARTING_TEXT}" /set 54 "Please wait. This window closes by itself." "${NAME}"
    StrCpy $9 1
!endif
    System::Call 'kernel32::GetTickCount() i .r8'
    waiting:
      Sleep 500
      Call Answers
      ${If} $0 == 1
        Goto ready
      ${EndIf}
      System::Call 'kernel32::GetTickCount() i .r7'
      IntOp $7 $7 - $8
      ${If} $7 < ${OPEN_WAIT_MS}
        Goto waiting
      ${EndIf}
    ${If} $9 == 1
      Banner::destroy
    ${EndIf}
    !ifdef WAIT_ONLY
      MessageBox MB_OK|MB_ICONEXCLAMATION "${NAME} has not started yet.$\r$\n$\r$\nIt starts by itself a minute or two after the PC starts, and the first time after it is installed. Wait a little, then open it again.$\r$\n$\r$\nIf it still does not open, restart the PC. If that does not help, call the person who looks after your computers."
    !else ifdef OPEN_HELPER
      MessageBox MB_OK|MB_ICONSTOP "${NAME} did not start within ${OPEN_WAIT} seconds.$\r$\n$\r$\nTry again in a moment. If it still does not open, open $\"${OPEN_HELPER}$\" in this folder and read what it says, or call the person who gave you the program."
    !else
      MessageBox MB_OK|MB_ICONSTOP "${NAME} did not start within ${OPEN_WAIT} seconds.$\r$\n$\r$\nTry again in a moment. If it still does not open, call the person who gave you the program."
    !endif
    Quit
  ${EndIf}
  ready:
  ${If} $9 == 1
    Banner::destroy
  ${EndIf}
  Call FindBrowser
  ${If} $R0 != ""
!ifdef KIOSK
    Exec '"$R0" --kiosk ${OPEN_URL} --edge-kiosk-type=fullscreen --user-data-dir="$LOCALAPPDATA\NextGenOS\${OPEN_PROFILE}" --no-first-run --no-default-browser-check'
!else
    Exec '"$R0" --app=${OPEN_URL} --user-data-dir="$LOCALAPPDATA\NextGenOS\${OPEN_PROFILE}" --no-first-run --no-default-browser-check'
!endif
  ${Else}
    ; Neither Edge nor Chrome. NOT the usual browser (the owner's rule: our programs open in a window of their own): say what is missing and what to do.
    MessageBox MB_OK|MB_ICONEXCLAMATION "${NAME} opens in a window of its own, and that needs Microsoft Edge or Google Chrome on this PC. Neither was found.$\r$\n$\r$\nMicrosoft Edge is free and comes with Windows 10 and 11 (run Windows Update), or it can be installed from microsoft.com/edge. Then open ${NAME} again."
  ${EndIf}
  Quit
!ifndef WAIT_ONLY
  notstarted:
  MessageBox MB_OK|MB_ICONSTOP "${NAME} could not be started: Windows would not run $EXEDIR\${PROGRAM}.$\r$\n$\r$\nA virus checker may have stopped it. Unpack the zip file again, all of it, into a new folder."
  Quit
!endif
!endif
missing:
  MessageBox MB_OK|MB_ICONSTOP "${NAME}'s files are not all here.$\r$\n$\r$\nUnpack the whole zip file into a folder (Right-click, Extract All) and open it from that folder, not from inside the zip."
SectionEnd
