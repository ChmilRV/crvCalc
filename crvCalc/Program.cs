using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Net;
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
        double result;
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
    class Expression
    {
        public string expression;
        public Expression(string expression)
        {
            this.expression = expression;
        }

        public static List<string> GetWithIn(string _expr)
        {
            List<string> res = new List<string>();
            Regex bracketPattern = new Regex(@"\((?<val>.*?)\)", RegexOptions.Compiled | RegexOptions.Singleline);      //????????????
            foreach (Match m in bracketPattern.Matches(_expr)) if (m.Success) res.Add(m.Groups["val"].Value);
            return res;

        }

        public static List<string> BracketsToSimple(string _expr)
        {
            List<string> res = new List<string>();
            int startBracket = _expr.IndexOf('(');

            return res;
        }


    }




    class Program
    {
        static void Main(string[] args)
        {
            Title="crvCalc v0.01";
            //Operations calc = new Operations();
            //WriteLine(calc.Add());
            
            Expression exp1 = new Expression("152-(89.7+5765,9438*655,83127)+(34.8-(72.5+5.98)+(6-5)/4)");
            WriteLine(exp1.expression);
            List<string> lists_1 = Expression.BracketsToSimple(exp1.expression);
            foreach (string item in lists_1) WriteLine(item);

            //поиск ()
            int closeBracket = exp1.expression.IndexOf(')');
            int openBracket = (exp1.expression.Substring(0,closeBracket)).LastIndexOf('(');
            
            //вырезание подстроки
            string sub1 = exp1.expression.Substring(openBracket+1,closeBracket-openBracket-1);
            WriteLine(sub1);

            char[] subChar = sub1.ToCharArray();
            List<int> positOper = new List<int>();
            for (int i = 0; i < subChar.Length; i++)
            {
                if ((subChar[i] == '*') || (subChar[i] == '/') || (subChar[i] == '+') || (subChar[i] == '-'))
                {
                    positOper.Add(i);
                }
            }
            foreach (int item in positOper) WriteLine(item);

            char[] opers = { '+', '-', '*', '/' };
            char[] opersFirst = { '*', '/' };  //первичный приоритет операторов
            char[] opersSecond = { '+', '-' };  //вторичный приоритет операторов

            //поиск оператора первичного приоритета
            int indexOpersFirst = sub1.IndexOfAny(opersFirst);
            WriteLine(indexOpersFirst);
            double num11 = Convert.ToDouble(sub1.Substring(positOper[0]+1,positOper[1]-positOper[0]-1));
            double num22 = Convert.ToDouble(sub1.Substring(indexOpersFirst+1));
            WriteLine(num11);
            WriteLine(num22);










            //Expression exp2 = new Expression("5-4*(4-3)-6+5-(3/2)");
            //WriteLine(exp2.expression);
            //List<string> lists_2 = Expression.GetWithIn(exp2.expression);
            //foreach (string item in lists_2) WriteLine(item);





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

