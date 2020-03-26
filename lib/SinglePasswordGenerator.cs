
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

        public SinglePasswordGenerator(int length, params string[] alphabets)
        {
            context = new InterpretingContext();

            resolver = new SimpleCommandResolver(length, alphabets);
        }

        public SinglePasswordGenerator(int length, IAlphabet alphabet, params string[] alphabets)
        {
            context = new InterpretingContext(alphabet);

            resolver = new SimpleCommandResolver(length, alphabets);
        }

        protected override string OnEvaluated()
        {
            return context.GetObject("Generated-0").ToString();
        }
    }
}