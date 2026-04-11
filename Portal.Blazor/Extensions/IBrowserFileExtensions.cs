using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Portal.Blazor.Extensions
{
    public static class BrowserFileExtensions
    {
        public static async Task<string> ToBase64String(this IBrowserFile file, long maxFileSize = 512000L)
        {
            using var stream = file.OpenReadStream(maxFileSize);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
