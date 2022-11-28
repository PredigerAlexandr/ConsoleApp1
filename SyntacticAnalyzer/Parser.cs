using ConsoleApp1;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalyzer
{
    public class Parser
    {
        Tuple<List<Lexem>, List<Variable>> result;
        public Parser()
        {
            Analysis _analisys = new Analysis();
            string filePath = "C:\\Users\\User\\OneDrive\\Desktop\\SAPR-master\\ConsoleApp1\\files\\input.txt";
            result = _analisys.AnalysisProcess(filePath);
        }


    }
}
