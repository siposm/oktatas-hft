using System;
using System.Threading.Tasks;

namespace _07_lock
{
    class Program
    {
        static int sum = 0;
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => Count());
            Task t2 = Task.Run(() => Count());

            Task.WhenAll(t1, t2).ContinueWith(x =>
             {
                 Console.WriteLine("SUM: " + sum);
             });

            Console.ReadLine();
        }

        static void Count()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (lockObject)
                {
                    sum = sum + 1;
                }
            }
        }
    }
}
