# Fix Blazored.Modal API changes
# The new API uses ModalResult from Blazored.Modal.Services namespace

$files = Get-ChildItem -Path "Portal.Blazor" -Filter "*.razor" -Recurse

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix ModalInstance.CloseAsync(data) to ModalInstance.CloseAsync(ModalResult.Ok(data))
    # Match patterns like: ModalInstance.CloseAsync(someVariable) or ModalInstance.CloseAsync(SomeEnum.Value)
    # But skip patterns that already have ModalResult
    $content = $content -replace '(await\s+)?ModalInstance\.CloseAsync\((?!ModalResult)([\w\.<>]+(?:\[[^\]]+\])?)\)', 'await ModalInstance.CloseAsync(ModalResult.Ok($2))'
    
    # Remove duplicate await keywords
    $content = $content -replace 'await await ModalInstance\.CloseAsync', 'await ModalInstance.CloseAsync'
    
    if ($content -ne $originalContent) {
        Write-Host "Fixing $($file.FullName)"
        Set-Content -Path $file.FullName -Value $content -NoNewline
    }
}

Write-Host "Modal fixes applied!"
