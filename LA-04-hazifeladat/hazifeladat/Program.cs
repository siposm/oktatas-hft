using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hazifeladat
{

    class NotValidAvengerException : Exception
    {

    }

    class NoAttributeException : Exception
    {

    }

    public enum TartozkodasiHely { Föld, Mars, Vormir, Titan }

    class AvengerAttribute : Attribute
    {
        public TartozkodasiHely Hely { get; set; }

        public AvengerAttribute(TartozkodasiHely tartozkodasiHely)
        {
            this.Hely = tartozkodasiHely;
        }
    }

    class SavedLivesAttribute : Attribute
    {
        public int Limit { get; set; }

        public SavedLivesAttribute(int limit)
        {
            this.Limit = limit;
        }
    }


    class Bosszuallo
    {
        public string Nev { get; set; }

        [SavedLives(30)]
        public int MegmentettDarabszam { get; set; }

        [Avenger(TartozkodasiHely.Titan)]
        public void Harcol()
        {

        }
    }

    class Fohadiszallas
    {
        public List<Bosszuallo> Bosszuallok { get; set; }

        public Fohadiszallas()
        {
            this.Bosszuallok = new List<Bosszuallo>();
        }

        public void HarcolniKuld(Bosszuallo b)
        {
            switch (b.GetType().GetMethod("Harcol").GetCustomAttribute<AvengerAttribute>().Hely)
            {
                case TartozkodasiHely.Föld:
                    Console.WriteLine("földön harcol");
                    break;
                case TartozkodasiHely.Mars:
                    Console.WriteLine("marson harcol");
                    break;
                case TartozkodasiHely.Vormir:
                    Console.WriteLine("vormiron harcol");
                    break;
                case TartozkodasiHely.Titan:
                    Console.WriteLine("titanon harcol");
                    break;
                default:
                    break;
            }
        }

        public void Felvesz(Bosszuallo b)
        {
            if( typeof(Bosszuallo).GetProperties().Where(x => x.GetCustomAttributes<SavedLivesAttribute>() != null) != null )
            {
                foreach (var item in typeof(Bosszuallo).GetProperties().Where(t => t.GetCustomAttribute<SavedLivesAttribute>() != null)) // foreach nem annyira szép itt
                {
                    if (item.GetCustomAttribute<SavedLivesAttribute>().Limit <= b.MegmentettDarabszam)
                        Bosszuallok.Add(b);
                    else
                        throw new NotValidAvengerException();
                }
            }
            else
                throw new NoAttributeException();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Fohadiszallas hq = new Fohadiszallas();

            hq.Felvesz(new Bosszuallo() { Nev = "Tony Stark", MegmentettDarabszam = 88 });

            try
            {
                hq.Felvesz(new Bosszuallo() { Nev = "Hawkeye", MegmentettDarabszam = 10 });
            }
            catch (NotValidAvengerException)
            {
                Console.WriteLine("hiba volt");
            }




            foreach (var item in hq.Bosszuallok)
            {
                Console.WriteLine(item.Nev);
            }

            hq.HarcolniKuld(new Bosszuallo() { Nev = "Tony Stark", MegmentettDarabszam = 88 });

        }
    }
}
