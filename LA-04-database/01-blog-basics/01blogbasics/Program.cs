using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01blogbasics
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
    }

    public class BlogContext : DbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }

        public BlogContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BlogDatabase.mdf;Integrated Security=True");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BlogContext db = new BlogContext();

            db.Blogs.Add(new Blog() { Title = "Ax1" });
            db.Blogs.Add(new Blog() { Title = "A2" });
            db.Blogs.Add(new Blog() { Title = "A3" });

            db.SaveChanges();

            // 1. read all
            foreach (var item in db.Blogs)
                Console.WriteLine($"{item.BlogId} - {item.Title}");

            // 2. add new item -- CREATE
            db.Blogs.Add(new Blog() { Title = "NEW" });
            db.SaveChanges();
            // -- READ
            var q = db.Blogs.OrderByDescending(x => x.BlogId).FirstOrDefault();
            Console.WriteLine("\nNEW BLOG TITLE: " + q.Title);

            // 3. modify existing item -- UPDATE
            var q1 = db.Blogs.OrderByDescending(x => x.BlogId).FirstOrDefault();
            q1.Title = "__NEW__";
            db.SaveChanges();
            var q2 = db.Blogs.OrderByDescending(x => x.BlogId).FirstOrDefault();
            Console.WriteLine("\nNEW BLOG TITLE v2: " + q2.Title);

            // 4. delete existing item -- DELETE
            var toDel = db.Blogs.FirstOrDefault(x => x.Title.Contains("x"));
            db.Blogs.Remove(toDel);
            db.SaveChanges();

            Console.WriteLine("\nAFTER DELETE: ");
            db.Blogs
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.BlogId} - {x.Title}"));

            // 5. purge database -- PURGE
            db.Blogs.RemoveRange(db.Blogs);
            db.SaveChanges();

            Console.WriteLine("\nAFTER PURGE: ");
            db.Blogs
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.BlogId} - {x.Title}"));
        }
    }
}
