using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class ComparisonNode:LogicalNode
    {
        public string Description = "ComparisonLogicalNode";
        public ComparisonNode(Token token, ExpressionNode expression1, ExpressionNode expression2)
            : base(token, expression1, expression2)
        {
            if(expression1.Type.Value != expression2.Type.Value)
            {
                throw new Exception("Нельзя сравнивать выражения разных типов");
            }
        }
    }
}
