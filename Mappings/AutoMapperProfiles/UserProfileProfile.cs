using AutoMapper;
using Constants;
using Domain.Entities;
using ViewModels.Commands;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Mappings.AutoMapperProfiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfile, EmployeeViewModel>()
                .ForMember(t => t.JobTitle,
                    opt => opt
                        .MapFrom(src => src.WorkHistories.OrderBy(w => w.StartDate).FirstOrDefault().JobTitle));

            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfile, PartialUserProfileDto>()
                .IncludeBase<UserProfile, UserLabelVm>()
                .ForMember(x => x.MailingAddress,
                    opt =>
                        opt.MapFrom(src => src.Addresses.FirstOrDefault()));
            CreateMap<UserProfile, FullUserProfileDto>()
                .IncludeBase<UserProfile, PartialUserProfileDto>()
                .ForMember(x => x.Blocks,
                    opt =>
                        opt.MapFrom(src =>
                            src.Blocks.Where(y => !y.ReportOnly && y.DateUnblocked == null).Select(y => y.Blocked.Id)))
                .ForMember(x => x.SchoolClaims,
                    opt =>
                        opt.MapFrom(src => src.SchoolClaims.Select(x => x.Id).ToList()))
                .ForMember(x => x.CompanyClaims,
                    opt =>
                        opt.MapFrom(src => src.CompanyClaims.Select(x => x.Id).ToList()))
                .ForMember(x => x.Connections,
                    opt => opt.MapFrom(src =>
                        src.ApprovedConnections.Where(x => x.DateApproved != null).Select(x => Tuple.Create(x.Initiator.Id, x))
                            .Union(src.InitiatedConnections.Select(x => Tuple.Create(x.Approver.Id, x)))));
            CreateMap<UpdateUserProfileCommand, UserProfile>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore());

            CreateMap<UserProfile, TransitioningUserVm>()
                .IncludeBase<UserProfile, UserProfileDto>();

            CreateMap<BaseRegisterCommand, UserProfile>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore())
                .ForMember(x => x.WorkSamples,
                    opt => opt.Ignore())
                .ForMember(x => x.SocialLinks,
                    opt => opt.Ignore())
                .ForMember(x => x.MultiSelections,
                    opt => opt.Ignore())
                .ForMember(x => x.PrimaryLanguage,
                    opt => opt.Ignore())
                .ForMember(x => x.WorkHistories,
                    opt => opt.Ignore())
                .ForMember(x => x.EducationHistories,
                    opt => opt.Ignore());

            CreateMap<RegisterIndividualCommand, UserProfile>()
                .IncludeBase<BaseRegisterCommand, UserProfile>();

            CreateMap<RegisterOrganizationCommand, UserProfile>()
                .IncludeBase<BaseRegisterCommand, UserProfile>();

            CreateMap<RegisterStudentCommand, UserProfile>()
                .IncludeBase<RegisterIndividualCommand, UserProfile>();

            CreateMap<RegisterEmployeeCommand, UserProfile>()
                .IncludeBase<RegisterIndividualCommand, UserProfile>();

            CreateMap<RegisterCompanyCommand, UserProfile>()
                .IncludeBase<RegisterOrganizationCommand, UserProfile>();

            CreateMap<RegisterCareerCenterCommand, UserProfile>()
                .IncludeBase<RegisterOrganizationCommand, UserProfile>();

            CreateMap<UserProfile, UserLabelVm>()
                .ForMember(x => x.LatestJob,
                    opt =>
                        opt.MapFrom(src => src.WorkHistories.OrderByDescending(x => x.EndDate).FirstOrDefault()));

            CreateMap<UserProfile, EmployeeVm>()
                .IncludeBase<UserProfile, UserLabelVm>()
                .ForMember(x => x.HelpOffered,
                    opt => opt.MapFrom(src =>
                        src.MultiSelections.Where(x => x.Value.SmartType.Name == SmartTypes.HelpNeeded).Distinct()
                            .ToList()));
        }
    }
}