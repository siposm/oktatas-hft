using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("classes-dll")]

namespace classes_dll
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Dog Dog { get; set; }
    }
    public class Dog
    {
        public string Name { get; set; }
    }
}