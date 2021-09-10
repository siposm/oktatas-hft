using System;

namespace _02_logger
{
    class Logger
    {
        private Action<string> logMethods;

        public void AddLogMethod(Action<string> logMethod)
        {
            logMethods += logMethod;
        }

        public void Log(string message)
        {
            // if (logMethods != null) ....
            logMethods?.Invoke(String.Format("[{0}] {1}", DateTime.Now, message));
        }


        // Second part: filter
        List<string> entries;
        public Logger()
        {
            entries = new List<string>();
            AddLogMethod(x => entries.Add(x));
        }

        // Only after the completed filter:
        // Func<string, bool> => delegate bool condition(string input);
        // Predicate<string> => delegate bool condition(string input);
        // Same, but cannot be interchanged!!!
        // FindAll() wants a Predicate<string> ....
        // Our Filter() and LINQ's Where() wants Func<string, bool> ...
        // With a DB, .Where() wants Expression<Func<string, bool>>
        public List<string> Filter(Func<string, bool> condition)
        {
            // return entries.FindAll(condition);
            // return entries.Where(condition).ToList();
            List<string> output = new List<string>();
            foreach (string akt in entries)
            {
                if (condition(akt)) output.Add(akt);
            }
            return output;
        }
    }

    class Program
    {
        static void ConsoleLog(string msg)
        {
            Console.WriteLine(msg);
        }
        
        static void Main(string[] args)
        {
            Logger log = new Logger();
            log.AddLogMethod(ConsoleLog);
            log.AddLogMethod(delegate (string msg) { Console.WriteLine(msg); });
            log.AddLogMethod(x => Console.WriteLine(x));
            log.AddLogMethod(x =>
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(x);
                }
            });
            log.Log("Starting Apache");
            System.Threading.Thread.Sleep(1000);
            log.Log("Starting MySQL");
            System.Threading.Thread.Sleep(1000);
            log.Log("Starting ProFTPd");
            System.Threading.Thread.Sleep(1000);
            log.Log("Killing ProFTPd");
            log.Log("Stopping Apache");

            // Second part: filter...
            Console.WriteLine("Filtering...");
            foreach (string akt in log.Filter(x => x.ToLower().Contains("apache")))
            {
                Console.WriteLine(akt);
            }

            Console.ReadLine();
        }
    }
}
