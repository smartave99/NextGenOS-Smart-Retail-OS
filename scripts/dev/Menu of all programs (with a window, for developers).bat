@echo off
rem For developers: a text menu in this window that starts each program from its source, or builds them all. A shop never uses this.
setlocal
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0suite-menu.ps1"
