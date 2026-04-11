using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class JobApplicationAnswerProfile : Profile
{
    public JobApplicationAnswerProfile()
    {
        CreateMap<JobApplicationAnswer, JobApplicationAnswerDto>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.JobApplicationId,
                opt => opt.MapFrom(src => src.JobApplication.Id))
            .ForMember(x => x.QuestionId,
                opt => opt.MapFrom(src => src.Question.Id))
            .ForMember(x => x.AnswerText,
                opt => opt.MapFrom(src => src.AnswerText));
    }
}