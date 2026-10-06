@echo off
rem Opens the NextGenOS Setup Studio with a window that shows what it says, for finding a problem. The normal way is the "Setup Studio" icon, which has no such window.
cd /d "%~dp0tools\setup-studio"
"node\node.exe" studio.mjs serve --open
pause
