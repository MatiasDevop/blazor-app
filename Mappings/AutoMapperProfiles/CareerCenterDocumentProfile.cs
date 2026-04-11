using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class CareerCenterDocumentProfile : Profile
    {
        public CareerCenterDocumentProfile()
        {
            CreateMap<CareerCenterDocumentDto, CareerCenterDocument>();
            CreateMap<CareerCenterDocument, PartialCareerCenterDocumentDto>()
                .ForMember(x => x.HasFile,
                    opt => opt.MapFrom(src => src.File != null))
                .ForMember(x => x.File, opt => opt.Ignore());
        }
    }
}