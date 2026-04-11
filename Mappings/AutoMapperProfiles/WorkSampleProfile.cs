using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class WorkSampleProfile : Profile
    {
        public WorkSampleProfile()
        {
            CreateMap<WorkSampleDto, WorkSample>();
            CreateMap<WorkSample, WorkSampleDto>()
                .ForMember(x => x.File,
                    opt => opt.Ignore());
        }
    }
}