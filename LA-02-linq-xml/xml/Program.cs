using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace xml
{
    class Program
    {
        static XDocument LoadXML()
        {
            return XDocument.Load("https://users.nik.uni-obuda.hu/siposm/db/workers.xml");
        }

        static void Process<T>(IEnumerable<T> input)
        {
            System.Console.WriteLine();
            foreach (var item in input)
                System.Console.WriteLine(item);
            System.Console.WriteLine();
        }

        static void Process(XDocument doc)
        {
            var persons = from x in doc.Root.Descendants("person")
                            select x;
                            
            foreach (var item in persons)
                System.Console.WriteLine(item);
        }

        static void Main(string[] args)
        {
            XDocument doc = LoadXML();
            Process(doc);
        }
    }
}
