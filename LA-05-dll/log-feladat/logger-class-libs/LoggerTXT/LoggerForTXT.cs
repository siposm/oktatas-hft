using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoggerLibrary; // !!!




namespace LoggerTXT
{
    public class LoggerForTXT : ILogger
    {
        public void Log(Student s)
        {
            StreamWriter sw = new StreamWriter("output_txt.txt");
            sw.WriteLine("GENERATED ON: " + DateTime.Now );
            sw.WriteLine(s.Name + " - " + s.Name.GetHashCode());
            sw.WriteLine(s.RegistrationDate);
            sw.Close();
        }
    }
}

