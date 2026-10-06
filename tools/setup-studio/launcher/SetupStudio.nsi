; The program people double-click to open the NextGenOS Setup Studio ("Setup Studio.exe"). It does one thing: it starts the Studio's own Node.js with the Studio's
; start-up file, with no black terminal window, and the Studio then opens in a window of its own (studio.mjs serve --app). It holds no secret and no licence.
;   makensis -DOUTFILE=<where to write it> -DICON=<studio.ico> -DVERSION=0.1.0 SetupStudio.nsi
Unicode true
!ifndef OUTFILE
  !error "Pass the file to write: -DOUTFILE=...\Setup Studio.exe"
!endif
!ifndef ICON
  !error "Pass the icon: -DICON=...\studio.ico"
!endif
!ifndef VERSION
  !define VERSION "0.1.0"
!endif
!ifndef NODE_TEST
  ; the folder (under the one this program is in) that holds node\node.exe and studio.mjs; a test points it at a stand-in
  !define STUDIO_DIR "tools\setup-studio"
!else
  !define STUDIO_DIR "${NODE_TEST}"
!endif

Name "NextGenOS Setup Studio"
OutFile "${OUTFILE}"
Icon "${ICON}"
RequestExecutionLevel user
SilentInstall silent
ShowInstDetails nevershow
XPStyle on
BrandingText " "
; Nothing in this program is worth compressing, and a program whose few words can be read is easier to trust and to check.
SetCompress off

VIProductVersion "${VERSION}.0"
VIAddVersionKey "ProductName" "NextGenOS Setup Studio"
VIAddVersionKey "CompanyName" "NextGenOS"
VIAddVersionKey "FileDescription" "Opens the NextGenOS Setup Studio"
VIAddVersionKey "FileVersion" "${VERSION}"
VIAddVersionKey "LegalCopyright" "(c) 2026 NextGenOS. All rights reserved."

Section
  SetOutPath "$EXEDIR\${STUDIO_DIR}"
  IfFileExists "$EXEDIR\${STUDIO_DIR}\node\node.exe" 0 missing
  IfFileExists "$EXEDIR\${STUDIO_DIR}\studio.mjs" 0 missing
  ; ShellExecute with a hidden window: the Studio's program runs, and no console window is shown.
  ExecShell "open" "$EXEDIR\${STUDIO_DIR}\node\node.exe" "studio.mjs serve --app" SW_HIDE
  Quit
missing:
  MessageBox MB_OK|MB_ICONSTOP "The Setup Studio's files are not all here.$\r$\n$\r$\nUnpack the whole zip file into a folder (Right-click, Extract All) and open Setup Studio from that folder, not from inside the zip."
SectionEnd
