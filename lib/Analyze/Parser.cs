using System;
using System.Collections.Generic;
using System.Linq;
using PasswordGenerator.Analyze.Tokenization;
using PasswordGenerator.Analyze.Exception;
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Analyze.Parsing;

namespace PasswordGenerator.Analyze
{
    internal class Parser
    {
        private readonly List<Token> tokens;
        private int i;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            i = 0;
        }

        public List<BaseExpression> Parse()
        {

            var res = new List<BaseExpression>();

            if(tokens != null && tokens.Count > 0)
            {
                var token = GetCurrent();

                while(token.Kind != TokenKind.End)
                {
                    if(token.Kind == TokenKind.Generate)
                    {
                        var par = new GenParser(tokens, i);
                        res.Add(par.Parse());
                        i = par.GetIter();
                    }

                    token = GetCurrent();
                }
            }

            return res;
        }

        private Token Match(TokenKind kind)
        {
            if(GetCurrent().Kind == kind)
            {
                var token = GetCurrent();
                NextToken();
                return token;
            }

            throw new ParserException($"Invalid token <{ GetCurrent().Kind }> expected <{ kind }>");
        }

        public Token GetCurrent()
        {
            if(tokens.Count <= i)
            {
                return tokens[tokens.Count];
            }

            return tokens[i];
        }

        private void NextToken() => i++;
    }
}