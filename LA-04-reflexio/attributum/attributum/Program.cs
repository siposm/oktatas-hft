using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace attributum
{
    
    class HelpAttribute : Attribute
    {
        public string HelpText { get; set; }
    }


    // megszorítás >> csak osztályra helyezhető attrib.

    [AttributeUsage(AttributeTargets.Class)]
    class MyClassAttribute : Attribute
    {
        // ...
    }


    // megszorítás >> csak metódusra helyezhető attrib.

    [AttributeUsage(AttributeTargets.Method)]
    class MyMethodAttribute : Attribute
    {
        // ...
    }

    [AttributeUsage(AttributeTargets.Property)]
    class CheckLength : Attribute
    {
        public int MaxLength { get; set; }
    }



    //[MyMethod] // nem ok
    [MyClass] // ok
    class Auto
    {
        [CheckLength(MaxLength = 7)]
        public string Rendszam { get; set; }

        [MyMethod] // ok
        //[MyClass] // nem ok
        public void Tankol()
        {

        }
    }



    class Neptun
    {
        /// <summary>
        /// Visszaadja 'int' a jelenleg aktív hallgatók számát.
        /// </summary>
        public int AktivHallgatokSzama { get; set; }

        [Obsolete]
        //[Obsolete("használd az újabb metódust")] // >> megjelenik az üzenet a tooltip-ben
        //[Obsolete("használd az újabb metódust",true)] // >> errort kap, nem warningot
        public void HallgatoFelvetele()
        {
            // hallgató felvitele...
        }

        [Help(HelpText ="új hallgató felvitele a neptun rendszerbe itt történik")]
        public void UJ_HallgatoFelvetele()
        {
            // hallgató felvitele...
        }
    }




    class Program
    {
        static void RendszamBeallitas(Auto a, string r)
        {
            // feltételezve, hogy ez valahol egy nagy program szeparált pontján történik...
            a.Rendszam = r;

            // ellenőrzés
            foreach (PropertyInfo p in a.GetType().GetProperties())
            {
                foreach (Attribute att in p.GetCustomAttributes())
                {
                    CheckLength c = (CheckLength)att;
                    if (p.Name == "Rendszam")
                    {
                        if (a.Rendszam.Length > c.MaxLength) // hossz ellenőrzése
                        {
                            throw new Exception("A megadott érték túl hosszú.");
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Neptun n = new Neptun();

            n.HallgatoFelvetele(); // tooltip >> deprecated (nem támogatott már)



            // -----------------------------------------------------------------------------------------------------------


            Auto a = new Auto();
            try
            {
                RendszamBeallitas(a, "ASD-123-");
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }

            
            
            
            // -----------------------------------------------------------------------------------------------------------



            // attribútum elérése reflexióval

            MethodInfo methodInfo = typeof(Neptun).GetMethod("UJ_HallgatoFelvetele");
            HelpAttribute helpAttribute = methodInfo.GetCustomAttribute<HelpAttribute>();

            Console.WriteLine(helpAttribute.HelpText);

        }
    }
}
