#!/bin/bash

# installing the client & server
cd client && npm install &
cd server && npm install &

# installing the frameworks
cd testautomation/cypress && npm install
cd testautomation/playwright && npm install
cd testautomation/playwright && npx playwright install
cd testautomation/selenium && dotnet build