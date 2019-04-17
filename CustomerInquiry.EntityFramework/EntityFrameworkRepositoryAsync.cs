using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Infrastructure.Dal;
using Core.Infrastructure.Dal.Queries;
using CustomerInquiry.EntityFramework.Extensions;

namespace CustomerInquiry.EntityFramework
{
    public class EntityFrameworkRepositoryAsync<TEntity> :
        IGenericRepositoryAsync<TEntity>
         where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IQueryableProvider _queryableProvider;

        public EntityFrameworkRepositoryAsync(DbContext context, IQueryableProvider queryableProvider)
        {
            _context = context;
            _queryableProvider = queryableProvider;
        }

        #region Get single
        public Task<TEntity> GetAsync<TKey>(TKey key)
        {
            return _context.Set<TEntity>().FindAsync(key);
        }

        public Task<TEntity> GetAsync(IQuery<TEntity> query)
        {
            return GetQueryable(query.Query(_queryableProvider), query.IncludeProperties).FirstOrDefaultAsync();
        }


        public Task<TProjection> GetAsync<TProjection>(IQuery<TEntity, TProjection> query) where TProjection : class
        {
            return query.Query(_queryableProvider).FirstOrDefaultAsync();
        }
        #endregion

        #region Collections
        public Task<List<TEntity>> GetCollectionAsync(IQuery<TEntity> query)
        {
            return GetQueryable(query.Query(_queryableProvider), query.IncludeProperties).ToListAsync();
        }

        public Task<List<TProjection>> GetCollectionAsync<TProjection>(IQuery<TEntity, TProjection> query)
        {
            return query.Query(_queryableProvider).ToListAsync();
        }
        #endregion

        #region Adding
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        #endregion

        #region Removing
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion

        private IQueryable<TEntity> GetQueryable(IQueryable<TEntity> query,
                                                 Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties == null ? query
                : query.Include(includeProperties);
        }
    }
}
