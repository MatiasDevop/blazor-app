using AutoMapper;
using Domain.Entities;
using Mappings.Converters;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            CreateMap<AttachmentDto, FileAttachment>()
                .ConvertUsing<FileDataConverter>();
            CreateMap<FileAttachment, AttachmentDto>()
                .ConvertUsing<FileDataConverter>();
        }
    }
}