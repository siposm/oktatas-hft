using System;

namespace linq
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; } /* eljegyezve / hajadon */

        public override string ToString()
        {
            return Name + " " + Age + " " + Status;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
