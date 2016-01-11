using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace codaT.WordProcessorTest
{
    public static class INotifyPropertyChangedHelper
    {
        public static void Raise<T>(this PropertyChangedEventHandler handler, Expression<Func<T>> propertyExpression)
        {
            if (handler != null)
            {
                var body = propertyExpression.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("'propertyExpression' should be a member expression");

                var expression = body.Expression as ConstantExpression;
                if (expression == null)
                    throw new ArgumentException("'propertyExpression' body should be a constant expression");

                object target = System.Linq.Expressions.Expression.Lambda(expression).Compile().DynamicInvoke();

                var e = new PropertyChangedEventArgs(body.Member.Name);
                handler(target, e);
            }
        }

        public static void Raise<T>(this PropertyChangedEventHandler handler, params Expression<Func<T>>[] propertyExpressions)
        {
            foreach (var propertyExpression in propertyExpressions)
            {
                handler.Raise<T>(propertyExpression);
            }
        }
    }
}
