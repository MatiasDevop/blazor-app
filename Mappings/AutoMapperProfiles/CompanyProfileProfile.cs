using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class CompanyProfileProfile : Profile
    {
        public CompanyProfileProfile()
        {
            CreateMap<CompanyProfile, CompanyDto>();
            CreateMap<CompanyProfile, CompanyProfileDto>()
                .ForMember(x => x.ActiveClaimId,
                    opt => opt.MapFrom(src => src.ActiveClaim == null ? (Guid?)null : src.ActiveClaim.Id));
            CreateMap<CompanyProfileDto, CompanyProfile>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore());
        }
    }
}