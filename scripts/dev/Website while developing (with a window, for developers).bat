@echo off
rem For developers: runs the online shop's development server, in this window (it needs Node.js). A customer's website is not opened this way: its package has "Start Website", which has no black window.
setlocal
cd /d "%~dp0..\..\apps\storefront-web-mobile"
echo Starting the online shop's development server (Next.js)...
if not exist "node_modules\" (
    echo Installing dependencies...
    call npm install
)
call npm run dev
