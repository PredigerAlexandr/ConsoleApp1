﻿using MainSyntaxAnalysis.Constants;
using MainSyntaxAnalysis.Models;
using MainSyntaxAnalysis.Node;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            BaseNode baseNode = Block();//начинаем обработку самого внешнего блока
        }

        //обрабатывает первые фигурные скобки 
        private StatementNode Block()
        {
            Match('{');
            IdentifiersTable table = top;//резервирует локальные переменные внешенго блока
            top = new IdentifiersTable(top);//создаёт новую таблицу идентификаторов для локальных переменных
            Declare();
            StatementNode node = Statements();//

            return node;
        }

        private StatementNode Statements()
        {
            if (currentLexem.Tag == '}')
            {
                return StatementNode.Null;
            }
            else
            {
                return new SequenceNode(Statement(), Statements());
            }
        }

        private StatementNode Statement()
        {
            ExpressionNode expression;
            StatementNode statement,
                statement1,
                statement2,
                savedStatement;

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
                case '{':
                    return Block();
                default:
                    return Assign();
            }
        }

        //переменная не может быть использована без чистой инициализации, только после этого она может быь использована, поэтому начало каждого блока проверяется на иницилизацию
        private void Declare()
        {
            while (currentLexem.Tag == (int)Tags.Basic)//проверяем на то, чтобы ади токена соответствовал айди типу данных
            {
                if (DataTypes.DateTypesDictionary.ContainsKey(((Word)currentLexem).Value))//проверяем на нахождения данного типа данных в нашем списке типов
                {
                    throw new Exception($"Найден неопознанный тип данных в строке: {codeLine}");
                }
                DataType type = (DataType)currentLexem;//задаём тип данных
                Move();
                Token token = currentLexem;
                Match((int)Tags.Id);
                Match(';');
                IdentifierNode node = new IdentifierNode((Word)token, type);
                top.Put(token, node);//добавляем иницилизрованные переменные в локальную таблицу идентификаторов
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
