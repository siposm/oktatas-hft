using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reflexio_feladat_2
{
    class Allat
    {
        public bool Novenyevo { get; set; }
    }

    class Macska : Allat
    {
        public Macska()
        {
            Novenyevo = false;
        }

        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int EletekSzama { get; set; }

        public string Koszon() { return "szia"; }

        [MethodToXML]
        public void Nyavog() { }

        [MethodToXML]
        public int Setal() { return 0; }

        [MethodToXML]
        public double FaraMaszik(string a, bool b) { return 0.5; }
    }

    [ModelToXML]
    class Kutya : Allat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public bool Nosteny { get; set; }

        [MethodToXML]
        public int Ugat()
        {
            return 10; // ugatás hosszát adja vissza (msp)
        }

        public void Koszon() { }

        [MethodToXML]
        public double Futas() { return 4.009; }

        [MethodToXML]
        public double Seta() { return 432.114; }
    }

    class Hallgato
    {
        public string Nev { get; set; }
        public string NeptunKod { get; set; }
        public bool Nem { get; set; }
        public DateTime Szuletes { get; set; }

        public void OraraJar() { }

        [MethodToXML]
        public void TargyFelvesz() { }

        [MethodToXML]
        public void TargyLead() { }

        [MethodToXML]
        public void VizsgaraJelentkezik() { }
    }

    class Auto
    {
        public string Rendszam { get; set; }
        public string Tulajdonos { get; set; }
        public bool Szemelygepjarmu { get; set; }
        public DateTime UzembehelyzesIdeje { get; set; }

        public void Tankol() { }

        [MethodToXML]
        public void Gyorsit() { }

        [MethodToXML]
        public void Lassit() { }

        [MethodToXML]
        public void Szervizel() { }
    }
}
