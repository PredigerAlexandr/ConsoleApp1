using MainSyntaxAnalysis.Constants;
using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis
{
    public class LexemAnalysis
    {
        public static int CodeLine = 1;
        char Peek = ' ';
        private string CodeText;
        private int Cursor = 0;

        public LexemAnalysis(string filePath)
        {
            CodeText = File.ReadAllText(filePath);
        }

        private void AddKeyWord(Word word)
        {
            Words.KeyWords.Add(word.Value, word);
        }

        void ReadChar()
        {
            if (Cursor == CodeText.Length)
            {
                Peek = '\0';
            }
            else
            {
                Peek = CodeText[Cursor++];
            }
        }

        bool ReadChar(char c)
        {
            ReadChar();
            if (Peek != c)
            {
                return false;
            }
            Peek = ' ';
            return true;
        }

        //бежим к следующему элементу кода
        public Token ScanNext()
        {
            for (; ; ReadChar())
            {
                if (Peek == ' ' || Peek == '\t' || Peek == '\r')
                {
                    continue;
                }
                else if (Peek == '\0')
                {
                    continue;
                    //return new Token('\0');
                }
                else if (Peek == '\n')
                {
                    CodeLine++;
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
                case '-':
                    if (ReadChar('-'))
                    {
                        return Words.Dec;
                    }
                    break;
                    //else
                    //{
                    //    return new Token('>');
                    //}
                case '+':
                    if (ReadChar('+'))
                    {
                        return Words.Inc;
                    }
                    break;
                    //else
                    //{
                    //    return new Token('&');
                    //}
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
                bool isKeyword = Words.KeyWords.ContainsKey(s);
                if (isKeyword)
                {
                    return Words.KeyWords[s];
                }

                Word word = new Word(s, (int)Tags.Id);
                Words.KeyWords.Add(s, word);
                return word;
            }

            Token token = new Token(Peek);
            Peek = ' ';
            return token;
        }
    }
}
