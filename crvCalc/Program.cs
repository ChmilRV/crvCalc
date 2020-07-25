using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //double stored;
        //Boolean isStored;

        public Operations() { }
        public double Add()
        {
            return result = (this.num1 + this.num2);
        }
        public double Subtract()
        {
            return result = (this.num1 - this.num2);
        }
        public double Multiply()
        {
            return result = (this.num1 * this.num2);
        }
        public double Divide()
        {
            return result = ((this.num1) / (this.num2));
        }
        //public double SquareRootNumber1()
        //{
        //    result = Math.Sqrt(this.number1);
        //    return result;
        //}
        //public double SquareRootNumber2()
        //{
        //    result = Math.Sqrt(this.number2);
        //    return result;
        //}
        //public Boolean isMemoryUsed()
        //{
        //    if (this.stored == 0)
        //    {
        //        this.isStored = false;
        //        return isStored;
        //    }
        //    else
        //        this.isStored = true;
        //    return this.isStored;
        //}
        //public double MemoryStore(double paramater_store1)
        //{
        //    this.stored = this.stored + paramater_store1;
        //    return this.stored;
        //}
        //public double MemoryRecall()
        //{
        //    if (MemoryStore(this.stored) == 0)
        //        return 0;
        //    else
        //        return MemoryStore(this.stored);
        //}
        //public double MemoryAdd(double paramater_store2)
        //{
        //    this.stored = this.stored + paramater_store2;
        //    return this.stored;
        //}
        //public double MemorySubtract(double paramater_store3)
        //{
        //    this.stored = this.stored - paramater_store3;
        //    return this.stored;
        //}
        //public double MemoryClear()
        //{
        //    return this.stored = 0;
        //}
    }






    class Program
    {
        static void Main(string[] args)
        {
            Console.Title="crvCalc v0.01";
            Operations calc = new Operations();
            try
            {
                
                


            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }
}
