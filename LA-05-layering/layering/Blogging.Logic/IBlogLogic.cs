using Blogging.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogging.Logic
{
    public interface IBlogLogic
    {
        Blog GetBlogById(int id);
        void ChangeBlogTitle(int id, string newTitle);
        IList<Blog> GetAllBlogs();
    }
}
