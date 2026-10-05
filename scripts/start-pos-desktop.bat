@echo off
setlocal
cd /d "%~dp0..\apps\pos-desktop"
if exist "Start_POS.bat" (
    call "Start_POS.bat"
) else (
    echo Error: Start_POS.bat not found in apps\pos-desktop.
    pause
)
