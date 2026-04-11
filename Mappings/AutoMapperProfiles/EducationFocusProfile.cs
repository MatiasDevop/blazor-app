using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class EducationFocusProfile : Profile
    {
        public EducationFocusProfile()
        {
            CreateMap<EducationFocus, EducationFocusDto>();
            CreateMap<EducationFocusDto, EducationFocus>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore())
                .ForMember(x => x.IsCustom,
                    opt => opt.MapFrom(x => true));
        }
    }
}