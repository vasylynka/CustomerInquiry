using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Infrastructure.Dal;
using Core.Infrastructure.Dal.Queries;

namespace Core.Infrastructure.Extensions
{
    public static class DalExtensions
    {
        /// <summary>
        /// Loads single result found by key from previous requests
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <typeparam name="TKey">Entity key type</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="key">Entity key</param>
        public static Task<TEntity> LoadAsync<TEntity, TKey>(this IUnitOfWorkAsync unitOfWorkAsync, TKey key) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            return repository.GetAsync(key);
        }

        /// <summary>
        /// Gets single result from data source using default query builder
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="predicate">Custom filter predicate</param>
        /// <param name="includeProperties">Included into result objects properties</param>
        public static Task<TEntity> LoadAsync<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync,
                                                  Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            return repository.GetAsync(new QueryBuilder<TEntity>().Build(p => p.Query<TEntity>().Where(predicate), includeProperties));
        }

        /// <summary>
        /// Gets collection result from data source using default query builder
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="predicate">Custom filter predicate</param>
        /// <param name="includeProperties">Included into result objects properties</param>
        public static Task<List<TEntity>> LoadCollectionAsync<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync,
            Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            return repository.GetCollectionAsync(new QueryBuilder<TEntity>().Build(p => p.Query<TEntity>().Where(predicate), includeProperties));
        }

        /// <summary>
        /// Remove entity item from data source using default query builder
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="predicate">Custom filter predicate</param>
        public static async Task RemoveAsync<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync, Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            var entity = await unitOfWorkAsync.LoadAsync(predicate);

            repository.Remove(entity);
        }

        /// <summary>
        /// Remove entity items from data source using default query builder
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="entities">List of entities to remove</param>
        public static void Remove<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync, IEnumerable<TEntity> entities) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            repository.Remove(entities);
        }

        /// <summary>
        /// Remove entity item from data source
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="entity"></param>
        public static void Remove<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync, TEntity entity) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            repository.Remove(entity);
        }

        /// <summary>
        /// Add entity item to data source
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="entity"></param>
        public static void Add<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync, TEntity entity) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            repository.Add(entity);
        }

        /// <summary>
        /// Add entity items to data source
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        /// <param name="unitOfWorkAsync"></param>
        /// <param name="entities"></param>
        public static void Add<TEntity>(this IUnitOfWorkAsync unitOfWorkAsync, IEnumerable<TEntity> entities) where TEntity : class
        {
            var repository = unitOfWorkAsync.GetRepository<TEntity>();
            repository.Add(entities);
        }
    }
}
