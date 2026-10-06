@echo off
rem For developers: starts the Windows POS from the folder Visual Studio built it into. A shop never uses this: the setup puts an icon on the desktop and in the Start menu.
setlocal
cd /d "%~dp0..\..\apps\pos-desktop"
if exist "Start POS from the build folder (with a window, for developers).bat" (
    call "Start POS from the build folder (with a window, for developers).bat"
) else (
    echo Error: "Start POS from the build folder (with a window, for developers).bat" was not found in apps\pos-desktop.
    pause
)
