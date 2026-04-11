using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles
{
    public class MutiSelectionProfile : Profile
    {
        public MutiSelectionProfile()
        {
            CreateMap<IEnumerable<MultiSelection>, Dictionary<string, List<SmartCodeDto>>>();
            //.ConvertUsing<MultiSelectionConverter>();

            CreateMap<IEnumerable<CompanyMultiSelection>, Dictionary<string, List<SmartCodeDto>>>();
            //.ConvertUsing<MultiSelectionConverter>();

            CreateMap<MultiSelection, SmartCodeDto>()
                .IncludeMembers(x => x.Value);
        }
    }
}