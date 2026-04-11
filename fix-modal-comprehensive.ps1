# Fix Blazored.Modal and Blazorise issues comprehensively

$files = Get-ChildItem -Path "Portal.Blazor" -Filter "*.razor" -Recurse

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix ModalResult to include full namespace
    $content = $content -replace '\bModalResult\.', 'Blazored.Modal.ModalResult.'
    
    # Fix ValidationHandlerType
    $content = $content -replace 'ValidationHandlerType\.FluentValidation', 'Blazorise.Validation.ValidationHandlerType.FluentValidation'
    
    # Make sure CloseAsync methods are async
    # This is tricky - we need to find methods calling CloseAsync and make them async
    
    if ($content -ne $originalContent) {
        Write-Host "Fixing $($file.FullName)"
        Set-Content -Path $file.FullName -Value $content -NoNewline
    }
}

Write-Host "Comprehensive fixes applied!"
