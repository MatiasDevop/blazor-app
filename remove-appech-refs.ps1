# PowerShell script to remove Appech references from Portal.Blazor files

$blazorPath = "Portal.Blazor"
$appechPatterns = @(
    "using Appech.Internal.AuthLib.Blazor;",
    "using Appech.Internal.ToastNotifications.Blazor.Domain.Enumerations;",
    "using Appech.Internal.ToastNotifications.Blazor.Services;",
    "@using Appech.Internal.AuthLib.Blazor",
    "@using Appech.Internal.ToastNotifications.Blazor.Domain.Enumerations",
    "@using Appech.Internal.ToastNotifications.Blazor.Services"
)

# Get all C# and Razor files
$files = Get-ChildItem -Path $blazorPath -Recurse -Include *.cs,*.razor | 
    Where-Object { $_.FullName -notlike "*\obj\*" -and $_.FullName -notlike "*\bin\*" }

$filesModified = 0

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    foreach ($pattern in $appechPatterns) {
        # Remove the pattern and any trailing newline
        $content = $content -replace [regex]::Escape($pattern) + "\r?\n?", ""
    }
    
    if ($content -ne $originalContent) {
        Set-Content -Path $file.FullName -Value $content -NoNewline
        Write-Host "Modified: $($file.FullName)" -ForegroundColor Green
        $filesModified++
    }
}

Write-Host "`nTotal files modified: $filesModified" -ForegroundColor Cyan
