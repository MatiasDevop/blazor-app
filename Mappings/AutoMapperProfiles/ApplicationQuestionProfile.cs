using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class ApplicationQuestionProfile : Profile
{
    public ApplicationQuestionProfile()
    {

        CreateMap<ApplicationQuestion, ApplicationQuestionDto>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Text,
                opt => opt.MapFrom(src => src.Text))
            .ForMember(x => x.JobPostId,
                opt => opt.MapFrom(src => src.JobPost.Id))
            .ForMember(x => x.Answers,
                opt => opt.MapFrom(src => src.Answers));

        CreateMap<ApplicationQuestionDto, ApplicationQuestion>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Text,
                opt => opt.MapFrom(src => src.Text))
            .ForPath(x => x.JobPost.Id,
                opt => opt.MapFrom(src => src.JobPostId))
            .ForMember(x => x.Answers,
                opt => opt.MapFrom(src => src.Answers));
    }
}