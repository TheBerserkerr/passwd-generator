
using System.Collections.Generic;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Analyze.Expression;

namespace PasswordGenerator.Analyze
{
    public class ExpressionCommandResolver : ICommandResolver
    {
        private List<BaseExpression> expressions;

        public ExpressionCommandResolver(List<BaseExpression> expressions)
        {
            this.expressions = expressions;
        }

        public List<BaseExpression> Resolve()
        {
            return expressions;
        }
    }
}