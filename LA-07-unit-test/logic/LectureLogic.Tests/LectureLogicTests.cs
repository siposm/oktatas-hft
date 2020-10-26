using NUnit.Framework;

namespace LectureLogic.Tests
{
    [TestFixture]
    public class LectureLogicTests
    {
        private ILectureLogic lLogic { get; set; } // iface

        [OneTimeSetUp]
        public void Setup()
        {
            this.lLogic = new LectureLogic();

            this.lLogic.AddLecture(new Lecture()
            {
                Name = "Test Lecture #0",
                HoursPerSemester = 30,
                Credit = 3
            });

            this.lLogic.AddLecture(new Lecture()
            {
                Name = "Test Lecture #1",
                HoursPerSemester = 100,
                Credit = 10
            });
        }

        [Test]
        public void AddLecture()
        {
            string newName = "Test Lecture #100";
            int newHours = 999;
            int newCredit = 222;

            lLogic.AddLecture(new Lecture()
            {
                Name = newName,
                HoursPerSemester = newHours,
                Credit = newCredit
            });

            Assert.That(lLogic.GetAll()[lLogic.LectureCount - 1].Name, Is.EqualTo(newName));
            Assert.That(lLogic.GetAll()[lLogic.LectureCount - 1].HoursPerSemester, Is.EqualTo(newHours));
            Assert.That(lLogic.GetAll()[lLogic.LectureCount - 1].Credit, Is.EqualTo(newCredit));
        }

        [Test]
        public void AddStudentToLecture()
        {
            Student temp = new Student()
            {
                Name = "Gipsz Jakab",
                StartYear = 2019
            };

            lectureLogic.GetLectureByIndex(1).Students.Add(temp);

            Assert.That(
                lectureLogic.GetLectureByIndex(1)
                .Students.Contains(temp),

                Is.True
            );
        }
    }
}