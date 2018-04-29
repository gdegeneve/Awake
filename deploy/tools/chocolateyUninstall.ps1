$ErrorActionPreference = 'Stop'

$packageName = "awake"
$toolsDir = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$fileLocation = "$(Join-Path $toolsDir $packageName).exe"

Get-Process | Where-Object {$_.Path -like $fileLocation} | Stop-Process -Force