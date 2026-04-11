using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class CompanyDocumentProfile : Profile
    {
        public CompanyDocumentProfile()
        {
            CreateMap<CompanyDocumentDto, CompanyDocument>();
            CreateMap<CompanyDocument, PartialCompanyDocumentDto>();
            //.ForMember(x => x.HasFile,
            //    opt => opt.MapFrom(src => src.File != null))
            //.ForMember(x => x.File, opt =>
            //    opt.MapFrom(src => src == null ? null : new AttachmentDto() { FileName = src.File.FileName }));
        }
    }
}