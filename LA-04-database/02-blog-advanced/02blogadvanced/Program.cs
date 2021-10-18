using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02blogadvanced
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        
        [MaxLength(120)]
        public string Content { get; set; }

        [NotMapped]
        public virtual Blog Blog { get; set; }

        [ForeignKey(nameof(Blog))]
        public int BlogId { get; set; }
    }

    [Table("Blogs")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [NotMapped]
        public string AllData => $"[{BlogId}] : {Title} : {Category} (likes: {LikesCount}) (comments: {Comments.Count()})";

        public int? LikesCount { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Blog()
        {
            Comments = new HashSet<Comment>();
        }
    }

    public class BlogContext : DbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public BlogContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BlogDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration

            // fluent api
            modelBuilder.Entity<Comment>(entity =>
            {
               entity.HasOne(comment => comment.Blog)
                   .WithMany(blog => blog.Comments)
                   .HasForeignKey(comment => comment.BlogId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region INIT
            BlogContext db = new BlogContext();

            Blog b1 = new Blog() { Category = "Nature", LikesCount = 43, Title = "#1 Nature Article" };
            b1.Comments.Add(new Comment() { Content = "Lorem ipsum dolor sit amet." });

            Blog b2 = new Blog() { Category = "Nature", LikesCount = 30, Title = "#2 IT life in the nature" };
            b2.Comments.Add(new Comment() { Content = "Great article, loved it!" });

            Blog b3 = new Blog() { Category = "Design", LikesCount = 120, Title = "#3 Science of Design" };
            b3.Comments.Add(new Comment() { Content = "Fantastic reading." });
            b3.Comments.Add(new Comment() { Content = "Thanks for sharing this stuff!" });
            b3.Comments.Add(new Comment() { Content = "Waste of tiiiiiiiiiiiime...." });
            b3.Comments.Add(new Comment() { Content = "Lorem ipsum." });
            b3.Comments.Add(new Comment() { Content = "Dolor sit amet." });

            Blog b4 = new Blog() { Category = "Design", LikesCount = null, Title = "#4 Designing a PWA" };
            b4.Comments.Add(new Comment() { Content = "This is pure SH!T." });
            b4.Comments.Add(new Comment() { Content = "Good words used here!" });

            Blog b5 = new Blog() { Category = "Architecture", LikesCount = 300, Title = "#5 Architecture on Mars" };
            b5.Comments.Add(new Comment() { Content = "Some words were incorrect." });

            db.Blogs.Add(b1);
            db.Blogs.Add(b2);
            db.Blogs.Add(b3);
            db.Blogs.Add(b4);
            db.Blogs.Add(b5);

            db.SaveChanges();
            #endregion

            // 1. listázzuk ki az összes bejegyzést
            // 1. list all blog posts
            Console.WriteLine("\n:: ALL RECORDS ::\n");
            db.Blogs
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.AllData}"));

            // 2. hány olyan blogbejegyzés van, melyre 120-nál kevesebb like érkezett
            // 2. how many blogs are where there is less likes than 120
            var q2 = db.Blogs.Where(x => x.LikesCount < 120).Count();
            Console.WriteLine("\n:: BLOG NO. WITH < 120 COMMENTS ::\n");
            Console.WriteLine("\t" + q2);

            // 3. mennyi a like-ok átlagos száma kategóriánként
            // 3. what is the average of the likes for every category
            var q3 = from x in db.Blogs
                     group x by x.Category into g
                     select new
                     {
                         CATEG = g.Key,
                         AVG_LIKES = g.Average(a => (a.LikesCount == null) ? 0 : a.LikesCount)
                     };
            
            q3.ToProcess("LIKES AVG PER GROUP");

            // 4. határozzuk meg a legtöbb kommentet kapott bejegyzést
            // 4. determine which one is the most commented blog
            var q4 = (from x in db.Blogs
                      orderby x.Comments.Count() descending
                      select new
                      {
                          TITLE = x.Title,
                          COMM_NO = x.Comments.Count()
                      }).FirstOrDefault();

            Console.WriteLine("\n:: BLOG WITH THE MOST COMMENTS :: \n");
            Console.WriteLine("\t" + q4);

            // 5. szűrjük ki a csúnya szóval rendelkező blogbejegyzést (név és id)
            // 5. filter the blogs where bad word is used (name and id)
            var rudeWordedComment = (from x in db.Comments
                                     where x.Content.Contains("SH!T")
                                     select x).SingleOrDefault();

            var q5 = from x in db.Blogs
                     where x.BlogId.Equals(rudeWordedComment.BlogId)
                     select new
                     {
                         TITLE = x.Title,
                         BLOGID = x.BlogId
                     };
            q5.ToProcess("BLOG WITH RUDE WORD");

            // 6. melyek azok a blogbejegyzések, amelyeknél a kommentszám kevesebb mint a legtöbb kommentszám
            // 6. get all blogs where the like number is less than the most comment number
            var maxCommNo = db.Blogs
                .OrderByDescending(x => x.Comments.Count())
                .FirstOrDefault().Comments.Count();

            var q7 = from x in db.Blogs
                     where x.Comments.Count() < maxCommNo
                     select new
                     {
                         TITLE = x.Title,
                         ID = x.BlogId,
                         COMM_NO = x.Comments.Count()
                     };

            q7.ToProcess("SPECIAL COMMENTS NUMBER");

            // X. kategóriánként hány komment érkezett
            // X. how many comments arrived for each category
            // [ special thanks to SzaboZs :) ]
            // 
            // Először próbáljátok meg Method Syntax-szal, utána Query Syntax-szal.
            // Firstly try with method syntax then with query syntax.
            //
            var qx_sub = from x in db.Comments
                         group x by x.BlogId into g
                         select new
                         {
                             BLOG_ID = g.Key,
                             COMM_NO = g.Count()
                         };
            var qx = from x in db.Blogs
                     join z in qx_sub on x.BlogId equals z.BLOG_ID
                     let joinedItem = new { x.BlogId, x.Category, z.COMM_NO }
                     group joinedItem by joinedItem.Category into grp
                     select new
                     {
                         Category = grp.Key,
                         Sum = grp.Sum(x => x.COMM_NO)
                     };

            qx.ToProcess("COMMENTS NO. PER GROUP");

            // DB purge v2
            //foreach (var item in db.Comments) db.Comments.Remove(item);
            //foreach (var item in db.Blogs) db.Blogs.Remove(item);
            //db.SaveChanges();
        }
    }

    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            foreach (var item in query)
                Console.WriteLine("\t" + item);

            Console.WriteLine("\n\n");
        }
    }
}
