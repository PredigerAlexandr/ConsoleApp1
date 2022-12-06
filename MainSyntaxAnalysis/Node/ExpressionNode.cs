using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class ExpressionNode
    {
        public Token Operation;
        public DataType Type;

        public ExpressionNode(Token operation, DataType type)
        {
            Operation = operation;
            Type = type;
        }
    }
}
