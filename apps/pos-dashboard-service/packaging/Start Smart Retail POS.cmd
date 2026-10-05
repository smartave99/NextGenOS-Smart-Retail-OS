@echo off
rem Starts Smart Retail POS and opens it in its own window.
cd /d "%~dp0"
start "Smart Retail POS" /min SmartRetail.Pos.Web.exe
rem Give the app a moment to start listening on 127.0.0.1:5080.
timeout /t 3 /nobreak >nul
start "" msedge --app=http://127.0.0.1:5080 || start "" http://127.0.0.1:5080
