:: Client
echo "=== Install Client ==="
cd ../client
call npm i

:: Server
echo "=== Install Server ==="
cd ../server
call npm i


:: Selenium
echo "=== Install Selenium ==="
cd ../testautomation/selenium
call dotnet build

:: Cypress
echo "=== Install Cypress ==="
cd ../cypress
call npm i

:: Playwirght
echo "=== Install Playwright ==="
cd ../playwright
call npm i
pause