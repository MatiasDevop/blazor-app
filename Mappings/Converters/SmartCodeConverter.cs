using AutoMapper;
using Domain.Entities;
using Mappings.Abstractions;

namespace Mappings.AutoMapperProfiles.Converters
{
    public class SmartCodeConverter : ITypeConverter<Guid, SmartCode>, ITypeConverter<SmartCode, Guid>
    {
        private readonly ISmartCodeLookup _lookup;

        public SmartCodeConverter(ISmartCodeLookup lookup)
        {
            _lookup = lookup;
        }
        
        public SmartCode Convert(Guid source, SmartCode destination, ResolutionContext context) =>
            _lookup.GetById(source);

        public Guid Convert(SmartCode source, Guid destination, ResolutionContext context) =>
            source?.Id ?? Guid.Empty;
    }
}