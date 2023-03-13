Write-Host "Install msbuild"

Install-Module -Name Invoke-MsBuild -RequiredVersion 2.6.2

Write-Host "Run msbuild on SLN file"

Invoke-MsBuild -Path "pubsubsample.sln" -MsBuildParameters "/target:Clean;Build /property:Configuration=Release"

Write-Host "Msbuild finished"