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
            //int[] A = new int[] { 2, 4, 6, 8, 3, 1, 5, 7, 2, 0 };

            List<int> A = Enumerable.Range(0, 10).ToList();

            Parallel.For(0, A.Count,
                i => Console.WriteLine("\t" + A[i])
            );

            Parallel.For(0, 100, i => Console.Write(i + " "));

            Parallel.ForEach(A, i => Console.Write(i + " "));

            Parallel.Invoke(
                () => Console.WriteLine("A"),
                () => Console.WriteLine("B"),
                () => Console.WriteLine("C"),
                () => Console.WriteLine("D"),
                () => Console.WriteLine("E")
            );

            //eddig blokkol
            Console.WriteLine("Vege");

            foreach (var e in A.AsParallel().Select(x => x))
                Console.Write(e + " ");
        }
    }
}
