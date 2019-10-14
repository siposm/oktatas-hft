using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unittesting;

namespace StudentTesting
{
    [TestFixture]
    public class Test
    {

        [Test]
        public void StudentNameTest()
        {
            Student s = new Student() { Name = "Lajos", StartYear = 2018 };

            Assert.AreEqual("Lajos", s.Name);
        }

        [Test]
        public void StudentLogTest()
        {
            Student s = new Student() { Name = "Lajos", StartYear = 2018 };

            s.LogStudentToTXT();

            string[] x = File.ReadAllLines("student.txt");

            Assert.AreEqual(x[0], s.Name);
        }

        [Test]
        public void StudentObjectThrowsTest()
        {
            Student s = new Student();

            Assert.That(() => s.CreateInstanceFromString("#Lajos%2012"),
                Throws.TypeOf<FormatException>());
        }

        [Test]
        public void StudentObjectNotThrowsTest()
        {
            Student s = new Student();

            Assert.That(() => s.CreateInstanceFromString("Lajos%2012"),
                ! Throws.TypeOf<FormatException>());
        }

        [TestCase(0, "Béla", 2012)]
        [TestCase(1, "Tamara", 2013)]
        public void CasesTest(int index, string name, int startYear)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Béla", StartYear = 2012 });
            students.Add(new Student() { Name = "Tamara", StartYear = 2013 });

            Assert.That(students[index].Name, Is.EqualTo(name));
            Assert.That(students[index].StartYear, Is.EqualTo(startYear));
        }

        [Test]
        public void SortingStudentsTest()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Béla", StartYear = 2012 });
            students.Add(new Student() { Name = "Tamara", StartYear = 2017 });
            students.Add(new Student() { Name = "Tamás", StartYear = 2013 });
            students.Add(new Student() { Name = "Andris", StartYear = 2015 });

            // version 1.
            //students.Sort(new Comparison<Student>((x, y) => x.Name.CompareTo(y.Name)));
            //Assert.AreEqual(students[0].Name, "Andris");

            // version 2.
            List<Student> sortedStudents = students.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(sortedStudents[0].Name, students[3].Name);
        }
    }
}
