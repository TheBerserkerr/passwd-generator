
using System;
using System.Collections.Generic;
using PasswordGenerator.Abstract;
using PasswordGenerator.Analyze;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Evaluating.Abstract;
using PasswordGenerator.Evaluating.Context;

namespace PasswordGenerator
{
    public class FromCommandPasswordGenerator : BaseGenerator<IEnumerable<string>>
    {
        public FromCommandPasswordGenerator(string cmd)
        {
            resolver = new StringCommandResolver(cmd);
            context = new InterpretingContext();
        }

        public FromCommandPasswordGenerator(string cmd, IInterpretingContext context)
        {
            resolver = new StringCommandResolver(cmd);
            context = new InterpretingContext();
        }

        public FromCommandPasswordGenerator(string cmd, IInterpretingContext context, IAlphabet alphabet)
        {
            resolver = new StringCommandResolver(cmd);
            context = new InterpretingContext(alphabet);
        }

        protected override IEnumerable<string> OnEvaluated()
        {
            int i = 0;
            while (i < Int32.MaxValue)
            {
                if (context.GetObject("Generated-" + i) != null)
                {
                    var res = context.GetObject("Generated-" + i).ToString();

                    i++;

                    yield return res;
                }
                else
                {
                    break;
                }
            }
        }
    }
}