using AutoMapper;
using ViewModels.EmailTemplateModels;
using ViewModels.Requests;

namespace Mappings.AutoMapperProfiles;

public class CareerCenterClaimRequestProfile : Profile
{
    public CareerCenterClaimRequestProfile()
    {
        CreateMap<SendCareerCenterClaimRequestedEmailNotification, CareerCenterClaimRequest>()
            .ForMember(d => d.RecipientEmail, o => o.MapFrom(s => s.RecipientEmail))
            .ForMember(d => d.CcName, o => o.MapFrom(s => s.CareerCenterName))
            .ForMember(d => d.ProfileUrl, o => o.MapFrom(s => s.ProfileUrl));
    }
}