using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace System
{
    public static partial class CollectionExtensions
    {
        public static Dictionary<int, TValue> ToDictionary<TValue>(this IList<TValue> source) => source?.ToDictionary(m => source.IndexOf(m));
        public static ILookup<int, TValue> ToLookup<TValue>(this IList<TValue> source) => source?.ToLookup(m => source.IndexOf(m));
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool where, Expression<Func<TSource, int, bool>> predicate) => where ? source?.Where(predicate) : source;
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool where, Expression<Func<TSource, bool>> predicate) => where ? source?.Where(predicate) : source;
    }
}
