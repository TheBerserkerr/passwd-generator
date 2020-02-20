
using System.Collections.Generic;
using PasswordGenerator.Analyze;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Evaluating.Abstract;
using PasswordGenerator.Evaluating.Context;
using PasswordGenerator.Evaluating.Function;

namespace PasswordGenerator.Evaluating
{
    internal class Evaluator
    {
        private readonly List<BaseExpression> expressions;
        private readonly IInterpretingContext context;

        public Evaluator(List<BaseExpression> expressions, IInterpretingContext context)
        {
            this.expressions = expressions;
            this.context = context;
        }

        public IInterpretingContext Evaluate()
        {
            foreach (var item in expressions)
            {
                if(item is GenExpression genExpression)
                    new GenEvaluator().Evaluate(context, this, genExpression);
            }
            return context;
        }
    }
}