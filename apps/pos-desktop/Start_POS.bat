@echo off
title Start Smart Retail POS by NextGenOS
echo Launching Smart Retail POS...
cd /d "%~dp0Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\bin\Debug"
if exist "Smart Retail POS.exe" (
    start "" "Smart Retail POS.exe"
) else (
    start "" "SmartAvenue99 POS.exe"
)
