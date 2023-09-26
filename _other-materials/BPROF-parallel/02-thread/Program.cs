using System.Xml.Linq;

namespace _02_thread
{
    internal class Program
    {
        static void ThreadWork()
        {
            int waiting = new Random().Next(10000);
            Thread.Sleep(waiting);
            Console.WriteLine($"Thread [{Thread.CurrentThread.Name}] did the work!");
        }
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            
            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(ThreadWork)
                {
                    Name = "_THREAD-" + i
                });
                threads[i].Start();
            }



            // stop -> sync
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }


            Thread t = new Thread(x =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("...thread is working from lambda...");
                Thread.Sleep(1000);
            });
            t.Start();
            t.Join();
        }
    }
}