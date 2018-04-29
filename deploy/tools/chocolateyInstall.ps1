$ErrorActionPreference = 'Stop'

$packageName = "awake"
$toolsDir = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$fileLocation = "$(Join-Path $toolsDir $packageName).exe"

$fileLocation
$toolsDir
$packageName

Get-Process | Where-Object {$_.Name -like $packageName} | Stop-Process -Force
Start-Process $fileLocation


