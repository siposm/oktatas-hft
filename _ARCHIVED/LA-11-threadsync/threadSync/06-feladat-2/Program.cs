using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_feladat_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int darab = 0;
            sw.Start();
            
            Parallel.For(1, 10000000, i => {
                if (IsPrime(i))
                    //darab++;      //versenyhelyzet, lock?
                    Interlocked.Increment(ref darab);   //atomi muvelettel gyorsabb
            });

            sw.Stop();

            Console.WriteLine(darab);
            Console.WriteLine(sw.Elapsed);

        }

        static int PrimeSearch(int from, int to)
        {
            int count = 0;
            for (int i = from; i <= to; i++)
                if (IsPrime(i))
                    count++;
            return count;
        }

        static bool IsPrime(int szam)
        {
            if (szam <= 1) return false;
            if (szam <= 3) return true;
            for (int i = 2; i <= (int)Math.Sqrt(szam); i++)
                if (szam % i == 0)
                    return false;
            return true;
        }
    }
}
