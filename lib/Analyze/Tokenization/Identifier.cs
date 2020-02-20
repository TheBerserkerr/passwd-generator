
namespace PasswordGenerator.Analyze.Tokenization
{
    internal class Identifier
    {
        public static Token Identify(string text)
        {
            switch(text)
            {
                case "gen":
                    return new Token { Kind = TokenKind.Generate };
                case "len":
                    return new Token { Kind = TokenKind.Length };
                case "alpha":
                    return new Token { Kind = TokenKind.Alphabet };
                default:
                    return new Token { Kind = TokenKind.Identifier, Value = text };
            }
        }
    }
}