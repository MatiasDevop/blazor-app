using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Portal.Blazor.Services;

public class HelperService
{
    public string GetEnumDescription(Enum value)
    {
        return value.GetType()?
            .GetMember(value.ToString())?
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
    }
}
