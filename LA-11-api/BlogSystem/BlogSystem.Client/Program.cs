using BlogSystem.Data;
using BlogSystem.Data.Models;
//using blogsystem.logic;
//using blogsystem.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            // HUNGARIAN
            /* Vastagkliens módszerrel lepéldányosítunk mindent
             * 
             * Helyette: a kliensünk egy frontend alkalmazás szerepét veszi fel
             * és az API réteggel fog kommunikálni
             *
             * Ehhez a kliens csak a Models réteget ismeri majd, mást nem.
             * Ezt ideálisabb lenne egy külön projectként hozzáadni, de nekünk már maradt a Data rétegben, így az van hozzáadva.
             */

            // ENGLISH
            /*
             * As a so-called thick client we have access to all the layers here and create objects here.
             * 
             * Instead: our client will be a frontend application and will communicate with the API layer.
             * 
             * For that the client should only know about the Models, nothing else.
             * It would be more ideal if Models were created here as a separate project, not being part of the Data layer, but for now it is ok like that.
             */



            Thread.Sleep(8000); // endpoint needs more time to start, we must wait for that

            RestService rserv = new RestService("http://localhost:42773"); // from launchSettings.json

            rserv.Post<Blog>(new Blog()
            {
                Title = "--MY-SECOND-NEW-BLOG--"
            }, "blog");

            var blogs = rserv.Get<Blog>("blog");

            var x = rserv.GetSingle<CategoryAndCount>("stat/GetLeastUsedCategory");

            ;







            #region ThickClientApproach
            //BlogContext blogCtx = new BlogContext();
            //BlogRepository blogRepo = new BlogRepository(blogCtx);

            //CommentRepository commentRepo = new CommentRepository(blogCtx);
            //CommentLogic commentLogic = new CommentLogic(commentRepo); 

            //BlogLogic blogLogic = new BlogLogic(blogRepo, commentRepo);



            //ListAll(blogLogic);

            //ListAll(commentLogic);

            //GetCommentNumberPerCategory(blogLogic);
            #endregion

        }
        #region ThickClientApproach
        //private static void ListAll(BlogLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL BLOGS ::\n");

        //    logic.GetAllBlogs()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x.MainData));
        //}

        //private static void ListAll(CommentLogic logic)
        //{
        //    Console.WriteLine("\n:: ALL COMMENTS ::\n");

        //    logic.GetAllComments()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x));
        //}

        //private static void GetCommentNumberPerCategory(BlogLogic logic)
        //{
        //    logic.GetCommentNumberPerCategory()
        //        .ToProcess("COMMENT COUNT PER CATEGORY");
        //}
        #endregion
    }
}
