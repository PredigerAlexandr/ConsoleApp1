using MainSyntaxAnalysis.Constants;
using MainSyntaxAnalysis.Models;
using MainSyntaxAnalysis.Node;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void StartParser()
        {
            StatementNode baseNode = Block();//начинаем обработку самого внешнего блока
        }

        //обрабатывает первые фигурные скобки 
        private StatementNode Block()
        {
            Match('{');
            StatementNode node = Statements();//

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
            if (currentLexem.Tag == '=')
            {
                Move();
                statement = new AssignNode(Words.IdentifiersTable((Word)token).Value, Bool());//создаём ноду присваения, также в ней проверяется, чтобы для числовому типу могло присвоится числовое выржение, а логическому выражению логическое и если инача, то выкидывает ошибку 
            }
            Match(';');
            return statement;
        }

        private ExpressionNode Bool()
        {
            ExpressionNode expression = Join();
            while (Lookahead.Tag == (int)Tags.Or)
            {
                Token token = Lookahead;
                Move();
                expression = new OrNode(token, expression, Join());
            }
            return expression;
        }

        private ExpressionNode Join()
        {
            ExpressionNode expression = Equality();
            while (Lookahead.Tag == (int)Tags.And)
            {
                Token token = Lookahead;
                Move();
                expression = new AndNode(token, expression, Equality());
            }
            return expression;
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
            Words.IdentiiersTable.Add(((Word)token).Value, new InitializationNode(type, (Word)token));//добавляем в таблицу идентификаторов саму переменную и её ноду иницилизации, которая хранит информацию о типе переменной
            Match(';');

            return statement;    
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
