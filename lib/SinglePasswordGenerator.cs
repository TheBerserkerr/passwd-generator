
using System.Collections.Generic;
using System.Linq;
using PasswordGenerator.Abstract;
using PasswordGenerator.Analyze;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Evaluating.Context;

namespace PasswordGenerator
{
    public class SinglePasswordGenerator : BaseGenerator<string>
    {

        public SinglePasswordGenerator(int lenght, params string[] alphabets)
        {
            context = new InterpretingContext();

            var ls = new List<BaseExpression>();
            ls.Add(new GenExpression { Length = lenght, Alphabets = alphabets.ToList()});

            resolver = new ExpressionCommandResolver(ls);
        }

        public SinglePasswordGenerator(int lenght, IAlphabet alphabet, params string[] alphabets)
        {
            context = new InterpretingContext(alphabet);

            var ls = new List<BaseExpression>();
            ls.Add(new GenExpression { Length = lenght, Alphabets = alphabets.ToList()});

            resolver = new ExpressionCommandResolver(ls);
        }

        protected override string OnEvaluated()
        {
            return context.GetObject("Generated-0").ToString();
        }
    }
}