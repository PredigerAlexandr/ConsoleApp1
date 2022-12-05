using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class IdentifierNode
    {
        public Word Word { get; set; }
        public DataType DataType { get; set; }

        public IdentifierNode(Word word, DataType dataType)
        {
            Word = word;
            DataType = dataType;
        }   
    }
}
