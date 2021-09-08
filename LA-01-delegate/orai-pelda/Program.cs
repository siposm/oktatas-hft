using System;
using System.Collections.Generic;

namespace LA_01_delegate
{

    public delegate int Methods(int a, int b);


    class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            return this.Age.CompareTo((obj as Person).Age);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Name, this.Age);
        }

    }



    class Program
    {
        static int M1(int a, int b) {
            System.Console.WriteLine(a+b);
            return a+b;
        }

        static int M2(int a, int b) {
            System.Console.WriteLine(a-b);
            return a-b;
        }

        static bool IsItEven(int szam) {
            return szam % 2 == 0;
        }




        static void Main(string[] args)
        {
            Methods met = new Methods( M1 );
            met += M2;

            met(10,5);

            met -= M2;
            met -= M1;

            if(met != null)
                met(10,5);

            met?.Invoke(10,5);

            // ############################################################

            met += delegate (int a, int b) // anonym method
            {
                System.Console.WriteLine(a*b);
                return a*b;
            };

            met(10,10);

            // ############################################################

            Random r = new Random();
            List<int> myList = new List<int>();

            for (int i = 0; i < 10; i++)
                myList.Add(r.Next(100));

            Console.WriteLine("ITEMS");
            foreach (var item in myList)
                Console.WriteLine(">>" + item);

            // delegate
            int p1 = myList.Find( IsItEven );
            System.Console.WriteLine(p1);

            // lambda
            int p2 = myList.Find( x => x % 2 == 0 );
            System.Console.WriteLine(p2);


            // ############################################################

            /*
             * 
             * > Action is a delegate (pointer) to a method, that takes zero, one or more input parameters, but does not return anything.
             * 
             * > Func is a delegate (pointer) to a method, that takes zero, one or more input parameters, and returns a value (or reference).
             * 
             * > Predicate is a special kind of Func often used for comparisons.
             * 
             * src: https://stackoverflow.com/questions/4317479/func-vs-action-vs-predicate
             * 
             * Érdemes a docs.microsoft.com-on is nézelődni!
             * Recommended to visit and learn more at docs.microsoft.com!
             *     
             */

            Action<string> welcommer = ( x => Console.WriteLine(">>>" + x) );

            welcommer += ( x => Console.WriteLine(":::" + x));
            welcommer += ( x => Console.WriteLine("==>" + x));
            welcommer += ( x => Console.WriteLine("~~~" + x));

            welcommer?.Invoke("John Wick");

            // ------------

            // https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=netcore-3.1
            Func<string, int> converter = x => int.Parse(x);

            int a = converter("333");
            int aa = converter("654");

            System.Console.WriteLine(a);
            System.Console.WriteLine(aa);

            Func<int, int, int> adder = (x,y) => x+y;

            int aaa = adder(10,11);
            System.Console.WriteLine(aaa);

            // --------

            Predicate<int> eldontes = IsItEven;
            Console.WriteLine(eldontes(10));
            Console.WriteLine(eldontes(11));

            // ############################################################

            Person[] ppl = new Person[]
            {
                new Person() { Name = "András", Age = 20 },
                new Person() { Name = "Klaudia", Age = 35 },
                new Person() { Name = "Barbara", Age = 75 },
                new Person() { Name = "János", Age = 12 }
            };

            foreach (var item in ppl)
                Console.WriteLine("> " + item);

            Array.Sort( ppl, PersonComparer );

            foreach (var item in ppl)
                Console.WriteLine("==> " + item);
        }

        static int PersonComparer(Person x, Person y)
        {
            return x.CompareTo(y);
        }
    }
}
