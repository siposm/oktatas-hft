using System;
using System.Threading.Tasks;

namespace _07_lock
{
    class Processor
    {
        public static int sum = 0;
        public static object lockObject = new object();

        public static void Count()
        {
            for (int i = 0; i < 50000; i++)
            {
                // lock (lockObject)
                {
                    sum = sum + 1;
                }
            }
        }
    }

    class Program
    {
        // The problem occurs if the "job" is in a separate class and even if it is in the same class.

        static int sum = 0;
        static object lockObject = new object();

        static void Main(string[] args)
        {
            // option A.
            // Task t1 = Task.Run(() => Count());
            // Task t2 = Task.Run(() => Count());

            // option B.
            Task t1 = Task.Run(() => Processor.Count());
            Task t2 = Task.Run(() => Processor.Count());

            Task.WhenAll(t1, t2).ContinueWith(x =>
             {
                 // option A.
                 //Console.WriteLine("SUM: " + sum);

                 // option B.
                 Console.WriteLine("SUM: " + Processor.sum);
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
