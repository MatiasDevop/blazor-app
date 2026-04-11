using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class PotentialConnectionProfile : Profile
    {
        public PotentialConnectionProfile()
        {
            CreateMap<PotentialConnection, PotentialConnectionDto>()
                .ForMember(x => x.UserId,
                opt =>
                    opt.MapFrom(src => src.Match.Id));
        }
    }
}