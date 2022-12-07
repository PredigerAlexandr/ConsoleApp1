using MainSyntaxAnalysis.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class IfElseNode:StatementNode
    {
        ExpressionNode Expression;
        StatementNode Statement1;
        StatementNode Statement2;

        public IfElseNode(ExpressionNode expression, StatementNode statement1, StatementNode statement2)
        {
            Expression = expression;
            Statement1 = statement1;
            Statement2 = statement2;

            if (expression.Type != DataTypes.Bool)
            {
                throw new Exception("Boolean statement required in if statement");
            }
        }
    }
}
