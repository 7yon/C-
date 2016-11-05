using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class AlgebraicExpression
    {
        private static Expression Differentiate(Expression expression)
        {
            if (expression is ConstantExpression) { return Expression.Constant(0.0); }
                
            else if (expression is ParameterExpression) { return Expression.Constant(1.0); }
                         
            else if (expression is BinaryExpression)
            {
                var currentExpression = expression as BinaryExpression;

                switch (expression.NodeType)
                {
                    case ExpressionType.Add:
                        return Expression.Add(Differentiate(currentExpression.Left),  Differentiate(currentExpression.Right));

                    case ExpressionType.Multiply:
                        return Expression.Add(
                        Expression.Multiply(currentExpression.Left, Differentiate(currentExpression.Right)),
                        Expression.Multiply(currentExpression.Right, Differentiate(currentExpression.Left)));
                }
            }

            else if ((expression is MethodCallExpression) &&
                ((expression as MethodCallExpression).Method.Name == "Sin"))
            {
                var argument = (expression as MethodCallExpression).Arguments[0];
                return Expression.Multiply(Expression.Call(typeof(Math).GetMethod("Cos"), argument), Differentiate(argument));
            }

            throw new ArgumentException("Выражение должно содежать только знаки + * ( ) и Sin");
        }

        public static Func<double, double> Differentiate(this Expression<Func<double, double>> expression)
        {
            return Expression.Lambda(Differentiate(expression.Body), expression.Parameters).Compile() as Func<double, double>;
        }
    }
}

