using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class AndNode:LogicalNode
    {
        public string Description = "AndLogicalNode";
        public AndNode(Token token, ExpressionNode expression1, ExpressionNode expression2)
            : base(token, expression1, expression2)
        {
        }
    }
}
