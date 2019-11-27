using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_thread_alapok
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Count);
                threads[i].Start(i);
            }

            // szinkronizációs pont // kommentezd ki és be, hogy lásd az eltérő működés vele / nélküle
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            // szekvenciális rész innentől
            Console.ResetColor();
            for (int i = 0; i < 5; i++)
                Console.WriteLine("F I N I S H E D");
        }

        // process esetén ezt a metódust csináltuk volna meg külön exe-ként
        static void Count(object o)
        {
            int id = (int)o;
            
            int min = r.Next(100);
            int max = r.Next(200, 800);

            for (int i = min; i < max; i++)
            {
                Console.ForegroundColor = (ConsoleColor)id;
                Console.WriteLine(i);
            }
        }
    }
}
