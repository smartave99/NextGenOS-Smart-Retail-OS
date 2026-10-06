@echo off
rem For people who work from the source copy: runs the Brand Studio in this terminal and opens a tab in your usual browser. Needs Node.js (https://nodejs.org), version 22 or newer.
rem Staff make a customer's look inside the Setup Studio (a program of its own, no terminal). To open this one as a program of its own: node tools\brand-studio\brand.mjs serve --app
cd /d "%~dp0\..\.."
where node >nul 2>nul || (echo Node.js is not installed. Install it from https://nodejs.org and run this again. & pause & exit /b 1)
node tools\brand-studio\brand.mjs serve --open
pause
