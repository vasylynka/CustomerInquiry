using System.Linq;

namespace Core.Infrastructure.Dal.Queries
{
    public interface IQueryableProvider
    {
        /// <summary>
        /// Provides IQueryable object from given Entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns></returns>
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    }
}
