using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class SocialLinkProfile : Profile
    {
        public SocialLinkProfile()
        {
            CreateMap<SocialLinkDto, SocialLink>();
            CreateMap<SocialLink, SocialLinkDto>();
        }
    }
}