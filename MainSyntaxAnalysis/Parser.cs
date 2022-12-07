using MainSyntaxAnalysis.Constants;
using MainSyntaxAnalysis.Models;
using MainSyntaxAnalysis.Node;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataType = MainSyntaxAnalysis.Models.DataType;

namespace MainSyntaxAnalysis
{
    public class Parser
    {
        private LexemAnalysis _lexemAnalysis;
        private Token currentLexem;
        private int codeLine = 0;
        IdentifiersTable top = null;

        public Parser(string path)
        {
            _lexemAnalysis = new LexemAnalysis(path);
        }

        public StatementNode StartParser()
        {
            Move();
            StatementNode baseNode = Block();//начинаем обработку самого внешнего блока
            return baseNode;
        }

        //обрабатывает первые фигурные скобки 
        private StatementNode Block()
        {
            Match('{');
            StatementNode node = Statements();//
            Match('}');
            return node;
        }

        private StatementNode Statements()
        {
            if (currentLexem.Tag == '}')
            {
                return new EmptyNode();
            }
            else
            {
                return new StatementNode(Statement(), Statements());
            }
        }

        private StatementNode Statement()
        {
            ExpressionNode expression;
            StatementNode statement,
                statement1,
                statement2;

            switch (currentLexem.Tag)
            {
                case (int)Tags.If:
                    Match((int)Tags.If);
                    Match('(');
                    expression = Bool();
                    Match(')');
                    statement1 = Statement();
                    if (currentLexem.Tag != (int)Tags.Else)
                    {
                        return new IfNode(expression, statement1);
                    }
                    Match((int)Tags.Else);
                    statement2 = Statement();
                    return new IfElseNode(expression, statement1, statement2);
                case (int)Tags.Basic:
                    statement = Declare();
                    return statement;
                case '{':
                    return Block();
                default:
                    return Assign();
            }
        }

        //Обрабатываем процесс присванивания
        private StatementNode Assign()
        {
            StatementNode statement;
            Token token = currentLexem;
            Match((int)Tags.Id);

            if (!Words.KeyWords.ContainsKey(((Word)token).Value))//проверяем была ли ранее объявленна переменная и если нет, то выкидываем ошибку
            {
                throw new Exception($"Use of undeclared variable {token}");
            }
            Match('=');
            statement = new AssignNode(Words.IdentifiersTable[((Word)token).Value], Bool());//создаём ноду присваения, также в ней проверяется, чтобы числовому типу могло присвоится числовое выржение, а логическому выражению логическое и если инача, то выкидывает ошибку 
            Match(';');
            return statement;
        }

        //обработка '||' случая// последня инстанция обработки
        private ExpressionNode Bool()
        {
            ExpressionNode expression = Join();
            while (currentLexem.Tag == (int)Tags.Or)
            {
                Token token = currentLexem;
                Move();
                expression = new OrNode(token, expression, Join());
            }
            return expression;
        }

        //обработка случая '&&' // '&&'->'||'
        private ExpressionNode Join()
        {
            ExpressionNode expression = Equality();
            while (currentLexem.Tag == (int)Tags.And)
            {
                Token token = currentLexem;
                Move();
                expression = new AndNode(token, expression, Equality());
            }
            return expression;
        }

        //обработка '==' и '!' // '==' и '!' -> '&&'
        private ExpressionNode Equality()
        {
            ExpressionNode expression = Comparison();
            while (currentLexem.Tag == (int)Tags.Eq || currentLexem.Tag == (int)Tags.Ne)
            {
                Token token = currentLexem;
                Move();
                expression = new ComparisonNode(token, expression, Comparison());
            }
            return expression;
        }

        //обработка '>' и '<'// '>' и '<' -> '==' и '!'
        private ExpressionNode Comparison()
        {
            ExpressionNode expression = Expression();
            switch (currentLexem.Tag)
            {
                case '<':
                case (int)Tags.Le:
                case (int)Tags.Ge:
                case '>':
                    Token token = currentLexem;
                    Move();
                    return new ComparisonNode(token, expression, Expression());
                default:
                    return expression;
            }
        }

        //обработка выражений с '+' и '-'// '+' и '-' -> '>' и '<'
        private ExpressionNode Expression()
        {
            ExpressionNode expression = Term();
            while (currentLexem.Tag == '+'
                || currentLexem.Tag == '-')
            {
                Token token = currentLexem;
                Move();
                expression = new ArithmeticNode(token, expression, Term());
            }
            return expression;
        }

        //обработка выражений с '*' и '/'// '*' и '/' -> '+' и '-'
        private ExpressionNode Term()
        {
            ExpressionNode expression = Unary();
            while (currentLexem.Tag == '*'
                || currentLexem.Tag == '/')
            {
                Token token = currentLexem;
                Move();
                expression = new ArithmeticNode(token, expression, Unary());
            }
            return expression;
        }

        private ExpressionNode Unary()
        {
            if (currentLexem.Tag == '-')
            {
                Move();
                return new UnaryNode(Words.Minus, Unary());
            }
            else if (currentLexem.Tag == '!')
            {
                Token token = currentLexem;
                Move();
                return new NotNode(token, Unary());
            }
            else if (currentLexem.Tag == (int)Tags.Inc)
            {
                Move();
                return new UnaryNode(Words.Inc, Factor());//будет работать только для контрукций типа ++а
            }
            else if (currentLexem.Tag == (int)Tags.Dec)
            {
                Move();
                return new UnaryNode(Words.Dec, Factor());//будет работать только для контрукций типа --а
            }
            else
            {
                return Factor();
            }
        }
        //переменная не может быть использована без чистой инициализации, только после этого она может быь использована, поэтому начало каждого блока проверяется на иницилизацию
        private StatementNode Declare()
        {
            StatementNode statement;
            if (DataTypes.DateTypesDictionary.ContainsKey(((Word)currentLexem).Value))//проверяем на нахождения данного типа данных в нашем списке типов
            {
                throw new Exception($"Найден неопознанный тип данных в строке: {codeLine}");
            }
            DataType type = (DataType)currentLexem;//задаём тип данных
            Move();
            Token token = currentLexem;
            Match((int)Tags.Id);
            statement = new InitializationNode( type, (Word)token);
            Words.IdentifiersTable.Add(((Word)token).Value, new InitializationNode(type, (Word)token));//добавляем в таблицу идентификаторов саму переменную и её ноду иницилизации, которая хранит информацию о типе переменной
            Match(';');

            return statement;    
        }

        private ExpressionNode Factor()
        {
            ExpressionNode expressionNode = null;

            switch (currentLexem.Tag)
            {
                case '(':
                    Move();
                    expressionNode = Bool();
                    Match(')');
                    return expressionNode;
                case (int)Tags.Num:
                    expressionNode = new ConstantNode(currentLexem, DataTypes.Int);
                    Move();
                    return expressionNode;
                case (int)Tags.Real:
                    expressionNode = new ConstantNode(currentLexem, DataTypes.Float);
                    Move();
                    return expressionNode;
                case (int)Tags.True:
                    expressionNode = new ConstantNode(Words.True, DataTypes.Bool);
                    Move();
                    return expressionNode;
                case (int)Tags.False:
                    expressionNode = new ConstantNode(Words.False, DataTypes.Bool);
                    Move();
                    return expressionNode;
                case (int)Tags.Id:
                    ExpressionNode identifier = new ExpressionNode(new Token(Words.IdentifiersTable[((Word)currentLexem).Value].Word.Tag), Words.IdentifiersTable[((Word)currentLexem).Value].DataType);
                    if (identifier == null)
                    {
                        throw new Exception ($"Use of undeclared variable {currentLexem}");
                    }
                    Move();
                    return identifier;
                default:
                    return expressionNode;
                    throw new Exception("Syntax error");
            }
        }




        //проверяем на предполагаемый элемент
        private void Match(int t)
    {
        if (currentLexem.Tag == t)
        {
            Move();
        }
        else
        {
            throw new Exception($"Ошибка ожидаемой лексемы, строка: {codeLine}");
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
