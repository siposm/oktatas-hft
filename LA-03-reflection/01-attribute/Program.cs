using System;

namespace _01_attribute
{

    class HelpAttribute : Attribute
    {
        public string HelpText { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]    // megszorítás >> csak osztályra helyezhető attrib.
    class MyClassAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]   // megszorítás >> csak metódusra helyezhető attrib.
    class MyMethodAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)] // megszorítás >> csak tulajdonságra helyezhető attrib.
    class CheckLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
    }


    //[MyMethod] // nem ok
    [MyClass] // ok
    class Car
    {
        [CheckLength(MaxLength = 7)]
        public string ID { get; set; }

        [MyMethod] // ok
        //[MyClass] // nem ok
        public void Drive()
        {

        }
    }


    class Neptun
    {
        /// <summary>
        /// Visszaadja 'int' a jelenleg aktív hallgatók számát.
        /// </summary>
        public int ActiveStudentNumber { get; set; }

        [Obsolete]
        //[Obsolete("használd az újabb metódust")] // >> megjelenik az üzenet a tooltip-ben
        //[Obsolete("használd az újabb metódust",true)] // >> errort kap, nem warningot
        public void EnrollStudent() { }

        [Help(HelpText = "új hallgató felvitele a neptun rendszerbe itt történik")]
        public void NEW_EnrollStudent() { }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Neptun n = new Neptun();
            n.EnrollStudent(); // --> tooltip -> deprecated
        }
    }
}
