using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _03_cancellation_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task t = new Task(() => {
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + "\t");
                    cts.Token.ThrowIfCancellationRequested();
                }
            }, cts.Token);

            t.ContinueWith(x => {
                Console.WriteLine("STOPPED!");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.Start();
            Console.WriteLine("STARTED!");
            Console.Write("... WAITING FOR INPUT: ");
            Console.ReadLine();
            Console.WriteLine("CANCELLING...");
            cts.Cancel();


            //Console.ReadLine();
        }
    }
}
