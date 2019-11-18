using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_task_alapok
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            // FELADAT: a 01-es project-ben található feladatot megvalósítani task segítségével

            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(Count, i);
                tasks[i].Start();
            }

            // sync
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                Console.WriteLine("\n---------\n");
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(250);
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
