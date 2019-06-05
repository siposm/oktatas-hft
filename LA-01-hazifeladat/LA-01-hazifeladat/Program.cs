using System;

namespace LA01hazifeladat
{
    class SpeciEventArgs<T> : EventArgs
    {
        public string Uzenet { get; set; }
        public T Elem { get; set; }
    }

    class Eloleny
    {
        public string Nev { get; set; }

        public override string ToString()
        {
            return this.Nev.ToUpper() + " - " + this.GetType().Name;
        }
    }

    class Ember : Eloleny
    { }

    class Kutya : Eloleny
    { }

    class LancoltLista<T>
    {
        public event EventHandler<SpeciEventArgs<T>> SpeciElemBeszurasa; // generikusan kell megadni a származtatott eventargs osztályt

        private Predicate<T> speciElemVizsgalat;

        private Comparison<T> rendezettsegiElv;

        public LancoltLista(Predicate<T> ellenorzoFgv)
        {
            this.speciElemVizsgalat = ellenorzoFgv;
        }

        #region lista metódusok

        private ListaElem fej;

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }

        public void Beszuras(T elem)
        {
            if (speciElemVizsgalat != null)
            {
                if (speciElemVizsgalat(elem))
                {
                    OnSpeciElemBeszurasa(new SpeciEventArgs<T>()
                    {
                        Uzenet = "esemény történt...",
                        Elem = elem
                    });
                }
            }

            bool listaelejere = false;

            if (rendezettsegiElv != null)
            {
                if (fej != null)
                {
                    if (rendezettsegiElv(fej.tartalom, elem) > 0)
                    {
                        listaelejere = true;
                    }
                }
            }


            ListaElem uj = new ListaElem() { tartalom = elem };


            if (listaelejere)
            {
                uj.kovetkezo = fej;
                fej = uj;
            }
            else
            {
                // lista végére
                if (fej == null)
                    fej = uj;
                else
                {
                    ListaElem p = fej;
                    while (p.kovetkezo != null)
                        p = p.kovetkezo;

                    p.kovetkezo = uj;
                }
            }
        }

        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Console.WriteLine(p.tartalom);
                p = p.kovetkezo;
            }
        }

        #endregion

        protected virtual void OnSpeciElemBeszurasa(SpeciEventArgs<T> args)
        {
            SpeciElemBeszurasa?.Invoke(this, args);
        }

        public void RendezesElve(Comparison<T> fgv)
        {
            this.rendezettsegiElv = fgv;
        }
    }










    class MainClass
    {
        public static void Ertesito(object src, SpeciEventArgs<Eloleny> args)
        {
            Console.WriteLine(
                "[EVENT]\n"
                +
                "üzenet: " + args.Uzenet
                +
                " elem: " + args.Elem
                );
        }

        public static void Main(string[] args)
        {
            Predicate<Eloleny> nevFgv = ( x => x.Nev == "Lajos" );
            Predicate<Eloleny> tipusFgv = ( x => x is Kutya );

            Comparison<Eloleny> osszehasonlitas = ((x, y) => x.Nev.CompareTo(y.Nev));

            LancoltLista<Eloleny> lista = new LancoltLista<Eloleny>(tipusFgv);
            Random r = new Random();

            lista.RendezesElve(osszehasonlitas);


            // esemény feliratkoztatásakor mehet a régi, szokott verzió
            // de létrehozhatunk helyben is anonim fgv-t

            lista.SpeciElemBeszurasa += Ertesito;
            lista.SpeciElemBeszurasa += (object src, SpeciEventArgs<Eloleny> sea) => {
                Console.WriteLine(
                "[EVENT]\n"
                +
                "üzenet: " + sea.Uzenet
                +
                " elem: " + sea.Elem
                );
            };

            lista.Beszuras(new Ember() { Nev = "D" });
            lista.Beszuras(new Ember() { Nev = "A" });
            lista.Beszuras(new Ember() { Nev = "C" });
            lista.Beszuras(new Ember() { Nev = "X" });
            lista.Beszuras(new Kutya() { Nev = "Bodrikutya" });


            Console.WriteLine("\n > BEJÁRÁS");
            lista.Bejaras();




        }
    }
}
