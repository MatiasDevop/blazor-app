using AutoMapper;
using Domain.Entities;
using Enums;
using ViewModels.Commands;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class SchoolClaimProfile : Profile
    {
        public SchoolClaimProfile()
        {
            CreateMap<SchoolClaimDto, SchoolClaim>()
                .ForMember(x => x.School,
                    opt => opt.Ignore())
                .ForMember(x => x.Documents,
                    opt => opt.Ignore())
                .ForMember(x => x.SocialLinks,
                    opt => opt.Ignore())
                .ForMember(x => x.Address,
                    opt => opt.Ignore());

            CreateMap<SchoolClaim, SchoolDto>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src.School.Id))
                .ForMember(x => x.HasCareerCenter,
                    opt => opt.MapFrom(src => true))
                .ForMember(x => x.CollegeName,
                    opt => opt.MapFrom(src => src.School.CollegeName))
                .ForMember(x => x.UniversityName,
                    opt => opt.MapFrom(src => src.School.UniversityName))
                .ForMember(x => x.City,
                    opt => opt.MapFrom(src => src.Address.City))
                .ForMember(x => x.State,
                    opt => opt.MapFrom(src => src.Address.State.Id))
                .ForMember(x => x.ZipCode,
                    opt => opt.MapFrom(src => src.Address.ZipCode));

            CreateMap<SchoolClaim, SchoolClaimDto>(MemberList.None)
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Documents,
                    opt => opt.MapFrom(src => src.Documents))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Logo,
                    opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest => dest.School,
                    opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Website,
                    opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.InstitutionType,
                    opt => opt.MapFrom(src => src.InstitutionType))
                .ForMember(dest => dest.OrganizationSize,
                    opt => opt.MapFrom(src => src.OrganizationSize))
                .ForMember(dest => dest.SocialLinks,
                    opt => opt.MapFrom(src => src.SocialLinks))
                .ForMember(dest => dest.CareerCenterName,
                    opt => opt.MapFrom(src => src.CareerCenterName))
                .ForMember(dest => dest.WhoWeAre,
                    opt => opt.MapFrom(src => src.WhoWeAre))
                .ForMember(dest => dest.PartnerPlan,
                    opt => opt.MapFrom(src => src.Subscriptions.FirstOrDefault(x => x.Status == SubscriptionStatus.Active).Plan))
                .ForMember(dest => dest.VideoUrl,
                    opt => opt.MapFrom(src => src.VideoUrl));


            CreateMap<SchoolClaim, FullCareerCenterDto>()
                .ForMember(x => x.PartnerPlanId, opt =>
                    opt.MapFrom(src => src.Subscriptions
                        .Where(x => x.Status == SubscriptionStatus.Active)
                        .Select(x => x.Plan.Id)
                        .FirstOrDefault()))
                .ForMember(x => x.ClaimOwnerId,
                    opt =>
                        opt.MapFrom(src => src.UserProfile.Id))
                .ForMember(x => x.Employees,
                    opt =>
                        opt.MapFrom(src =>
                            src.UserConnections
                                .Where(x => x.User.ProfileType != ProfileType.Student)
                                .ToList()));

            CreateMap<UpdateCareerCenterProfileCommand, SchoolClaim>()
                .ForMember(x => x.Address,
                opt => opt.Ignore());
        }
    }
}