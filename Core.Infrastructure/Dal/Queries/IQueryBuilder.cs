using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Infrastructure.Dal.Queries
{
    public interface IQueryBuilder<TEntity> where TEntity : class
    {
        /// <summary>
        /// Builds query object which returns filtered set of entities
        /// </summary>
        /// <param name="query">Customer defined query rules</param>
        /// <param name="includeProperties">Included into result properties</param>
        /// <returns><see cref="IQuery{TEntity}"/>Query execution object</returns>
        IQuery<TEntity> Build(Func<IQueryableProvider, IQueryable<TEntity>> query, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Builds query object which returns not filtered set of entities
        /// </summary>
        /// <param name="includeProperties">Included into result properties</param>
        /// <returns><see cref="IQuery{TEntity}"/>Query execution object</returns>
        IQuery<TEntity> Build(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
