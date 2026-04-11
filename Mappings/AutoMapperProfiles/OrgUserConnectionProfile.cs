using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Mappings.AutoMapperProfiles
{
    public class OrgUserConnectionProfile : Profile
    {
        public OrgUserConnectionProfile()
        {
            CreateMap<OrgUserConnection, OrgUserConnectionDto>()
                .ForMember(x => x.CompanyId,
                    opt =>
                        opt.MapFrom(src => src.Company == null ? (Guid?)null : src.Company.Id))
                .ForMember(x => x.SchoolId,
                    opt =>
                        opt.MapFrom(src => src.School == null ? (Guid?)null : src.School.Id))
                .ForMember(x => x.UserId,
                    opt => opt.MapFrom(src => src.User.Id));

            CreateMap<OrgUserConnection, FullOrgUserConnectionDto>()
                .ForMember(x => x.CompanyId,
                    opt =>
                        opt.MapFrom(src => src.Company == null ? (Guid?)null : src.Company.Id))
                .ForMember(x => x.SchoolId,
                    opt =>
                        opt.MapFrom(src => src.School == null ? (Guid?)null : src.School.Id))
                .ForMember(x => x.UserId,
                    opt => opt.MapFrom(src => src.User.Id))
                .ForMember(x => x.UserFullName, opt =>
                    opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

            CreateMap<OrgUserConnectionDto, OrgUserConnection>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore())
                .ForMember(x => x.Company,
                    opt => opt.Ignore())
                .ForMember(x => x.School,
                    opt => opt.Ignore())
                .ForMember(x => x.User,
                    opt => opt.Ignore());

            CreateMap<OrgUserConnection, EmployeeVm>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src.User.Id))
                .ForMember(x => x.Permissions,
                    opt => opt.MapFrom(src => src))
                .IncludeMembers(x => x.User);
        }
    }
}