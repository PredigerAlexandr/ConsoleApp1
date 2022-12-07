using MainSyntaxAnalysis;


Parser parser = new Parser("C:\\Users\\User\\OneDrive\\Desktop\\УлГТУ\\SAPRlab2\\ConsoleApp1\\MainSyntaxAnalysis\\Examples\\input.txt");

var syntaxTree = parser.StartParser();

Console.ReadKey();