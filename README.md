# Swiss Testing Night - Test Automation Tools

## Overview

This repository is dedicated to the Swiss Testing Night event, focusing on testing a System Under Test (SUT) using different Test Automation (TA) tools, including Selenium, Cypress, and Playwright. The SUT used for this demonstration is derived from the [Tab Tracker](https://github.com/codyseibert/tab-tracker) repository by Cody Seibert and updated by [Xebia](https://github.com/xebia/cypress-training/).

## Repository Structure

### Installation and Setup

Before running the tests, ensure you have the necessary dependencies installed:

#### `install_dependencies.bat`

This batch file installs the required dependencies for the project, including the necessary Node.js packages and libraries. For that you need to have [Node Js](https://nodejs.org/en/) installed: You must at least have **NODE version 8.2.1**

For Selenium you need net6.0 installed (command 'dotnet' should work).


```bash
install_dependencies.bat
```

If there are any problems, please run the commands in the file manually.

### Starting the Application

To start the System Under Test (SUT), use the following batch file:

#### `start_application.bat`

This batch file initializes and runs the Tab Tracker application.

```bash
start_application.bat
```

### Running Test Suites

We have test suites written in different Test Automation (TA) tools: Selenium, Cypress, and Playwright. You can run them individually or in sequence using the following batch files:

#### `run_selenium.bat`

This batch file executes the test suite using Selenium.

```bash
run_selenium.bat
```

#### `run_cypress.bat`

This batch file executes the test suite using Cypress.

```bash
run_cypress.bat
```

#### `run_playwright.bat`

This batch file executes the test suite using Playwright.

```bash
run_playwright.bat
```

Each batch file runs a set of predefined test cases for the SUT, using the respective TA tool.

## Getting Started

1. Clone this repository to your local machine:

```bash
git clone https://github.com/your-username/swiss-testing-night-ta-tools.git
```

2. Navigate to the project directory:

```bash
cd swiss-testing-night-ta-tools
```

3. Install dependencies:

```bash
install_dependencies.bat
```

4. Start the application:

```bash
start_application.bat
```

5. Run the desired test suite:

```bash
run_selenium.bat
run_cypress.bat
run_playwright.bat
```

## Special Case (Tricentis Tosca)

1. Install Tricentis Tosca
```bash
"https://xebiagroup.sharepoint.com/:f:/r/sites/productquality.ch/Gedeelde%20documenten/General/Tosca/Tosca%20installation%20packages/2023.1.1?csf=1&web=1&e=AO7VjD"
```

2. Set up new Project

Follow the instruction:
```bash
"https://intranet-swissq.atlassian.net/wiki/spaces/ZUNFT/pages/10156081156/Swiss+Testing+Day+2025"
```

3. Run Execution list with Powershel Script

Please open the toscaexe.ps1 file in a editor and check, if the workplace path and the executionScript path are correct.
Once all path are correct, you can execute the Powershell Script

### Acces Tabtracer App via local network
Since the Tabtracker application does not work in the virtual environment like Parallels Desktop, we use a Windows notebook as a "server" and access it externally from MacBooks.

1. Start the TabTracker Application on your Windows device
2. Make sure all devices are connected to the same network
3. Make sure there is no active firewall between
4. To run the tests you must make sure that the urls match this format: http://*Deine IPv4-Adresse*:8080
5. Make sure to change the baseURL in this file: "*client/src/services/Api.js"
