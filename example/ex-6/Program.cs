using System;
using System.Linq;
using System.Collections.Generic;
using PasswordGenerator;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Analyze;
using PasswordGenerator.Abstract;
using PasswordGenerator.Evaluating.Context;
using PasswordGenerator.Analyze.Expression;

namespace ex_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple generate password using custom generator

            // 54 characters length
            // using uppercase letters, lowercase letters, symbols and digits
            var generator = new CustomGenerator();

            // generate password
            // returns list of passwords
            var pass = generator.Generate();

            System.Console.WriteLine(pass);
        }
    }

    public class CustomGenerator : BaseGenerator<string>
    {

        public CustomGenerator()
        {
            context = new InterpretingContext();
            resolver = new CustomCommandResolver();
        }

        protected override string OnEvaluated()
        {
            return "test";
        }
    }

    public class CustomCommandResolver : ICommandResolver
    {
        public List<BaseExpression> Resolve()
        {
            var ls = new List<BaseExpression>();
            ls.Add(new GenExpression { Length = 12, Alphabets = new List<string> { "ll" }});

            return ls;
        }
    }
}
