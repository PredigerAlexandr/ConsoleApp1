using SyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalysis
{
    public class Handler
    {
        static Token (string lexemValue)
        {
            for (; ; ReadChar())
            {
                if (Peek == ' ' || Peek == '\t')
                {
                    continue;
                }
                else if (Peek == '\0')
                {
                    return new Token('\0');
                }
                else if (Peek == '\n')
                {
                    Line = Line + 1;
                }
                else
                {
                    break;
                }
            }

            switch (Peek)
            {
                case '&':
                    if (ReadChar('&'))
                    {
                        return Words.And;
                    }
                    else
                    {
                        return new Token('&');
                    }
                case '|':
                    if (ReadChar('|'))
                    {
                        return Words.Or;
                    }
                    else
                    {
                        return new Token('|');
                    }
                case '=':
                    if (ReadChar('='))
                    {
                        return Words.Eq;
                    }
                    else
                    {
                        return new Token('=');
                    }
                case '!':
                    if (ReadChar('='))
                    {
                        return Words.Ne;
                    }
                    else
                    {
                        return new Token('!');
                    }
                case '<':
                    if (ReadChar('='))
                    {
                        return Words.Le;
                    }
                    else
                    {
                        return new Token('<');
                    }
                case '>':
                    if (ReadChar('='))
                    {
                        return Words.Ge;
                    }
                    else
                    {
                        return new Token('>');
                    }
            }

            if (char.IsDigit(Peek))
            {
                int value = 0;
                do
                {
                    value = 10 * value + Convert.ToInt32(Peek);
                    ReadChar();
                } while (char.IsDigit(Peek));

                if (Peek != '.')
                {
                    return new Num(value);
                }

                float fValue = value;
                float d = 10;

                for (; ; )
                {
                    ReadChar();
                    if (!char.IsDigit(Peek))
                    {
                        break;
                    }
                    fValue = fValue + Convert.ToInt32(Peek) / d;
                    d = d * 10;
                }

                return new Real(fValue);
            }

            if (char.IsLetter(Peek))
            {
                StringBuilder buffer = new StringBuilder();

                do
                {
                    buffer.Append(Peek);
                    ReadChar();
                } while (char.IsLetterOrDigit(Peek));

                string s = buffer.ToString();
                bool isKeyword = keywords.ContainsKey(s);
                if (isKeyword)
                {
                    return keywords[s];
                }

                Word word = new Word(s, (int)Tags.Id);
                keywords.Add(s, word);
                return word;
            }

            Token token = new Token(Peek);
            Peek = ' ';
            return token;
        }

    }
}
