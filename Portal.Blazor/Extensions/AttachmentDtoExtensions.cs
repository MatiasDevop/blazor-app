using System.Linq;
using ViewModels.Dtos;

namespace Portal.Blazor.Extensions
{
    public static class AttachmentDtoExtensions
    {
        public static string ToDataString(this AttachmentDto dto) =>
            $"data:image/{dto.FileName?.Split('.').LastOrDefault()?.Replace("svg", "svg+xml")};base64, {dto.FileContent}";
    }
}
