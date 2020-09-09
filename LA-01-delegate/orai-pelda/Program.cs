using System;
using System.Collections.Generic;

namespace LA_01_delegate
{

    public delegate int Metodusok(int a, int b);


    class Ember : IComparable
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }

        public int CompareTo(object obj)
        {
            return this.Eletkor.CompareTo((obj as Ember).Eletkor);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Nev, this.Eletkor);
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

        static bool ParosE(int szam) {
            return szam % 2 == 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--LA01--");

            Metodusok met = new Metodusok( M1 );
            met += M2;

            met(10,5);

            met -= M2;
            met -= M1;

            if(met != null)
                met(10,5);

            met?.Invoke(10,5);

            // ############################################################

            met += delegate (int a, int b)
            {
                System.Console.WriteLine(a*b);
                return a*b;
            };

            met(10,10);

            // ############################################################

            Random r = new Random();
            List<int> lista = new List<int>();

            for (int i = 0; i < 10; i++)
                lista.Add(r.Next(100));

            Console.WriteLine("ELEMEK");
            foreach (var item in lista)
                Console.WriteLine(">>" + item);

            // delegate
            int p1 = lista.Find( ParosE );
            System.Console.WriteLine(p1);

            // lambda
            int p2 = lista.Find( x => x % 2 == 0 );
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
             *     
             */

            Action<string> udvozlo = ( x => Console.WriteLine(">>>" + x) );

            udvozlo += ( x => Console.WriteLine(":::" + x));
            udvozlo += ( x => Console.WriteLine("==>" + x));
            udvozlo += ( x => Console.WriteLine("~~~" + x));

            udvozlo?.Invoke("John Wick");

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

            Predicate<int> eldontes = ParosE;
            Console.WriteLine(eldontes(10));
            Console.WriteLine(eldontes(11));

            // ############################################################

            Ember[] emberek = new Ember[]
            {
                new Ember() { Nev = "András", Eletkor = 20 },
                new Ember() { Nev = "Klaudia", Eletkor = 35 },
                new Ember() { Nev = "Barbara", Eletkor = 75 },
                new Ember() { Nev = "János", Eletkor = 12 }
            };

            foreach (var item in emberek)
                Console.WriteLine("> " + item);

            Array.Sort( emberek, EmberOsszehasonlito );

            foreach (var item in emberek)
                Console.WriteLine("==> " + item);
        }

        static int EmberOsszehasonlito(Ember x, Ember y)
        {
            return x.CompareTo(y);
        }
    }
}
