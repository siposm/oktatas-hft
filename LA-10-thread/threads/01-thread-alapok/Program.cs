using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_thread_alapok
{
    class Ember
    {
        public string Nev { get; set; }
    }

    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            Task<string> t1 = new Task<string>(() =>
           {
               Thread.Sleep(1000);
               return "alma";
           });
            t1.Start();

            Console.WriteLine(t1.Result);

            Task<Ember> t2 = Task.Run(() =>
           {
               Thread.Sleep(1000);
               return new Ember() { Nev = "Lajos" };
           });
            t2.ContinueWith<int>(x =>
            {
                Console.WriteLine("Vége a <t2> task-nak.");
                return x.Id;
            }).ContinueWith(x => Console.WriteLine("ID: " + x.Id));

            // az alsó rész megírása után komment ezt ki / be !!
            // result esetén meg kell várni az eredményt, tehát olyan mintha a .wait-et is meghívnánk
            //t2.Wait();
            Console.WriteLine(t2.Result);



            // --------------------------------------------------------------------



            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Count);
                threads[i].Start(i);
            }

            //szinkronizációs pont // kommentezd ki és be
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            //szekvenciális rész
            Console.ResetColor();
            for (int i = 0; i < 5; i++)
                Console.WriteLine("F I N I S H E D");
        }

        // process esetén ezt a metódust csináltuk volna meg külön exe-ként
        static void Count(object o)
        {
            int id = (int)o;
            
            int min = r.Next(100);
            int max = r.Next(200, 800);

            for (int i = min; i < max; i++)
            {
                Console.ForegroundColor = (ConsoleColor)id;
                Console.WriteLine(i);
            }
        }
    }
}
