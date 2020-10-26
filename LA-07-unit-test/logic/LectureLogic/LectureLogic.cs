using System;
using System.Collections.Generic;

namespace LectureLogic
{
    /*
    *   Note: model / entity class-okat nem szoktunk unit-tesztelni!
    */

    public class Lecture
    {
        public string Name { get; set; }
        public int HoursPerSemester { get; set; }
        public int Credit { get; set; }
        public List<Student> Students { get; set; } // dotnet add reference !!! a student-hez

        public Lecture()
        {
            this.Students = new List<Student>();
        }
    }

    public interface ILectureLogic
    {
        int LectureCount { get; }
        List<Lecture> GetAll();
        void AddLecture(Lecture lec);
        Lecture GetLectureByIndex(int index);
        void AddStudentToLecture(Student stud, int lectureIndex);
    }

    public class LectureLogic : ILectureLogic
    {
        private List<Lecture> Lectures { get; set; }

        public int LectureCount
        {
            get
            {
                return this.Lectures.Count;
            }
        }

        public LectureLogic()
        {
            this.Lectures = new List<Lecture>();
        }

        public void AddLecture(Lecture lec)
        {
            this.Lectures.Add(lec);
        }

        public Lecture GetLectureByIndex(int index)
        {
            return this.Lectures[index];
        }

        public void AddStudentToLecture(Student stud, int lectureIndex)
        {
            this.Lectures[lectureIndex].Students.Add(stud);
        }

        public List<Lecture> GetAll()
        {
            return this.Lectures;
        }
    }
}
