using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Portal.Blazor.Extensions;

public static class QueryStringHelper
{
    public static string Build(string uri, object obj)
    {
        var type = obj.GetType();
        var properties = type.GetProperties();
        var values = properties
            .Select(x => ConvertPropertyToString(x, x.GetValue(obj)))
            .Where(v => !string.IsNullOrEmpty(v));
        return $"{uri}?{string.Join('&', values)}";
    }

    private static string ConvertPropertyToString(PropertyInfo prop, object obj)
    {
        if (obj == null)
            return null;
        var type = obj.GetType();
        if (type.IsEnum)
            return $"{prop.Name}={(int) obj}";
        if (type.GetInterfaces().Contains(typeof(IEnumerable)) && type != typeof(string))
        {
            var items = ((IEnumerable) obj).Cast<object>()
                .Select(x => ConvertPropertyToString(prop, x))
                .Where(v => !string.IsNullOrEmpty(v))
                .ToList();
            return items.Count > 0 ? string.Join('&', items) : null;
        }
        var str = obj.ToString();
        return string.IsNullOrEmpty(str) ? null : $"{prop.Name}={HttpUtility.UrlEncode(str)}";
    }
}
