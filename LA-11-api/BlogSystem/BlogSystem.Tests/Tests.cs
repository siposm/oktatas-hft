using BlogSystem.Data;
using BlogSystem.Logic;
using BlogSystem.Repository;
using Moq;
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
        //      moq

        private BlogLogic BlogLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IBlogRepository> mockedBlogRepo = new Mock<IBlogRepository>();
            Mock<ICommentRepository> mockedCommentRepo = new Mock<ICommentRepository>();

            mockedBlogRepo.Setup(x => x.GetOne(It.IsAny<int>())).Returns(
                new Blog()
                {
                    BlogId = 5,
                    Category = "Frontend",
                    LikesCount = 300,
                    Title = "#5 Frontend Architecture",
                    Tags = "vue, angular",
                    HasLink = true,
                    HasImage = true
                });

            mockedBlogRepo.Setup(x => x.GetAll()).Returns(this.FakeBlogObjects);
            mockedCommentRepo.Setup(x => x.GetAll()).Returns(this.FakeCommentObjects);

            this.BlogLogic = new BlogLogic(mockedBlogRepo.Object, mockedCommentRepo.Object);
        }

        [Test]
        public void GetOneBlog_ReturnsCorrectInstance()
        {
            var blogItem = this.BlogLogic.GetBlogById(1);

            Assert.That(blogItem.Category, Is.EqualTo("Frontend"));
        }

        [Test]
        public void GetAllBlogs_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.BlogLogic.GetAllBlogs().Count, Is.EqualTo(5));
        }

        [Test]
        public void AverageLikesCount_ReturnsCorrectValue()
        {
            Assert.That(this.BlogLogic.AverageLikesCount(), Is.EqualTo(123.25));
        }

        [Test]
        public void GetLeastUsedCategory_ReturnsCorrectValue()
        {
            Assert.That(this.BlogLogic.GetLeastUsedCategory().Category, Is.EqualTo("Frontend"));
            Assert.That(this.BlogLogic.GetLeastUsedCategory().Count, Is.EqualTo(1));
        }

        [TestCase(1, "something ALMA")]
        [TestCase(1, "ALMA something")]
        [TestCase(1, "something ALMA something")]
        public void ChangeBlogTitle_ThrowsException_IfContainsForbiddenWords(int index, string input)
        {
            Assert.That(() => this.BlogLogic.ChangeBlogTitle(index, input), Throws.TypeOf<Exception>());
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void GetBlogById_ThrowsException_IfIndexIsTooBig(int index)
        {
            Assert.That(() => this.BlogLogic.GetBlogById(index), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [TestCase(1, "something x")]
        [TestCase(1, "x something")]
        [TestCase(1, "something x something")]
        public void ChangeBlogTitle_DoesNotThrowException_IfDoesNotContainForbiddenWords(int index, string input)
        {
            Assert.That(() => this.BlogLogic.ChangeBlogTitle(index, input), Throws.Nothing);

            // using fakes we had problem here, because it lacked implementation for the ChangeBlogTitle method!
        }

        [Test]
        public void GetBlogsWithRudeComments_ReturnsCorrectBlogInstance()
        {
            Assert.That(this.BlogLogic.GetBlogsWithRudeComments().First().BlogId, Is.EqualTo(4));
        }








        private IQueryable<Comment> FakeCommentObjects()
        {
            Blog b0 = new Blog() { BlogId = 1, Category = "Nature", LikesCount = 43, Title = "#1 Nature Article", Tags = "sport, education", HasLink = false, HasImage = false };
            Blog b1 = new Blog() { BlogId = 2, Category = "Nature", LikesCount = 30, Title = "#2 IT life in the nature", Tags = "IT, education", HasLink = null, HasImage = null };
            Blog b2 = new Blog() { BlogId = 3, Category = "Design", LikesCount = 120, Title = "#3 Science of Design", Tags = "programming, csharp", HasLink = true, HasImage = false };
            Blog b3 = new Blog() { BlogId = 4, Category = "Design", LikesCount = null, Title = "#4 Designing a PWA", Tags = "cuda, nvidia, core", HasLink = false, HasImage = false };
            Blog b4 = new Blog() { BlogId = 5, Category = "Frontend", LikesCount = 300, Title = "#5 Frontend Architecture", Tags = "vue, angular", HasLink = true, HasImage = true };

            b0.Comments = new List<Comment>();
            b1.Comments = new List<Comment>();
            b2.Comments = new List<Comment>();
            b3.Comments = new List<Comment>();
            b4.Comments = new List<Comment>();

            // -------------------------------------------------------------------------------------------------------

            Comment c0 = new Comment() { CommentId = 1, Content = "Some words were incorrect." };
            Comment c1 = new Comment() { CommentId = 2, Content = "Lorem ipsum dolor sit amet." };
            Comment c2 = new Comment() { CommentId = 3, Content = "Great article, loved it!" };
            Comment c3 = new Comment() { CommentId = 4, Content = "Fantastic reading." };
            Comment c4 = new Comment() { CommentId = 5, Content = "Thanks for sharing this stuff!" };
            Comment c5 = new Comment() { CommentId = 6, Content = "Waste of tiiiiiiiiiiiime...." };
            Comment c6 = new Comment() { CommentId = 7, Content = "Lorem ipsum." };
            Comment c7 = new Comment() { CommentId = 8, Content = "Dolor sit amet." };
            Comment c8 = new Comment() { CommentId = 9, Content = "This is pure SH!T." };
            Comment c9 = new Comment() { CommentId = 10, Content = "Good words used here!" };

            c0.Blog = b0;
            c1.Blog = b1;

            c2.Blog = b2;
            c3.Blog = b2;
            c4.Blog = b2;
            c5.Blog = b2;
            c6.Blog = b2;

            c7.Blog = b3;
            c8.Blog = b3;

            c9.Blog = b4;

            // -------------------------------------------------------------------------------------------------------

            c0.BlogId = b0.BlogId; b0.Comments.Add(c0);
            c1.BlogId = b1.BlogId; b1.Comments.Add(c1);

            c2.BlogId = b2.BlogId; b2.Comments.Add(c2);
            c3.BlogId = b2.BlogId; b2.Comments.Add(c3);
            c4.BlogId = b2.BlogId; b2.Comments.Add(c4);
            c5.BlogId = b2.BlogId; b2.Comments.Add(c5);
            c6.BlogId = b2.BlogId; b2.Comments.Add(c6);

            c7.BlogId = b3.BlogId; b3.Comments.Add(c7);
            c8.BlogId = b3.BlogId; b3.Comments.Add(c8);

            c9.BlogId = b4.BlogId; b4.Comments.Add(c9);

            // -------------------------------------------------------------------------------------------------------

            List<Comment> items = new List<Comment>();

            items.Add(c0);
            items.Add(c1);
            items.Add(c2);
            items.Add(c3);
            items.Add(c4);
            items.Add(c5);
            items.Add(c6);
            items.Add(c7);
            items.Add(c8);
            items.Add(c9);

            return items.AsQueryable();
        }
        private IQueryable<Blog> FakeBlogObjects()
        {
            Blog b0 = new Blog() { BlogId = 1, Category = "Nature", LikesCount = 43, Title = "#1 Nature Article", Tags = "sport, education", HasLink = false, HasImage = false };
            Blog b1 = new Blog() { BlogId = 2, Category = "Nature", LikesCount = 30, Title = "#2 IT life in the nature", Tags = "IT, education", HasLink = null, HasImage = null };
            Blog b2 = new Blog() { BlogId = 3, Category = "Design", LikesCount = 120, Title = "#3 Science of Design", Tags = "programming, csharp", HasLink = true, HasImage = false };
            Blog b3 = new Blog() { BlogId = 4, Category = "Design", LikesCount = null, Title = "#4 Designing a PWA", Tags = "cuda, nvidia, core", HasLink = false, HasImage = false };
            Blog b4 = new Blog() { BlogId = 5, Category = "Frontend", LikesCount = 300, Title = "#5 Frontend Architecture", Tags = "vue, angular", HasLink = true, HasImage = true };

            b0.Comments = new List<Comment>();
            b1.Comments = new List<Comment>();
            b2.Comments = new List<Comment>();
            b3.Comments = new List<Comment>();
            b4.Comments = new List<Comment>();

            // -------------------------------------------------------------------------------------------------------

            Comment c0 = new Comment() { CommentId = 1, Content = "Some words were incorrect." };
            Comment c1 = new Comment() { CommentId = 2, Content = "Lorem ipsum dolor sit amet." };
            Comment c2 = new Comment() { CommentId = 3, Content = "Great article, loved it!" };
            Comment c3 = new Comment() { CommentId = 4, Content = "Fantastic reading." };
            Comment c4 = new Comment() { CommentId = 5, Content = "Thanks for sharing this stuff!" };
            Comment c5 = new Comment() { CommentId = 6, Content = "Waste of tiiiiiiiiiiiime...." };
            Comment c6 = new Comment() { CommentId = 7, Content = "Lorem ipsum." };
            Comment c7 = new Comment() { CommentId = 8, Content = "Dolor sit amet." };
            Comment c8 = new Comment() { CommentId = 9, Content = "This is pure SH!T." };
            Comment c9 = new Comment() { CommentId = 10, Content = "Good words used here!" };

            c0.Blog = b0;
            c1.Blog = b1;

            c2.Blog = b2;
            c3.Blog = b2;
            c4.Blog = b2;
            c5.Blog = b2;
            c6.Blog = b2;

            c7.Blog = b3;
            c8.Blog = b3;

            c9.Blog = b4;

            // -------------------------------------------------------------------------------------------------------

            c0.BlogId = b0.BlogId; b0.Comments.Add(c0);
            c1.BlogId = b1.BlogId; b1.Comments.Add(c1);

            c2.BlogId = b2.BlogId; b2.Comments.Add(c2);
            c3.BlogId = b2.BlogId; b2.Comments.Add(c3);
            c4.BlogId = b2.BlogId; b2.Comments.Add(c4);
            c5.BlogId = b2.BlogId; b2.Comments.Add(c5);
            c6.BlogId = b2.BlogId; b2.Comments.Add(c6);

            c7.BlogId = b3.BlogId; b3.Comments.Add(c7);
            c8.BlogId = b3.BlogId; b3.Comments.Add(c8);

            c9.BlogId = b4.BlogId; b4.Comments.Add(c9);

            // -------------------------------------------------------------------------------------------------------

            List<Blog> items = new List<Blog>();

            items.Add(b0);
            items.Add(b1);
            items.Add(b2);
            items.Add(b3);
            items.Add(b4);

            return items.AsQueryable();
        }
    }
}
