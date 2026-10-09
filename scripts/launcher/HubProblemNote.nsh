; When the shop program (the Business Hub, a Windows service) does not answer, this says in ONE plain sentence what is wrong, and writes a note of what Windows knows about it, for
; the person who looks after the PC. Used by the setup (apps/business-hub/installer/SmartRetailHub.nsi) and by the icon that opens the program (scripts/launcher/AppLauncher.nsi), so
; the two say the same thing. It needs LogicLib, TcpAnswers.nsh (included first), and two settings made by whoever includes it:
;   !define HUB_SERVICE "NextGenOSHub"      the name of the Windows service
;   !define HUB_PORT "5280"                 the place (port) it answers at, on this PC only
; Call HubWriteNote. It leaves the sentence in $R7 and the path of the note in $R8 (the registers $0 to $3 and $R0 to $R6 are used and put back). The note is a plain text file in the
; person's own folder (%LOCALAPPDATA%\NextGenOS\problem-note.txt): the caller shows the sentence and opens the note (Notepad, or the program named in NEXTGENOS_NOTE_VIEWER).
; Only built-in Windows commands are used, each hidden: no black window shows, and nothing is downloaded or left behind except the note. The note holds no sale, customer, password or key.
!ifndef HUB_PROBLEM_NOTE_INCLUDED
!define HUB_PROBLEM_NOTE_INCLUDED
!ifndef HUB_SERVICE
  !error "Say the name of the Windows service: !define HUB_SERVICE ..."
!endif
!ifndef HUB_PORT
  !error "Say the port the program answers at: !define HUB_PORT ..."
!endif
!ifndef TCP_ANSWERS_INCLUDED
  !error "Include TcpAnswers.nsh before this file."
!endif

; Appends the output of one command to the note ($R8), with a title line above it.
!macro HubNoteSection TITLE COMMAND
  nsExec::ExecToStack 'cmd.exe /c echo.>> "$R8" & echo ---- ${TITLE} ---->> "$R8"'
  Pop $0
  Pop $1
  nsExec::ExecToStack 'cmd.exe /c (${COMMAND}) >> "$R8" 2>&1'
  Pop $0
  Pop $1
!macroend

Function HubWriteNote
  Push $0
  Push $1
  Push $2
  Push $3
  Push $R0
  Push $R1
  Push $R2
  Push $R3
  Push $R4
  Push $R5
  Push $R6

  ; where the note goes
  ReadEnvStr $R0 "LOCALAPPDATA"
  ${If} $R0 == ""
    ReadEnvStr $R0 "TEMP"
  ${EndIf}
  CreateDirectory "$R0\NextGenOS"
  StrCpy $R8 "$R0\NextGenOS\problem-note.txt"

  ; the sentence: what the service is doing
  nsExec::ExecToStack 'sc.exe query ${HUB_SERVICE}'
  Pop $0
  Pop $1
  ${If} $0 != 0
    StrCpy $R7 "Smart Retail POS is not installed correctly on this PC: its Windows service is missing. Run the setup again."
  ${Else}
    nsExec::ExecToStack 'cmd.exe /c sc.exe query ${HUB_SERVICE} | find "RUNNING"'
    Pop $0
    Pop $1
    ${If} $0 == 0
      StrCpy $R7 "Smart Retail POS is switched on but does not answer on this PC's own address (127.0.0.1, place ${HUB_PORT}). A security program, a firewall or another program may be in the way."
    ${Else}
      nsExec::ExecToStack 'cmd.exe /c sc.exe query ${HUB_SERVICE} | find "START_PENDING"'
      Pop $0
      Pop $1
      ${If} $0 == 0
        StrCpy $R7 "Smart Retail POS is still starting. This PC is slow to start it. Wait a few minutes and open it again."
      ${Else}
        ; Switched off. Is it because Windows keeps the place (port) for itself (Hyper-V, Docker, WSL)? Then no program can use it, and restarting the PC usually frees it.
        Call PortBind
        ${If} $0 == 10013
          StrCpy $R7 "Windows is keeping the place (port ${HUB_PORT}) that Smart Retail POS needs for itself on this PC, so the program cannot start. Restart the PC. If this comes back, tell the person who looks after your computers."
        ${Else}
          StrCpy $R7 "Windows could not keep Smart Retail POS running: it is switched off. The note says what Windows wrote about it."
        ${EndIf}
      ${EndIf}
    ${EndIf}
  ${EndIf}

  ; the note
  FileOpen $R5 "$R8" w
  FileWrite $R5 "Smart Retail POS: a note about why it did not open$\r$\n"
  FileWrite $R5 "$R7$\r$\n$\r$\n"
  FileWrite $R5 "Please send this note, or a picture of it, to the person who gave you the program.$\r$\n"
  FileClose $R5
  !insertmacro HubNoteSection "the day and time" "date /t & time /t & ver"
  !insertmacro HubNoteSection "the program, as Windows sees it" "sc.exe queryex ${HUB_SERVICE} & sc.exe qc ${HUB_SERVICE}"
  !insertmacro HubNoteSection "who holds the place (port ${HUB_PORT}) on this PC" "netstat -ano -p tcp | findstr :${HUB_PORT}"
  !insertmacro HubNoteSection "places Windows keeps for itself (Hyper-V, Docker, WSL): if ${HUB_PORT} is inside one, the program cannot use it" "netsh int ipv4 show excludedportrange protocol=tcp"
  nsExec::ExecToStack 'cmd.exe /c echo.>> "$R8" & echo ---- what Windows wrote about starting the program ---->> "$R8"'
  Pop $0
  Pop $1
  nsExec::ExecToStack 'cmd.exe /c wevtutil.exe qe System "/q:*[System[Provider[@Name=$\'Service Control Manager$\'] and (EventID=7000 or EventID=7001 or EventID=7009 or EventID=7011 or EventID=7023 or EventID=7024 or EventID=7031 or EventID=7034)]]" /c:6 /rd:true /f:text >> "$R8" 2>&1'
  Pop $0
  Pop $1
  nsExec::ExecToStack 'cmd.exe /c echo.>> "$R8" & echo ---- the newest errors Windows wrote about programs ---->> "$R8"'
  Pop $0
  Pop $1
  nsExec::ExecToStack 'cmd.exe /c wevtutil.exe qe Application "/q:*[System[(Level=2)]]" /c:6 /rd:true /f:text >> "$R8" 2>&1'
  Pop $0
  Pop $1
  ReadEnvStr $R6 "ProgramData"
  ${If} $R6 != ""
    !insertmacro HubNoteSection "the notes the program keeps about how it started" 'type "$R6\NextGenOS\Logs\hub-start.txt"'
  ${EndIf}

  Pop $R6
  Pop $R5
  Pop $R4
  Pop $R3
  Pop $R2
  Pop $R1
  Pop $R0
  Pop $3
  Pop $2
  Pop $1
  Pop $0
FunctionEnd

; Leaves 1 in $0 when Windows says the service is switched off (STOPPED), otherwise 0.
Function HubServiceStopped
  Push $1
  nsExec::ExecToStack 'cmd.exe /c sc.exe query ${HUB_SERVICE} | find "STOPPED"'
  Pop $0
  Pop $1
  ${If} $0 == 0
    StrCpy $0 1
  ${Else}
    StrCpy $0 0
  ${EndIf}
  Pop $1
FunctionEnd

; Asks Windows to start the service. Windows lets the people at the PC ask for this (the setup allows it) and nothing more. Does nothing when it is not allowed or already on its way.
Function HubServiceStart
  Push $0
  Push $1
  nsExec::ExecToStack 'sc.exe start ${HUB_SERVICE}'
  Pop $0
  Pop $1
  Pop $1
  Pop $0
FunctionEnd

; Opens the note in a window of its own (Notepad). NEXTGENOS_NOTE_VIEWER names another program, for tests.
Function HubOpenNote
  Push $R0
  ReadEnvStr $R0 "NEXTGENOS_NOTE_VIEWER"
  ${If} $R0 == ""
    StrCpy $R0 "notepad.exe"
  ${EndIf}
  Exec '"$R0" "$R8"'
  Pop $R0
FunctionEnd
!endif
