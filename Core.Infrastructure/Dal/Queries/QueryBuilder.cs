using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Infrastructure.Dal.Queries
{
    /// <summary>
    /// Default query builder, builds query for getting all records
    /// </summary>
    /// <typeparam name="TEntity">Entity model type</typeparam>
    public class QueryBuilder<TEntity> : IQueryBuilder<TEntity> where TEntity : class
    {
        public virtual IQuery<TEntity> Build(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return new EntityQuery<TEntity>(q => q.Query<TEntity>(), includeProperties);
        }

        public virtual IQuery<TEntity> Build(Func<IQueryableProvider, IQueryable<TEntity>> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return new EntityQuery<TEntity>(query, includeProperties);
        }
    }
}
