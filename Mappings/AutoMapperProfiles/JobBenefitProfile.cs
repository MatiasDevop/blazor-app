using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class JobBenefitProfile : Profile
{
    public JobBenefitProfile()
    {
        CreateMap<JobBenefit, JobBenefitDto>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.JopPostId,
                opt => opt.MapFrom(src => src.JobPost.Id))
            .ForMember(x => x.Text,
                opt => opt.MapFrom(src => src.Text));

        CreateMap<JobBenefitDto, JobBenefit>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForPath(x => x.JobPost.Id,
                opt => opt.MapFrom(src => src.JopPostId))
            .ForMember(x => x.Text,
                opt => opt.MapFrom(src => src.Text));
    }
}