using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class NotNode:LogicalNode
    {
        public NotNode(Token token, ExpressionNode expression1)
            : base(token, expression1, expression1)
        {
            if (expression1.Type.Value != "bool")
            {
                throw new Exception("Оператор ! не может использовать ни для каких типов выражений, кроме как для логических");
            }
        }
    }
}
