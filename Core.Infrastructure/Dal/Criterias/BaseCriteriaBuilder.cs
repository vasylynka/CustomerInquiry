using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Infrastructure.Common;
using Core.Infrastructure.Extensions;

namespace Core.Infrastructure.Dal.Criterias
{
    /// <summary>
    /// Base class for search criteria builders
    /// </summary>
    /// <typeparam name="TEntity">Entity model</typeparam>
    /// <typeparam name="TModel">Criteria model</typeparam>
    public abstract class BaseCriteriaBuilder<TEntity, TModel> : ICriteriaBuilder<TEntity, TModel>
        where TEntity : class
        where TModel : class, ISearchModel
    {
        private readonly List<Criteria> _criterias = new List<Criteria>();

        public interface ICriteria
        {
            /// <summary>
            /// Defines validation criteria for added search criteria
            /// </summary>
            /// <param name="validation">Validation delegate</param>
            void When(Func<TModel, bool> validation);
        }

        internal class Criteria : ICriteria
        {
            private Func<TModel, bool> _validation;
            private readonly Func<TModel, Expression<Func<TEntity, bool>>> _criteria;

            public Criteria(Func<TModel, Expression<Func<TEntity, bool>>> func)
            {
                _criteria = func;
            }

            public void When(Func<TModel, bool> validation)
            {
                _validation = validation;
            }

            public Expression<Func<TEntity, bool>> GetWhenValid(TModel model)
            {
                if (_validation == null)
                    return x => true;

                if (_validation(model))
                    return _criteria(model);

                return null;
            }
        }
        /// <summary>
        /// Adds user defined search criteria into search predicate collection
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        protected ICriteria AddCriteria(Func<TModel, Expression<Func<TEntity, bool>>> criteria)
        {
            var instance = new Criteria(criteria);
            _criterias.Add(instance);
            return instance;
        }
        /// <summary>
        /// Builds expression by user search model
        /// </summary>
        /// <param name="model">Search params model</param>
        /// <returns></returns>
        public Expression<Func<TEntity, bool>> Build(TModel model)
        {
            if (!_criterias.Any())
                return x => true;

            var compiledCriterias = new List<Expression<Func<TEntity, bool>>>();

            foreach (var criteria in _criterias)
            {
                var compiledCriteria = criteria.GetWhenValid(model);
                if (compiledCriteria != null)
                    compiledCriterias.Add(compiledCriteria);
            }

            if (!compiledCriterias.Any())
                return x => true;

            var first = compiledCriterias.First();

            for (int i = 1; i < compiledCriterias.Count; i++)
            {
                first = first.And(compiledCriterias[i]);
            }

            return first;
        }
    }
}
