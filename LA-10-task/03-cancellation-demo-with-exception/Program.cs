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

            cts.Cancel();

            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is OperationCanceledException) // This we know how to handle.
                    {
                        Console.WriteLine("The operation was canceled.");
                        return true; // Mark as 'handled'
                    }
                    return false; // Let anything else stop the application.
                });
            }


            Console.ReadLine();
        }
    }
}
