using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalysis.Nodes.BaseNodes
{
    public class StatementNode:SyntaxTreeNode
    {
        public StatementNode()
        {
        }

        public static StatementNode Null = new StatementNode();
        public static StatementNode Enclosing = Null;
    }
}
