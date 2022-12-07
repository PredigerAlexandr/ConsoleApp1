using MainSyntaxAnalysis.Constants;
using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    //служит для отрицательных чисел декремента и инкремента
    public class UnaryNode:ExpressionNode
    {
        public ExpressionNode expressionNode;

        public UnaryNode(Token token, ExpressionNode expressionNode) : base(token, null)
        {
            this.expressionNode = expressionNode;

            if (expressionNode.Type.Value == "bool")
            {
                throw new Exception($"Оператор - не может взаимодействовать с переменными типа bool");
            }
            
        }
    }
}
