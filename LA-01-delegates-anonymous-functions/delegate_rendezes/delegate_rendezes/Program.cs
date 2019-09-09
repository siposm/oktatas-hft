using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_rendezes
{

    interface MyCompareTo <T> : IComparable
    {
        Comparison<T> Comparison { get; set; }
    }

    class Student : MyCompareTo <Student>
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Comparison<Student> Comparison { get; set; }

        public int CompareTo(object obj)
        {
            // ?.Invoke esetén lenne null check, de akkor nem elégül ki a visszatérési érték
            // megoldás: if-else VAGY try-catch koncepció köréépítése
            try
            {
                return Comparison.Invoke(this, (obj as Student));
            }
            catch (NullReferenceException)
            {
                return -200;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // két hallgató összehasonlítása

            Student s1 = new Student() { Name = "A Lajos", ID = 10 };
            Student s2 = new Student() { Name = "B Béla", ID = 1230 };

            //s1.Comparison = new Comparison<Student>((x, y) => x.ID.CompareTo(y.ID));
            s2.Comparison = new Comparison<Student>((x, y) => x.Name.CompareTo(y.Name));

            Console.WriteLine(s1.CompareTo(s2)); // ID : -1 >> s1 kisebb mint s2
            Console.WriteLine(s2.CompareTo(s1)); // NÉV : 1 >> s2 nagyobb mint s1

            Console.WriteLine("\n--------\n");

            
            
            
            // -----------------------------------------------------------------




            Student[] studs = new Student[10];
            Random r = new Random();

            for (int i = 0; i < studs.Length; i++)
                studs[i] = new Student()
                {
                    Name = "Hallgató-" + r.Next(100,1000),
                    ID = r.Next(10, 100)
                };

            for (int i = 0; i < studs.Length; i++)
                Console.WriteLine(studs[i].Name + "\t" + studs[i].ID);


            //Array.Sort(studs, new Comparison<Student>((x, y) => x.Name.CompareTo(y.Name)));
            Array.Sort(studs, new Comparison<Student>((x, y) => x.ID.CompareTo(y.ID)));


            Console.WriteLine("\n--------\n");

            for (int i = 0; i < studs.Length; i++)
                Console.WriteLine(studs[i].Name + "\t" + studs[i].ID);
        }
    }
}
