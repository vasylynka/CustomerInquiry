using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure.Dal;
using CustomerInquiry.EntityFramework.Infrastructure;

namespace CustomerInquiry.EntityFramework
{
    public class EntityFrameworkUnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly DbContext _context;

        public EntityFrameworkUnitOfWorkAsync()
        {
            _context = new CustomerInquiryDbContext();
        }

        public IGenericRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var provider = new EntityFrameworkQueryableProvider(_context);
            return new EntityFrameworkRepositoryAsync<TEntity>(_context, provider);
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
