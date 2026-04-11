using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class UserFavoriteProfile : Profile
    {
        public UserFavoriteProfile()
        {
            CreateMap<UserFavoriteDto, UserFavorite>();
            CreateMap<UserFavorite, UserFavoriteDto>();
        }
    }
}