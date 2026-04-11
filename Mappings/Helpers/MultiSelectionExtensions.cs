
using Domain.Entities;

namespace Mappings.Helpers;

public static class MultiSelectionExtensions
{
    public static IEnumerable<SmartCode> BySmartType(this IEnumerable<MultiSelection> values, string smartType) =>
        values.Where(x => x.Value.SmartType?.Name == smartType).Select(x => x.Value);
}