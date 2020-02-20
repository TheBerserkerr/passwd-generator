
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Evaluating.Abstract;

namespace PasswordGenerator.Evaluating.Function
{
    internal abstract class BaseEvaluator
    {
        public abstract void Evaluate(IInterpretingContext context, Evaluator mainEvaluator, BaseExpression expression);
    }
}