using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    public  class BaseNode
    {
        public  left;
        public BaseNode right;

        public BaseNode(BaseNode left=null, BaseNode right=null)
        {
            this.left = left;
            this.right = right;
        }
    }
}
