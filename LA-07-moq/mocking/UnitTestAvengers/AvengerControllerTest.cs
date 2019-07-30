using System;
using System.Collections.Generic;

// ms built in unit testing
// [TestClass], [TestMethod]
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestAvengerInsertion()
        {
            // itt jön a probléma: kellene repo is hozzá... >> mockolunk egyet
            //var avengerController = new AvengerController( [REPO_REF_IDE] );


            // ARRANGE
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            {
                new Avenger() { Name = "Captain America", Gender = false, SuperPower = true },
                new Avenger() { Name = "Thor", Gender = false, SuperPower = true }
            });
            // látható, hogy ez nem az a "repo tartalom" amit korábban megírtunk az osztályban
            // hanem csak egy kamu, ami tesztelésre alkalmas

            var avengerController = new AvengerController(mockRepo.Object);



            // ACT
            avengerController.AddAvenger(new Avenger()
            {
                Name = "Test Avenger"
            });


            // ASSERT
            mockRepo.Verify(x => x.AddAvenger(It.IsAny<Avenger>()));
        }



        [Test]
        public void TestAvengerInsertion_WrongOutput()
        {
            // itt jön a probléma: kellene repo is hozzá... >> mockolunk egyet
            //var avengerController = new AvengerController( [REPO_REF_IDE] );


            // ARRANGE
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(x => x.GetAvengers()).Returns(new List<Avenger>()
            {
                new Avenger() { Name = "Captain America", Gender = false, SuperPower = true },
                new Avenger() { Name = "Thor", Gender = false, SuperPower = true }
            });
            // látható, hogy ez nem az a "repo tartalom" amit korábban megírtunk az osztályban
            // hanem csak egy kamu, ami tesztelésre alkalmas

            var avengerController = new AvengerController(mockRepo.Object);



            // ACT
            avengerController.AddAvengerROSSZ(new Avenger()
            {
                Name = "Teszt Tony"
            });


            // ASSERT
            mockRepo.Verify(x => x.AddAvenger(It.IsAny<Avenger>()));
        }
    }
}
