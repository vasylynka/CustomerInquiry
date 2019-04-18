using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Infrastructure.Dal.Queries;

namespace Core.Infrastructure.Dal
{
    public interface IRepository { }

    /// <summary>
    /// General interface for data access
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IGenericRepositoryAsync<TEntity> : IRepository where TEntity : class
    {
        /// <summary>
        /// Gets single entity object by given key, in case of second invoke of object it will be extracted from cache
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="key">Given key</param>
        Task<TEntity> GetAsync<TKey>(TKey key);

        /// <summary>
        /// Gets single entity object by user defined specification
        /// </summary>
        /// <param name="query">
        /// Compiled query object which contains user defined specification
        /// <see cref="IQuery"/>
        /// </param>
        Task<TEntity> GetAsync(IQuery<TEntity> query);
        
        /// <summary>
        /// Gets collection of entity objects by user defined specification
        /// </summary>
        /// <param name="query">Compiled query object which contains user defined specification
        /// <see cref="IQuery"/>
        /// </param>
        Task<List<TEntity>> GetCollectionAsync(IQuery<TEntity> query);
        
        /// <summary>
        /// Adds an entity object to data source
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds a collection of entity objects to data source
        /// </summary>
        /// <param name="entity">Entity instances</param>
        void Add(IEnumerable<TEntity> entity);

        /// <summary>
        /// Remove an entity from data source
        /// </summary>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove a collection of entities from data source
        /// </summary>
        void Remove(IEnumerable<TEntity> entity);
    }
}
