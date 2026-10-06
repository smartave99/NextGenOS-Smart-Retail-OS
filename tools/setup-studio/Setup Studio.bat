@echo off
rem For people working on the Studio from the source copy: runs it in this window and opens a tab in your usual browser. Staff use the bundle's "Setup Studio" icon, which has no terminal. It carries its own Node.js when it came as a bundle (node\node.exe); from a source copy it needs Node.js 22 or newer.
cd /d "%~dp0"
if exist "node\node.exe" ( set "NODE=node\node.exe" ) else ( set "NODE=node" )
where %NODE% >nul 2>nul || if not exist "node\node.exe" (echo Node.js is not installed. Install it from https://nodejs.org and run this again. & pause & exit /b 1)
%NODE% studio.mjs serve --open
pause
