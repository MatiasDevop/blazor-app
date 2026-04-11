using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Mappings.AutoMapperProfiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, CareerCenterCardViewModel>()
                .ForMember(t => t.Name,
                    opt => opt
                        .MapFrom(src => src.UniversityName ?? src.CollegeName));

            CreateMap<SchoolDto, School>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore());

            CreateMap<School, SchoolDto>()
                .ForMember(x => x.ActiveClaimId,
                    opt => opt.MapFrom(src => src.ActiveClaim == null ? (Guid?)null : src.ActiveClaim.Id));
        }
    }
}