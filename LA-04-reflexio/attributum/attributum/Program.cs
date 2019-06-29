﻿using System;
using System.Collections.Generic;
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



    class Neptun
    {
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
        static void Main(string[] args)
        {
            Neptun n = new Neptun();

            n.HallgatoFelvetele(); // tooltip >> deprecated (nem támogatott már)




            // -----------------------------------------------------------------------------------------------------------



            // attribútum elérése reflexióval

            MethodInfo methodInfo = typeof(Neptun).GetMethod("UJ_HallgatoFelvetele");
            HelpAttribute helpAttribute = methodInfo.GetCustomAttribute<HelpAttribute>();

            Console.WriteLine(helpAttribute.HelpText);

        }
    }
}