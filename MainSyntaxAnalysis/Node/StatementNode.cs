using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class StatementNode
    {
        public StatementNode()
        {
        }

        public static StatementNode Null = new StatementNode();

        public void Generate(int a, int b) { }

        int After = 0;

        public static StatementNode Enclosing = StatementNode.Null;
    }
}
