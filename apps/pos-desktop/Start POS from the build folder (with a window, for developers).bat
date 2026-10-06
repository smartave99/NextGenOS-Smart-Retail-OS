@echo off
rem For developers: starts the POS from the folder Visual Studio built it into (bin\Debug). A shop never uses this: the setup (installer\SmartRetailOS_Setup.iss) puts a Start menu
rem entry and a desktop icon that open "SmartAvenue99 POS.exe" directly, with no black window. This file shows one for a moment, which is why its name says so.
title Start Smart Retail POS by NextGenOS
echo Launching Smart Retail POS...
cd /d "%~dp0Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug"
if exist "Smart Retail POS.exe" (
    start "" "Smart Retail POS.exe"
) else (
    start "" "SmartAvenue99 POS.exe"
)
