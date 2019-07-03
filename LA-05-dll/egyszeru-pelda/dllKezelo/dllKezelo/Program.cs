using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CalculatorLibrary; // saját dll usingolása!

namespace dllKezelo
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine(calc.Addition(10, 25));
            Console.WriteLine(calc.Substraction(50,12));


        }
    }
}
