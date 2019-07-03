using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoggerTXT;        // >> logger for txt
using LoggerLibrary;    // >> interface + student osztály

using System.Linq;      // >> xdocument
using System.Xml.Linq;  // >> xdocument

namespace logger
{
    class LoggerForXML : ILogger
    {
        public void Log(Student student)
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(
                new XElement("student_entity",
                    new XElement("name" , student.Name,
                        new XAttribute("hash" , student.Name.GetHashCode())),
                    new XElement("registration", student.RegistrationDate)
                ));
            xdoc.Save("output_xml.xml");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoggerForTXT txtLogger = new LoggerForTXT();
                txtLogger.Log(new Student() { Name = "Gipsz Géza" });

                LoggerForXML xmlLogger = new LoggerForXML();
                xmlLogger.Log(new Student() { Name = "Gipsz Géza" });
            }
            catch (Exception)
            {
                Console.WriteLine("[ERR] error happened");
            }
            finally
            {
                Console.WriteLine("ready...");
            }
        }
    }
}
