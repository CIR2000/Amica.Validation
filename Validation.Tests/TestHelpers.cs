using FluentValidation;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Amica.Validation.Tests
{
    public static class TestHelpers
    {
        public static string GetPropertyName<T, TValue>(this T model, Expression<Func<T, TValue>> expression) where T : class
        {
            var memberExpression = (MemberExpression)expression.Body;
            var memberExpressionOrg = memberExpression;

            var Path = "";

            while (memberExpression != null && memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
            {
                var propInfo = memberExpression.Expression.GetType().GetProperty("Member");
                var propValue = propInfo.GetValue(memberExpression.Expression, null) as PropertyInfo;
                if (propValue != null) Path = propValue.Name + "." + Path;

                memberExpression = memberExpression.Expression as MemberExpression;
            }

            return Path + memberExpressionOrg.Member.Name;
        }
        public static void ShouldHaveNestedValidationErrorFor<T, TValue>(this IValidator<T> validator, Expression<Func<T, TValue>> expression, T objectToTest) where T : class
        {
            var propertyName = objectToTest.GetPropertyName(expression);
            var count = validator.Validate(objectToTest).Errors.Count(x => x.PropertyName == propertyName);

            if (count == 0)
            {
                throw new ValidationException(string.Format("Expected a validation error for property {0}", propertyName));
            }
        }

        public static void ShouldNotHaveNestedValidationErrorFor<T, TValue>(this IValidator<T> validator, Expression<Func<T, TValue>> expression, T objectToTest) where T : class
        {
            var propertyName = objectToTest.GetPropertyName(expression);
            var count = validator.Validate(objectToTest).Errors.Count(x => x.PropertyName == propertyName);

            if (count > 0)
            {
                throw new ValidationException(string.Format("Expected no validation errors for property {0}", propertyName));
            }
        }

    }
}
