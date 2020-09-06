using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace code_first_example
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; } // lazy loading
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; } // lazy loading
    }   

    // ------------------------------------------------------------

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    // ------------------------------------------------------------

    class Program
    {
        // [src1] https://www.entityframeworktutorial.net/code-first/simple-code-first-example.aspx
        // [src2] https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

        static void Main(string[] args)
        {
            BloggingContext db = new BloggingContext();
            db.Blogs.Add(new Blog() { BlogId = 0, Name = "Test Blog" });
            db.SaveChanges();

            var q = from x in db.Blogs
                    orderby x.Name
                    select x;

            Console.WriteLine("> FULL DATABASE:");
            foreach (var item in q)
                Console.WriteLine("\t> " + item.Name);
        }
    }
}
