using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_lock
{
    
    // * * * * * * * * * * * * *
    //
    //      VERSENYHELYZET
    //
    // * * * * * * * * * * * * *

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

                Console.ForegroundColor = (ConsoleColor)Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {_c}");
                Console.ResetColor();
                Thread.Sleep(250);
            }
        }

        // probléma feloldása: lock-olással
        static void IncrementVersion_3()
        {
            while (true)
            {
                // A Lock is a way for us to synchronize between Threads.
                // A lock is a shared object that can be Acquired by a Thread, and also Released.
                // Once Acquired, other threads can be made to halt execution until the lock is Released.
                // A lock is usually placed around a critical section, where you want to allow a single Thread at a time.
                // -
                // The code between the brackets is executed in a thread-safe manner and will not let
                // other threads operate on the object being locked until the lock execution is completed.
                lock (threadLocker)
                {
                    int _c = counter;
                    Thread.Sleep(250);
                    counter = _c + 1; // _c++?

                    Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {_c}");
                }
                Thread.Sleep(250);
            }
        }

        static void Main(string[] args)
        {
            //Thread t1 = new Thread(IncrementVersion_1);
            //Thread t2 = new Thread(IncrementVersion_1);

            Thread t1 = new Thread(IncrementVersion_2);
            Thread t2 = new Thread(IncrementVersion_2);

            //Thread t1 = new Thread(IncrementVersion_3);
            //Thread t2 = new Thread(IncrementVersion_3);

            t1.Start();
            Thread.Sleep(300);
            t2.Start();



        }
    }
}
