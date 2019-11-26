using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

            Parallel.ForEach(A, i => Console.Write(i + " "));

            // action delegate-tet / -teket fogad
            Parallel.Invoke(
                () => Console.WriteLine("A"),
                () => Console.WriteLine("B"),
                () => Console.WriteLine("C"),
                () => Console.WriteLine("D")
            );


            // ------------------------------------------------------------------------
            // PLINQ

            int[] C = new int[] { 2, 4, 6, 8, 3, 1, 5, 7, 2, 0 };

            ParallelQuery<int> pq = from x in C.AsParallel()
                                    where x % 5 == 0
                                    select x;

            pq.ForAll(i => DoWork(i));


            Console.WriteLine("\n-\t-\t-\t-\n");
            // ------------------------------------------------------------------------
            // párhuzamos feldolgozás vs szekvenciális (megéri?)

            // ESET 1.
            int sum = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 100000, x => sum += x);
            sw.Stop();

            Console.WriteLine("PAR TIME:\t" + sw.Elapsed);

            sw.Reset();
            sw.Start();
            sum = 0;
            for (int i = 0; i < 100000; i++) sum += i;
            sw.Stop();

            Console.WriteLine("SEQ TIME:\t" + sw.Elapsed);

            // ez esetben látható, hogy a feladat nem jól párhuzamosítható...





            Console.WriteLine("\n-\t-\t-\t-\n");
            
            // ESET 2.
            sw.Reset();
            sw.Start();
            Parallel.For(0, 100000, x => Encrypt());
            sw.Stop();

            Console.WriteLine("PAR TIME:\t" + sw.Elapsed);

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 100000; i++) Encrypt();
            sw.Stop();

            Console.WriteLine("SEQ TIME:\t" + sw.Elapsed);

            // ebben az esetben pedig elég nagy feladatot választva (for iterációszám) végül a párhuzamos megmutatja előnyét
        }

        static string Encrypt(string stringToEncrypt = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce aliquam magna ligula. Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
        {
            string retValue = "";

            Rijndael rij = Rijndael.Create();
            rij.GenerateKey();
            rij.GenerateIV();

            ICryptoTransform transformer = rij.CreateEncryptor();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, transformer, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(stringToEncrypt);

            retValue = Encoding.UTF8.GetString(ms.ToArray());

            return retValue;
        }

        static void DoWork(int i)
        {
            Console.WriteLine(">> " + i);
        }
    }
}
