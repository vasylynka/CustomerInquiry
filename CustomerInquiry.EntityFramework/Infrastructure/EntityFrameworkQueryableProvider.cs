using System.Data.Entity;
using System.Linq;
using Core.Infrastructure.Dal.Queries;

namespace CustomerInquiry.EntityFramework.Infrastructure
{
    public class EntityFrameworkQueryableProvider : IQueryableProvider
    {
        private readonly DbContext _context;

        public EntityFrameworkQueryableProvider(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            return query;
        }
    }
}
