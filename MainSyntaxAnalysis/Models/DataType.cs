using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Models
{
    public class DataType : Word
    {
        public int Width = 0;
        public DataType(string value, int tag, int width) : base(value, tag)
        {
            Width = width;
        }
    }
}
