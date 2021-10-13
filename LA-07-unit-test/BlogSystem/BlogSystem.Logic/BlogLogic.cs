using BlogSystem.Data;
using BlogSystem.Data.Models;
using BlogSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Logic
{
    public interface IBlogLogic
    {
        Blog GetBlogById(int id);
        void ChangeBlogTitle(int id, string newTitle);
        IList<Blog> GetAllBlogs();
    }


    public class BlogLogic : IBlogLogic
    {
        IBlogRepository blogRepo;
        ICommentRepository commentRepo;

        public BlogLogic(IBlogRepository bRepo, ICommentRepository cRepo) // DEP. INJ.
        {
            this.blogRepo = bRepo;
            this.commentRepo = cRepo;
        }

        public void ChangeBlogTitle(int id, string newTitle)
        {
            if (newTitle == "")
                throw new Exception("[ERR] Title can't be empty!");

            if (newTitle.Contains("ALMA"))
                throw new Exception("[ERR] Title can't contains forbidden words!");
            // TODO add blacklist-based approach to check for words.

            blogRepo.ChangeTitle(id, newTitle);
        }

        public IList<Blog> GetAllBlogs()
        {
            return blogRepo.GetAll().ToList();
        }

        public Blog GetBlogById(int id)
        {
            return blogRepo.GetOne(id);
        }

        public IEnumerable<CommentNumberPerCategory> GetCommentNumberPerCategory()
        {
            var qx_sub = from x in commentRepo.GetAll()
                         group x by x.BlogId into g
                         select new
                         {
                             BLOG_ID = g.Key,
                             COMM_NO = g.Count()
                         };

            var qx = from x in blogRepo.GetAll()
                     join z in qx_sub on x.BlogId equals z.BLOG_ID
                     let joinedItem = new { x.BlogId, x.Category, z.COMM_NO }
                     group joinedItem by joinedItem.Category into grp
                     select new CommentNumberPerCategory
                     {
                         Category = grp.Key,
                         CommentCount = grp.Sum(x => x.COMM_NO)
                     };

            return qx;
        }
    }
}
