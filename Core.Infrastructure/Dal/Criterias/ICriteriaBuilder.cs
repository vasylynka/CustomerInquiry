using System;
using System.Linq.Expressions;

namespace Core.Infrastructure.Dal.Criterias
{
    /// <summary>
    /// Builds criteria for search services
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public interface ICriteriaBuilder<TEntity, in TModel>
        where TEntity : class
        where TModel : class
    {
        Expression<Func<TEntity, bool>> Build(TModel model);
    }
}
