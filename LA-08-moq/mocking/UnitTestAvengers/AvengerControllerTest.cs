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

        // moq-olásnál nem a repót tesztelem, hanem a controllert (ahol a business logic van)
        // tehát a bonyolultabb algoritmusokat! CRUD műveleteket szinte sosem...


        Mock<IRepository> mockRepo;
        AvengerController avengerController;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            {
                new Avenger() { Name = "Captain America", Gender = false, Superpower = true, Strength = 2 },
                new Avenger() { Name = "Thor", Gender = false, Superpower = true, Strength = 20 },
                new Avenger() { Name = "Black Widow", Gender = true, Superpower = false, Strength = 5 },
                new Avenger() { Name = "Scarlet Witch", Gender = true, Superpower = true, Strength = 18 },
                new Avenger() { Name = "Spider-Man", Gender = false, Superpower = true, Strength = 13 },
                new Avenger() { Name = "Ant-Man", Gender = false, Superpower = false, Strength = 9 },
                new Avenger() { Name = "Vision", Gender = false, Superpower = true, Strength = 17 },
                new Avenger() { Name = "Iron Man", Gender = false, Superpower = false, Strength = 16 }
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

            Assert.NotNull(ave1);

            Assert.That(ave1.Name == "Captain America");
            Assert.That(ave1.Superpower == true);

            Assert.That(ave2.Name == "Thor");
            Assert.That(ave2.Gender == false);

            
            // referenciás érdekesség
            Avenger thor = new Avenger() { Name = "Thor", Gender = false, Superpower = true, Strength = 20 };
            Assert.AreNotSame(ave2, thor);
            thor = ave2;
            Assert.AreSame(ave2, thor);
        }

        [Test]
        public void Test_SelectAvengersByIndexException()
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
                Assert.IsTrue(avenger.Superpower);
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

        [Test]
        public void Test_SelectAvengerByIndex_Verify()
        {
            avengerController.SelectAvengerByIndex(2);

            mockRepo.Verify(x => x.GetAvengers(), Times.Exactly(2));
        }

        [Test]
        public void Test_AddAvenger_Verify()
        {
            // egy metódust meghívva konkrét értékkel tesztelésként (AddAvenger a controllerben)
            // ami tovább hívja a repo AddAvenger metódusát (bármilyen értékkel)?

            avengerController.AddAvenger(new Avenger() { Name = "Test Tony" });

            // repo AddAvenger metódusa!
            mockRepo.Verify(x => x.AddAvenger(It.IsAny<Avenger>()), Times.Once());
        }

        [Test]
        public void Test_CountRecursiveForExactNumber()
        {
            int number = 10;
            avengerController.GetRecursiveMethod(number);
            mockRepo.Verify( x => x.GetRecursivelySomething(), Times.Exactly(number) );
        }

        [Test]
        public void Test_CountRecursiveForBetweenValues()
        {
            int min = 10;
            int max = 21;
            int number = new Random().Next(min, max);
            avengerController.GetRecursiveMethod(number);
            mockRepo.Verify(x => x.GetRecursivelySomething(), Times.Between(min, max, Range.Inclusive));
        }
    }
}
