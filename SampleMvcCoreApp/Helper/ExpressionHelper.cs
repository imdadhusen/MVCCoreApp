using System.Linq.Expressions;

namespace SampleMvcCoreApp.Helper
{
    public static class ExpressionHelper
    {
        public static Expression<Func<T, bool>> Compose<T>(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null && second == null)
            {
                return null;
            }
            else if (first == null)
            {
                return second;
            }
            else if (second == null)
            {
                return first;
            }

            var parameter = Expression.Parameter(typeof(T));
            var visitor = new ReplaceExpressionVisitor(first.Parameters[0], parameter);
            var newFirst = visitor.Visit(first.Body);
            var body = Expression.AndAlso(newFirst, second.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _oldValue ? _newValue : base.VisitParameter(node);
            }
        }
    }

}
