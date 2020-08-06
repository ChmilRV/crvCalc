﻿using System;
using static System.Console;
using System.Globalization;
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
		//public Operations() { }
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

				//while (value.Substring(value.IndexOf('(') - 1, 1).IndexOfAny(new char[] { '*', '/', '+', '-' }) == -1)
				//{
				//    value = value.Insert(value.IndexOf('('), "*");
				//}





				expression = value;
			}
		}
		public ExpressionLogic(string _expression)
		{
			Expression = _expression;
		}
		public static string FindBracket(string _expr)
		{

			string sub;
			int openBracket;
			int closeBracket = _expr.IndexOf(')');
			if (closeBracket != -1)
			{
				openBracket = (_expr.Substring(0, closeBracket)).LastIndexOf('(');
				sub = _expr.Substring(openBracket + 1, closeBracket - openBracket - 1);
			}
			else sub = _expr;
			return sub;
		}
		public static string BracketsToSimple(string sub)
		{
			//IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
			char[] opers = { '*', '/', '+', '-' };
			string[] numbers;

			while (sub.IndexOfAny(opers, 1) != -1)
			{

				foreach (char op in opers)
				{
					
					if (sub.IndexOf('-')==0) 
					{
						numbers = (sub.Remove(0,1)).Split(opers);
						numbers[0] = '-' + numbers[0];
					}
					else numbers = sub.Split(opers);

					while (sub.IndexOf(op, 1) != -1 )
					{
						for (int i = 1; i < numbers.Length; i++)
						{
							if (sub.IndexOf(numbers[i], sub.IndexOf(op,1)) == sub.IndexOf(op,1) + 1)
							{
								double num1 = Convert.ToDouble(numbers[i - 1]/*, formatter*/);
								double num2 = Convert.ToDouble(numbers[i]/*, formatter*/);
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

								sub = sub.Replace(numbers[i - 1] + op + numbers[i], Convert.ToString(result));
								
								//WriteLine(sub);
								break;
							}
						}

						if (sub.IndexOf('-') == 0)
						{
							numbers = sub.Remove(0,1).Split(opers);
							numbers[0] = '-' + numbers[0];
						}
						else numbers = sub.Split(opers);

					}
		
				}

			}
			return sub;
		}


		public static string ExpressionToResult(string _expr)
		{
            string tempExp = _expr;
			do
            {
                string sub = FindBracket(tempExp);
                string tempSub = sub;
                //WriteLine(sub);
                string simple = BracketsToSimple(sub);
				if (tempExp.IndexOfAny(new char[] { '(', ')' }) != -1) tempExp = tempExp.Replace('(' + tempSub + ')', simple);
                else tempExp = tempExp.Replace(tempSub, simple);
				//WriteLine(tempExp);

				tempExp = tempExp.Replace("+-", "-");
                tempExp = tempExp.Replace("--", "+");


                WriteLine(tempExp);

            } while (tempExp.Split(new char[] { '*', '/', '+', '-' }).Length > 2);

			return tempExp;
		}





	}



	class Program
	{
		static void Main(string[] args)
		{
			Title="crvCalc v0.01";

			//string testString = "-2*(-10-12)- 2*(100+5) ( 8-13)+(34,8-(72,5+5,98)(78-5)+(4-5)/4)*(-5)";
			string testString = "(-125+25-15)+(3-18)*2-25";
			WriteLine(testString);
			ExpressionLogic exp1 = new ExpressionLogic(testString);
			WriteLine(exp1.Expression);
			string tempExp = exp1.Expression;
			string resultExp = ExpressionLogic.ExpressionToResult(tempExp);

			

			WriteLine(resultExp);

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

