using System;
using PasswordGenerator;

namespace ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple generate password

            // 54 characters length
            // using uppercase letters, lowercase letters, symbols and digits
            var generator = new SinglePasswordGenerator(54, "ll", "ul", "d", "s");

            // generate password
            // returns string
            var pass = generator.Generate();

            System.Console.WriteLine(pass);
        }
    }
}
