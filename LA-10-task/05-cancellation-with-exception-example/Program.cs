using System;
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

                // comment in and out this if to see that the exception is not handled
                if (i == 6)
                    throw new IndexOutOfRangeException("Some exception which is NOT handled!");
            }
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task taskWithCancel = Task.Run(() => CancellableLongOperation(cts.Token), cts.Token);

            //cts.Cancel(); // comment this in and out to see different outputs

            try
            {
                taskWithCancel.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is OperationCanceledException) // This is what we know how to handle.
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
