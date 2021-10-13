using BlogSystem.Data;
using BlogSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests
{
    public class FakeCommentRepository : ICommentRepository
    {
        public IQueryable<Comment> GetAll()
        {
            Blog b0 = new Blog() { BlogId = 1, Category = "Nature", LikesCount = 43, Title = "#1 Nature Article", Tags = "sport, education", HasLink = false, HasImage = false };
            Blog b1 = new Blog() { BlogId = 2, Category = "Nature", LikesCount = 30, Title = "#2 IT life in the nature", Tags = "IT, education", HasLink = null, HasImage = null };
            Blog b2 = new Blog() { BlogId = 3, Category = "Design", LikesCount = 120, Title = "#3 Science of Design", Tags = "programming, csharp", HasLink = true, HasImage = false };
            Blog b3 = new Blog() { BlogId = 4, Category = "Design", LikesCount = null, Title = "#4 Designing a PWA", Tags = "cuda, nvidia, core", HasLink = false, HasImage = false };
            Blog b4 = new Blog() { BlogId = 5, Category = "Frontend", LikesCount = 300, Title = "#5 Frontend Architecture", Tags = "vue, angular", HasLink = true, HasImage = true };

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

            // -------------------------------------------------------------------------------------------------------

            c0.BlogId = b0.BlogId;
            c1.BlogId = b1.BlogId;

            c2.BlogId = b2.BlogId;
            c3.BlogId = b2.BlogId;
            c4.BlogId = b2.BlogId;
            c5.BlogId = b2.BlogId;
            c6.BlogId = b2.BlogId;

            c7.BlogId = b3.BlogId;
            c8.BlogId = b3.BlogId;

            c9.BlogId = b4.BlogId;

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

        public Comment GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }
    }
}
