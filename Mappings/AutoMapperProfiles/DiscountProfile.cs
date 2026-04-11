using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, DiscountDto>()
                .ForMember(x => x.TargetPlan,
                    opt => opt.MapFrom(src => src.TargetPlan == null ? (Guid?)null : src.TargetPlan.Id));
        }
    }
}