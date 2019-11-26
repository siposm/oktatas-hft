using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_deadlock
{
    // * * * * * * * * * * * * *
    //
    //      HOLTPONT
    //          két szál egyidejűleg várakozik ugyan arra az erőforrásra, de egyik sem szerzi meg
    //
    // * * * * * * * * * * * * *

    class Program
    {
        static void Main(string[] args)
        {
            object o1 = new object();
            object o2 = new object();

            Console.WriteLine(">> STARTED...");

            var task1 = Task.Run(() =>
            {
                lock (o1)
                {
                    Thread.Sleep(1000);
                    lock (o2) { Console.WriteLine("thread 1 done"); }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (o2)
                {
                    Thread.Sleep(1000);
                    lock (o1) { Console.WriteLine("thread 2 done"); }
                }
            });

            Task.WaitAll(task1, task2);

            // debug
            // debug > break all
            // debug > windows > threads

            // megoldás 1: ugyan abban a sorrendben lock-olni (o1 o2 aztán megint o1 o2 objektumra hivatkozás jelen feladatban)
            // megoldás 2: timeout használata (lásd 04 project)

            Console.WriteLine(">> FINISHED...");
        }
    }
}
