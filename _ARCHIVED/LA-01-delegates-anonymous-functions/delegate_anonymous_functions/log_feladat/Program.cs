using System;
using System.IO;

namespace log_feladat
{
    interface ILog
    {
        void AddLogMethod(Action<string> method);
        void Log(string message);
    }

    class Logger : ILog
    {
        private Action<string> logMethods;

        public void AddLogMethod(Action<string> method)
        {
            logMethods += method;
        }

        public void Log(string message)
        {
            if (logMethods != null) // invoke is jó
                logMethods(DateTime.Now.ToShortDateString() + " " + message);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.AddLogMethod(Console.WriteLine);

            logger.AddLogMethod(x =>
            {
                StreamWriter sw = new StreamWriter("logs.txt");
                sw.WriteLine(x);
                sw.Close(); // hibalehetőség!
            });

            /*logger.AddLogMethod(m =>
            {
                using (StreamWriter writer = new StreamWriter("log.txt"))
                {
                    writer.WriteLine(m);
                }
            });*/

            // magyarázat: a s.w. IDisposable interfacet valósít meg, ami alapján
            // a hívás után a desktruktort hívja meg. ezért nem látunk összeakadást (violation exception)
            // röviden: az inline using esetén csak a blokkon belül él az objektum!

            logger.Log("log message goes here");
            logger.Log("lorem ipsum dolor sit amet");
        }
    }
}
