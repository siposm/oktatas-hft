using System;
using System.Collections.Generic;

namespace StudentLogic
{
    public class Student : IComparable
    {
        public string Name { get; set; }
        public int StartYear { get; set; }

        public char GetFirstCharacter
        {
            get { return char.ToUpper(this.Name[0]); }
        }

        public int CompareTo(object obj)
        {
            return this.StartYear.CompareTo((obj as Student).StartYear);
        }

        public int CountSemester()
        {
            return (DateTime.Now.Year - this.StartYear) * 2;
        }

        public void CreateInstanceFromString(string input)
        {
            if (input.Contains("#"))
                throw new FormatException("not valid format");
            else
            {
                // input = [name]%[year]

                this.Name = input.Split('%')[0];
                this.StartYear = int.Parse(input.Split('%')[1]);
            }
        }
    }

    public class Logic
    {
        List<Student> Students { get; set; }

        public Logic()
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
    }
}
