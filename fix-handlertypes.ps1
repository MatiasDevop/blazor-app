# Fix Blazorise HandlerTypes API changes
# Replace HandlerType="HandlerTypes.FluentValidation" with Handler="@ValidationHandlerType.FluentValidation"

$files = Get-ChildItem -Path "Portal.Blazor" -Filter "*.razor" -Recurse

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix HandlerType to Handler
    $content = $content -replace 'HandlerType="HandlerTypes\.FluentValidation"', 'Handler="@ValidationHandlerType.FluentValidation"'
    
    if ($content -ne $originalContent) {
        Write-Host "Fixing $($file.FullName)"
        Set-Content -Path $file.FullName -Value $content -NoNewline
    }
}

Write-Host "HandlerTypes fixes applied!"
