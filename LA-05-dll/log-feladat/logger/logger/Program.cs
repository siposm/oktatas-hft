using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoggerTXT;        // >> logger for txt
using LoggerLibrary;    // >> interface + student osztály

using System.Xml.Linq;  // >> xdocument
using System.Reflection;// >> assembly
using System.IO;        // >> directory info

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
                    new XElement("registration_year", student.RegistrationDate.Year)
                ));
            xdoc.Save("output_xml.xml");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Feladat 1.: kézi tesztelés
            // ----------------------------------------------------

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



            




            // Feladat 2.: automatikus tesztelés / futtatás
            // ----------------------------------------------------

            List<Type> loggerClasses = new List<Type>();

            loggerClasses.AddRange(Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterface("ILogger") != null));

            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            foreach (var item in dinfo.GetFiles("*.dll"))
            {
                loggerClasses.AddRange(
                    Assembly.LoadFrom(item.FullName).GetTypes()
                    .Where ( x => x.GetInterface("ILogger") != null)
                    );
            }

            Console.Write("STUDENT NAME: ");
            string name = Console.ReadLine();

            Student stud = new Student() { Name = name };

            foreach (var item in loggerClasses)
            {
                var instance = Activator.CreateInstance(item);

                var q = item.GetMethod("Log");

                q.Invoke(instance, new object[] { stud });
            }
        }
    }
}
