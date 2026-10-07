; NextGenOS Setup Studio: 1-click Windows Setup Installer
; makensis -DVERSION=1.0.0 -DSOURCE=<folder> -DUNINSTALL_LIST=<uninstall-files.nsh> -DOUTFILE=<setup.exe> -DICON=<studio.ico> SetupStudio.nsi

Unicode true
Target amd64-unicode
ManifestDPIAware true
SetCompressor /SOLID lzma
RequestExecutionLevel admin

!ifndef VERSION
  !error "Pass the version: -DVERSION=1.0.0"
!endif
!ifndef SOURCE
  !error "Pass the source folder: -DSOURCE=...\NextGenOS Setup Studio"
!endif
!ifndef UNINSTALL_LIST
  !error "Pass the list of installed files: -DUNINSTALL_LIST=...\uninstall-files.nsh"
!endif
!ifndef OUTFILE
  !error "Pass the setup file to write: -DOUTFILE=...\NextGenOS-Setup-Studio-Setup.exe"
!endif
!ifndef ICON
  !define ICON "..\launcher\studio.ico"
!endif

!define APP "NextGenOS Setup Studio"
!define COMPANY "NextGenOS"
!define EXE "Setup Studio.exe"
!define UNINSTALL_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\NextGenOS.SetupStudio"
!define MENU_FOLDER "NextGenOS Setup Studio"

!include MUI2.nsh
!include LogicLib.nsh
!include FileFunc.nsh
!include x64.nsh

Name "${APP}"
OutFile "${OUTFILE}"
BrandingText "${COMPANY}"
InstallDir "$PROGRAMFILES64\${COMPANY}\${APP}"
InstallDirRegKey HKLM "${UNINSTALL_KEY}" "InstallLocation"

!define MUI_ICON "${ICON}"
!define MUI_UNICON "${ICON}"

VIProductVersion "${VERSION}.0"
VIAddVersionKey "ProductName" "${APP}"
VIAddVersionKey "CompanyName" "${COMPANY}"
VIAddVersionKey "FileDescription" "${APP} Setup"
VIAddVersionKey "FileVersion" "${VERSION}"
VIAddVersionKey "ProductVersion" "${VERSION}"
VIAddVersionKey "LegalCopyright" "(c) 2026 ${COMPANY}"

!define MUI_ABORTWARNING

!define MUI_WELCOMEPAGE_TITLE "Install ${APP}"
!define MUI_WELCOMEPAGE_TEXT "This installs the ${APP} on this PC.$\r$\n$\r$\nFor NextGenOS staff only: turn customer details into ready-to-install Smart Retail POS packs.$\r$\n$\r$\nClick Next to continue."
!insertmacro MUI_PAGE_WELCOME

!define MUI_PAGE_CUSTOMFUNCTION_LEAVE CheckFolder
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!define MUI_FINISHPAGE_TITLE "${APP} is installed"
!define MUI_FINISHPAGE_TEXT "The Setup Studio has been installed on your PC.$\r$\n$\r$\nIt keeps its files in Documents\NextGenOS Setup Studio."
!define MUI_FINISHPAGE_TEXT_LARGE
!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_TEXT "Open NextGenOS Setup Studio now"
!define MUI_FINISHPAGE_RUN_FUNCTION OpenStudio
!insertmacro MUI_PAGE_FINISH

!define MUI_UNCONFIRMPAGE_TEXT_TOP "${APP} will be removed from this PC. Your project files in Documents\NextGenOS Setup Studio will not be touched."
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

Function CheckFolder
  ${If} ${FileExists} "$INSTDIR\*.*"
    ; allowed if already installed or upgrading
  ${EndIf}
FunctionEnd

Function OpenStudio
  ExecShell "open" "$INSTDIR\${EXE}"
FunctionEnd

Section "Install" SecInstall
  SetOutPath "$INSTDIR"
  File /r "${SOURCE}\*.*"

  ; Shortcuts
  CreateDirectory "$SMPROGRAMS\${MENU_FOLDER}"
  CreateShortcut "$SMPROGRAMS\${MENU_FOLDER}\${APP}.lnk" "$INSTDIR\${EXE}" "" "$INSTDIR\${EXE}" 0
  CreateShortcut "$DESKTOP\${APP}.lnk" "$INSTDIR\${EXE}" "" "$INSTDIR\${EXE}" 0

  ; Uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  CreateShortcut "$SMPROGRAMS\${MENU_FOLDER}\Uninstall ${APP}.lnk" "$INSTDIR\Uninstall.exe"

  ; Registry entries for Add/Remove Programs
  WriteRegStr HKLM "${UNINSTALL_KEY}" "DisplayName" "${APP}"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "DisplayVersion" "${VERSION}"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "Publisher" "${COMPANY}"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "DisplayIcon" "$INSTDIR\${EXE},0"
  WriteRegStr HKLM "${UNINSTALL_KEY}" "UninstallString" '"$INSTDIR\Uninstall.exe"'
  WriteRegStr HKLM "${UNINSTALL_KEY}" "QuietUninstallString" '"$INSTDIR\Uninstall.exe" /S'
  WriteRegStr HKLM "${UNINSTALL_KEY}" "InstallLocation" "$INSTDIR"
  WriteRegDWORD HKLM "${UNINSTALL_KEY}" "NoModify" 1
  WriteRegDWORD HKLM "${UNINSTALL_KEY}" "NoRepair" 1

  ${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
  IntFmt $0 "0x%08X" $0
  WriteRegDWORD HKLM "${UNINSTALL_KEY}" "EstimatedSize" "$0"
SectionEnd

Section "Uninstall" SecUninstall
  ; Shortcuts
  Delete "$DESKTOP\${APP}.lnk"
  Delete "$SMPROGRAMS\${MENU_FOLDER}\${APP}.lnk"
  Delete "$SMPROGRAMS\${MENU_FOLDER}\Uninstall ${APP}.lnk"
  RMDir "$SMPROGRAMS\${MENU_FOLDER}"

  ; Files
  !include "${UNINSTALL_LIST}"
  Delete "$INSTDIR\Uninstall.exe"
  RMDir "$INSTDIR"

  ; Registry
  DeleteRegKey HKLM "${UNINSTALL_KEY}"
SectionEnd
