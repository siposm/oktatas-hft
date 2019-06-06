using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Hallgato
    {
        public string Nev { get; set; }
        public override string ToString()
        {
            return Nev + " " + Eletkor + " " + Kapcsolat;
        }
        public int Eletkor { get; set; }
        public bool Kapcsolat { get; set; }
    }

    class MainClass
    {
        static void Feldolgoz<T> (IEnumerable<T> lista)
        {
            Console.WriteLine();

            foreach (var item in lista)
                Console.WriteLine(item);

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            // kell using system . collections . generic
            // kell using system . linq

            List<int> lista = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
                lista.Add(r.Next(99));





            // var bevezetése !!! indokolt esetben csak
            var valami = new Hallgato() { Nev = "X Ember" };
            var masikValami = new { Nev = "Lajoska", Eletkor = 23, Nemzetiseg = "Magyar" };





            // páros számok kinyerése LINQ-val
            var parosSzamok = from x in lista
                              where x % 2 == 0
                              select x;

            Feldolgoz(parosSzamok);

            // páros számok kinyerése LINQ-val és lambdával-val
            var parosSzamok2 = lista.Where(x => x % 2 == 0);

            Feldolgoz(parosSzamok2);




            // =================================================================



            var rendezettSzamok = lista.OrderBy(x => x);

            Feldolgoz(rendezettSzamok);

            List<Hallgato> hallgatok = new List<Hallgato>();
            hallgatok.Add(new Hallgato() { Nev = "Toporgó Tamás" });
            hallgatok.Add(new Hallgato() { Nev = "Embertelen Elemér" });
            hallgatok.Add(new Hallgato() { Nev = "Xedik Xavér" });
            hallgatok.Add(new Hallgato() { Nev = "Kilencedik Klaudia" });
            hallgatok.Add(new Hallgato() { Nev = "Ketyós KlaUdIA" });


            var rendezettHallgatok = hallgatok.OrderBy(x => x.Nev);

            Feldolgoz(rendezettHallgatok);




            // =================================================================



            var nevnaposok = hallgatok.Where( x => x.Nev.Contains("Tamás") );

            Feldolgoz(nevnaposok);


            // feladat:
            // adott egy adatbázis List-ként, kérdezzük le a Klaudiák számát
            // ekkora mérettel hozzunk létre tömböt
            // és másoljuk át a tömbbe a Klaudiákat
            //
            // figyeljünk arra, hogy az adatbázisban lehet, hogy kis és nagybetűvel egyaránt lesz név

            #region feladat

            int dbSzam = hallgatok.Count(x => x.Nev.ToUpper().Contains("klaudia".ToUpper()));
            var klaudiak = hallgatok.Where(x => x.Nev.ToUpper().Contains("klaudia".ToUpper()));

            Hallgato[] valogatottak = new Hallgato[dbSzam];
            int index = 0;

            foreach (var egy_konkret_elem in klaudiak)
                valogatottak[index++] = egy_konkret_elem;

            Feldolgoz(valogatottak);

            #endregion




            // =================================================================


            // feladat:
            // hallgatók lekérése, akiknek életkoruk 20-50 között van
            // és még nincsenek párkapcsolatban
            // ehhez egészítsük ki a hallgató osztályt

            #region feladat

            // hallgatók adatainak kiegészítése

            for (int i = 0; i < hallgatok.Count; i++)
            {
                Predicate<int> kapcsolatDonto = x => { return x == 0; };

                hallgatok[i].Kapcsolat = (bool)kapcsolatDonto?.Invoke(r.Next(2));
                hallgatok[i].Eletkor = r.Next(10, 60);
            }

            Feldolgoz(hallgatok);

            // hallgatók lekérése

            var lekertHallgatok = hallgatok.Where(x =>
            {
               return x.Kapcsolat == true && (x.Eletkor > 19 && x.Eletkor < 51);   
            });

            Feldolgoz(lekertHallgatok);

            #endregion





            // =================================================================



            // feladat:
            // hallgatók lekérése, akiknek életkoruk 20-50 között van
            // és még nincsenek párkapcsolatban
            // ehhez egészítsük ki a hallgató osztályt

            #region feladat

            // hallgatók adatainak kiegészítése

            for (int i = 0; i < hallgatok.Count; i++)
            {
                Predicate<int> kapcsolatDonto = x => { return x == 0; };

                hallgatok[i].Kapcsolat = (bool)kapcsolatDonto?.Invoke(r.Next(2));
                hallgatok[i].Eletkor = r.Next(10, 60);
            }

            Feldolgoz(hallgatok);



            // hallgatók lekérése

            lekertHallgatok = hallgatok.Where(x =>
            {
                return x.Kapcsolat == true && (x.Eletkor > 19 && x.Eletkor < 51);
            });
            Feldolgoz(lekertHallgatok);




            // feladat:
            // kérjük le azokat, akik kapcsolatban vannak
            // a kapott eredményt rendezzük sorrendbe név alapján
            // és alakítsuk nagybetűssé a neveket

            var kapcsolatban = hallgatok.Where(x => x.Kapcsolat == true)
                .OrderBy(x => x.Nev)
                .Select(x => x.Nev.ToUpper());
            
            Feldolgoz(kapcsolatban);


            #endregion






            // =================================================================



            // feladat:
            // kérjük le a kapcsolatban / nem kapcs. lévő hallgatókat

            #region feladat

            var csoport1 = hallgatok.GroupBy( x => x.Kapcsolat );

            var csoport2 = from x in hallgatok
                           group x by x.Kapcsolat into xres
                           select new { csoport = xres.Key , darab = xres.Count() };

            foreach (var item in csoport1)
                Console.WriteLine("csoport: {0} <> darabszám: {1}", item.Key, item.Count());

            Console.WriteLine("---");

            foreach (var item in csoport2)
                Console.WriteLine("csoport: {0} <> darabszám: {1}", item.csoport, item.darab);

            #endregion






            // =================================================================



            // feladat:
            // kérjük le azokat a hallgatókat, akiknek a nevében van 'e' vagy 'E' betű
            //
            // alakítsuk a nevét nagybetűssé egy új objektum keretein belül
            // tároljuk el mellé még az életkorát is (más-más nevű tulajdonságban)
            // 
            // rendezzük életkor szerint

            #region feladat

            var eHallgatok = from x in hallgatok
                             where x.Nev.Contains('e') || x.Nev.Contains('E')
                             orderby x.Eletkor
                             select new {
                                 HallgatoNeve = x.Nev.ToUpper(),
                                 HallgatoKora = x.Eletkor,
                                 HallgatoStatusz = x.Kapcsolat
                              };

            Feldolgoz(eHallgatok);



            // feladat:
            // végezzük el ugyan ezt a lekérdezést, de csoportosítsuk kapcsolatban lévő státusz szerint
            // és az egyes csoportokban nézzük meg, hogy mennyi az átlagos életkor


            var eHallgatok2 = from x in eHallgatok
                              group x by x.HallgatoStatusz into g
                              select new
                              {
                                  Atlag = g.Average(a => a.HallgatoKora),
                                  Darab = g.Count(),
                                  Csoport = g.Key
                              };

            Feldolgoz(eHallgatok2);

            /* 
             * Természetesen van lehetőség az egyes query-ket egymásba is ágyazni,
             * hasonlóan SQL lekérdezésekhez (persze fontos, hogy ez nem ugyan az).
             * 
             * Ez esetben próbáljuk ki:
             * 
             * Az 'eHallgatok' helyére másoljuk be a teljes lekérdezést zárójelek közé rakva.
             * Lefuttatva ugyan azt fogjuk kapni!
             * 
             * Érdemes átlátni ezt a fajta verziót is, amikor
             * komplexebb egymásbaágyazások vannak.            
             * 
             * */

            #endregion

        }
    }
}
