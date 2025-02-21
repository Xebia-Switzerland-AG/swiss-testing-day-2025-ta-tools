<#  
  // *************************** PS Script to Run TCShell Script***************************  
  // This script logs into Tosca Workspace, executes all TCs in an execution lists  
  // in the specified folder, and checks them back in after execution.  
#>

# ************************** INIT VARIABLES **************************
$username = "Admin"
$password = "" # Add password if required
$workspacePath = "C:\Tosca_Projects\Tosca_Workspaces\STD\STD.tws"
$executionScriptPath = "C:\Xebia\exelist.tcs"
$tcshellPath = "C:\Program Files (x86)\TRICENTIS\Tosca Testsuite\ToscaCommander\TCShell.exe"

$datecode = Get-Date -Format yyyyMMdd_HHmmss
$logFilePath = "$PSScriptRoot\tosca_log_$datecode.txt"

# ************************** VALIDATE SCRIPT FILE **************************
if (!(Test-Path $executionScriptPath)) {
    Write-Host "Error: TCS script not found at $executionScriptPath"
    exit 1
}

if (!(Test-Path $tcshellPath)) {
    Write-Host "Error: TCShell.exe not found at $tcshellPath"
    exit 1
}

# ************************** EXECUTE TOSCA COMMANDER **************************  
try {
    Write-Host "Starting Tosca Commander..."
    $arguments = "-workspace `"$workspacePath`" -login `"$username`" `"$password`" `"$executionScriptPath`""
    Start-Process -FilePath `"$tcshellPath`" -ArgumentList $arguments -NoNewWindow -RedirectStandardOutput $logFilePath -Wait
    Write-Host "Tosca Commander execution completed. Logs saved to $logFilePath"
} catch {
    Write-Host "Error: Failed to execute Tosca Commander. Details: $_"
    exit 1
}