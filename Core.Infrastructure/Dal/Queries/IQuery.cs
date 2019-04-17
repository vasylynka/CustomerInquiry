using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Infrastructure.Dal.Queries
{
    public interface IQuery { }

    /// <summary>
    /// Entity query object, contains user defined query rule, global filters and included properties
    /// </summary>
    /// <typeparam name="TEntity">Entity model</typeparam>
    public interface IQuery<TEntity> : IQuery where TEntity : class
    {
        Func<IQueryableProvider, IQueryable<TEntity>> Query { get; }

        Expression<Func<TEntity, object>>[] IncludeProperties { get; }
    }

    /// <summary>
    ///  Projection query object, contains user defined query rule, global filters and included properties
    /// </summary>
    /// <typeparam name="TEntity">Entity model</typeparam>
    /// <typeparam name="TProjection">Projection model</typeparam>
    public interface IQuery<TEntity, out TProjection> : IQuery where TEntity : class
    {
        Func<IQueryableProvider, IQueryable<TProjection>> Query { get; }
    }
}
