using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalysis.Models
{
    //баозвый класс токена для каждого элемента
    public class Token
    {
        public int Tag { get; private set; }

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
