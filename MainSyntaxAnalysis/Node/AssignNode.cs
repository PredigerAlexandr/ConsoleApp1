using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class AssignNode:StatementNode
    {
        IdentifierNode identifierNode;
        ExpressionNode expressionNode;
        
        public AssignNode(IdentifierNode identifierNode, ExpressionNode expressionNode)
        {
            this.identifierNode = identifierNode;
            this.expressionNode = expressionNode;

            if(identifierNode.DataType != expressionNode.Type)
            {
                throw new Exception($"Ошибка в неправильном присвоении типов: {identifierNode.Word.Value}");
            }
        } 
    }
}
