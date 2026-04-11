using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class UserConnectionProfile : Profile
    {
        public UserConnectionProfile()
        {
            CreateMap<UserConnection, UserConnectionDto>();
            CreateMap<Tuple<Guid, UserConnection>, UserConnectionDto>()
                .ForMember(x => x.UserId,
                    opt =>
                        opt.MapFrom(src => src.Item1))
                .IncludeMembers(x => x.Item2);
        }
    }
}