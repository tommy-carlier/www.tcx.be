$url = 'https://download.sysinternals.com/files/SysinternalsSuite.zip'
$zipPath = 'd:\dev\tools\SysinternalsSuite.zip'
$tempFolder = 'd:\dev\tools\temp-sys-internals'
$folder = 'd:\dev\tools\sys-internals'

Write-Host 'Downloading' $url 'to' $zipPath
$web = New-Object System.Net.WebClient
$web.DownloadFile($url, $zipPath)

Write-Host 'Extracting' $zipPath 'to' $tempFolder
Add-Type -assembly 'System.IO.Compression.FileSystem'
[System.IO.Compression.ZipFile]::ExtractToDirectory($zipPath, $tempFolder)

Write-Host 'Copying files from' $tempFolder 'to' $folder
Copy-Item (Join-Path $tempFolder '*') $folder

Write-Host 'Removing temporary files'
Remove-Item $zipPath
Remove-Item $tempFolder -Recurse