@echo off
title Start Smart Retail OS by NextGen OS
echo Launching Smart Retail OS...
cd /d "%~dp0Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug"
if exist "Smart Retail OS.exe" (
    start "" "Smart Retail OS.exe"
) else (
    start "" "SmartAvenue99 POS.exe"
)
