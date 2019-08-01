using System;
using System.Collections.Generic;

// ms built in unit testing
// [TestClass], [TestMethod]
//using Microsoft.VisualStudio.TestTools.UnitTesting;

// nunit fw használata
// [TestFixture], [Test]
using NUnit.Framework;

using mocking; // másik projekt namespace

using Moq; // moq nuget hozzáadása után




namespace UnitTestAvengers
{
    // Moq's official Github:
    // https://github.com/Moq/moq4/wiki/Quickstart

    [TestFixture]
    public class AvengerControllerTest
    {
        //var avengerController = new AvengerController( [REPO_REF_IDE] );
        // itt jön a probléma: kellene repo is hozzá... >> mockolunk egyet

        // látható, hogy ez nem az a "repo tartalom" amit korábban megírtunk az osztályban
        // hanem csak egy demo, ami tesztelésre alkalmas


        Mock<IRepository> mockRepo;
        AvengerController avengerController;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            {
                new Avenger() { Name = "Captain America", Gender = false, SuperPower = true, Strength = 2 },
                new Avenger() { Name = "Thor", Gender = false, SuperPower = true, Strength = 20 },
                new Avenger() { Name = "Black Widow", Gender = true, SuperPower = false, Strength = 5 },
                new Avenger() { Name = "Scarlet Witch", Gender = true, SuperPower = true, Strength = 18 },
                new Avenger() { Name = "Spider-Man", Gender = false, SuperPower = true, Strength = 13 },
                new Avenger() { Name = "Ant-Man", Gender = false, SuperPower = false, Strength = 9 },
                new Avenger() { Name = "Vision", Gender = false, SuperPower = true, Strength = 17 },
                new Avenger() { Name = "Iron Man", Gender = false, SuperPower = false, Strength = 16 }
            });

            avengerController = new AvengerController(mockRepo.Object);
        }

        [Test]
        public void Test_SelectAvengersByGender()
        {
            List<Avenger> listFalse = avengerController.SelectAvengersByGender(false); // men
            List<Avenger> listTrue = avengerController.SelectAvengersByGender(true); // women

            Assert.That(listFalse.Count == 6 && listTrue.Count == 2);
        }

        [Test]
        public void Test_SelectAvengerByIndex()
        {
            Avenger ave1 = avengerController.SelectAvengerByIndex(0);
            Avenger ave2 = avengerController.SelectAvengerByIndex(1);

            Assert.That(ave1.Name == "Captain America");
            Assert.That(ave1.SuperPower == true);

            Assert.That(ave2.Name == "Thor");
            Assert.That(ave2.Gender == false);
        }

        [Test]
        public void Test_SelectAvengersByIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => avengerController.SelectAvengerByIndex(200));

            Assert.DoesNotThrow(() => avengerController.SelectAvengerByIndex(2));
        }

        [Test]
        public void Test_GetStrongestAvenger()
        {
            Avenger item = avengerController.GetStrongestAvenger();

            Assert.That(item.Name == "Thor");
        }

        [Test]
        public void Test_AvengersAssemble()
        {
            foreach (Avenger avenger in avengerController.AvengersAssemble())
            {
                Assert.IsTrue(avenger.SuperPower);
            }
        }

        [Test]
        public void Test_GetStrongestAvengers()
        {
            List<Avenger> avs = avengerController.GetStrongestAvengers(3);

            // 20, 18, 17
            // Thor, Scarlet, Vision

            Assert.That(avs[0].Name == "Thor");
            Assert.That(avs[1].Name == "Scarlet Witch");
            Assert.That(avs[2].Name == "Vision");
        }

    }
}
