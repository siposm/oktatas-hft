using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_task_alapok
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
            }).ContinueWith(x => Console.WriteLine("ID: " + x.Id)); // ez nem mindig látszódik, .wait-tel meg lehet várni...



            // result esetén meg kell várni az eredményt, tehát olyan mintha a .wait-et is meghívnánk
            //t2.Wait();

            // az alsó rész megírása után komment ezt ki / be !!
            Console.WriteLine(t2.Result);


            // task indítási lehetőségek:
            //Task task1 = new Task(new Action(PrintMessage));
            //Task task2 = new Task(delegate { PrintMessage(); });
            //Task task3 = new Task(() => PrintMessage());
            //Task task4 = new Task(() => { PrintMessage(); });



            // ------------------------------------------------------------------------------------------------



            // FELADAT: a 01-es project-ben található feladatot megvalósítani task segítségével

            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                // new Task ( Action delegate )
                tasks[i] = new Task(Count, i);
                tasks[i].Start();

                // task.run vs task.start !
            }

            // sync
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                Console.ResetColor();
                Console.WriteLine("\n---------\n");
                for (int i = 0; i < 10; i++)
                {
                    //System.Threading.Thread.Sleep(250);
                    Console.WriteLine($"\t{i}. task finished");
                }
                Console.WriteLine("\n---------\n");
            }).Wait();
        }

        static void Count(object o)
        {
            int id = (int)o;

            int min = r.Next(10);
            int max = r.Next(20, 80);

            for (int i = min; i < max; i++)
            {
                Console.ForegroundColor = (ConsoleColor)id;
                Console.WriteLine(i);
            }
        }
    }
}
