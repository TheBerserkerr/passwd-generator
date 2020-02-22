
using System.Collections.Generic;
using System.Linq;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Analyze.Expression;

namespace PasswordGenerator.Analyze
{
    public class SimpleCommandResolver : ICommandResolver
    {
        private readonly List<BaseExpression> ls;

        public SimpleCommandResolver(int lenght, params string[] alphabets)
        {
            ls = new List<BaseExpression>();
            ls.Add(new GenExpression { Length = lenght, Alphabets = alphabets.ToList()});
        }

        public List<BaseExpression> Resolve()
        {
            return ls;
        }
    }
}