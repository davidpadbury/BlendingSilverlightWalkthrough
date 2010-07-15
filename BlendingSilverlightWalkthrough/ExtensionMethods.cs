namespace BlendingSilverlightWalkthrough
{
    using System.Reflection;
    using System.Linq.Expressions;
    using Expression = System.Linq.Expressions.Expression;

    public static class ExtensionMethods
    {
        /// <summary>
        /// Convertes an expression into a <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="expression">The expression to convert.</param>
        /// <returns>The member info.</returns>
        /// <remarks>Taken from Caliburn.Micro</remarks>
        public static MemberInfo GetMemberInfo(this Expression expression)
        {
            var lambda = (LambdaExpression)expression;

            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression)lambda.Body;

            return memberExpression.Member;
        }
    }
}