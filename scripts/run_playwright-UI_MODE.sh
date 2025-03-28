#!/bin/bash

# Navigate to the directory
cd testautomation/playwright

# Run Playwright tests
npx playwright test --ui

# Pause to keep the terminal open
read -p "Press Enter to exit..."
