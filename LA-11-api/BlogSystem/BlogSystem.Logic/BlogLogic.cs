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
        void AddNewBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void DeleteBlog(int id);

        IEnumerable<CommentNumberPerCategory> GetCommentNumberPerCategory();
        double? AverageLikesCount();
        CategoryAndCount GetLeastUsedCategory();
        IList<Blog> GetBlogsWithRudeComments();

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
            if (id < blogRepo.GetAll().Count())
                return blogRepo.GetOne(id);
            else
                throw new IndexOutOfRangeException("[ERR] ID was too big!");
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

        public double? AverageLikesCount()
        {
            return blogRepo.GetAll().ToList().Average(x => x.LikesCount);
        }

        public CategoryAndCount GetLeastUsedCategory()
        {
            return blogRepo
                .GetAll()
                .GroupBy(x => x.Category)
                .Select(g => new CategoryAndCount
                {
                    Category = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Count)
                .First();
        }

        public IList<Blog> GetBlogsWithRudeComments()
        {
            string rudeWord = "SH!T";

            var q = from x in commentRepo.GetAll()
                    where x.Content.Contains(rudeWord)
                    select x.Blog;

            return q.ToList();
        }

        public void AddNewBlog(Blog blog)
        {
            blogRepo.AddNewBlog(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            blogRepo.UpdateBlog(blog);
        }

        public void DeleteBlog(int id)
        {
            blogRepo.DeleteBlogById(id);
        }
    }
}
