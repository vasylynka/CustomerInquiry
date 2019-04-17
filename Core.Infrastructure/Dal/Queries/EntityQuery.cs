using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Infrastructure.Dal.Queries
{
    public class EntityQuery<TEntity> : IQuery<TEntity> where TEntity : class
    {
        public EntityQuery(
            Func<IQueryableProvider, IQueryable<TEntity>> query,
            Expression<Func<TEntity, object>>[] includeProperties)
        {
            Query = query;
            IncludeProperties = includeProperties;
        }

        public Func<IQueryableProvider, IQueryable<TEntity>> Query { get; }

        public Expression<Func<TEntity, object>>[] IncludeProperties { get; }
    }
}
