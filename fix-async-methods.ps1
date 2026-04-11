# Fix async void methods to async Task in modal components

$modalFiles = Get-ChildItem -Path "Portal.Blazor\Components\Modals","Portal.Blazor\Jobs\Components\Modals" -Filter "*.razor" -Recurse

foreach ($file in $modalFiles) {
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix private void methods that call await to be private async Task
    $content = $content -replace 'private void (On\w+|Handle\w+)\s*\(\s*\)\s*\{([^}]*await\s+ModalInstance\.CloseAsync)', 'private async Task $1()
    {$2'
    
    if ($content -ne $originalContent) {
        Write-Host "Fixing async methods in $($file.FullName)"
        Set-Content -Path $file.FullName -Value $content -NoNewline
    }
}

Write-Host "Async method fixes applied!"
