using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hazifeladat
{
    class Headquarters
    {
        public List<object> Storage { get; set; }

        public Headquarters()
        {
            this.Storage = new List<object>();
        }

        public void SendToFight(object elem)
        {
            // itt is lehetne vizsgálni, hogy van-e ilyen metódusa egyáltalán, de nem tettem meg, hogy lássuk az exceptiont...
            // ami akkor váltódik ki, ha kikommentezzük a megfelelő osztályban az AvengerAttribute-ot

            switch (elem.GetType().GetMethod("Fight").GetCustomAttribute<AvengerAttribute>().Location)
            {
                case CurrentLocation.Earth:
                    Console.WriteLine("földön harcol");
                    break;
                case CurrentLocation.Mars:
                    Console.WriteLine("marson harcol");
                    break;
                case CurrentLocation.Vormir:
                    Console.WriteLine("vormiron harcol");
                    break;
                case CurrentLocation.Titan:
                    Console.WriteLine("titánon harcol");
                    break;
                default:
                    break;
            }
        }

        public void Enroll(object item)
        {
            // van-e ilyen attribútuma
            if (item.GetType().GetProperties().Where(x => x.GetCustomAttribute(typeof(SavedLivesAttribute)) != null).Any())
            {
                // property ahol van megfelelő attrib. 
                PropertyInfo pinfo = item.GetType().GetProperties().Where(x => x.GetCustomAttribute(typeof(SavedLivesAttribute)) != null).FirstOrDefault();

                // megfelelő property már meg van >> kell a percentage érték és az int érték
                double percentageValue = double.Parse(((SavedLivesAttribute)pinfo.GetCustomAttribute(typeof(SavedLivesAttribute))).Percentage.Split('%')[0]);
                double limitNumber = ((SavedLivesAttribute)pinfo.GetCustomAttribute(typeof(SavedLivesAttribute))).Limit;

                // számolás + aktuális entitás értékének lekérdezése (megfelelő prop. alapján!)
                double lowerBoundary = limitNumber - (limitNumber * (percentageValue/100));
                int actualEntitysValue = (int)pinfo.GetValue(item);
                
                if ( lowerBoundary <= actualEntitysValue )
                {
                    // debug:
                    //Console.WriteLine(pinfo); Console.WriteLine(pinfo.GetValue(item));

                    Storage.Add(item);
                }
                else
                    throw new NotValidAvengerException();
            }
            else
                throw new NoSavedLivesAttributeException();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Headquarters hq = new Headquarters();

            // tesztelés: OK
            hq.Enroll(new Avenger() { Name = "Tony Stark", SavedQuantity = 88 });
            hq.Enroll(new Avenger() { Name = "Vízió", SavedQuantity = 101 });
            hq.Enroll(new Avenger() { Name = "Hulk", SavedQuantity = 30 });


            // ---------------------------------------------------------------------------


            // tesztelés: NEM OK (kevés megmentett ember)
            try
            {
                hq.Enroll(new Avenger() { Name = "Hawkeye", SavedQuantity = 10 });
            }
            catch (NotValidAvengerException)
            {
                Console.WriteLine("[ERR] ez a bosszúálló még nem elég tapasztalt");
            }


            // ---------------------------------------------------------------------------


            // tesztelés: NEM OK (nincs ilyen attrib.)
            try
            {
                hq.Enroll(new NotAvenger() { Name = "Ultron" });
            }
            catch (NoSavedLivesAttributeException)
            {
                Console.WriteLine("[ERR] nincs ilyen attribútuma...");
            }


            // ---------------------------------------------------------------------------



            // tesztelés: NEM OK (nincs ilyen metódus)
            try
            {
                hq.SendToFight(new NotAvenger() { Name = "Ultron" });
            }
            catch (ArgumentException)
            {
                Console.WriteLine("[ERR] nincs ilyen metódusa...");
            }


            // ---------------------------------------------------------------------------



            Console.WriteLine("FELVETT BOSSZÚÁLLÓK:");
            foreach (var item in hq.Storage)
                Console.WriteLine("\t> " + item);




            hq.SendToFight(new Avenger() { Name = "Tony Stark", SavedQuantity = 88 });

        }
    }
}
