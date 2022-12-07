using MainSyntaxAnalysis.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class IfNode:StatementNode
    {
        ExpressionNode Expression;
        StatementNode Statement;

        public IfNode(ExpressionNode expression, StatementNode statement)
        {
            Expression = expression;
            Statement = statement;

            if (Expression.Type != DataTypes.Bool)//проверка на то, что бы в контрукции содержалось логическое выражение
            {
                throw new Exception("В конструкции If должно содержаться логическое выражение"); 
            }
        }
    }
}
