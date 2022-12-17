using System;
using System.Linq;
using System.Linq.Expressions;

namespace HelpDebugGov.Application.Extensions;

public static class FilterExtensions
{
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
    {
        if (condition) return source.Where(predicate);

        return source;
    }
}