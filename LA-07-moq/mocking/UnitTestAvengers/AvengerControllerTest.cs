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
    [TestFixture]
    public class AvengerControllerTest
    {


        [Test]
        public void Test_SelectAvengersByGender()
        {
            //var avengerController = new AvengerController( [REPO_REF_IDE] );
            // itt jön a probléma: kellene repo is hozzá... >> mockolunk egyet

            // kiszervezhetők [SetUp]-ba a fix dolgok (pl. repo inicializálás)
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            {
                new Avenger() { Name = "Captain America", Gender = false, SuperPower = true },
                new Avenger() { Name = "Thor", Gender = false, SuperPower = true }
            });
            // látható, hogy ez nem az a "repo tartalom" amit korábban megírtunk az osztályban
            // hanem csak egy demo, ami tesztelésre alkalmas

            var avengerController = new AvengerController(mockRepo.Object);

            List<Avenger> listFalse = avengerController.SelectAvengersByGender(false);
            List<Avenger> listTrue = avengerController.SelectAvengersByGender(true);

            Assert.That(listFalse.Count == 2 && listTrue.Count == 0);
        }

        [Test]
        public void Test_AddAvenger()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.AddAvenger(
                new Avenger() { Name = "Teszt Tony" })).
                Returns(0);
            
            var avengerController = new AvengerController(mockRepo.Object);

            // ACT
            int index = avengerController.AddAvenger(new Avenger()
            {
                Name = "Test Avenger"
            });

            
            //ASSERT
            Assert.AreEqual(index, 0);
            //Assert.AreEqual(index, 1); // expected: 0, but was: 1


            // ennek van-e értelme itt?
            Assert.AreEqual(avengerController.GetAvengers()[0].Name, "Teszt Tony");
            Assert.AreEqual(avengerController.GetAvengers()[0].Name, "Test Avenger");
            
            
            
            // ezzel mi legyen?
            //mockRepo.Verify(x => x.AddAvenger(It.IsAny<Avenger>()));
        }

        [Test]
        public void Test_AddAvenger_Wrongly()
        {
            // itt jön a probléma: kellene repo is hozzá... >> mockolunk egyet
            //var avengerController = new AvengerController( [REPO_REF_IDE] );


            // ARRANGE
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            {
                // alapból úgy teszünk, mintha üres lenne a DB
                //new Avenger() { Name = "Captain America", Gender = false, SuperPower = true },
                //new Avenger() { Name = "Thor", Gender = false, SuperPower = true }
            });
            
            var avengerController = new AvengerController(mockRepo.Object);
            List<Avenger> loadedRepo = avengerController.GetAvengers(); // csak a fent mock-oltak lesznek benne ami most üres


            // ACT
            // avengerController.AddAvengerROSSZ(new Avenger() // ezzel szándékosan hibára fut!
            avengerController.AddAvenger(new Avenger()
            {
                Name = "Teszt Tony"
            });


            // ASSERT
            mockRepo.Verify(x => x.AddAvenger(It.IsAny<Avenger>()));
        }

        [Test]
        public void Test_AvengerSelect()
        {
            //Mock<IRepository> mockRepo = new Mock<IRepository>();

            //mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            //{
            //    new Avenger() { Name = "Captain America", Gender = false, SuperPower = true },
            //    new Avenger() { Name = "Thor", Gender = false, SuperPower = true }
            //});

            //var avengerController = new AvengerController(mockRepo.Object);

            //// ACT
            //Avenger item = avengerController.SelectAvengerByIndex(1);
            //;
            //// ASSERT
            //Assert.That(item.Name == "Captain America");
        }
    }
}
