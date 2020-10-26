using System;

namespace Calculator
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public int Mul(int a, int b)
        {
            return a * b;
        }

        public double Div(int what, int with)
        {
            if (with == 0)
                throw new DivideByZeroException("ERR :: cannot divide by zero");

            return what / with;
        }
    }
}
