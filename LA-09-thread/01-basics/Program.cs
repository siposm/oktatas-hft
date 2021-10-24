using System;
using System.Threading;

namespace _01_basics
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread( o => {
                    int id = (int)o; // object
            
                    int min = r.Next(10);
                    int max = r.Next(20, 30);

                    for (int i = min; i < max; i++)
                    {
                        Console.WriteLine($"\t [{id}] : {i}");
                    }
                });
                threads[i].Start(i);
            }

            // szinkronizációs pont // kommentezd ki és be, hogy lásd az eltérő működés vele / nélküle
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            // szekvenciális rész innentől
            for (int i = 0; i < 5; i++)
                Console.WriteLine("F I N I S H E D");

        }
    }
}
