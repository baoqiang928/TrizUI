using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Triz.DAL
{
    public static class PredicateExtensionses
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp_flow, Expression<Func<T, bool>> expression2)
        {

            var invokedExpression = System.Linq.Expressions.Expression.Invoke(expression2, exp_flow.Parameters.Cast<System.Linq.Expressions.Expression>());

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(System.Linq.Expressions.Expression.Or(exp_flow.Body, invokedExpression), exp_flow.Parameters);

        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp_flow, Expression<Func<T, bool>> expression2)
        {

            var invokedExpression = System.Linq.Expressions.Expression.Invoke(expression2, exp_flow.Parameters.Cast<System.Linq.Expressions.Expression>());

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(System.Linq.Expressions.Expression.And(exp_flow.Body, invokedExpression), exp_flow.Parameters);

        }
    }


}
