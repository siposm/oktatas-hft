using System;
using System.Collections.Generic;

namespace delegate_anonymous_functions
{
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

    public delegate int Metodusok(int a, int b);

    class MainClass
    {
        public static int OsszeAd(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        public static int OsszeAd2(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        public static bool ParosE(int szam)
        {
            return szam % 2 == 0;
        }

        public static void Main(string[] args)
        {

            // delegált mint "metódusreferencia gyűjtő"
            // azonos metódusszignatúrájú elemek tárolása

            // szignatúra: visszatérési_típus ____ ( paraméterek_típusa_és_darabszáma )

            // használható a már ismert belerakás
            // illetve helyileg névtelen fgv-t is létre tudunk hozni

            Metodusok methods = new Metodusok(OsszeAd);

            methods += OsszeAd2;


            // "elsütéskor" null ellenőrzése (események alapján)
            methods(10, 20); // OK
            methods -= OsszeAd;
            methods -= OsszeAd2;
            //methods(10, 20); // NEM OK

            // kivédés >> null ellenőrzés kézileg vagy beépített módon
            if (methods != null)
                methods(10, 20);

            methods?.Invoke(10, 20);




            // névtelen függvény használata delegálttal
            methods += delegate (int x, int y)
            {
                Console.WriteLine(x + y);
                return x + y;
            };





            // =================================================================


            Random r = new Random();
            List<int> lista = new List<int>();

            for (int i = 0; i < 10; i++)
                lista.Add(r.Next(100));

            Console.WriteLine("ELEMEK");
            foreach (var item in lista)
                Console.WriteLine(item);


            // névtelen függvény létrehozása
            // helyben, ahol szükség van rá
            // ehhez delegate-et használunk
            // ezt a formát ma már nem igazán használjuk (helyette: lambda)

            Console.WriteLine("\nLISTA KERESÉS DELEGÁLTTAL");
            int keresettParosElem = lista.Find(delegate (int x) {
                return x % 2 == 0;
            });

            int keresettXElem = lista.Find(delegate (int x) {
                return x > 10 && x < 82 && x % 2 == 1;
            });

            Console.WriteLine(keresettParosElem);
            Console.WriteLine(keresettXElem);

            List<int> paratlanok = lista.FindAll(delegate (int x)
            {
                return x % 2 == 1;
            });

            Console.WriteLine();
            foreach (var item in paratlanok)
                Console.WriteLine(item);


            // =================================================================


            Console.WriteLine("\nLISTA KERESÉS LAMBDÁVAL");
            keresettParosElem = lista.Find(x => x % 2 == 0);
            keresettXElem = lista.Find(x => x > 10 && x < 82 && x % 2 == 1);

            Console.WriteLine(keresettParosElem);
            Console.WriteLine(keresettXElem);
            Console.WriteLine();

            List<Ember> emberLista = new List<Ember>();
            for (int i = 0; i < 10; i++)
                emberLista.Add(new Ember()
                {
                    Nev = i + ". Jakab Király",
                    Eletkor = r.Next(10, 60)
                });

            List<Ember> keresettek = emberLista.FindAll(x => x.Eletkor < 23);
            foreach (var item in keresettek)
                Console.WriteLine(item);


            // =================================================================


            // nem mindig kell nekünk kézzel létrehozni delegáltakat
            // hiszen van erre (is) beépített lehetőség
            // Func < [paraméterek...] , [visszatérés_típusa] >

            Console.WriteLine("\nKONVERTER LAMBDÁVAL FUNC SEGÍTSÉGÉVEL");
            Func<string, int> converter = x => int.Parse(x);

            int a = converter("333");

            Console.WriteLine(a);


            // =================================================================


            Console.WriteLine();
            Action<string> udvozlo = (x => Console.WriteLine(">>> " + x));

            udvozlo += (x => Console.WriteLine("--- " + x));
            udvozlo += (x => Console.WriteLine("::: " + x));
            udvozlo += (x => Console.WriteLine("==> " + x));

            udvozlo?.Invoke("John Wick");



            Console.WriteLine("\n\n");

            Predicate<int> vizsgalat = ParosE;
            Console.WriteLine(vizsgalat(10));
            Console.WriteLine(vizsgalat(11));

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
             */

            Console.WriteLine("\n\n");

            // =================================================================



            // rendezés lambdával

            Ember[] emberek = new Ember[]
            {
                new Ember() { Nev = "András", Eletkor = 20 },
                new Ember() { Nev = "Klaudia", Eletkor = 35 },
                new Ember() { Nev = "Barbara", Eletkor = 75 },
                new Ember() { Nev = "János", Eletkor = 12 }
            };

            foreach (var item in emberek)
                Console.WriteLine("> " + item);

            Array.Sort(emberek, EmberOsszehasonlito);
            // Array.Sort(emberek, (Ember x, Ember y) => x.CompareTo(y));
            // Array.Sort(emberek, (Ember x, Ember y) => x.Eletkor.CompareTo(y.Eletkor));

            foreach (var item in emberek)
                Console.WriteLine("--> " + item);


        }

        public static int EmberOsszehasonlito(Ember x, Ember y)
        {
            return x.CompareTo(y);
        }
    }
}
