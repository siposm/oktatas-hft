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
    public class StudentTest
    {
        [Test]
        public void StudentNameTest()
        {
            Student s = new Student() { Name = "Lajos", StartYear = 2018 };
            Assert.AreEqual("Lajos", s.Name);
        }

        [Test]
        public void StudentSemesterTest()
        {
            Student s = new Student() { Name = "Lajos", StartYear = 2018 };
            Assert.That(s.CountSemester(), Is.EqualTo(2));
        }

        [Test]
        public void StudentFirstCharacterTest()
        {
            Student s = new Student() { Name = "Lajos" };
            Assert.That(s.GetFirstCharacter, Is.EqualTo('L'));
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

        //[TestCase(0, "Béla", 2012, TestName = "Első teszt")]
        //[TestCase(1, "Tamara", 2013, TestName = "Második teszt")]
        [TestCase(0, "Béla", 2012)]
        [TestCase(1, "Tamara", 2013)]
        public void CasesTest(int index, string name, int startYear)
        {
            Assert.That(name, Is.AnyOf(new[] { "Béla", "Tamara" }));
            Assert.That(name, Is.Not.AnyOf(new[] { "X", "Y" }));
        }

        [Test]
        public void SortingStudentsViaCompareToTest()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Tamara", StartYear = 2015 });
            students.Add(new Student() { Name = "Tamás", StartYear = 2013 });
            students.Add(new Student() { Name = "Béla", StartYear = 2011 }); // should be 1st
            students.Add(new Student() { Name = "Andris", StartYear = 2012 });

            students.Sort(); // default compareto

            // check first
            Assert.That(students[0].Name, Is.EqualTo("Béla"));
            Assert.That(students[0].StartYear, Is.EqualTo(2011));

            // check last
            Assert.That(students[students.Count() - 1].Name, Is.EqualTo("Tamara"));
            Assert.That(students[students.Count() - 1].StartYear, Is.EqualTo(2015));
        }

        [Test]
        public void SortingStudentsViaDelegateTest()
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
