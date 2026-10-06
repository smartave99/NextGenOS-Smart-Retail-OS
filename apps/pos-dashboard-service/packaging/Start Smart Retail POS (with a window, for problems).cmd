@echo off
rem Opens Smart Retail POS in this window so that you can read what it says, for finding a problem.
rem The normal way is "Start Smart Retail POS" (the icon), which has no such window. Closing this window stops the program.
cd /d "%~dp0"
echo Smart Retail POS is starting. It answers at http://127.0.0.1:5080 when it is ready.
echo Leave this window open while you use it. To stop it, close this window.
echo.
SmartRetail.Pos.Web.exe
echo.
echo Smart Retail POS has stopped. If the lines above say why, send them to the person who gave you the program.
pause
