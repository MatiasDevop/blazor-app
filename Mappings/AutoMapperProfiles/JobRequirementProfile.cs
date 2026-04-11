using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class JobRequirementProfile : Profile
{
    public JobRequirementProfile()
    {
        CreateMap<JobRequirement, JobRequirementDto>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.GroupId,
                opt => opt.MapFrom(src => src.Group.Id))
            .ForMember(x => x.Text,
                opt => opt.MapFrom(src => src.Text));

        CreateMap<JobRequirementDto, JobRequirement>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForPath(x => x.Group.Id,
                opt => opt.MapFrom(src => src.GroupId))
            .ForMember(x => x.Text,
                opt => opt.MapFrom(src => src.Text));
    }
}