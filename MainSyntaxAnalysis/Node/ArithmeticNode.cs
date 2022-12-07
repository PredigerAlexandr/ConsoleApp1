using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class ArithmeticNode:ExpressionNode
    {
        public string Description = "ArithmeticNode";

        public ExpressionNode expressionNode1;
        public ExpressionNode expressionNode2;

        public ArithmeticNode(Token token, ExpressionNode expressionNode1, ExpressionNode expressionNode2) : base(token, null)
        {
            this.expressionNode1 = expressionNode1; 
            this.expressionNode2 = expressionNode2;

            if(expressionNode1.Type.Value== "bool" || expressionNode2.Type.Value== "bool" || expressionNode1.Type.Value!= expressionNode2.Type.Value)
            {
                throw new Exception($"В выражении ошибка типов данных: {expressionNode1.Type.Value} {expressionNode2.Type.Value}");
            }
        }
    }
}
