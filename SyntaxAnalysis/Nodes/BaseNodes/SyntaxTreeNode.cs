using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalysis.Nodes.BaseNodes
{
    //базовый класс для всех нод
    public class SyntaxTreeNode
    {
        public int LexLine = 0;//строка кода

        public SyntaxTreeNode()
        {

        }

        public void Error(string msg)
        {
            throw new Exception($"Error around {LexLine}:{msg}");
        }
    }
}
