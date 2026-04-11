using AutoMapper;
using Domain.Entities;
using ViewModels.Dtos;

namespace Mappings.AutoMapperProfiles.Converters
{
    public class MultiSelectionConverter : ITypeConverter<IEnumerable<MultiSelection>, Dictionary<string, List<SmartCodeDto>>>, ITypeConverter<IEnumerable<CompanyMultiSelection>, Dictionary<string, List<SmartCodeDto>>>
    {
        public Dictionary<string, List<SmartCodeDto>> Convert(IEnumerable<MultiSelection> source, Dictionary<string, List<SmartCodeDto>> destination, ResolutionContext context)
        {
            var dict = new Dictionary<string, List<SmartCodeDto>>();
            foreach (var val in source)
            {
                var key = val.Value.SmartType?.Name;
                if (key == null)
                    continue;
                if (!dict.ContainsKey(key))
                    dict[key] = new List<SmartCodeDto>();
                dict[key].Add(context.Mapper.Map<SmartCodeDto>(val.Value));
            }

            return dict;
        }

        public Dictionary<string, List<SmartCodeDto>> Convert(IEnumerable<CompanyMultiSelection> source, Dictionary<string, List<SmartCodeDto>> destination, ResolutionContext context)
        {
            var dict = new Dictionary<string, List<SmartCodeDto>>();
            foreach (var val in source)
            {
                var key = val.Field ?? val.Value.SmartType.Name;
                if (!dict.ContainsKey(key))
                    dict[key] = new List<SmartCodeDto>();
                dict[key].Add(context.Mapper.Map<SmartCodeDto>(val.Value));
            }

            return dict;
        }
    }
}