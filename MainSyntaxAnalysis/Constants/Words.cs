using MainSyntaxAnalysis.Models;
using MainSyntaxAnalysis.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Constants
{
    public static class Words
    {
        public static Word And = new Word("&&", (int)Tags.And);
        public static Word Or = new Word("||", (int)Tags.Or);
        public static Word Eq = new Word("==", (int)Tags.Eq);
        public static Word Ne = new Word("!=", (int)Tags.Ne);
        public static Word Le = new Word("<=", (int)Tags.Le);
        public static Word Ge = new Word(">=", (int)Tags.Ge);
        public static Word Minus = new Word("minus", (int)Tags.Minus);
        public static Word True = new Word("true", (int)Tags.True);
        public static Word False = new Word("false", (int)Tags.False);
        public static Word Temp = new Word("t", (int)Tags.Temp);
        public static Word If = new Word("if", (int)Tags.If);
        public static Word While = new Word("while", (int)Tags.While);
        public static Word Else = new Word("else", (int)Tags.Else);
        public static Word Do = new Word("do", (int)Tags.Do);
        public static Word Break = new Word("break", (int)Tags.Break);

        public static Dictionary<string, Word> KeyWords = new Dictionary<string, Word>()
        {
            { And.Value, And },
            { Or.Value, Or },
            { Eq.Value, Eq },
            { Ne.Value, Ne },
            { Le.Value, Le },
            { Ge.Value, Ge },
            { Minus.Value, Minus },
            { True.Value, True },
            { False.Value, False },
            { Temp.Value, Temp },
            { If.Value, If },
            { While.Value, While },
            { Else.Value, Else },
            { Do.Value, Do },
            { Break.Value, Break }
        };

        public static Dictionary<string, InitializationNode> IdentifiersTable = new Dictionary<string, InitializationNode>();
    }
}
