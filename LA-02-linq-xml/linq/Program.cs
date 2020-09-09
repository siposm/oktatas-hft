using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; } /* eljegyezve / hajadon */

        public override string ToString()
        {
            return Name + " " + Age + " " + Status;
        }
    }

    class Program
    {
        static void Process <T> (IEnumerable<T> x)
        {
            System.Console.WriteLine("\n\t~~~~~~~~~~~\n");

            // x.Length és társai nem elérhetők mert interface-n keresztül nézem !!!
            foreach (var item in x)
                System.Console.WriteLine(item);

            System.Console.WriteLine();
        }

        static void Main(string[] args)
        {
            
            
            // ###################################################################################################################



            #region INTRODUCTION-TO-LINQ

            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
                list.Add(r.Next(99));

            IEnumerable<int> filteredList = list.FindAll(x => x % 2 == 0);
            int maxItem = filteredList.Max(x => x);
            


            // var bevezetése !!! indokolt esetben csak
            var stud1 = new Student() { Name = "X Ember" };
            var stud2 = new {   Name = "Lajoska",
                                Age = 23,
                                Nationality = "Magyar" }; // tetszőleges "struktúra" megadható, kialakítható (!= osztály)

            string s = stud2.Name; // ugyan úgy lekérhetők a tulajdonságai mintha általunk definiált objektum lenne




            // páros számok kinyerése LINQ-val (query syntax !!!)
            var evens = from x in list
                              where x % 2 == 0
                              select x;

            Process(evens);

            // páros számok kinyerése LINQ-val (method syntax !!! + lambda)
            var evens2 = list.Where(x => x % 2 == 0);

            Process(evens2);


            #endregion

            
            
            // ###################################################################################################################



            #region GENERATE-DATA

            var orderedNumbers = list.OrderBy(x => x);

            Process(orderedNumbers);

            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Toporgó Tamás" });
            students.Add(new Student() { Name = "Embertelen Elemér" });
            students.Add(new Student() { Name = "Xedik Xavér" });
            students.Add(new Student() { Name = "Kilencedik Klaudia" });
            students.Add(new Student() { Name = "Ketyós KlaUdIA" });


            // bevezető példák / tesztelés

            var orderedStuds = students.OrderBy(x => x.Name);

            Process(orderedStuds);

            var nameIs = students.Where(x => x.Name.Contains("Tamás"));

            Process(nameIs);



            #endregion

            
            
            // ###################################################################################################################



            #region TASK1

            // 1. feladat:
            // adott egy adatbázis List-ként, kérdezzük le a Klaudiák számát
            // ekkora mérettel hozzunk létre tömböt
            // és másoljuk át a tömbbe a Klaudiákat
            //
            // figyeljünk arra, hogy az adatbázisban lehet, hogy kis és nagybetűvel egyaránt lesz név


            int count = students.Count(x => x.Name.ToUpper().Contains("klaudia".ToUpper()));
            var klaudiak = students.Where(x => x.Name.ToUpper().Contains("klaudia".ToUpper()));

            Student[] selectedOnes = new Student[count];
            int index = 0;

            foreach (var oneGivenItem in klaudiak)
                selectedOnes[index++] = oneGivenItem;

            Process(selectedOnes);


            #endregion

            
            
            // ###################################################################################################################



            #region TASK2

            // 2. feladat:
            // hallgatók lekérése, akiknek életkoruk 20-50 között van
            // és még nincsenek párkapcsolatban
            // (ehhez egészítsük ki a hallgató osztályt)

            // hallgatók adatainak kiegészítése (életkor + kapcs. státusz)

            Predicate<int> statusRandomizer = x => { return x == 0; };

            for (int i = 0; i < students.Count; i++)
            {
                students[i].Status = (bool)statusRandomizer?.Invoke(r.Next(2));
                students[i].Age = r.Next(10, 60);
            }

            Process(students);

            // hallgatók lekérése

            var selectedStuds = students.Where(x =>
            {
                /* ==true lehagyható */
               return x.Status == true && (x.Age > 19 && x.Age < 51);   
            });

            Process(selectedStuds);


            #endregion

            
            
            // ###################################################################################################################



            #region TASK3

            // 3. feladat:
            // kérjük le azokat, akik kapcsolatban vannak
            // a kapott eredményt rendezzük sorrendbe név alapján
            // és alakítsuk nagybetűssé a neveket

            var taken = students.Where(x => x.Status == true)
                .OrderBy(x => x.Name)
                .Select(x => x.Name.ToUpper());
            
            Process(taken);

            #endregion

            
            
            // ###################################################################################################################



            #region TASK4

            // 4. feladat:
            // kérjük le a kapcsolatban / nem kapcs. lévő hallgatókat
            // csoportsítva és számoljuk meg, hogy hány entitás van egyik/másik csoportban

            var group1 = students.GroupBy( x => x.Status );

            var group2 = from x in students
                           group x by x.Status into xres
                           select new
                           { 
                               _GROUP = xres.Key ,
                               _COUNT = xres.Count()
                            };
                            /* direkt jelöltem meg alulvonással! */

            foreach (var item in group1)
                Console.WriteLine("csoport: {0} <> darabszám: {1}", item.Key, item.Count());

            Console.WriteLine("---");

            foreach (var item in group2)
                Console.WriteLine("csoport: {0} <> darabszám: {1}", item._GROUP, item._COUNT);

            #endregion

            
            
            // ###################################################################################################################



            #region TASK5

            // 5. feladat:
            // kérjük le azokat a hallgatókat, akiknek a nevében van 'e' vagy 'E' betű
            //
            // alakítsuk a nevét nagybetűssé egy új objektum keretein belül
            // tároljuk el mellé még az életkorát is (más-más nevű tulajdonságban)
            // 
            // rendezzük életkor szerint

            var e_Students = from x in students
                             where x.Name.Contains('e') || x.Name.Contains('E')
                             orderby x.Age
                             select new {
                                 _NAME = x.Name.ToUpper(),
                                 _AGE = x.Age,
                                 _STATUS = x.Status
                              };

            Process(e_Students);



            // 5.1. feladat:
            // végezzük el ugyan ezt a lekérdezést, de csoportosítsuk kapcsolatban lévő státusz szerint
            // és az egyes csoportokban nézzük meg, hogy mennyi az átlagos életkor

            var e_Students2 = from x in e_Students
                              group x by x._STATUS into g
                              select new
                              {
                                  _AVERAGE = g.Average(a => a._AGE),
                                  _COUNT = g.Count(),
                                  _GROUP = g.Key
                              };

            Process(e_Students2);

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
