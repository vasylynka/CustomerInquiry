using System;
using System.Threading.Tasks;

namespace Core.Infrastructure.Dal
{
    public interface IUnitOfWorkAsync : IDisposable
    {
        /// <summary>
        /// Creates repository instance for Entity
        /// </summary>
        /// <typeparam name="TEntity">Entity model</typeparam>
        IGenericRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class;

        /// <summary>
        /// Save all changes under single transaction
        /// </summary>
        /// <returns>Status code</returns>
        Task<int> SaveChanges();
    }
}
