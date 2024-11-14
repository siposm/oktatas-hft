using System.Reflection;
using System.Xml.Linq;

namespace _04_reflection_attribute
{
    internal class Program
    {
        static List<IMyObject> GetStudents()
        {
            List<IMyObject> students =
            [
                new Student() { Email = "gipsz.jakab@gmail.com" },
                new Person() { Name = "Toldi Janos" },
                new BScStudent() { Email = "matyas15@yahoo.com", Name = "Matyas Kiraly" },
                new BScStudent() { Email = "stevejobs@apple.com", Name = "Steve Jobs" },
                new Student() { Email = "kiss.tamas.ferenc@uni-obuda.hu", Name = "Kiss T. Ferenc" },
            ];

            return students;
        }
        static void Main(string[] args)
        {
            List<IMyObject> students = GetStudents();

            ;

            foreach (var studentObject in students)
            {
                if (studentObject is Student) // not good, too weak filtering because it includes the descendant classes as well
                //if (studentObject.GetType().Equals(typeof(Student)))
                {
                    foreach (PropertyInfo prop in studentObject.GetType().GetProperties())
                    {
                        if (prop.Name == "Email")
                        {
                            foreach (Attribute attr in prop.GetCustomAttributes())
                            {
                                CheckLengthAttribute? cla = attr as CheckLengthAttribute;
                                string? firstPart = prop.GetValue(studentObject)?.ToString()?.Split('@')[0];

                                if (firstPart?.Length <= cla?.MaxLength)
                                {
                                    // email ok
                                    ((Student)studentObject).Approved = true;
                                }
                                else
                                {
                                    // email not ok
                                    ((Student)studentObject).Approved = false;
                                    //throw new Exception("ERROR: EMAIL IS INCORRECT!");
                                }
                            }
                        }
                    }
                }
            }

            ;

            var q = students.OfType<Student>().GroupBy(x => x.Approved);

            ;
        }
    }
}
