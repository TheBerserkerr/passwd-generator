using System;
using PasswordGenerator;
using PasswordGenerator.Analyze.Abstract;

namespace ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple generate password with custom alphabet

            // 54 characters length
            // using custom alphabet
            var generator = new SinglePasswordGenerator(54, new CustomAlphabet(), "l");

            // generate password
            // returns string
            var pass = generator.Generate();

            System.Console.WriteLine(pass);
        }
    }

    class CustomAlphabet : IAlphabet
    {
        public string GetAlphabet(string key)
        {
            if(key == "l") 
            {
                return "ABC";
            }
            else if (key == "u")
            {
                return "abc";
            }

            return "1";
        }
    }
}
