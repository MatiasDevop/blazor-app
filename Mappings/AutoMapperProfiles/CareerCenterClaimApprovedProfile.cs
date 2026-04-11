using AutoMapper;
using ViewModels.EmailTemplateModels;
using ViewModels.Requests;

namespace Mappings.AutoMapperProfiles;

public class CareerCenterClaimApprovedProfile : Profile
{
    public CareerCenterClaimApprovedProfile()
    {
        CreateMap<SendCareerCenterClaimApprovedEmailNotification, CareerCenterClaimApproved>()
            .ForMember(d => d.RecipientEmail, o => o.MapFrom(s => s.RecipientEmail))
            .ForMember(d => d.CcName, o => o.MapFrom(s => s.CareerCenterName))
            .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount.ToString("$#,##0.00")))
            .ForMember(d => d.StartDate, o => o.MapFrom(s => s.StartDate.ToString("MMMM dd, yyyy")))
            .ForMember(d => d.ExpireDate, o => o.MapFrom(s => s.ExpireDate.ToString("MMMM dd, yyyy")))
            .ForMember(d => d.ProfileUrl, o => o.MapFrom(s => s.ProfileUrl))
            .ForMember(d => d.InvoicePaid, o => o.MapFrom(s => s.InvoicePaid ? "true" : "false"));
    }
}