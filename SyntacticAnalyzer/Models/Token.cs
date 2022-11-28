using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalyzer.Models
{
    internal class Token
    {
        public int Tag { get; set; }

        public Token(int tag)
        {
            Tag = tag;
        }

        public override string ToString()
        {
            return $"Tag: {Tag}";
        }
    }
}
