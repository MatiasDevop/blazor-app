using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class InvoiceHeaderProfile : Profile
    {
        public InvoiceHeaderProfile()
        {
            CreateMap<InvoiceHeader, InvoiceDto>();
        }
    }
}