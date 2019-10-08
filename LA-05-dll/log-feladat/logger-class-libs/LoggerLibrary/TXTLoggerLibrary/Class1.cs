using System;
using System.IO;
using LoggerLibrary;

namespace TXTLoggerLibrary
{
    public class LoggerForTXT : ILogger
    {
        public void Log(Student s)
        {
            StreamWriter sw = new StreamWriter("output_txt.txt");
            sw.WriteLine("GENERATED ON: " + DateTime.Now);
            sw.WriteLine(s.Name + " - " + s.Name.GetHashCode());
            sw.WriteLine(s.RegistrationDate);
            sw.Close();
        }
    }
}
