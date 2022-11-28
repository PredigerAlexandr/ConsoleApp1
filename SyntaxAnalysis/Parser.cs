using ConsoleApp1;
using ConsoleApp1.Models;
using SyntaxAnalysis.Models;
using SyntaxAnalysis.Nodes.BaseNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalyzer
{
    public class Parser
    {
        List<Lexem> lexemList;
        int indexLex = 0;
        Token CurrentLex;

        //при иницилизации парсинга выполняем формирование всех лекем с помощью лексичекого анализатора
        public Parser()
        {
            Analysis _analisys = new Analysis();
            string filePath = "C:\\Users\\User\\OneDrive\\Desktop\\SAPR-master\\ConsoleApp1\\files\\input.txt";
            lexemList = _analisys.AnalysisProcess(filePath).Item1;
        }

        public StatementNode Program()
        {
            StatementNode statementNode = Block();//возвращаемое дерево
            Console.WriteLine(statementNode.ToString());
            return statementNode;
        }

        private void Match(int t)
        {
            if (CurrentLex.Tag == t)
            {
                Move();
            }
            else
            {
                Error("Syntax error");
            }
        }
        private void Move()
        {
            CurrentLex = Next();
            if (CurrentLex.Tag == '\0')
            {
                return;
            }
        }
        private StatementNode Block()
        {
            Match('{');
            IdentifiersTable table = top;//иницилизируем дерево, если программа начинается с "{"
            top = new IdentifiersTable(top);//помещаем ранее созданное дерево, в конструтор дерева, как "предыдущее"
            Declare();//произвели иницилизацию всех переменных
            StatementNode node = Statements();//начинаем заполненение дерева после иницилизации всех переменных
            Match('}');
            top = table;
            return node;
        }

        public void Error(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
