using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Infrastructure.Extensions
{
    public static class LinqExtension
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null)
                return second;

            var param = first.Parameters[0];

            var visitor = new SubstExpressionVisitor
            {
                subst = {[second.Parameters[0]] = param}
            };

            Expression body = Expression.And(first.Body, visitor.Visit(second.Body));

            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }

    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = 
            new Dictionary<Expression, Expression>();
    }
}
