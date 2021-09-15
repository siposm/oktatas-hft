using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; } // single / taken

        public override string ToString()
        {
            return Name + " " + Age + " " + Status;
        }
    }

    class Program
    {
        static void Process <T> (IEnumerable<T> x)
        {
            Console.WriteLine("\n\t~~~~~~~~~~~\n");

            // x.Length és társai nem elérhetők mert interface-n keresztül nézem !!!
            // x.Length and others are NOT available, since they are seen THROUGH the interface
            foreach (var item in x)
                Console.WriteLine(item);

            Console.WriteLine();
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
            // fordító majd lekezeli
            // a létrehozáskor engem nem érdekel vagy nem tudom hogy mi a típusa
            // minden NE legyen var
            //
            // var should be used only in specific cases
            // var means that the compiler will take care of the type and determine it in runtime
            // we should avoid using var for everything

            var stud1 = new Student() { Name = "X Person" };
            var stud2 = new {   Name = "Tony Stark",
                                Age = 23,
                                Nationality = "Hungarian" };
                                // ideiglenes, apró, csak adat összefogására
                                // only for small, temporary data to hold them together

            // ugyan úgy lekérhetők a tulajdonságai mintha általunk definiált objektum lenne
            // properties available even though there is no specific type defined by us previously
            string s = stud2.Name;




            // páros számok kinyerése LINQ-val (query syntax)
            // get all even numbers with LINQ query syntax
            var evens = from x in list
                              where x % 2 == 0
                              select x;

            Process(evens);

            // páros számok kinyerése LINQ-val (method syntax + lambda)
            // get all even numbers with LINQ method syntax (linq operators) + lambda
            var evens2 = list.Where(x => x % 2 == 0);

            Process(evens2);


            #endregion

            
            
            // ###################################################################################################################



            #region GENERATE-DATA

            var orderedNumbers = list.OrderBy(x => x);

            Process(orderedNumbers);

            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Tim Tom" });
            students.Add(new Student() { Name = "Even Edward" });
            students.Add(new Student() { Name = "Lorem Lora" });
            students.Add(new Student() { Name = "Killer Karol" });
            students.Add(new Student() { Name = "King kARol" });


            // bevezető példák / tesztelés
            // intro examples

            var orderedStuds = students.OrderBy(x => x.Name);

            Process(orderedStuds);

            var nameIs = students.Where(x => x.Name.Contains("Tom"));

            Process(nameIs);



            #endregion

            
            
            // ###################################################################################################################



            #region TASK1

            // HU ******************
            // 1. feladat:
            // adott egy adatbázis List-ként, kérdezzük le a Karol-ok számát
            // ekkora mérettel hozzunk létre tömböt
            // és másoljuk át a tömbbe a Karol-okat
            //
            // figyeljünk arra, hogy az adatbázisban lehet, hogy kis és nagybetűvel egyaránt lesz név
            
            // EN ******************
            // we have a database as List, get how many Karols are there
            // create an array with this length and copy all the Karols there
            //
            // make sure that names can contain small and capital letters as well


            int count = students.Count(x => x.Name.ToUpper().Contains("karol".ToUpper()));
            var karols = students.Where(x => x.Name.ToUpper().Contains("karol".ToUpper()));

            Student[] selectedOnes = new Student[count];
            int index = 0;

            foreach (var oneGivenItem in karols)
                selectedOnes[index++] = oneGivenItem;

            Process(selectedOnes);


            #endregion

            
            
            // ###################################################################################################################



            #region TASK2

            // HU ******************
            // 2. feladat:
            // hallgatók lekérése, akiknek életkoruk 20-50 között van
            // és még nincsenek párkapcsolatban
            // (ehhez egészítsük ki a hallgató osztályt)
            //
            // hallgatók adatainak kiegészítése (életkor + kapcs. státusz)
            //
            // EN ******************
            // get students who has age between 20-50 and not yet taken (for this, add extra properties to the class)

            Predicate<int> statusRandomizer = x => { return x == 0; };

            for (int i = 0; i < students.Count; i++)
            {
                students[i].Status = (bool)statusRandomizer?.Invoke(r.Next(2));
                students[i].Age = r.Next(10, 60);
            }

            Process(students);

            // hallgatók lekérése
            // get students

            var selectedStuds = students.Where(x =>
            {
                /* ==true lehagyható */
                /* ==true can be left */
               return x.Status == true && (x.Age > 19 && x.Age < 51);   
            });

            Process(selectedStuds);


            #endregion

            
            
            // ###################################################################################################################



            #region TASK3

            // HU ******************
            // 3. feladat:
            // kérjük le azokat, akik kapcsolatban vannak
            // a kapott eredményt rendezzük sorrendbe név alapján
            // és alakítsuk nagybetűssé a neveket
            //
            // EN ******************
            //get taken students and order the output by the name, and make names to all caps
            

            var taken = students    
                .Where(x => x.Status == true)
                .OrderBy(x => x.Name)
                .Select(x => x.Name.ToUpper());
            
            Process(taken);

            #endregion

            
            
            // ###################################################################################################################



            #region TASK4

            // HU ******************
            // 4. feladat:
            // kérjük le a kapcsolatban / nem kapcs. lévő hallgatókat
            // csoportsítva és számoljuk meg, hogy hány entitás van egyik/másik csoportban
            //
            // EN ******************
            // get taken and not taken students and group them and count them

            var group1 = students.GroupBy( x => x.Status );

            var group2 = from x in students
                           group x by x.Status into xres
                           select new
                           { 
                               _GROUP = xres.Key ,
                               _COUNT = xres.Count()
                            };
                            /* direkt jelöltem meg alulvonással! */
                            /* marked with _ for a reason */

            foreach (var item in group1)
                Console.WriteLine("Group: {0} <> Quantity: {1}", item.Key, item.Count());

            Console.WriteLine("---");

            foreach (var item in group2)
                Console.WriteLine("Group: {0} <> Quantity: {1}", item._GROUP, item._COUNT);

            #endregion

            
            
            // ###################################################################################################################



            #region TASK5

            // HU ******************
            // 5. feladat:
            // kérjük le azokat a hallgatókat, akiknek a nevében van 'e' vagy 'E' betű
            //
            // alakítsuk a nevét nagybetűssé egy új objektum keretein belül
            // tároljuk el mellé még az életkorát is (más-más nevű tulajdonságban)
            // 
            // rendezzük életkor szerint
            //
            // EN ******************
            // get students who has 'e' or 'E' in their names
            // make name to all caps using a new anonym class
            // store the age next to it
            // and order by their age

            var e_Students = from x in students
                             where x.Name.Contains('e') || x.Name.Contains('E')
                             orderby x.Age
                             select new {
                                 _NAME = x.Name.ToUpper(),
                                 _AGE = x.Age,
                                 _STATUS = x.Status
                              };

            Process(e_Students);



            // HU ******************
            // 5.1. feladat:
            // végezzük el ugyan ezt a lekérdezést, de csoportosítsuk kapcsolatban lévő státusz szerint
            // és az egyes csoportokban nézzük meg, hogy mennyi az átlagos életkor
            //
            // EN ******************
            // make the same as above but group students by their status and check their average age

            var e_Students2 = from x in e_Students
                              group x by x._STATUS into g
                              select new
                              {
                                  _AVERAGE = g.Average(a => a._AGE),
                                  _COUNT = g.Count(),
                                  _GROUP = g.Key
                              };

            Process(e_Students2);

            // HU ******************
            /* 
             * Természetesen van lehetőség az egyes query-ket egymásba is ágyazni,
             * hasonlóan SQL lekérdezésekhez (persze fontos, hogy ez nem ugyan az).
             * 
             * Ez esetben próbáljuk ki:
             * 
             * Az 'e_Students' helyére másoljuk be a teljes lekérdezést zárójelek közé rakva.
             * Lefuttatva ugyan azt fogjuk kapni!
             * 
             * Érdemes átlátni ezt a fajta verziót is, amikor
             * komplexebb egymásbaágyazások vannak.            
             * 
             * */

             

            // EN ******************
            /*
            * Of course there is a possibility to insert queries into each other, like SQL statements.
            *
            * In this case try the following: copy the full query in the place of 'e_Students' and run it.
            */


            #endregion
        }
    }
}
