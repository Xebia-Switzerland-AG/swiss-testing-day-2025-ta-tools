@echo off
cd testautomation
cd selenium
curl "http://localhost:8081/reset" && echo.
dotnet test
echo. && curl "http://localhost:8081/reset" && echo.
pause