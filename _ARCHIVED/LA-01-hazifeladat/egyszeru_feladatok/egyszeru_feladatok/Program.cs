using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nevtelenfuggvenyek
{
    public delegate int SzamVarazslo(int a, int b, int c);

    public delegate List<int> SzamListazo(int[] tomb);

    public delegate List<T> SzamGenListazo<T>(T[] tomb);

    public delegate List<T> SzamListazo<T, K>(T[] tomb, K feltetel);

    class Szemely
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            // SzamVarazslo szv = new SzamVarazslo(_ paraméter _);
            SzamVarazslo szv = ((x, y, z) => { return x + y + z; });
            szv += ((x, y, z) => x * y * z);

            szv(1, 2, 3);

            // ------------------------------------------

            SzamListazo szl = (x =>
            {
                List<int> elemek = new List<int>();
                foreach (int item in x)
                    elemek.Add(item);

                return elemek;
            });

            szl(new int[] { 1, 2, 3 });

            // ------------------------------------------

            SzamGenListazo<int> szgl = (x =>
            {
                List<int> elemek = new List<int>();
                foreach (int item in x)
                    elemek.Add(item);

                return elemek;
            });

            szgl(new int[] { 1, 2, 3 });

            // ------------------------------------------

            SzamListazo<Szemely, int> szlsz = ((x, y) =>
            {
                List<Szemely> lista = new List<Szemely>();
                foreach (var item in x)
                {
                    if ((item as Szemely).Eletkor > y)
                        lista.Add(item);
                }
                return lista;
            });

            szlsz(new Szemely[]
            {
                new Szemely() {Nev = "Lajos",Eletkor = 22},
                new Szemely() {Nev = "Timi",Eletkor = 13},
                new Szemely() {Nev = "Brigi",Eletkor = 63},
            }, 22);
        }
    }
}
