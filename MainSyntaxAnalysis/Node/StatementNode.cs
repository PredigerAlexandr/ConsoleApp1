using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public class StatementNode
    {
        StatementNode statment1;
        StatementNode statment2;

        public StatementNode(StatementNode statment1=null, StatementNode statment2=null)
        {
            this.statment1 = statment1;
            this.statment2 = statment2;
        }
    }
}
