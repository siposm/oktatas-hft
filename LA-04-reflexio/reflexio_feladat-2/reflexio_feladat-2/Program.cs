using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace reflexio_feladat_2
{
    

    class DataFetcher
    {

        /*
        * Ebben az esetben a futó programból lekérjük a típusokat
        * kiválasztjuk belőle ami nekünk kell (jelen esetben Kutya)
        * majd ennek a típusnak lekérjük a tulajdonságait és metódusait.
        * 
        * Ezt követően ezeket xml fájlba írjuk és elmentjük.
        * 
        * */

        public void FetchDataFromProgram()
        {
            Assembly asse = Assembly.GetExecutingAssembly();

            Type[] types = asse.GetTypes();

            //foreach (var item in types)
            //{
            //    Console.WriteLine(item);
            //}

            Type objType = types.Where(x => x.GetCustomAttribute<ModelToXMLAttribute>() != null ).FirstOrDefault();
            
            var instance = Activator.CreateInstance(objType);

            List<PropertyInfo> properties = new List<PropertyInfo>();
            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (var prop in instance.GetType().GetProperties() )
            {
                properties.Add(prop);
                //Console.WriteLine(prop.GetValue(instance)); // var lényege / használhatósága !
            }
            
            //foreach (var method in instance.GetType().GetMethods())
            //{
            //    methods.Add(method);
            //}
            // probléma: minden metódus belekerül (tostring, equals, stb) >> megoldás: szűrés attrib. szerint

            foreach (var method in instance.GetType().GetMethods().Where( x => x.GetCustomAttribute<MethodToXMLAttribute>() != null ))
            {
                methods.Add(method);
            }



            WriteToXML(objType,properties,methods);
        }

        private void WriteToXML(Type objType, List<PropertyInfo> properties, List<MethodInfo> methods)
        {
            XDocument xdoc = new XDocument();

            xdoc.Add(new XElement("entities"));

            xdoc.Element("entities").Add(new XElement("entity"));
            xdoc.Element("entities").Element("entity").Add(new XElement("hash", objType.Name.GetHashCode()));
            xdoc.Element("entities").Element("entity").Add(new XElement("type", objType.Name));
            xdoc.Element("entities").Element("entity").Add(new XElement("namespace", objType.Namespace));
            xdoc.Element("entities").Element("entity").Add(new XElement("properties"));
            xdoc.Element("entities").Element("entity").Add(new XElement("methods"));

            foreach (var item in properties)
            {
                xdoc.Element("entities").Element("entity").Element("properties").Add(
                    new XElement("property", item)
                );
            }

            foreach (var item in methods)
            {
                xdoc.Element("entities").Element("entity").Element("methods").Add(
                    new XElement("method", item)
                );
            }

            xdoc.Save("program_output.xml");
        }




        /*
         * Ebben az esetben viszont nem csak magukat a tulajdonságokat és metódusokat kérjük le
         * hanem azok aktuális értékeit is!
         * 
         * Így tehát egy teljesen dinamikusan működő list-to-xml metódust készítünk.
         * */

        // list <> ienumerable
        public void FetchDataFromCollection <T> (IEnumerable<T> collection)
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(new XElement("entities"));

            foreach (var listItem in collection)
            {
                XElement uj = new XElement("entity",
                    new XElement("hash", listItem.GetType().Name.GetHashCode()),
                    new XElement("type", listItem.GetType().Name),
                    new XElement("namespace", listItem.GetType().Namespace),
                    new XElement("properties"),
                    new XElement("methods")
                    );

                foreach (var propItem in listItem.GetType().GetProperties())
                {
                    //Console.WriteLine(
                    //    "PROP NAME: {0} \t\t PROP VALUE: {1}",
                    //    propItem, propItem.GetValue(listItem));

                    uj.Element("properties").Add(
                        new XElement("property",
                            new XElement("name", propItem),
                            new XElement("value", propItem.GetValue(listItem))
                       ));
                }

                foreach (var methodItem in listItem.GetType().GetMethods().Where(x => x.GetCustomAttribute<MethodToXMLAttribute>() != null))
                {
                    //Console.WriteLine(methodItem);

                    uj.Element("methods").Add(
                        new XElement("method",
                            new XElement("name", methodItem)
                       ));
                }

                xdoc.Root.Add(uj);

            }

            xdoc.Save("list_output.xml");
        }

        
    }


    class Program
    {
        static void Main(string[] args)
        {
            DataFetcher dc = new DataFetcher();

            dc.FetchDataFromProgram();



            List<Hallgato> hList = new List<Hallgato>();
            hList.Add(new Hallgato() { Nev = "Lajos" });
            hList.Add(new Hallgato() { Nev = "Géza" });
            hList.Add(new Hallgato() { Nev = "Tamás" });

            List<Auto> aList = new List<Auto>();
            aList.Add(new Auto() { Rendszam = "AAA-111", Tulajdonos = "Gipsz Jakab", UzembehelyzesIdeje = new DateTime(2018, 03, 13) });
            aList.Add(new Auto() { Rendszam = "BBB-222", Tulajdonos = "Kiss Ede", UzembehelyzesIdeje = new DateTime(2003, 12, 1) });
            aList.Add(new Auto() { Rendszam = "CCC-333", Tulajdonos = "Tony Stark", UzembehelyzesIdeje = new DateTime(1999, 5, 30) });



            dc.FetchDataFromCollection(hList);
            Console.WriteLine();
            dc.FetchDataFromCollection(aList);


        }
    }
}
