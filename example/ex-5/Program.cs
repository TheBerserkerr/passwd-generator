using System;
using PasswordGenerator;
using PasswordGenerator.Analyze;
using PasswordGenerator.Abstract;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Evaluating.Context;

namespace ex_5
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
            resolver = new SimpleCommandResolver(10, "ll", "ul");
        }

        protected override string OnEvaluated()
        {
            return "test";
        }
    }

    // NEXT
    public class CustomCommandResolver
    {
    }
}
