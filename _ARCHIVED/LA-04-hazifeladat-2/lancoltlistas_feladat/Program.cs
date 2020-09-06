using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lancoltlistas_feladat
{
    class LancoltLista<T>
    {
        public LancoltLista()
        {
            TulcsordulasiTerulet = new List<T>();
            fej = null;
        }

        private ListaElem fej;

        public List<T> TulcsordulasiTerulet { get; set; }

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }

        public void Beszuras(T ujTartalom)
        {
            if (ujTartalom.GetType().GetMethods().Where(x => x.Name.Equals("Ugrik")).Any())
            {
                ElejereBeszuras(ujTartalom);
            }
            else if (ujTartalom.GetType().GetMethods().Where(x => x.Name.Equals("Nyavog")).Any())
            {
                VegereBeszuras(ujTartalom);
            }
            else
            {
                TulcsordulasiTerulet.Add(ujTartalom);

                // debug
                Console.WriteLine("TULCS");
                Console.WriteLine(ujTartalom);
            }
        }

        private void VegereBeszuras(T uj)
        {
            // debug
            Console.WriteLine("VÉGÉRE");
            Console.WriteLine(uj);

            // todo: beszúrás megírása
        }

        private void ElejereBeszuras(T uj)
        {
            // debug
            Console.WriteLine("ELEJÉRE");
            Console.WriteLine(uj);

            // todo: beszúrás megírása
        }
    }

    abstract class Allat
    {

    }

    class Kutya : Allat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }

        public void Ugrik()
        {

        }
    }

    class Macska : Allat
    {
        public string Nev { get; set; }
        public int EletekSzama { get; set; }
        public int Eletkor { get; set; }

        public void Nyavog()
        {

        }

        public void Maszik()
        {

        }
    }

    class Liba : Allat
    {
        public int Suly { get; set; }
        public int Eletkor { get; set; }

        public void Lepegetes()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LancoltLista<Allat> list = new LancoltLista<Allat>();
            list.Beszuras(new Kutya() { Nev = "Bodri" });
            list.Beszuras(new Macska() { Nev = "Cirmi" });
            list.Beszuras(new Liba() { Suly = 6 });
        }
    }
}
