using AutoMapper;
using Domain.Entities;
using Enums;
using ViewModels.Commands;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class CompanyClaimProfile : Profile
    {
        public CompanyClaimProfile()
        {
            CreateMap<CompanyClaimDto, CompanyClaim>()
                .ForMember(x => x.CompanyProfile,
                    opt => opt.Ignore())
                .ForMember(x => x.Majors,
                    opt => opt.Ignore())
                .ForMember(x => x.MultiSelections,
                    opt => opt.Ignore())
                .ForMember(x => x.Documents,
                    opt => opt.Ignore())
                .ForMember(x => x.SocialLinks,
                    opt => opt.Ignore())
                .ForMember(x => x.Address,
                    opt => opt.Ignore())
                .ForMember(x => x.AcceptedWorkAuthorizations,
                    opt => opt.Ignore());

            CreateMap<CompanyClaim, CompanyClaimDto>(MemberList.None)
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address,
                    opt => opt.Ignore())
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.CompanyProfile));

            CreateMap<CompanyClaim, CompanyProfileDto>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src.CompanyProfile.Id))
                .ForMember(x => x.Name,
                    opt => opt.MapFrom(src => src.CompanyProfile.Name))
                .ForMember(x => x.City,
                    opt => opt.MapFrom(src => src.Address.City));
            //.ForMember(x => x.State,
            //    opt => opt.MapFrom(src => src.Address.State.Id))
            //.ForMember(x => x.ZipCode,
            //    opt => opt.MapFrom(src => src.Address.ZipCode));

            CreateMap<UpdateCompanyProfileCommand, CompanyClaim>()
                .ForMember(x => x.Address,
                    opt => opt.Ignore())
                .ForMember(x => x.MultiSelections,
                    opt => opt.Ignore())
                .ForMember(x => x.Majors,
                    opt => opt.Ignore())
                .ForMember(x => x.Description,
                    opt =>
                        opt.MapFrom(src => src.Description));

            CreateMap<CompanyClaim, FullCompanyDto>()
                .ForMember(x => x.PartnerPlanId, opt =>
                    opt.MapFrom(src => src.Subscriptions
                        .Where(x => x.Status == SubscriptionStatus.Active)
                        .Select(x => x.Plan.Id)
                        .FirstOrDefault()))
                .ForMember(x => x.Majors,
                    opt => opt.MapFrom(src => src.Majors.Select(x => x.EducationFocus)))
                .ForMember(x => x.ClaimOwnerId,
                    opt =>
                        opt.MapFrom(src => src.UserProfile.Id))
                //.ForMember(x => x.Employees,
                //    opt =>
                //        opt.MapFrom(src =>
                //            src.UserConnections
                //                .Where(x => x.User.ProfileType != ProfileType.Student)
                //                .ToList()))
                .ForMember(x => x.AcceptedWorkAuthorizations,
                    opt =>
                        opt.MapFrom(src =>
                            src.AcceptedWorkAuthorizations.ToList()));
            //.ForMember(dest => dest.ClaimIsActive,
            //    opt =>
            //        opt.MapFrom(src => src.CompanyProfile.ActiveClaim != null));

            CreateMap<UpdateAffinityGroupCommand, CompanyClaim>();

            CreateMap<CompanyClaimWorkAuthorization, CompanyWorkAuthorizationDto>()
                .ForMember(x => x.Id,
                    opt =>
                        opt.MapFrom(src => src.Id));
            //.ForMember(x => x.WorkAuthorization,
            //    opt =>
            //        opt.MapFrom(src => src.WorkAuthorization))
            //.ForMember(x => x.WorkAuthorizationOther,
            //    opt =>
            //        opt.MapFrom(src => src.WorkAuthorizationOther));

            CreateMap<CompanyWorkAuthorizationDto, CompanyClaimWorkAuthorization>()
                .ForMember(x => x.Id,
                    opt => opt.Ignore())
                .ForMember(x => x.CompanyClaim,
                    opt => opt.Ignore());
            //.ForMember(x => x.WorkAuthorization,
            //    opt =>
            //        opt.MapFrom(src => src.WorkAuthorization))
            //.ForMember(x => x.WorkAuthorizationOther,
            //    opt =>
            //        opt.MapFrom(src => src.WorkAuthorizationOther));
        }
    }
}