using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = Enumerable.Range(0, 20).ToList();
            
            Parallel.For(0, A.Count, i => {
                    if (A[i] % 2 == 0)
                        Console.WriteLine("\t" + A[i]);
                }
            );

            Parallel.For(0, 20, i => Console.Write(i + " "));

            Parallel.ForEach(A, i => Console.Write(i + " "));

            // action delegate-tet / -teket fogad
            Parallel.Invoke(
                () => Console.WriteLine("A"),
                () => Console.WriteLine("B"),
                () => Console.WriteLine("C"),
                () => Console.WriteLine("D")
            );

            // PLINQ

            int[] C = new int[] { 2, 4, 6, 8, 3, 1, 5, 7, 2, 0 };

            ParallelQuery<int> pq = from x in A.AsParallel()
                                    where x % 5 == 0
                                    select x;

            pq.ForAll(i => DoWork(i));
        }

        static void DoWork(int i)
        {
            Console.WriteLine(">> " + i);
        }
    }
}
