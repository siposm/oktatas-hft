using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StudentLogic.Tests
{
    [TestFixture]
    public class Tests
    {
        private StudentLogic sLogic { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            this.sLogic = new StudentLogic();

            this.sLogic.AddStudent(new Student()
            {
                Name = "Test Person #0",
                StartYear = 2004
            });

            this.sLogic.AddStudent(new Student()
            {
                Name = "Test Person #1",
                StartYear = 2016
            });

            this.sLogic.AddStudent(new Student()
            {
                Name = "Test Person #2",
                StartYear = 2012
            });
        }

        [TestCase(3, "Person #3")]
        [TestCase(4, "Person #4")]
        public void AddStudentTest(int index, string studName)
        {
            this.sLogic.AddStudent(new Student()
            {
                Name = studName
            });

            Assert.That(sLogic.GetStudentByIndex(index).Name, Is.EqualTo(studName)); // GetStudent metódusban _lehet_ hiba, amivel itt nem számolok
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)] // note: 1-10-100 nem működik hiszen nincs ennyi elem a listában jelenleg
        public void GetStudentTest(int index)
        {
            var x = sLogic.GetStudentByIndex(index);
            var y = sLogic.GetStudentByIndex(index);

            Assert.That(x, Is.SameAs(y));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void RemoveStudentByIndex_Throws(int index)
        {
            Assert.That(() => sLogic.RemoveStudentByIndex(index), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void OrderStudents()
        {
            List<Student> copy = new List<Student>();

            foreach (var item in sLogic.GetAll())
                copy.Add(item);

            copy.Sort();

            Assert.That(copy[0].Name, Is.Not.EqualTo(sLogic.GetAll()[0]));
        }
    }
}