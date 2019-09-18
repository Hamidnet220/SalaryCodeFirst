using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace SalaryApp.DataLayer
{
    public class ExpressionHandler: System.Linq.Expressions.ExpressionVisitor
    {
        List<string> visitedProperties = new List<string>();


        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member is PropertyInfo)
                visitedProperties.Add(node.Member.Name);
            return base.VisitMember(node);
        }

        public string GetPropertyName(Expression expression)
        {
            visitedProperties.Clear();
            Visit(expression);
            visitedProperties.Reverse();
            return string.Join(".",visitedProperties);
        }
    }
}
