﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Net;
using System.Security.Cryptography.X509Certificates;
/*Разработать консольный калькулятор.
При разработке рекомендуется:
	использовать ООП (создать класс математических действий, в котором необходимо реализовать методы для выполнения арифметических действий и т.д.);
	использовать обработку исключений;
	написать документацию к использованию калькулятора и выводить ее;
	использовать приоритет математических операций;
	уметь вычислять выражения типа: "5-4*(4-3)-6+5-(3/2)", если калькулятор не использует псевдографику;
	разработать интерфейс, используя символы псевдографики.*/
namespace crvCalc
{
    class Operations
    {
        double num1;
        double num2;
        public double Num1
        {
            get
            {
                return num1;
            }
            set
            {
                num1 = value;
            }
        }
        public double Num2
        {
            get
            {
                return num2;
            }
            set
            {
                num2 = value;
            }
        }
        public Operations() { }
        public Operations(double _num1, double _num2)
        {
            Num1 = _num1;
            Num2 = _num2;
        }
        public double Add()
        {
            return Num1 + Num2;
        }
        public double Subtract()
        {
            return Num1 - Num2;
        }
        public double Multiply()
        {
            return Num1 * Num2;
        }
        public double Divide()
        {
            return Num1 / Num2;
        }


    }
    class ExpressionLogic
    {
        string expression;
        public string Expression
        {
            get
            {
                return expression;
            }
            set
            {
                while (value.IndexOf(" ") != -1)
                {
                    value = value.Remove(value.IndexOf(" "), 1);
                }

                while (value.IndexOf(")(") != -1)
                {
                    value = value.Insert(value.IndexOf(")(") + 1, "*");
                }




                while (value.Substring(value.IndexOf('(') - 1, 1).IndexOfAny(new char[] { '*', '/', '+', '-' }) == -1)
                {
                    value = value.Insert(value.IndexOf('('), "*");
                }




                expression = value;
            }
        }

        public ExpressionLogic(string _expression)
        {
            Expression = _expression;
        }
               

        public static string FindBracket(string _expr)
        {
            //поиск ()
            int closeBracket = _expr.IndexOf(')');
            int openBracket = (_expr.Substring(0, closeBracket)).LastIndexOf('(');
            //вырезание подстроки
            string sub = _expr.Substring(openBracket + 1, closeBracket - openBracket - 1);
            return sub;
        }
        public static string BracketsToSimple(string sub)
        {
            char[] opers = { '*', '/', '+', '-' };
            while (sub.IndexOfAny(opers) != -1)
            {
                foreach (char op in opers)
                {
                    string[] numbers = sub.Split(opers);

                    if (numbers.Length == 1)
                    {


                    }

                    //if (sub.IndexOf('-') == 0)
                    //{
                    //    numbers[0] = '-' + numbers[0];
                    //    sub.Remove(0, 1);
                    //}
                    while (sub.IndexOf(op) != -1)
                    {
                        for (int i = 1; i < numbers.Length; i++)
                        {

                            if (sub.IndexOf(numbers[i], sub.IndexOf(op)) == sub.IndexOf(op) + 1)
                            {
                                double num1 = Convert.ToDouble(numbers[i - 1]);
                                double num2 = Convert.ToDouble(numbers[i]);
                                Operations calc = new Operations(num1, num2);
                                double result = 0;
                                switch (op)
                                {
                                    case '*':
                                        result = calc.Multiply();
                                        break;
                                    case '/':
                                        result = calc.Divide();
                                        break;
                                    case '+':
                                        result = calc.Add();
                                        break;
                                    case '-':
                                        result = calc.Subtract();
                                        break;
                                }
                                if (result < 0)
                                {

                                }
                                sub = sub.Replace(numbers[i - 1] + op + numbers[i], Convert.ToString(result));
                                WriteLine(sub);
                                break;
                            }
                        }
                        numbers = sub.Split(opers);
                    } 
                }
            }
            return sub;
        }





    }



    class Program
    {
        static void Main(string[] args)
        {
            Title="crvCalc v0.01";

            string testString = "152 - 2(100+5) ( 12+8)+(34,8-7(72,5+5,98)(78-5)+5(6-5)/4)";  //=-44115,23 - ?

            WriteLine(testString);
            ExpressionLogic exp1 = new ExpressionLogic(testString);


            WriteLine(exp1.Expression);

            //WriteLine(exp1.Expression.Substring(exp1.Expression.IndexOf('(') - 1, 1).IndexOfAny(new char[] { '*', '/', '+', '-' }));
            //WriteLine(exp1.Expression.Insert(exp1.Expression.IndexOf('('), "*"));

            //string tempExp = exp1.Expression;

            //while (tempExp.IndexOfAny(new char[]{'(',')' })!=-1)
            //{
            //    string sub = ExpressionLogic.FindBracket(tempExp);
            //    string tempSub = sub;
            //    WriteLine(sub);
            //    string simple = ExpressionLogic.BracketsToSimple(sub);
            //    tempExp = tempExp.Replace('(' + tempSub + ')', simple);
            //    WriteLine(tempExp);


            //}



            //try
            //{
            //
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}


            ReadKey();
        }
    }
}

