using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LancoltListaLibrary; // --- saját
using mycompare_interface; // --- saját

namespace lista_dll
{
    class ConditionedChainedList<T> : ChainedList<T>, MyCompare<T>
    {
        public int Count { get; private set; }

        [ToInsert]
        public Comparison<T> Comparison { get; set; }
        public Predicate<T> Predicate { get; set; }

        public int CompareTo(object obj)
        {
            return this.Count.CompareTo((obj as ConditionedChainedList<T>).Count);
        }

        public void InsertIF(T newContent)
        {
            if (Predicate.Invoke(newContent))
                base.Insert(newContent);
            else
                throw new PredicateException();
        }
    }


    class PredicateException : Exception
    {

    }



    class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return string.Format("{0} <{1}>", Name, ID);
        }
    }



    class Program
    {
        static bool MyPredicateFunction(Student stud)
        {
            return stud.Name.Contains("Stark");
        }

        static void Main(string[] args)
        {
            ConditionedChainedList<Student> clist = new ConditionedChainedList<Student>();

            clist.Comparison = new Comparison<Student>((x, y) => x.Name.CompareTo(y.Name));
            clist.Predicate = new Predicate<Student>(MyPredicateFunction);

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    clist.InsertIF(new Student()
                    {
                        Name = i + ". Stark Student" + r.Next(100),
                        //Name = i + ". Student" + r.Next(100), // "Stark" missing >> error
                        ID = r.Next(1000, 10000)
                    });
                }
                catch (PredicateException)
                {
                    Console.WriteLine("[ERR] error happened");
                }
            }

            clist.Process();
        }
    }
}
