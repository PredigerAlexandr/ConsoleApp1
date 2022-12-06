using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class SequenceNode:StatementNode
    {
        StatementNode Statement1;
        StatementNode Statement2;

        public SequenceNode(StatementNode statement1, StatementNode statement2)
        {
            Statement1 = statement1;
            Statement2 = statement2;
        }
    }
}
