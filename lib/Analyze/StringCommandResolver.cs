
using System.Collections.Generic;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Analyze.Expression;

namespace PasswordGenerator.Analyze
{
    public class StringCommandResolver : ICommandResolver
    {
        private readonly string cmd;

        public StringCommandResolver(string cmd)
        {
            this.cmd = cmd;
        }

        public List<BaseExpression> Resolve()
        {
            return new Parser(new Lexer(cmd).Tokenize()).Parse();
        }
    }
}