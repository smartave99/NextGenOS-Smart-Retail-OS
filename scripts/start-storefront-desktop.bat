@echo off
setlocal
cd /d "%~dp0..\apps\storefront-web-mobile"
echo Starting Smart Retail POS Desktop Client (Electron)...
if not exist "node_modules\" (
    echo Installing dependencies...
    call npm install
)
call npm run desktop
