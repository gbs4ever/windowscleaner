Write-Host "Cleaning previous builds..."

dotnet clean

if (Test-Path ".\publish") {
    Remove-Item ".\publish" -Recurse -Force
}


Write-Host "Publishing WindowsCleanup..."

dotnet publish `
    -c Release `
    -r win-x64 `
    --self-contained true `
    /p:PublishSingleFile=true


$source = ".\bin\Release\net9.0-windows\win-x64\publish"

$destination = ".\publish"


Write-Host "Creating portable package..."

New-Item -ItemType Directory -Force -Path $destination | Out-Null


Copy-Item `
    "$source\WindowsCleanup.exe" `
    "$destination\WindowsCleanup.exe"


Copy-Item `
    ".\README.md" `
    "$destination\README.md"


Write-Host ""
Write-Host "Build complete!"
Write-Host ""
Write-Host "Output:"
Write-Host "$destination\WindowsCleanup.exe"