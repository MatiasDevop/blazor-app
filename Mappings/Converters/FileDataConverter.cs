using AutoMapper;
using ViewModels.Dtos;
using Domain.Entities;

namespace Mappings.Converters
{
    public class FileDataConverter : ITypeConverter<AttachmentDto, FileAttachment>, ITypeConverter<FileAttachment, AttachmentDto>
    {
        public FileAttachment Convert(AttachmentDto source, FileAttachment destination, ResolutionContext context)
        {
            if (source == null)
                return null;
            if (destination == null)
                return new FileAttachment
                {
                    FileName = source.FileName,
                    Content = string.IsNullOrEmpty(source.FileContent) ? Array.Empty<byte>() : System.Convert.FromBase64String(source.FileContent),
                };
            destination.FileName = source.FileName;
            if (!string.IsNullOrEmpty(source.FileContent))
                destination.Content = System.Convert.FromBase64String(source.FileContent);
            return destination;
        }

        public AttachmentDto Convert(FileAttachment source, AttachmentDto destination, ResolutionContext context) =>
            source == null
                ? null
                : new AttachmentDto()
                {
                    FileName = source.FileName,
                    FileContent = source.Content == null ? null : System.Convert.ToBase64String(source.Content)
                };
    }
}