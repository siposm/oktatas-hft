using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TXTLoggerLibrary; // >> logger for txt
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

            // minden osztály ami loggerként funkcionál (ILogger-t megvalósítják)
            List<Type> loggerClasses = new List<Type>();

            // csak az interfészt megvalósító osztályok hozzáadása
            loggerClasses.AddRange(Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterface("ILogger") != null));

            // aktuális könyvtár ahol a .exe fájl van (!)
            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            // adott mappa dll fájljainak bejárása
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
                // minden Logger osztály Log metódusát meg akarjuk hívni

                // 1. példányokat hozunk létre
                var instance = Activator.CreateInstance(item);

                // 2. a Log metódusra mutató referenciát hozunk létre
                var q = item.GetMethod("Log");

                // 3. meghívjuk a log metódust adott paraméterrel
                q.Invoke(instance, new object[] { stud });

                // 4. kimenetek ellenőrzése /bin/debug-ban
            }
        }
    }
}
