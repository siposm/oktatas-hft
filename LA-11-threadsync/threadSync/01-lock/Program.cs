using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_lock
{
    class Program
    {
        static int counter = 0;
        static object threadLocker = new object();

        // nincs probléma, globális változón dolgozik
        static void IncrementVersion_1()
        {
            while (true)
            {
                counter++;
                Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {counter}");
                Thread.Sleep(250);
            }
        }

        // megjelenik a probléma, mert saját belső változóval kezdünk dolgozni
        // (amit a különböző szálak (jelen esetben 2) a működés során "összekevernek")
        static void IncrementVersion_2()
        {
            while (true)
            {
                int _c = counter;
                Thread.Sleep(250);
                counter = _c + 1;

                Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {_c}");
                Thread.Sleep(250);
            }
        }

        // probléma feloldása: lock-olással
        static void IncrementVersion_3()
        {
            while (true)
            {
                lock(threadLocker)
                {
                    int _c = counter;
                    Thread.Sleep(250);
                    counter = _c + 1;

                    Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {_c}");
                }
                Thread.Sleep(250);
            }
        }

        static void Main(string[] args)
        {
            //Thread t1 = new Thread(IncrementVersion_1);
            //Thread t2 = new Thread(IncrementVersion_1);

            //Thread t1 = new Thread(IncrementVersion_2);
            //Thread t2 = new Thread(IncrementVersion_2);

            Thread t1 = new Thread(IncrementVersion_3);
            Thread t2 = new Thread(IncrementVersion_3);

            t1.Start();
            Thread.Sleep(300);
            t2.Start();



        }
    }
}
