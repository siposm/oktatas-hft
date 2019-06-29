using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflexio
{

    class Ember
    {
        public int ID { get; set; }
        public string Nev { get; set; }
    }

    class Hallgato : Ember
    {
        public string NeptunKod { get; set; }
        public int Kredit { get; set; }
    }

    class NappalisHallgato : Hallgato
    {
        public int BeiratkozasEve; // sima mező, nem tulajdonság

        private int FelevekSzama1;
        private int FelevekSzama2;
        private int FelevekSzama3;
        private int FelevekSzama4;

        public string Udvozles()
        {
            return "Szia, én "+ Nev +" vagyok!";
        }
    }







    class Program
    {
        static void Main(string[] args)
        {
            Ember e = new Ember() { Nev = "Lajos", ID = 889 };

            Type t = typeof(Ember);
            PropertyInfo[] infos = t.GetProperties(); // using system . reflection

            foreach (var item in infos)
            {
                Console.WriteLine(">> tulajdonság neve: " + item.Name);
                Console.WriteLine("\t> tulajdonság tartalma: " + item.GetValue(e)); // meg kell adni a konkrét objektumot
            }


            // csak egy dedikált tulajdonság is lekérdezhető
            PropertyInfo pinfo = t.GetProperty("Nev");
            Console.WriteLine(pinfo);
            Console.WriteLine(pinfo.GetValue(e));





            // ----------------------------------------------------------------------






            Hallgato[] hallgatok = new Hallgato[4];
            Random r = new Random();

            for (int i = 0; i < 4; i++)
            {
                hallgatok[i] = new Hallgato()
                {
                    Nev = "Hallgató" + i,
                    ID = r.Next(1000),
                    Kredit = r.Next(60),
                    NeptunKod = r.Next(100, 999).ToString()
                };
            }

            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            foreach (Hallgato hallgato in hallgatok)
            {
                Type t2 = typeof(Hallgato);
                PropertyInfo[] infos2 = t2.GetProperties();

                foreach (var propItem in infos2)
                {
                    Console.WriteLine("> {0}: {1}" , propItem.Name, propItem.GetValue(hallgato));
                }
                Console.WriteLine();
            }





            // ----------------------------------------------------------------------





            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            NappalisHallgato nh = new NappalisHallgato()
            {
                Nev = "nappalis hallgato",
                BeiratkozasEve = 2019
            };

            FieldInfo[] fields = typeof(NappalisHallgato).GetFields();
            FieldInfo nhField = typeof(NappalisHallgato).GetField("BeiratkozasEve"); // pontos egyezés szükséges! (case sensitive)

            Console.WriteLine(nhField);
            Console.WriteLine(nhField.GetValue(nh));

            MethodInfo mInfo = typeof(NappalisHallgato).GetMethod("Udvozles");
            Console.WriteLine(mInfo);






            // ----------------------------------------------------------------------






            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            FieldInfo[] finfos = typeof(NappalisHallgato).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            // tulajdonság: nonpublic | static
            
            foreach (var item in finfos)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
