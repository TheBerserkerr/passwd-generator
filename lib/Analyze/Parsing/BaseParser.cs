using System.Collections.Generic;
using PasswordGenerator.Analyze.Exception;
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Analyze.Tokenization;

namespace PasswordGenerator.Analyze.Parsing
{
    internal abstract class BaseParser
    {
        protected readonly List<Token> tokens;
        protected int i;

        public BaseParser(List<Token> tokens, int i)
        {
            this.tokens = tokens;
            this.i = i;
        }

        public abstract BaseExpression Parse();

        public int GetIter() => i;

        protected Token Match(TokenKind kind)
        {
            if(GetCurrent().Kind == kind)
            {
                var token = GetCurrent();
                NextToken();
                return token;
            }

            throw new ParserException($"Invalid token <{ GetCurrent().Kind }> expected <{ kind }>");
        }

        protected Token GetCurrent()
        {
            if(tokens.Count <= i)
            {
                return tokens[tokens.Count];
            }

            return tokens[i];
        }

        protected void NextToken() => i++;
    }
}