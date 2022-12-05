using MainSyntaxAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSyntaxAnalysis.Constants
{
    public class DataTypes
    {
        public static DataType Int = new DataType("int", (int)Tags.Basic, 4);
        public static DataType Float = new DataType("float", (int)Tags.Basic, 8);
        public static DataType Char = new DataType("char", (int)Tags.Basic, 1);
        public static DataType Bool = new DataType("bool", (int)Tags.Basic, 1);

        public static Dictionary<string, DataType> DateTypesDictionary = new Dictionary<string, DataType>(){
            {"int", Int},
            {"float", Float},
            {"bool", Bool},
            {"char", Char }
        };
    }
}
