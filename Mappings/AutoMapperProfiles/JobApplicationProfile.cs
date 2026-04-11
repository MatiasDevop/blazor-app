using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class JobApplicationProfile : Profile
{
    public JobApplicationProfile()
    {
        CreateMap<JobApplication, JobApplicationDto>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.JobPostId,
                opt => opt.MapFrom(src => src.JobPost.Id))
            .ForMember(x => x.ApplicantId,
                opt => opt.MapFrom(src => src.Applicant.Id))
            .ForMember(x => x.DateApplied,
                opt => opt.MapFrom(src => src.DateApplied))
            .ForMember(x => x.DateReviewed,
                opt => opt.MapFrom(src => src.DateReviewed))
            .ForMember(x => x.Status,
                opt => opt.MapFrom(src => src.Status))
            .ForMember(x => x.CoverLetter,
                opt => opt.MapFrom(src => src.CoverLetter))
            .ForMember(x => x.Answers,
                opt => opt.MapFrom(src => src.Answers))
            .ForMember(x => x.JobPost,
                opt => opt.MapFrom(src => src.JobPost))
            .ForMember(x => x.Applicant,
                opt => opt.MapFrom(src => src.Applicant));
    }
}