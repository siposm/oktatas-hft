using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace _08_reflection_xml_export
{
    class DataFetcher
    {

        /*
        * <HU>
        * Ebben az esetben a futó programból lekérjük a típusokat
        * kiválasztjuk belőle ami nekünk kell (megfelelő attrib. alapján)
        * majd ennek a típusnak lekérjük a tulajdonságait és metódusait.
        * Ezt követően ezeket xml fájlba írjuk és elmentjük.
        * 
        * <EN>
        * In this case we will get the types from the running program (via the Assembly)
        * from that we will get the types we really need (based on the attributes)
        * then we will get the properties and methods of these types and create and xml out of it.
        * 
        * */

        public void FetchDataFromProgram()
        {
            // <HU> Jelenleg csak 1 elemre van megírva (FirstOrDefault), ami nem más mint a Dog objektum (vagy amire rárakódik az attrib.).
            // <EN> At the moment it is only written for 1 type (first or default) which is Dog (or whatever has the attributes).

            Assembly assem = Assembly.GetExecutingAssembly();
            
            Type[] types = assem.GetTypes();
            
            foreach (var item in types)
            {
                Console.WriteLine(item);
            }

            IEnumerable<Type> objectTypes = types.Where(x => x.GetCustomAttribute<ModelToXMLAttribute>() != null);


            XDocument xdoc = new XDocument();
            xdoc.Add(new XElement("entities"));

            foreach (var item in objectTypes)
            {
                var instance = Activator.CreateInstance(item);

                List<PropertyInfo> properties = new List<PropertyInfo>();
                List<MethodInfo> methods = new List<MethodInfo>();

                instance?.GetType().GetProperties().ToList().ForEach(x => properties.Add(x));
                //foreach (var prop in instance.GetType().GetProperties()) properties.Add(prop);

                //foreach (var method in instance.GetType().GetMethods())
                //    methods.Add(method);
                // probléma: minden metódus belekerül (tostring, equals, stb) >> megoldás: szűrés attrib. szerint
                // problem: all the methods will be inside (tostring, equals etc) >> solution: filter by attributes

                instance?.GetType()
                        .GetMethods()
                        .Where(x => x.GetCustomAttribute<MethodToXMLAttribute>() != null)
                        .ToList()
                        .ForEach(x => methods.Add(x));

                // foreach (var method in instance.GetType().GetMethods().Where( x => x.GetCustomAttribute<MethodToXMLAttribute>() != null))
                //     methods.Add(method);

                XElement entityNode = WriteToXML(item, properties, methods);
                xdoc.Root!.Add(entityNode);
            }
            
            xdoc.Save("exported-objects.xml");
        }

        private XElement WriteToXML(Type objType, List<PropertyInfo> properties, List<MethodInfo> methods)
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

            // 5. feladat {HF}
            // methods-ok esetén legyen külön tag a visszatérésnek és külön a névnek

            // 6. feladat {HF}
            // ellenőrizzétek le, hogy mi történik ha az Entities.cs-ben a Kutya osztály helyett
            // az Auto osztályra teszitek rá a [ModelToXML] attribútumot
            // a teljes kimeneti xml ennek megfelelően frissülni fog

            // 7. feladat {HF}
            // csináljátok meg a FetchDataFromProgram metódust úgy, hogy több db entitásra is működjön
            // amin rajta van a [ModelToXML] attribútum

            XElement xe = new XElement("entity");
            xe.Add(new XAttribute("hash", objType.Name.GetHashCode()));
            xe.Add(new XElement("type", objType.Name));
            xe.Add(new XElement("namespace", objType.Namespace));
            xe.Add(new XElement("properties", new XAttribute("count", properties.Count)));
            xe.Add(new XElement("methods", new XAttribute("count", methods.Count)));

            foreach (var item in properties)
            {
                xe.Element("properties")?.Add(new XElement("property", item));
            }

            Func<MethodInfo, string> trimChars = x =>
            {
                string temp = x.Name.TrimEnd(')');
                temp = temp.TrimEnd('(');
                return $"{x.ReturnParameter} {temp}";
            };

            foreach (var item in methods)
            {
                xe.Element("methods")?.Add(new XElement("method", trimChars(item)));
            }

            return xe;
        }
    }
}
