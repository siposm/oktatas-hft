using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unittesting
{
    public class Neptun
    {
        private List<Student> Students;

        public Neptun()
        {
            this.Students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            this.Students.Add(s);
        }

        public void RemoveStudent(Student s)
        {
            this.Students.Remove(s);
        }

        public Student GetStudentByIndex(int index)
        {
            return this.Students[index];
        }

        public List<Student> GetStudentsByCriteria(Predicate<string> pred)
        {
            return (from x in Students
                    where pred(x.Name)
                    select x).ToList();
        }
    }
}
