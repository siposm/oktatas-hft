using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace xml
{
    static class Operations /* extension method => collection.MethodName(params) */
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"************* {header} ************");
            foreach (var item in input) Console.WriteLine(item);
            Console.WriteLine($"************* {header} ************");
        }
    }

    class Program
    {
        static XDocument LoadXML()
        {
            return XDocument.Load("https://users.nik.uni-obuda.hu/siposm/db/workers.xml");
        }

        static void Process<T>(IEnumerable<T> input)
        {
            System.Console.WriteLine("\n\t~~~~~~~~~~~\n");

            foreach (var item in input)
                System.Console.WriteLine(item);
            
            System.Console.WriteLine();
        }

        static void Process(XDocument doc)
        {
            var people = from x in doc.Root.Descendants("person")
                            select x;

            foreach (var item in people)
                System.Console.WriteLine(item);
        }

        static void Main(string[] args)
        {
            XDocument doc = LoadXML();
            Process(doc);

            // 0. feladat:
            // írjuk ki minden ember nevét
            //
            // write out all the names

            var task0 = from x in doc.Root.Descendants("person")
                            select x.Element("name").Value;

            Process(task0);
            task0.ToConsole("TASK 0");

            // 1. feladat:
            // kérdezzük le a tamásokat (figyelve kis és nagybetűkre)
            //
            // get all the people named Tamás (small and capital letters)

            var task1 = from x in doc.Root.Descendants("person")
                          where x.Element("name").Value.ToUpper().Contains("tamás".ToUpper())
                          select x.Element("name").Value;

            Process(task1);

            // 2. feladat:
            // kérjük le a polihisztorokat (email és név)
            //
            // get all the polihystors mail and name

            var task2 = from x in doc.Root.Descendants("person")
                                where x.Element("rank").Value.Equals("polihisztor")
                                select new
                                {
                                    Nev = x.Element("name").Value,
                                    Mail = x.Element("email").Value
                                };

            Process(task2);

            // 3. feladat:
            // számoljuk meg, hányan dolgoznak az egyes intézetekben
            //
            // count how many employees are there in each faculty

            var task3 = from x in doc.Root.Descendants("person")
                      group x by x.Element("dept").Value into g
                      select new
                      {
                          Letszam = g.Count(),
                          Intezet = g.Key
                      };

            Process(task3);

            // 4. feladat
            // számoljuk meg (egy teljesen új lekéréssel) hogy csak az AII-ben hányan
            // HF: csináljuk meg ugyan ezt, de az eredmény a 3. feladat "intezetek" változójából nyerjük ki!
            //
            // count how many employees are there in the AII faculty

            var task4 = from x in doc.Root.Descendants("person")
                      where x.Element("dept").Value.Equals("Alkalmazott Informatikai Intézet")
                      group x by x.Element("dept").Value into g
                      select new
                      {
                          Letszam = g.Count(),
                          Intezet = g.Key
                      };

            Process(task4);

            // 5. feladat:
            // adjunk hozzá az egész állományhoz egy új alkalmazottat
            //
            // add a new employee to the items


            XElement uj = new XElement("person",
                new XElement("name", "Ultron"),
                new XElement("email", "ultron@gmail.com"),
                new XElement("dept", "Alkalmazott Informatikai Intézet"),
                new XElement("rank", "pusztító"),
                new XElement("phone", "1234567890"),
                new XElement("room", "BA.6.66")
            );

            doc.Root.Add(uj);

            //Process(doc);

            // mentés, ha akarjuk
            // save if we want to
            
            //allomany.Save("ujTetszolegesNev.xml");


        }
    }
}
