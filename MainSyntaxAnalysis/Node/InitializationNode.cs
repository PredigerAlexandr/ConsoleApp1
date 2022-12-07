using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class InitializationNode: StatementNode
    {
        public DataType DataType;
        public Word Word;
        
        public InitializationNode(DataType type, Word word)
        {
            this.DataType = type;
            this.Word = word;
        }

    }
}
