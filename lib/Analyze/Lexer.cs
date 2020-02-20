using System;
using System.Linq;
using System.Collections.Generic;
using PasswordGenerator.Analyze.Tokenization;

namespace PasswordGenerator.Analyze
{
    internal class Lexer
    {
        private readonly string command;
        private int i;

        public Lexer(string command)
        {
            this.command = command;
            i = 0;
        }

        public List<Token> Tokenize()
        {
            var res = new List<Token>();

            while(GetCurrent() != '\0')
            {
                if(char.IsWhiteSpace(GetCurrent()))
                {
                    while(char.IsWhiteSpace(GetCurrent()))
                        NextToken();
                }

                if(char.IsLetter(GetCurrent()))
                {
                    var start = i;

                    while(char.IsLetter(GetCurrent()))
                        NextToken();

                    var end = i;

                    var text = command.Substring(start, end - start);

                    res.Add(Identifier.Identify(text));

                    continue;
                }

                if(char.IsDigit(GetCurrent()))
                {
                    var start = i;

                    while(char.IsDigit(GetCurrent()))
                        NextToken();

                    var end = i;

                    var text = command.Substring(start, end - start);

                    res.Add(new Token { Kind = TokenKind.Number, Value = text });

                    continue;
                }

                if(GetCurrent() == '|')
                {
                    res.Add(new Token { Kind = TokenKind.And });

                    NextToken();

                    continue;
                }
            }

            res.Add(new Token { Kind = TokenKind.End });

            return res;
        }

        private char GetCurrent()
        {
            if(i >= command.Length)
            {
                return '\0';
            }

            return command[i];
        }

        private void NextToken() => i++;
    }
}