using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    //нода присваения значения
    public class AssignNode:StatementNode
    {
        public string Description = "AssignNode";

        InitializationNode initializationNode;
        ExpressionNode expressionNode;
        
        public AssignNode(InitializationNode initializationNode, ExpressionNode expressionNode)
        {
            this.initializationNode = initializationNode;
            this.expressionNode = expressionNode;

            if(initializationNode.DataType.Value != expressionNode.Type.Value)//проверка на соответсие типов
            {
                throw new Exception($"Ошибка в неправильном присвоении типов: {initializationNode.Word.Value}");
            }
        } 
    }
}
