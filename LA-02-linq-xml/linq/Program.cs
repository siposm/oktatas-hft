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

            #region GENERATE-DATA
            #endregion

            #region TASK1
            #endregion

            #region TASK2
            #endregion

            #region TASK3
            #endregion

            #region TASK4
            #endregion

            #region TASK5
            #endregion
        }
    }
}
