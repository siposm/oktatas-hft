using BlogSystem.Data;
using BlogSystem.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogSystem.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        IBlogLogic blogLogic;

        public BlogController(IBlogLogic blogLogic)
        {
            this.blogLogic = blogLogic;
        }



        // GET: /blog
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return blogLogic.GetAllBlogs();
        }

        // GET /blog/5
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return blogLogic.GetBlogById(id);
        }

        // POST /blog
        [HttpPost]
        public void Post([FromBody] Blog value)
        {
            blogLogic.AddNewBlog(value);
        }

        // PUT /blog
        [HttpPut]
        public void Put([FromBody] Blog value)
        {
            blogLogic.UpdateBlog(value);
        }

        // DELETE /blog/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            blogLogic.DeleteBlog(id);
        }
    }
}
