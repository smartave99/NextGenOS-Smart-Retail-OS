; Does a program answer on this PC? A plain connection is made and closed at once; nothing is sent. Shared by the icon that opens the shop program (scripts/launcher/AppLauncher.nsi) and its
; setup (apps/business-hub/installer/SmartRetailHub.nsi), so that both ask the same way. It needs LogicLib, and two settings made by whoever includes it:
;   !define ANSWER_HOST "127.0.0.1"      the address, as numbers
;   !define ANSWER_PORT "5280"           the place (port)
; Call Answers. It leaves 1 in $0 when something accepts a connection there, otherwise 0. The registers $1 to $5 are used and put back.
; Call PortBind. It tries to take the place (port) for a moment and lets it go again: $0 is 0 when a program can use it, 10013 when Windows keeps it for itself (Hyper-V, Docker and WSL
; reserve places like that, and a program cannot use them), 10048 when another program already has it, any other number for another fault (a Windows socket error). Same registers.
!ifndef TCP_ANSWERS_INCLUDED
!define TCP_ANSWERS_INCLUDED
!ifndef ANSWER_HOST
  !error "Say the address: !define ANSWER_HOST ..."
!endif
!ifndef ANSWER_PORT
  !error "Say the port: !define ANSWER_PORT ..."
!endif

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
    System::Call 'ws2_32::inet_addr(m "${ANSWER_HOST}") i .r3'
    System::Call 'ws2_32::htons(i ${ANSWER_PORT}) i .r4'
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

; Can a program take the place (port) on this PC's own address? (See the top of this file.)
Function PortBind
  Push $1
  Push $2
  Push $3
  Push $4
  Push $5
  StrCpy $0 -1
  System::Alloc 512
  Pop $1
  System::Call 'ws2_32::WSAStartup(i 0x0202, p r1) i .r5'
  ${If} $5 == 0
    System::Call 'ws2_32::inet_addr(m "${ANSWER_HOST}") i .r3'
    System::Call 'ws2_32::htons(i ${ANSWER_PORT}) i .r4'
    System::Alloc 16
    Pop $2
    System::Call '*$2(&i2 2, &i2 r4, &i4 r3)'
    System::Call 'ws2_32::socket(i 2, i 1, i 6) p .r5'
    System::Call 'ws2_32::bind(p r5, p r2, i 16) i .r3'
    ${If} $3 == 0
      StrCpy $0 0
    ${Else}
      System::Call 'ws2_32::WSAGetLastError() i .r0'
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
!endif
