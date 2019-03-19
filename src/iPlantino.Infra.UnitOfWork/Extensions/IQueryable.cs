using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.EntityFrameworkCore
{
    public static class IQueryable
    {
        public static IQueryable<TSource> Distinct<TSource, TCompare>(
             this IQueryable<TSource> source, Func<TSource, TCompare> selector)
        {
            return source.Distinct(new EqualityComparer<TSource, TCompare>(selector));
        }

        public static IQueryable<TSource> Intersect<TSource, TCompare>(
             this IQueryable<TSource> source, IQueryable<TSource> intersect, Func<TSource, TCompare> selector)
        {
            return source.Intersect(intersect, new EqualityComparer<TSource, TCompare>(selector));
        }

        public static IQueryable<TSource> Except<TSource, TCompare>(
            this IQueryable<TSource> source, IQueryable<TSource> Except, Func<TSource, TCompare> selector)
        {
            return source.Except(Except, new EqualityComparer<TSource, TCompare>(selector));
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                        (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params string[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query;
        }

        public static IQueryable<T> OrderPaging<T>(this IQueryable<T> OriginalObject, string sortColumn, string sortDirection, int iDisplayStart, int iDisplayLength)
        {
            if (!string.IsNullOrEmpty(sortColumn) && sortColumn.Length > 0)
            {
                var sortList = sortColumn.Split('.');
                if (sortDirection == "desc")
                {
                    OriginalObject = sortList.Length == 2 ? OriginalObject
                            .OrderByDescending(x => x.GetType().GetProperty(sortList[0]).GetValue(x, null) != null ?
                                                    x.GetType().GetProperty(sortList[0]).GetValue(x, null).GetType().GetProperty(sortList[1]).GetValue(x.GetType().GetProperty(sortList[0]).GetValue(x, null), null) :
                                                    true) : OriginalObject
                            .OrderByDescending(x => x.GetType().GetProperty(sortColumn) != null ?
                                                    x.GetType().GetProperty(sortColumn).GetValue(x, null) :
                                                    true);
                }
                else
                {
                    OriginalObject = sortList.Length == 2 ? OriginalObject
                            .OrderBy(x => x.GetType().GetProperty(sortList[0]).GetValue(x, null) != null ?
                                          x.GetType().GetProperty(sortList[0]).GetValue(x, null).GetType().GetProperty(sortList[1]).GetValue(x.GetType().GetProperty(sortList[0]).GetValue(x, null), null) :
                                          true) : OriginalObject
                            .OrderBy(x => x.GetType().GetProperty(sortColumn) != null ?
                                          x.GetType().GetProperty(sortColumn).GetValue(x, null) :
                                          true);
                }
            }

            return OriginalObject.Skip(iDisplayStart).Take(iDisplayLength);
        }
    }
}