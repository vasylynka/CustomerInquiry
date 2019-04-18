using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerInquiry.EntityFramework.Extensions
{
    internal static class LinqDataExtension
    {
        public static IQueryable<TEntity> Include<TEntity>(
            this IQueryable<TEntity> query,
            params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return includeProperties.Aggregate(query,
                (current, includeProperty) => current.Include<TEntity, object>(includeProperty));
        }
    }
}
