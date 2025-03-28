#!/bin/bash

# installing the client & server
cd client && npm install &
cd server && npm install &

# installing the frameworks
ls
cd testautomation && cd cypress && npm install
cd .. && cd playwright && npm install
cd .. && cd playwright && npx playwright install
cd .. && cd selenium && dotnet build