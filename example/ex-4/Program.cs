using System;
using PasswordGenerator;
using PasswordGenerator.Analyze.Abstract;

namespace ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple generate password using command line and custom alphabet

            // 54 characters length
            // using uppercase letters, lowercase letters, symbols and digits
            var generator = new FromCommandPasswordGenerator("gen len 54 alpha l|u", new CustomAlphabet());

            // generate password
            // returns list of passwords
            var pass = generator.Generate();

            foreach (var item in pass)
            {
                System.Console.WriteLine(item);
            }
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

            return null;
        }
    }
}
