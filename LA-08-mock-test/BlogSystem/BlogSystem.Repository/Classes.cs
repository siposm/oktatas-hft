using BlogSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>(); // set => halmaz; != beállítás
        }

        public abstract T GetOne(int id);
    }

    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext ctx) : base(ctx) { /* ... */ }

        public void ChangeTitle(int id, string newTitle)
        {
            var blog = GetOne(id);
            blog.Title = newTitle;
            ctx.SaveChanges();
        }

        public override Blog GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.BlogId == id);
        }
    }

    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext ctx) : base(ctx) { }

        public override Comment GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CommentId == id);
        }

        public void UpdateContent(int id, string newContent)
        {
            var comment = GetOne(id);
            comment.Content = newContent;
            ctx.SaveChanges();
        }
    }
}
