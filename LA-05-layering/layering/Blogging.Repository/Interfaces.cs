using Blogging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogging.Repository
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
}
