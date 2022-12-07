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
        DataType dType;
        Word word;
        
        public InitializationNode(DataType type, Word word)
        {
            this.dType = type;
            this.word = word;
        }

    }
}
