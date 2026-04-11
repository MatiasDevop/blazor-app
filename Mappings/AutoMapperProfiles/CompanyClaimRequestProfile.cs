using AutoMapper;
using ViewModels.EmailTemplateModels;
using ViewModels.Requests;

namespace Mappings.AutoMapperProfiles;

public class CompanyClaimRequestProfile : Profile
{
    public CompanyClaimRequestProfile()
    {
        CreateMap<SendCompanyClaimRequestedEmailNotification, CompanyClaimRequest>()
            .ForMember(d => d.RecipientEmail, o => o.MapFrom(s => s.RecipientEmail))
            .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.CompanyName))
            .ForMember(d => d.ProfileUrl, o => o.MapFrom(s => s.ProfileUrl));
    }
}