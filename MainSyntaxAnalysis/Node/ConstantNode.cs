using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    internal class ConstantNode:ExpressionNode
    {
        public ConstantNode(Token token, DataType dataType) : base(token, dataType)
        {
        }
    }
}
