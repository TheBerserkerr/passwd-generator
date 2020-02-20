
using System.Collections.Generic;
using System.Linq;
using PasswordGenerator.Analyze.Expression;
using PasswordGenerator.Analyze.Tokenization;

namespace PasswordGenerator.Analyze.Parsing
{
    internal class GenParser : BaseParser
    {
        public GenParser(List<Token> tokens, int i) : base(tokens, i)
        {
        }

        public override BaseExpression Parse()
        {
            Match(TokenKind.Generate);

            List<Token> alpha = new List<Token>();
            Token len = new Token();

            if(GetCurrent().Kind == TokenKind.Length)
            {
                Match(TokenKind.Length);
                len = Match(TokenKind.Number);

                Match(TokenKind.Alphabet);

                alpha.Add(Match(TokenKind.Identifier));
                
                while(GetCurrent().Kind == TokenKind.And)
                {
                    Match(TokenKind.And);
                    alpha.Add(Match(TokenKind.Identifier));
                }
            }

            if(GetCurrent().Kind == TokenKind.Alphabet)
            {
                Match(TokenKind.Alphabet);

                alpha.Add(Match(TokenKind.Identifier));
                
                while(GetCurrent().Kind == TokenKind.And)
                {
                    alpha.Add(Match(TokenKind.Identifier));
                }

                Match(TokenKind.Length);
                len = Match(TokenKind.Number);
            }

            return new GenExpression { Length = int.Parse(len.Value), Alphabets = alpha.Select(x=>x.Value).ToList() };
        }
    }
}