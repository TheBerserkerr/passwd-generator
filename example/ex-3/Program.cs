using System;
using PasswordGenerator;

namespace ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple generate password using command line

            // 54 characters length
            // using uppercase letters, lowercase letters, symbols and digits
            var generator = new FromCommandPasswordGenerator("gen len 54 alpha ul|ll|s|d");

            // generate password
            // returns list of passwords
            var pass = generator.Generate();

            foreach (var item in pass)
            {
                System.Console.WriteLine(item);
            }
        }
    }

}
