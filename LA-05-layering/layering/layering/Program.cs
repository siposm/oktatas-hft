using Blogging.Data;
using Blogging.Logic;
using Blogging.Repository;
using ConsoleTools;
using System;
using System.Linq;

namespace layering
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogContext ctx = new BlogContext();
            BlogRepository repo = new BlogRepository(ctx);
            BlogLogic logic = new BlogLogic(repo);

            var menu = new ConsoleMenu()
                .Add(">> LIST ALL", () => ListAll(logic))
                .Add(">> GET BY ID", () => GetById(logic))
                .Add(">> CHANGE TITLE", () => ChangeTitle(logic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAll(BlogLogic logic)
        {
            Console.WriteLine("\n:: ALL BLOGS ::\n");
            logic.GetAllBlogs()
                .ToList()
                .ForEach(x => Console.WriteLine(x.MainData));

            Console.ReadLine();
        }

        private static void GetById(BlogLogic logic)
        {
            Console.Write("ENTERT ID HERE: ");
            int id = int.Parse(Console.ReadLine());

            var q = logic.GetBlogById(id);

            Console.WriteLine("\n:: SELECTED BLOG ::\n");
            Console.WriteLine(q); // tostring

            Console.ReadLine();
        }

        private static void ChangeTitle(BlogLogic logic)
        {
            Console.Write("ENTER ID HERE: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("ENTER NEW TITLE HERE: ");
            string newTitle = Console.ReadLine();

            logic.ChangeBlogTitle(id, newTitle);

            var q = logic.GetBlogById(id);

            Console.WriteLine("\n:: NEW TITLE ::\n");
            Console.WriteLine(q.Title);

            Console.ReadLine();
        }
    }
}
