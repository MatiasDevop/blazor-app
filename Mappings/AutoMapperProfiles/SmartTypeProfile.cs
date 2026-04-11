using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class SmartTypeProfile : Profile
    {
        public SmartTypeProfile()
        {
            CreateMap<SmartType, SmartTypeDto>()
                .ForMember(x => x.SmartCodes,
                    opt => opt.Ignore());
            CreateMap<SmartCode, SmartCodeDto>();
            //CreateMap<SmartCode, Guid>()
            //  .ConvertUsing<SmartCodeConverter>();
            //CreateMap<Guid, SmartCode>()
            //    .ConvertUsing<SmartCodeConverter>();

            CreateMap<SmartCodeDto, SmartCode>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore())
                .ForMember(x => x.Order,
                    opt => opt.Ignore())
                .ForMember(x => x.Code,
                    opt =>
                        opt.MapFrom(src => Guid.NewGuid().ToString()))
                .ForMember(x => x.Description,
                    opt =>
                        opt.MapFrom(src => "User Created Value"))
                .ForMember(x => x.IsCustom,
                    opt =>
                        opt.MapFrom(src => true));
        }
    }
}