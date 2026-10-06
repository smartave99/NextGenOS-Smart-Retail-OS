; A small Windows program that opens one of our programs with no black terminal window: the icon a person double-clicks ("Setup Studio.exe", "Start Website.exe", ...).
; It starts the program's own Node.js with the program's start-up file, hidden; the program then opens its own window (see scripts/lib/app-window.mjs).
; It holds no secret and no licence. Made by scripts/lib/build-launcher.mjs:
;   makensis -DOUTFILE=... -DNAME="NextGenOS Setup Studio" -DPROGRAM="tools\setup-studio\node\node.exe" -DWORKDIR="tools\setup-studio" -DCHECK="tools\setup-studio\studio.mjs"
;            -DARGS="studio.mjs serve --app" [-DICON=...\x.ico] [-DVERSION=0.1.0] [-DCOMPANY=NextGenOS] AppLauncher.nsi
; Every path is relative to the folder the launcher is in.
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
  !error "Pass what the program is given: -DARGS=..."
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

Section
  SetOutPath "$EXEDIR\${WORKDIR}"
  IfFileExists "$EXEDIR\${PROGRAM}" 0 missing
  IfFileExists "$EXEDIR\${CHECK}" 0 missing
  ; ShellExecute with a hidden window: the program runs and no console window is shown.
  ExecShell "open" "$EXEDIR\${PROGRAM}" "${ARGS}" SW_HIDE
  Quit
missing:
  MessageBox MB_OK|MB_ICONSTOP "${NAME}'s files are not all here.$\r$\n$\r$\nUnpack the whole zip file into a folder (Right-click, Extract All) and open it from that folder, not from inside the zip."
SectionEnd
