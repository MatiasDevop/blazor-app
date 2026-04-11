using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class JobRequirementGroupProfile : Profile
{
    public JobRequirementGroupProfile()
    {
        CreateMap<JobRequirementGroup, JobRequirementGroupDto>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.JobPostId,
                opt => opt.MapFrom(src => src.JobPost.Id))
            .ForMember(x => x.Label,
                opt => opt.MapFrom(src => src.Label))
            .ForMember(x => x.Order,
                opt => opt.MapFrom(src => src.Order))
            .ForMember(x => x.Requirements,
                opt => opt.MapFrom(src => src.Requirements));

        CreateMap<JobRequirementGroupDto, JobRequirementGroup>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForPath(x => x.JobPost.Id,
                opt => opt.MapFrom(src => src.JobPostId))
            .ForMember(x => x.Label,
                opt => opt.MapFrom(src => src.Label))
            .ForMember(x => x.Order,
                opt => opt.MapFrom(src => src.Order))
            .ForMember(x => x.Requirements,
                opt => opt.MapFrom(src => src.Requirements));
    }
}