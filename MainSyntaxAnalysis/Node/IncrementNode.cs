using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class IncrementNode:ArithmeticNode
    {
        public IncrementNode(Token token, ExpressionNode expressionNode1):base(token, expressionNode1,expressionNode1)
        {

        }

    }
}
