# Swiss Testing Day 2025 - Test Automation Tools

## Overview

This repository is dedicated to the Swiss Testing Day 2025 event, focusing on testing a System Under Test (SUT) using different Test Automation (TA) tools, including Selenium, Cypress, and Playwright. The SUT used for this demonstration is derived from the [Tab Tracker](https://github.com/codyseibert/tab-tracker) repository by Cody Seibert and updated by [Xebia](https://github.com/xebia/cypress-training/).

## Repository Structure

## Getting Started

To get started with this project, follow these steps:

Windows users should:

1. Clone this repository to your local machine.
2. Run `setup.bat` from the scripts folder to install the required
   dependencies
3. Execute `start_sut.bat` to start the System Under Test.

MacOS / Linux users should:

1. Clone this repository to your local machine.
2. From the root folder, run `./scripts/setup.sh` to install the required dependencies.
3. From the root folder, run `./scripts/start_sut.sh` to start the
   System Under Test.
4. If you cannot execute the `.sh`-file, try to give it access, like here: `chmod +x ./scripts/setup.sh`

### Running your tests

To make your exploration and testing process more accessible, we've created
some scripts which can be found in the `scripts` folder. These scripts
help you start a testrun with the selected testing tool. The following scripts
can be found in the `scripts` folder:

- **run_cypress** Executes a Cypress test run.
- **run_playwright** Executes a Playwright test run.
- **run_selenium** Executes a Selenium test run.


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
