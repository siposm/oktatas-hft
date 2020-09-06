using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using unittesting; // !!!

namespace NeptunTesting
{
    [TestFixture]
    public class NeptunTest
    {
        [Test]
        public void AddAndRemoveStudentTest()
        {
            Neptun n = new Neptun();
            int state1 = n.GetStudentNumber;

            Student s = new Student() { Name = "A" }; // should be dedicated element

            n.AddStudent(s);
            int state2 = n.GetStudentNumber;

            n.RemoveStudent(s);
            int state3 = n.GetStudentNumber;
            
            Assert.AreNotEqual(state1, state2);
            Assert.AreEqual(state1, state3);
        }

        [Test]
        public void GetStudentByIndexTest()
        {
            Neptun n = new Neptun();
            n.AddStudent(new Student() { Name = "A" });
            n.AddStudent(new Student() { Name = "B" });
            n.AddStudent(new Student() { Name = "C" });

            Student s = n.GetStudentByIndex(0);

            Assert.That(s.Name, Is.EqualTo("A"));
            Assert.That(s.Name, Is.Not.EqualTo("C"));
        }

        [Test]
        public void GetStudentsByCriteria()
        {
            Neptun n = new Neptun();
            n.AddStudent(new Student() { Name = "A hallgató" });
            n.AddStudent(new Student() { Name = "B" });
            n.AddStudent(new Student() { Name = "C hallgató" });
            n.AddStudent(new Student() { Name = "D ha" });

            List<Student> q = n.GetStudentsByCriteria(new Predicate<string>(x => x.Length > 5));

            Assert.IsTrue(q[0].Name.Equals("A hallgató"));
        }
    }
}
