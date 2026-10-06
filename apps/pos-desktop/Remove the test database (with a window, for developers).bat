@echo off
rem For developers: removes the throw-away SQL Server container used to test the POS. A shop never uses this. It shows a window on purpose, so the person sees what it removed.
title Teardown POS Test Environment
echo ====================================================
echo Cleaning up SmartAvenue99 POS Test Container...
echo ====================================================
docker stop pos-sql-server
docker rm -f pos-sql-server
echo.
echo ====================================================
echo Cleanup completed successfully!
echo The temporary Azure SQL container and its databases
echo have been completely removed from your system.
echo ====================================================
pause
