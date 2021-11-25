using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _06_cancellation_demo_with_continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(300);
                    Console.Write(i + "\t");

                    if (cts.Token.IsCancellationRequested)
                    {
                        cts.Token.ThrowIfCancellationRequested();
                    }
                }
            }, cts.Token);

            task.ContinueWith(x =>
            {
                Console.WriteLine("TASK HAS BEEN CANCELED.");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Thread.Sleep(2000);
            Console.WriteLine("Cancellation starting in 2 seconds...");
            Thread.Sleep(2000);
            cts.Cancel();
            Console.WriteLine("Cancellation finished!");

            Console.ReadLine();
        }
    }
}
