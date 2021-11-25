using System;
using System.Threading;
using System.Threading.Tasks;

namespace tasktest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(() =>
            {
                Thread.Sleep(5000); // 5 sec wait
                Console.WriteLine("[1] hello from the task!");
            });

            t.ContinueWith(t => { Console.WriteLine("[2] hello from the continuation! :)"); })
            .ContinueWith(t => { Console.WriteLine("[3] hello from the second continuation! :)"); })
            .ContinueWith(t => { Console.WriteLine("[4] hello from the third continuation! :)"); })
            .ContinueWith(t => { Console.WriteLine("[5] hello from the fourth continuation! :)"); });

            t.Start();

            Console.WriteLine("[0] some random lines after the 5 second mark...");

            Console.ReadLine();

            // ReadLine is important otherwise the started task would end in the same way of course,
            // but since the console's thread is closed (as the program reaches it's end)
            // we would not see the console writeline neither of the task, nor of the contuniation!!!
        }
    }
}
