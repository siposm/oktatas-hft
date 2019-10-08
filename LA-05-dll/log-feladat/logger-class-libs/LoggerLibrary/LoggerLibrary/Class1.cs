using System;

namespace LoggerLibrary
{
    public interface ILogger
    {
        void Log(Student student);
    }

    public class Student
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Student()
        {
            this.RegistrationDate = DateTime.Now;
        }
    }
}
