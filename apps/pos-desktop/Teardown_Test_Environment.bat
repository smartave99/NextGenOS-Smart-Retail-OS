@echo off
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
