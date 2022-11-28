using ConsoleApp1.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Analysis _analisys = new Analysis();
            string filePath = "C:\\Users\\User\\OneDrive\\Desktop\\SAPR-master\\ConsoleApp1\\files\\input.txt";
            Tuple<List<Lexem>,List<Variable>> result = _analisys.AnalysisProcess(filePath);
            Console.WriteLine("Lexems:\n");
            foreach(var item in result.Item1)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nVariables:\n");
            foreach (var item in result.Item2)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
