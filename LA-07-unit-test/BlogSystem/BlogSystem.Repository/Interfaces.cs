using BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }

    public interface IBlogRepository : IRepository<Blog>
    {
        void ChangeTitle(int id, string newTitle);
    }

    public interface ICommentRepository : IRepository<Comment>
    {
        void UpdateContent(int id, string newContent);
    }
}
