using MainSyntaxAnalysis.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Models
{
    public class Real:Token
    {
        public double Value { get; set; }

        public Real (double value):base((int)Tags.Real)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
