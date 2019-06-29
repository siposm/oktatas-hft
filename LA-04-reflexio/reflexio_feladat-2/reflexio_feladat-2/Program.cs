using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace reflexio_feladat_2
{

    class ModelToXMLAttribute : Attribute
    {

    }

    class MethodToXMLAttribute : Attribute
    {

    }

    [ModelToXML]
    class Kutya
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public bool Nosteny { get; set; }

        [MethodToXML]
        public int Ugat()
        {
            return 10; // ugatás hosszát adja vissza (msp)
        }

        public void Koszon()
        {
            // ...
        }

        [MethodToXML]
        public double Futas()
        {
            return 4.009;
        }

        [MethodToXML]
        public double Seta()
        {
            return 432.114;
        }
    }



    class DataFetcher
    {
        public void FetchData()
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

            xdoc.Save("output.xml");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DataFetcher dc = new DataFetcher();
            dc.FetchData();
        }
    }
}
