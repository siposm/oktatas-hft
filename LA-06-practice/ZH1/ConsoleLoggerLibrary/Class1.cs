using System;

namespace ConsoleLoggerLibrary
{
    public class ConsoleLogger
    {
        public void ConsoleLog(object o)
        {
            Console.Write("> LOG OUTPUT:");
            Console.WriteLine("\t" + o.ToString());
            Console.WriteLine("-------------");
        }
    }
}
