using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ViewModels.Extensions;

public static class IEnumerableExtensions
{
    public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, string propertyName) =>
        (IOrderedEnumerable<TSource>) source.GetResult(propertyName, "OrderBy", 2);
        
    public static IOrderedEnumerable<TSource> OrderByDescending<TSource>(this IEnumerable<TSource> source, string propertyName) =>
        (IOrderedEnumerable<TSource>) source.GetResult(propertyName, "OrderByDescending", 2);
    
    public static IOrderedEnumerable<TSource> ThenBy<TSource>(this IOrderedEnumerable<TSource> source, string propertyName) =>
        (IOrderedEnumerable<TSource>) source.GetResult(propertyName, "ThenBy", 2);
        
    public static IOrderedEnumerable<TSource> ThenByDescending<TSource>(this IOrderedEnumerable<TSource> source, string propertyName) =>
        (IOrderedEnumerable<TSource>) source.GetResult(propertyName, "ThenByDescending", 2);

    private static IEnumerable<TSource> GetResult<TSource>(this IEnumerable<TSource> source, string propertyName, string method, int parameters)
    {
        // LAMBDA: x => x.[PropertyName]
        var parameter = Expression.Parameter(typeof(TSource), "x");
        Expression property = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda(property, parameter);

        // REFLECTION: source.OrderBy(x => x.Property)
        var orderByMethod = typeof(Enumerable).GetMethods().First(x => x.Name == method && x.GetParameters().Length == parameters);
        var orderByGeneric = orderByMethod.MakeGenericMethod(typeof(TSource), property.Type);
        var result = orderByGeneric.Invoke(null, new object[] { source, lambda });

        return (IEnumerable<TSource>)result;
    }
}