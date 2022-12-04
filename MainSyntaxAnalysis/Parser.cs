using MainSyntaxAnalysis.Models;
using MainSyntaxAnalysis.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis
{
    public class Parser
    {
        private LexemAnalysis _lexemAnalysis;
        private Token currentLexem;

        public Parser(string path)
        {
            _lexemAnalysis = new LexemAnalysis(path);
        }

        public void StartParser()
        {
            BaseNode baseNode = Block();//начинаем обработку самого внешнего блока
        }

        //обрабатывает первые фигурные скобки 
        private BaseNode Block()
        {
            Match()

            return new BaseNode();
        }

        private void Match(int t)
        {
            if (currentLexem.Tag == t)
            {
                Move();
            }
            else
            {
                Error("Syntax error");
            }
        }

        //переход у следуюзей лексеме
        private void Move()
        {
            currentLexem = _lexemAnalysis.ScanNext();
            if (currentLexem.Tag == '\0')//если равен концу строки
            {
                return;
            }
        }
    }
}
