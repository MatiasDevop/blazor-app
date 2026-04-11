using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<Address, FullAddressDto>();
            CreateMap<FullAddressDto, Address>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore());
        }
    }
}