using NUnit.Framework;
using System;

namespace BlogSystem.Tests
{
    [TestFixture]
    public class BlogLogicTests
    {
        // NuGets below needed to be installed:
        //      nunit 3
        //      nunit 3 testadapter
        //      microsoft testing sdk

        [Test]
        public void Test1()
        {
            Assert.That(true, Is.True);
        }
    }
}
