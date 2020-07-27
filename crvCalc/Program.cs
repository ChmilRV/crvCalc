using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Schema;
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
            Operations calc = new Operations();
            //WriteLine(calc.Add());
            
            Expression exp1 = new Expression("12+(34-(2.5+5)+(6-5)/4)");
            WriteLine(exp1.expression);
            List<string> lists_1 = Expression.BracketsToSimple(exp1.expression);
            foreach (string item in lists_1) WriteLine(item);

            int firstOpenBracket = exp1.expression.IndexOf('(');
            WriteLine(firstOpenBracket);
            int firstCloseBracket = exp1.expression.IndexOf(')');
            WriteLine(firstCloseBracket);
            int secondOpenBracket = exp1.expression.IndexOf('(', firstOpenBracket+1);
            WriteLine(secondOpenBracket);


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
