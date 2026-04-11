using AutoMapper;
using Domain.Entities;
using ViewModels.Commands;

namespace Mappings.AutoMapperProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<CreatePaymentMethodCommand, PaymentMethod>(MemberList.None)
                .ForMember(x => x.NameOnCard,
                    opt => opt.MapFrom(src => src.Cardholder))
                .ForMember(x => x.StripeId,
                    opt => opt.MapFrom(src => $"{src.CustomerId}:{src.PaymentMethodId}"))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ExpirationMonth,
                    opt => opt.MapFrom(src => src.ExpirationMonth))
                .ForMember(dest => dest.ExpirationYear,
                    opt => opt.MapFrom(src => src.ExpirationYear))
                .ForMember(dest => dest.MaskedAccount,
                    opt => opt.MapFrom(src => src.MaskedAccount));
        }
    }
}