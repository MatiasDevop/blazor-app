using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class EducationHistoryProfile : Profile
    {
        public EducationHistoryProfile()
        {
            CreateMap<EducationHistoryDto, EducationHistory>()
                .IncludeMembers(s => s.School)
                .ForMember(x => x.Majors,
                    opt => opt.Ignore())
                .ForMember(x => x.Minors,
                    opt => opt.Ignore())
                .ForMember(x => x.GraduationDate,
                    opt =>
                        opt.MapFrom(src => src.GraduationDate.Year == 9999 ? DateTime.MaxValue : src.GraduationDate))
                .ForMember(x => x.GradePointAverage,
                    opt =>
                        opt.MapFrom(src => src.GradePointAverage.HasValue ? src.GradePointAverage : null));
            CreateMap<SchoolDto, EducationHistory>(MemberList.None);

            CreateMap<EducationHistory, EducationHistoryDto>().ForMember(x => x.GraduationDate,
                opt =>
                    opt.MapFrom(src => src.GraduationDate.Year == 9999 ? DateTime.MaxValue : src.GraduationDate));
        }
    }
}