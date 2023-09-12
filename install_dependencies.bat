:: Client
echo "Install Client"
cd client
call npm i
cd ..

:: Server
echo "Install Server"
cd server
call npm i
cd ..

:: Selenium
echo "Install Selenium"
cd testautomation/selenium
call dotnet build
cd ..

:: Cypress
echo "Install Cypress"
cd cypress
call npm i
cd ..

:: Playwirght
echo "Install Playwright"
cd playwright
call npm i
cd ..
pause