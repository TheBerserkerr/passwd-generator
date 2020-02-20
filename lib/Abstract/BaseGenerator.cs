
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Evaluating;
using PasswordGenerator.Evaluating.Abstract;

namespace PasswordGenerator.Abstract
{
    public abstract class BaseGenerator<T> where T : class
    {
        protected ICommandResolver resolver;
        protected IInterpretingContext context;
        protected IAlphabet alphabet;

        protected abstract T OnEvaluated();

        public T Generate()
        {
            context = new Evaluator(resolver.Resolve(), context).Evaluate();

            return OnEvaluated();
        }
    }
}