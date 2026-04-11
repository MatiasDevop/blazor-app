using AutoMapper;
using ViewModels.EmailTemplateModels;
using ViewModels.Requests;

namespace Mappings.AutoMapperProfiles;

public class CareerCenterPaymentReceivedProfile : Profile
{
    public CareerCenterPaymentReceivedProfile()
    {
        CreateMap<SendCareerCenterAchCheckInvoicePaidEmailNotification, CareerCenterPaymentReceived>()
            .ForMember(d => d.RecipientEmail, o => o.MapFrom(s => s.RecipientEmail))
            .ForMember(d => d.CcName, o => o.MapFrom(s => s.CareerCenterName))
            .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount.ToString("$#,##0.00")))
            .ForMember(d => d.StartDate, o => o.MapFrom(s => s.StartDate.ToString("MMMM dd, yyyy")))
            .ForMember(d => d.ExpireDate, o => o.MapFrom(s => s.ExpireDate.ToString("MMMM dd, yyyy")))
            .ForMember(d => d.ProfileUrl, o => o.MapFrom(s => s.ProfileUrl))
            .ForMember(d => d.Approved, o => o.MapFrom(s => s.Approved ? "true" : "false"));
    }
}