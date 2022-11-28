using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Models
{
    public class Word:Token
    {
        public string Value { get; set; }

        public Word(string value, int tag):base(tag)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
