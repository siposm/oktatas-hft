using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unittesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Neptun n = new Neptun();
            n.AddStudent(new Student() { Name = "A hallgató" });
            n.AddStudent(new Student() { Name = "B" });
            n.AddStudent(new Student() { Name = "C hallgató" });
            n.AddStudent(new Student() { Name = "D ha" });

            var q = n.GetStudentsByCriteria(new Predicate<string>(x => x.Length > 5));
            foreach (var item in q)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
