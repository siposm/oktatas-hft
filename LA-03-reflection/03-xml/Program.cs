using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace _03_xml
{
    class DataFetcher
    {

        /*
        * Ebben az esetben a futó programból lekérjük a típusokat
        * kiválasztjuk belőle ami nekünk kell (megfelelő attrib. alapján)
        * majd ennek a típusnak lekérjük a tulajdonságait és metódusait.
        * 
        * Ezt követően ezeket xml fájlba írjuk és elmentjük.
        * 
        * */

        public void FetchDataFromProgram()
        {
            // Jelenleg csak 1 elemre van megírva (FirstOrDefault), ami nem más mint a Dog objektum (vagy amire rárakódik az attrib.).

            Assembly assem = Assembly.GetExecutingAssembly();
            Type[] types = assem.GetTypes();
            foreach (var item in types) Console.WriteLine(item);
            Type objType = types.Where(x => x.GetCustomAttribute<ModelToXMLAttribute>() != null ).FirstOrDefault(); // Csak 1 obj. jelenleg
            var instance = Activator.CreateInstance(objType);
            List<PropertyInfo> properties = new List<PropertyInfo>();
            List<MethodInfo> methods = new List<MethodInfo>();
            
            instance.GetType().GetProperties().ToList().ForEach( x => properties.Add(x));
            //foreach (var prop in instance.GetType().GetProperties()) properties.Add(prop);
            
            //foreach (var method in instance.GetType().GetMethods())
            //    methods.Add(method);
            // probléma: minden metódus belekerül (tostring, equals, stb) >> megoldás: szűrés attrib. szerint

            instance.GetType()
                    .GetMethods()
                    .ToList()
                    .Where(x => x.GetCustomAttribute<MethodToXMLAttribute>() != null)
                    .ToList()
                    .ForEach( x => methods.Add(x));
            
            // foreach (var method in instance.GetType().GetMethods().Where( x => x.GetCustomAttribute<MethodToXMLAttribute>() != null))
            //     methods.Add(method);

            WriteToXML(objType, properties, methods);
        }

        private void WriteToXML(Type objType, List<PropertyInfo> properties, List<MethodInfo> methods)
        {

            // 1. feladat:
            // Írjuk ki XML-be struktúráltan a következő formában:
            #region minta-xml
            /*
                <?xml version="1.0" encoding="utf-8"?>
                <entities>
                <entity>
                    <hash>1234610245</hash>
                    <type>Kutya</type>
                    <namespace>_03_xml</namespace>
                    <properties>
                        <property>System.String Nev</property>
                        <property>...</property>
                    </properties>
                    <methods>
                        <method>System.String get_Nev()</method>
                        <method>...</method>
                    </methods>
                </entity>
                </entities>
            */
            #endregion

            // 2. feladat:
            // módosítsuk a hash részt és helyezzük el attribútumként az entity tag-ben

            // 3. feladat
            // a properties és methods tag-ekben attribútumként jelenjen meg az elemek száma

            // 4. feladat
            // methods-ok esetén a () jeleket töröljük és úgy mentsük (erre Func-ot használjunk)

            // 5. feladat H.F.
            // methods-ok esetén legyen külön tag a visszatérésnek és külön a névnek

            XDocument xdoc = new XDocument();

            xdoc.Add(new XElement("entities")); // Root

            xdoc.Root.Add(new XElement("entity"));
            xdoc.Root.Element("entity").Add(new XAttribute("hash", objType.Name.GetHashCode()));
            xdoc.Root.Element("entity").Add(new XElement("type", objType.Name));
            xdoc.Root.Element("entity").Add(new XElement("namespace", objType.Namespace));
            xdoc.Root.Element("entity").Add(new XElement("properties", new XAttribute("count", properties.Count)));
            xdoc.Root.Element("entity").Add(new XElement("methods", new XAttribute("count", methods.Count)));

            foreach (var item in properties)
            {
                xdoc.Root.Element("entity").Element("properties").Add(
                    new XElement("property", item)
                );
            }

            Func<MethodInfo, string> trimChars  = x => {
                var temp = x.Name.TrimEnd(')');
                temp = temp.TrimEnd('(');
                return x.ReturnParameter + temp;
            };

            foreach (var item in methods)
            {
                xdoc.Root.Element("entity").Element("methods").Add(
                    new XElement("method", trimChars(item))
                );
            }

            xdoc.Save("program_output.xml");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataFetcher df = new DataFetcher();
            df.FetchDataFromProgram();
        }
    }
}
