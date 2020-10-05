using Blogging.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blogging.Repository
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
}
