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
    }

    public interface ILectureLogic
    {
        void AddLecture(Lecture lec);
        Lecture GetLectureByIndex(int index);
        void AddStudentToLecture(Student stud, int lectureIndex);
    }

    public class LectureLogic : ILectureLogic
    {
        private List<Lecture> Lectures { get; set; }

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
    }
}
