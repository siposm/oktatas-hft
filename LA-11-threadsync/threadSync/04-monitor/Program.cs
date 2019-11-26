using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_monitor
{
    class Program
    {
        static int sum = 0;
        static object lockObject = new object();

        // Egyéb példák: https://docs.microsoft.com/en-us/dotnet/api/system.threading.monitor?view=netframework-4.8

        static void Main(string[] args)
        {
            Thread th01 = new Thread(Count);
            Thread th02 = new Thread(Count);
            th01.Start();
            th02.Start();
            th01.Join();
            th02.Join();
            Console.WriteLine("Sum: " + sum);
            Console.ReadLine();
        }

        static void Count()
        {
            for (int i = 0; i < 50000; i++)
            {
                // Remember, we said that the  lock  statement is actually  Monitor.Enter() 
                // and  Monitor.Exit()  under the hood. When using those methods, it’s possible to
                // pass a Timeout as a parameter. This means that if the locked failed to Acquire
                // within the Timeout, False is returned.

                //Monitor.Enter(lockObject)
                Monitor.TryEnter(lockObject, TimeSpan.FromMilliseconds(100));

                try
                {
                    int _c = sum;
                    sum = _c + 1;
                    //Interlocked.Increment(ref sum);
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
        }
    }
}
