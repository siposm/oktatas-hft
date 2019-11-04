using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.Parse(args[0]);
            int max = int.Parse(args[1]);

            int sum = 0;
            for (int i = min; i <= max; i++)
            {
                Console.WriteLine($"[{i}]");
                System.Threading.Thread.Sleep(250); // negyed msp
                sum += i;
            }
            Console.WriteLine(" > SUM: " + sum);
        }
    }
}
