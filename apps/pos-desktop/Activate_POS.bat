@echo off
title Activate Smart Retail OS by NextGen OS
echo Activating Smart Retail OS Enterprise Edition...
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0Activate_POS.ps1"
pause
