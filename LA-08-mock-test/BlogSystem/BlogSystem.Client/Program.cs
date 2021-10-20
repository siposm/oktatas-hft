using BlogSystem.Data;
using BlogSystem.Logic;
using BlogSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSystem.Client
{
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

    class Program
    {
        static void Main(string[] args)
        {
            BlogContext blogCtx = new BlogContext();
            BlogRepository blogRepo = new BlogRepository(blogCtx);
            
            CommentRepository commentRepo = new CommentRepository(blogCtx);
            CommentLogic commentLogic = new CommentLogic(commentRepo); 
            
            BlogLogic blogLogic = new BlogLogic(blogRepo, commentRepo);

            

            ListAll(blogLogic);

            ListAll(commentLogic);

            GetCommentNumberPerCategory(blogLogic);

        }

        private static void ListAll(BlogLogic logic)
        {
            Console.WriteLine("\n:: ALL BLOGS ::\n");

            logic.GetAllBlogs()
                .ToList()
                .ForEach(x => Console.WriteLine("\t" + x.MainData));
        }

        private static void ListAll(CommentLogic logic)
        {
            Console.WriteLine("\n:: ALL COMMENTS ::\n");

            logic.GetAllComments()
                .ToList()
                .ForEach(x => Console.WriteLine("\t" + x));
        }

        private static void GetCommentNumberPerCategory(BlogLogic logic)
        {
            logic.GetCommentNumberPerCategory()
                .ToProcess("COMMENT COUNT PER CATEGORY");
        }
    }
}
