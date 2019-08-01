using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unittesting
{
    public class Calculator // osztály public!
    {
        public string Welcome()
        {
            return "Welcome to the calculator. See owner's manual.";
        }

        public int Addition(int a, int b)
        {
            return a + b;
        }

        public int Multiplication(int a, int b)
        {
            return a * b;
        }
    }
}
