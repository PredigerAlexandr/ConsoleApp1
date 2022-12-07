using MainSyntaxAnalysis.Constants;
using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class LogicalNode:ExpressionNode
    {
        public string Description = "LogicalNode";

        ExpressionNode expressionNode1;
        ExpressionNode expressionNode2;
        public LogicalNode(Token token, ExpressionNode expressionNode1, ExpressionNode expressionNode2)
            :base(token, DataTypes.Bool)
        {
            this.expressionNode1 = expressionNode1;
            this.expressionNode2 = expressionNode2;

            if (expressionNode1.Type.Value != expressionNode2.Type.Value)
            {
                throw new Exception($"Ошибка в неправильном присвоении типов: {expressionNode1.Type.Value} и {expressionNode2.Type.Value}");
            }
        }
    }
}
