#!/bin/bash

# Navigate to the directory
cd testautomation/playwright

# Run Playwright tests
npm run playwright:run

# Pause to keep the terminal open
read -p "Press Enter to exit..."
