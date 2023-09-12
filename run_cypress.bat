@echo off
cd testautomation
cd cypress
curl "http://localhost:8081/reset" && echo.
info.vbs
echo. && curl "http://localhost:8081/reset" && echo.
pause