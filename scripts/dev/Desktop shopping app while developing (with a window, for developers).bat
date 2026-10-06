@echo off
rem For developers: runs the desktop shopping app (Electron) from its source, in this window (it needs Node.js).
setlocal
cd /d "%~dp0..\..\apps\storefront-web-mobile"
echo Starting the desktop shopping app (Electron)...
if not exist "node_modules\" (
    echo Installing dependencies...
    call npm install
)
call npm run desktop
