using System;
using System.Collections.Generic;

namespace StudentLogic
{
    public class StudentLogic
    {
        private List<Student> Students { get; set; }

        public StudentLogic()
        {
            this.Students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            if (s.Name == null)
                throw new NullReferenceException("string is null");

            if (s.Name == "")
                throw new Exception("string is empty");

            this.Students.Add(s);
        }

        public void RemoveStudentByIndex(int index)
        {
            if (index < 0 || index > Students.Count)
                throw new IndexOutOfRangeException("index value was too big or too small");

            this.Students.RemoveAt(index);
        }

        public Student GetStudentByIndex(int index)
        {
            if (index < 0 || index > Students.Count)
                throw new IndexOutOfRangeException("index value was too big or too small");

            return this.Students[index];
        }

        public List<Student> GetAll()
        {
            return this.Students;
        }
    }
}
