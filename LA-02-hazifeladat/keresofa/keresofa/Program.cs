using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace keresofa
{
    class BST<T>
    {
        FaElem gyoker;

        Comparison<T> osszehasonlitas;
        public Comparison<T> Osszehasonlitas
        {
            get => osszehasonlitas;
            set => osszehasonlitas = value;
        }

        public

        class FaElem
        {
            public T tartalom;
            public FaElem bal;
            public FaElem jobb;
        }

        public void Beszuras(T tartalom)
        {
            Beszuras(ref gyoker, tartalom);
        }
        private void Beszuras(ref FaElem p , T tartalom)
        {
            if( p == null )
            {
                p = new FaElem();
                p.tartalom = tartalom;
                p.bal = null; p.jobb = null;
            }
            else if ( osszehasonlitas(p.tartalom, tartalom) > 0 )
            {
                Beszuras(ref p.bal, tartalom);
            }
            else if ( osszehasonlitas(p.tartalom, tartalom) < 0)
            {
                Beszuras(ref p.jobb, tartalom);
            }
            else
            {
                throw new Exception("kulcsütközés");
            }
        }

        public void Bejaras()
        {
            Bejaras(ref gyoker);
        }

        private void Bejaras(ref FaElem p)
        {
            if(p != null)
            {
                Bejaras(ref p.bal);
                Console.WriteLine(p.tartalom);
                Bejaras(ref p.jobb);
            }
        }
    }


    class Szemely : IComparable
    {
        public string Nev { get; set; }
        public string Email { get; set; }
        public string Munkahely { get; set; }
        public string Beosztas { get; set; }
        public string Tel { get; set; }
        public string Szoba { get; set; }

        public int CompareTo(object obj)
        {
            return this.Nev.CompareTo(obj);
        }

        public override string ToString()
        {
            return this.Nev;
        }
    }


    class MainClass
    {
        public static void Main(string[] args)
        {

            BST<Szemely> bst = new BST<Szemely>();

            Comparison<Szemely> osszehasonlitas = ((x, y) => x.Nev.CompareTo(y.Nev));

            bst.Osszehasonlitas = osszehasonlitas;



            // -----------------------------------------------------------------



            XDocument xml = XDocument.Load("treeworkers.xml");
            var alapHarmas = from x in xml.Root.Descendants("person")
                             where x.Element("name").Value.Equals("Tony Stark")
                             select x;

            foreach (var item in alapHarmas)
                Console.WriteLine(item);

            Console.WriteLine("\n\n\n");



            // -----------------------------------------------------------------



            Szemely tony = (from x in alapHarmas
                       select new Szemely
                       {
                           Nev = x.Element("name").Value,
                           Email = x.Element("email").Value,
                           Munkahely = x.Element("dept").Value,
                           Beosztas = x.Element("rank").Value,
                           Tel = x.Element("phone").Value,
                           Szoba = x.Element("room").Value
                       }).FirstOrDefault();

            var friends = from x in alapHarmas.Descendants("friends")
                       select x;

            Szemely bruce = (from x in friends.Descendants("person")
                             where x.Element("name").Value.Equals("Bruce Banner")
                             select new Szemely
                             {
                                 Nev = x.Element("name").Value,
                                 Email = x.Element("email").Value,
                                 Munkahely = x.Element("dept").Value,
                                 Beosztas = x.Element("rank").Value,
                                 Tel = x.Element("phone").Value,
                                 Szoba = x.Element("room").Value
                             }).FirstOrDefault();

            Szemely szabolcs = (from x in friends.Descendants("person")
                             where x.Element("name").Value.Equals("Dr. Sergyán Szabolcs")
                             select new Szemely
                             {
                                 Nev = x.Element("name").Value,
                                 Email = x.Element("email").Value,
                                 Munkahely = x.Element("dept").Value,
                                 Beosztas = x.Element("rank").Value,
                                 Tel = x.Element("phone").Value,
                                 Szoba = x.Element("room").Value
                             }).FirstOrDefault();


            // ez jó, de ha nagyon sok barátja lenne, akkor ...
            // helyette: foreach-csel sima ügy!

            List<Szemely> baratok = new List<Szemely>();

            foreach (var item in friends.Elements("person"))
            {
                baratok.Add(new Szemely()
                {
                    Nev = item.Element("name").Value,
                    Email = item.Element("email").Value,
                    Munkahely = item.Element("dept").Value,
                    Beosztas = item.Element("rank").Value,
                    Tel = item.Element("phone").Value,
                    Szoba = item.Element("room").Value
                });
            }


            var tovabbiak = from x in xml.Root.Descendants("person").Skip(3)
                            select x;

            List<Szemely> tovabbiakLista = new List<Szemely>();

            foreach (var item in tovabbiak)
            {
                tovabbiakLista.Add(new Szemely()
                {
                    Nev = item.Element("name").Value,
                    Email = item.Element("email").Value,
                    Munkahely = item.Element("dept").Value,
                    Beosztas = item.Element("rank").Value,
                    Tel = item.Element("phone").Value,
                    Szoba = item.Element("room").Value
                });
            }



            // -----------------------------------------------------------------



            bst.Beszuras(tony);
            bst.Beszuras(bruce);
            bst.Beszuras(szabolcs);

            foreach (var item in tovabbiakLista)
                bst.Beszuras(item as Szemely);

            bst.Bejaras();
        }
    }
}
