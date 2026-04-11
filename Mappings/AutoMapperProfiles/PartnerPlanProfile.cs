using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class PartnerPlanProfile : Profile
    {
        public PartnerPlanProfile()
        {
            CreateMap<PartnerPlan, PartnerPlanDto>()
                .ForMember(x => x.CurrentPrice,
                    opt =>
                        opt.MapFrom(src => src.GetActivePrice()));
            CreateMap<PlanContentSection, PlanContentSectionDto>();
            CreateMap<PlanContent, PlanContentDto>();
            CreateMap<PlanPrice, PlanPriceDto>();
        }
    }
}