﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace _05_cancellation_with_exception_example
{
    class Program
    {
        static void CancellableLongOperation(CancellationToken ct)
        {
            for (int i = 0; i < 10 && !ct.IsCancellationRequested; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            Task taskWithCancel = Task.Run(() => CancellableLongOperation(source.Token), source.Token);

            source.Cancel(); // comment this in and out to see different outputs

            try
            {
                taskWithCancel.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is OperationCanceledException) // This we know how to handle.
                    {
                        Console.WriteLine("The operation was aborted.");
                        return true; // Mark as 'handled'
                    }
                    return false; // Let anything else stop the application.
                });
            }

        }
    }
}
