using BlogSystem.Data;
using BlogSystem.Data.Models;
using BlogSystem.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSystem.Tests
{
    [TestFixture]
    public class BlogLogicTests
    {
        // NuGets below needed to be installed:
        //      nunit 3
        //      nunit 3 testadapter
        //      microsoft testing sdk

        private BlogLogic blogLogic { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            FakeBlogRepository fbr = new FakeBlogRepository();
            FakeCommentRepository fcr = new FakeCommentRepository();

            this.blogLogic = new BlogLogic(fbr, fcr);
        }


        [Test]
        public void CommentPerCategory_IsCalculatedCorrectly_1()
        {
            // ARRANGE --> moved to [OneTimeSetup] method

            // ACT
            IEnumerable<CommentNumberPerCategory> x = this.blogLogic
                .GetCommentNumberPerCategory()
                .OrderByDescending(x => x.CommentCount);

            // ASSERT
            Assert.That(x.First().Category, Is.EqualTo("Design"));
            Assert.That(x.First().CommentCount, Is.EqualTo(7));

        }

        [Test]
        public void CommentPerCategory_IsCalculatedCorrectly_2()
        {
            // ARRANGE --> moved to [OneTimeSetup] method

            // ACT
            IEnumerable<CommentNumberPerCategory> x = this.blogLogic
                .GetCommentNumberPerCategory()
                .OrderBy(x => x.CommentCount);

            // ASSERT
            Assert.That(x.First().Category, Is.EqualTo("Frontend"));
            Assert.That(x.First().CommentCount, Is.EqualTo(1));

        }

        [TestCase(1, "something ALMA")]
        [TestCase(1, "ALMA something")]
        [TestCase(1, "something ALMA something")]
        public void ChangeBlogTitle_ThrowsException_IfContainsForbiddenWords(int index, string input)
        {
            Assert.That(() => blogLogic.ChangeBlogTitle(index, input), Throws.TypeOf<Exception>());
        }


        [TestCase(1, "something x")]
        [TestCase(1, "x something")]
        [TestCase(1, "something x something")]
        public void ChangeBlogTitle_DoesNotThrowException_IfDoesNotContainForbiddenWords(int index, string input)
        {
            Assert.That(() => blogLogic.ChangeBlogTitle(index, input), Throws.Nothing);

            // Check error log! Problem: we have a FAKE with missing functionality!
            //
            // Expected: No Exception to be thrown
            // But was:  < System.NotImplementedException:
            //
            // So when we have blogLogic method call, the exception is thrown --> OK.
            // But when we should not have exception, it means that blogLogic would call the repo's method, which is not implemented!
            //

        }


        [TestCase(1, "")]
        [TestCase(2, null)]
        [TestCase(3, "")]
        public void ChangeBlogTitle_ThrowsException_IfTitleIsEmptyOrNull(int index, string input)
        {
            Assert.That(() => blogLogic.ChangeBlogTitle(index, input), Throws.TypeOf<Exception>());
            
            // exception type should be specified, after creating custom-made descendant class!
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void GetBlogById_ThrowsException_IfIndexIsTooBig(int index)
        {
            Assert.That(() => blogLogic.GetBlogById(index), Throws.TypeOf<IndexOutOfRangeException>());
        }
    }
}
