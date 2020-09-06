using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_feladat_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Készítsünk programot, amelyben 4 Task versenyez a konzolra íráson!
            // Az egyes Taskok külön sorokba, különböző színnel írhatnak.

            Task.Run(() => RunConsole(ConsoleColor.Green, 0));
            Task.Run(() => RunConsole(ConsoleColor.Blue, 2));
            Task.Run(() => RunConsole(ConsoleColor.Yellow, 4));
            Task.Run(() => RunConsole(ConsoleColor.Cyan, 6));
            Console.ReadLine();
        }

        static Random rand = new Random();

        static object lockObject = new object();


        static void RunConsole(ConsoleColor c, int soridx)
        {
            for (int i = 0; i < 80; i++)
            {
                // vagy task.delay
                Task.Delay(rand.Next(120, 750)).ContinueWith(x =>
                {
                    string s = ((char)rand.Next('a', 'z' + 1)).ToString();
                    Draw(s, c, soridx, i);
                }).Wait();

                // vagy thread.sleep
                //Thread.Sleep(rand.Next(120, 750));
                //string s = ((char)rand.Next('a', 'z' + 1)).ToString();
                //Draw(s, c, soridx, i);
            }
        }

        static void Draw(string s, ConsoleColor c, int x, int y)
        {
            lock (lockObject)
            {
                Console.SetCursorPosition(y, x);
                Console.ForegroundColor = c;
                Console.Write(s);
            }
        }
    }
}
