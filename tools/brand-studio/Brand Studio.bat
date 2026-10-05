@echo off
rem Opens the Brand Studio in your web browser. Needs Node.js (https://nodejs.org), version 22 or newer.
cd /d "%~dp0\..\.."
where node >nul 2>nul || (echo Node.js is not installed. Install it from https://nodejs.org and run this again. & pause & exit /b 1)
node tools\brand-studio\brand.mjs serve --open
pause
