using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_lock_2
{
    class Program
    {
        static int sum = 0;
        static object lockObject = new object();

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
            //eloszor lock nelkul, aztan:
            //lock (lockObject)
            //{
            //    for (int i = 0; i < 50000; i++)
            //    {
            //        sum = sum + 1;
            //    }
            //}

            //vegul az egesz cserelheto arra hogy:
            for (int i = 0; i < 50000; i++)
                Interlocked.Increment(ref sum); //atomi muvelet : nem megszakithato
            //nyilvan a cikluson belul, de lock nelkul
        }
    }
}
