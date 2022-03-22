using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleLoggerLibrary;

namespace whp_esti_zh1
{
    class Program
    {
        static void Main(string[] args)
        {
            // FELADAT 0. (dll)
            // class lib > build > using

            // FELADAT 1. (reflexió)
            Detector d = new Detector();
            d.DetectWorkerClasses();

            // FELADAT 2. (xml to object)
            Func<string, IEnumerable<Worker>> xmlReader = (x =>
            {
                XDocument xdoc = XDocument.Load(x);
                List<Worker> list = new List<Worker>();

                foreach (var item in xdoc.Root.Descendants("person"))
                    list.Add(new Worker()
                    {
                        Email = item.Element("email").Value
                    });

                return list;
            });

            IEnumerable<Worker> w = xmlReader("workers.xml");

            // FELADAT 3. (attribute + reflection)
            ConsoleLogger cl = new ConsoleLogger();
            Validator v = new Validator();
            foreach (var item in w) cl.ConsoleLog(v.CheckEmail(item));

            // FELADAT 4. (linq)
            XDocument doc = XDocument.Load("workers.xml");

            // 4.1. kérdezzük le a tamásokat
            var f1 = from x in doc.Descendants("person")
                          where x.Element("name").Value.ToUpper().Contains("TAMÁS")
                          select x;

            // 4.2. egyes intézetekben hányan dolgoznak, dbszám alapján csökkenőbe rendezve
            var f2 = from x in doc.Descendants("person")
                     group x by x.Element("dept").Value into g
                     orderby g.Count() descending
                     select new
                     {
                         DEPT = g.Key,
                         COUNT = g.Count()
                     };

            // 4.3. dolgozók nevei és emailjei akik a "BA" épület 3. szinten dolgoznak
            var f3 = from x in doc.Descendants("person")
                     where x.Element("room").Value != ""
                        && x.Element("room").Value.Contains("BA.3")
                     select new
                     {
                         NAME = x.Element("name").Value,
                         MAIL = x.Element("email").Value
                     };

            // 4.4. átlagosan mennyi a kereset intézetenként
            var f4 = from x in doc.Descendants("person")
                     group x by x.Element("dept").Value into g
                     select new
                     {
                         AVGSAL = g.Average(a => int.Parse(a.Element("sal").Value)),
                         DEPT = g.Key
                     };
            
        }
    }
}
