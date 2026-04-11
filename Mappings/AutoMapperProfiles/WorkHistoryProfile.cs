using AutoMapper;
using Domain.Entities;
using Enums;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class WorkHistoryProfile : Profile
    {
        public WorkHistoryProfile()
        {
            CreateMap<WorkHistoryDto, WorkHistory>()
                .ForMember(x => x.Company,
                    opt => opt.Ignore())
                .ForMember(x => x.CareerCenter,
                    opt => opt.Ignore())
                .ForMember(x => x.EndDate,
                    opt =>
                        opt.MapFrom(src => src.EndDate.Year == 9999 ? DateTime.MaxValue : src.EndDate));

            CreateMap<WorkHistory, WorkHistoryDto>()
                .ForMember(x => x.EmploymentCategoryType,
                    opt => opt.MapFrom(src => src.Company == null ? EmploymentCategoryType.CareerCenter : EmploymentCategoryType.Company))
                .ForMember(x => x.EndDate,
                    opt =>
                        opt.MapFrom(src => src.EndDate.Year == 9999 ? DateTime.MaxValue : src.EndDate));
        }
    }
}