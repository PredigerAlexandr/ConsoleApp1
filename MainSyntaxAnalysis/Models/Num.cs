using MainSyntaxAnalysis.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Models
{
    public class Num:Token
    {
        public int Value { get; set; }

        public Num(int value):base((int)Tags.Num)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
