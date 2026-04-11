using AutoMapper;
using Domain.Entities;
using Enums;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles;

public class SearchObjectProfile : Profile
{
    public SearchObjectProfile()
    {
        CreateMap<UserProfile, SearchObjectDto>()
            .ForMember(x => x.Title,
                opt =>
                    opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(x => x.Type,
                opt =>
                    opt.MapFrom(src => SearchObjectType.Person))
            //.ForMember(x => x.Passions,
            //    opt =>
            //        opt.MapFrom(src => src.MultiSelections.BySmartType(SmartTypes.Passions).Select(x => x.Label)))
            //.ForMember(x => x.Industries,
            //    opt =>
            //        opt.MapFrom(src => src.MultiSelections.BySmartType(SmartTypes.JobIndustry).Select(x => x.Label)))
            //.ForMember(x => x.Skills,
            //    opt =>
            //        opt.MapFrom(src =>
            //            src.MultiSelections.BySmartType(SmartTypes.ProfessionalCareerSkills).Select(x => x.Label)))
            .ForMember(x => x.Degrees,
                opt =>
                    opt.MapFrom(src => src.EducationHistories
                        .SelectMany(x => x.Majors.Union(x.Minors))
                        .Select(x => x.Name)
                        .Distinct()))
            .ForMember(x => x.WebDomain,
                opt =>
                    opt.MapFrom(src => src.SocialLinks.Select(x => x.Url).Where(x => x != null)))
            .ForMember(x => x.Phones,
                opt =>
                    opt.MapFrom(src => (new[] { src.Mobile, src.Phone }).Where(y => y != null)))
            .ForMember(x => x.Gender,
                opt =>
                    opt.MapFrom(src => src.GenderIdentity == null ? null : src.GenderIdentity.Label))
            .ForMember(x => x.Orientation,
                opt =>
                    opt.MapFrom(src => src.SexualIdentity == null ? null : src.SexualIdentity.Label))
            .ForMember(x => x.UserType,
                opt =>
                    opt.MapFrom(src => src.ProfileType.ToString()))
            .ForMember(x => x.City,
                opt =>
                    opt.MapFrom(src => src.Addresses.Select(x => x.City).FirstOrDefault()))
            .ForMember(x => x.State,
                opt =>
                    opt.MapFrom(src => src.Addresses.Select(x => x.State == null ? null : x.State.Label).FirstOrDefault()));
        CreateMap<CompanyClaim, SearchObjectDto>()
            .ForMember(x => x.Title,
                opt =>
                    opt.MapFrom(src => src.CompanyProfile.Name))
            .ForMember(x => x.Type,
                opt =>
                    opt.MapFrom(src => SearchObjectType.Company))
            .ForMember(x => x.Degrees,
                opt =>
                    opt.MapFrom(src => src.Majors.Select(x => x.EducationFocus.Name).Distinct()))
            .ForMember(x => x.Industries,
                opt =>
                    opt.MapFrom(src => src.MultiSelections.Select(x => x.Value.Label).Distinct()))
            .ForMember(x => x.WebDomain,
                opt =>
                    opt.MapFrom(src => src.SocialLinks.Select(x => x.Url).Where(x => x != null)))
            .ForMember(x => x.Description,
                opt =>
                    opt.MapFrom(src => src.Description))
            .ForMember(x => x.City,
                opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(x => x.State,
                opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.State == null ? null : src.Address.State.Label));
        CreateMap<SchoolClaim, SearchObjectDto>()
            .ForMember(x => x.Title,
                opt =>
                    opt.MapFrom(src => src.CareerCenterName))
            .ForMember(x => x.Type,
                opt =>
                    opt.MapFrom(src => SearchObjectType.CareerCenter))
            .ForMember(x => x.WebDomain,
                opt =>
                    opt.MapFrom(src => src.SocialLinks.Select(x => x.Url).Where(x => x != null)))
            .ForMember(x => x.Description,
                opt =>
                    opt.MapFrom(src => src.WhoWeAre))
            .ForMember(x => x.City,
                opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(x => x.State,
                opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.State == null ? null : src.Address.State.Label))
            .ForMember(x => x.School,
                opt => opt.MapFrom(src => src.School.DisplayName));
    }
}