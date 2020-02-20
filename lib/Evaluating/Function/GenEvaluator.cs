
using System;
using System.Linq;
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Evaluating.Abstract;

namespace PasswordGenerator.Evaluating.Function
{
    internal class GenEvaluator : BaseEvaluator
    {
        public override void Evaluate(IInterpretingContext context, Evaluator mainEvaluator, BaseExpression expression)
        {
            var exp = expression as GenExpression;
            var alphabet = exp.Alphabets.Select(x => context.Alphabet.GetAlphabet(x)).Aggregate((current, next) => current + next);
            var rand = new Random();

            var res = "";

            for (var i = 0; i < exp.Length; i++)
            {
                res += alphabet[rand.Next(0, alphabet.Length)];
            }

            PushToContext(res, context);
        }

        private void PushToContext(string password, IInterpretingContext context)
        {
            int i = 0;
            while (i < Int32.MaxValue)
            {
                if (context.GetObject("Generated-" + i) != null)
                {
                    i++;
                }
                else
                {
                    context.SetObject("Generated-" + i, password);
                    break;
                }
            }
        }
    }
}