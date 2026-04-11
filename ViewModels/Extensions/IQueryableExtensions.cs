using System.Linq;
using System.Linq.Expressions;

namespace ViewModels.Extensions;

public static class IQueryableExtensions
{
    public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName) =>
        (IOrderedQueryable<TSource>) source.GetResult(propertyName, "OrderBy", 2);
        
    public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> source, string propertyName) =>
        (IOrderedQueryable<TSource>) source.GetResult(propertyName, "OrderByDescending", 2);
    
    public static IOrderedQueryable<TSource> ThenBy<TSource>(this IOrderedQueryable<TSource> source, string propertyName) =>
        (IOrderedQueryable<TSource>) source.GetResult(propertyName, "ThenBy", 2);
        
    public static IOrderedQueryable<TSource> ThenByDescending<TSource>(this IOrderedQueryable<TSource> source, string propertyName) =>
        (IOrderedQueryable<TSource>) source.GetResult(propertyName, "ThenByDescending", 2);

    private static IQueryable<TSource> GetResult<TSource>(this IQueryable<TSource> source, string propertyName, string method, int parameters)
    {
        // LAMBDA: x => x.[PropertyName]
        var parameter = Expression.Parameter(typeof(TSource), "x");
        Expression property = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda(property, parameter);

        // REFLECTION: source.OrderBy(x => x.Property)
        var orderByMethod = typeof(Queryable).GetMethods().First(x => x.Name == method && x.GetParameters().Length == parameters);
        var orderByGeneric = orderByMethod.MakeGenericMethod(typeof(TSource), property.Type);
        var result = orderByGeneric.Invoke(null, new object[] { source, lambda });

        return (IQueryable<TSource>)result;
    }
}