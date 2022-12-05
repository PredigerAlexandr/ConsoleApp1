using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Node
{
    //реализация таблицы переменных, которая будет отвечать за локальные и глобальные переменные переменные
    public  class IdentifiersTable
    {
        private Dictionary<Token, IdentifierNode> _table;
        protected IdentifiersTable _previous;

        public IdentifiersTable(IdentifiersTable prev)
        {
            _table = new Dictionary<Token, IdentifierNode>();
            _previous = prev;
        }

        public void Put(Token token, IdentifierNode identifier)
        {
            _table.Add(token, identifier);
        }

        public IdentifierNode? Get(Token token)
        {
            for (IdentifiersTable t = this; t != null; t = t._previous)
            {
                if (t._table.ContainsKey(token))
                {
                    return t._table[token];
                }
            }

            return null;
        }
    }
}
