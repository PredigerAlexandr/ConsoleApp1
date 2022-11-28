using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Models
{
    public class Token
    {
        public int Tag { get; set; }

        public Token(int tag)
        {
            Tag = tag;
        }

        public virtual string ToString()
        {
            return $"{Tag}";
        }
    }
}
