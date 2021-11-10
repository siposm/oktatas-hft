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
    public class CommentController : ControllerBase
    {
        ICommentLogic commentLogic;

        public CommentController(ICommentLogic commentLogic)
        {
            this.commentLogic = commentLogic;
        }

        // GET: /comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return commentLogic.GetAllComments();
        }

        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return commentLogic.GetCommentById(id);
        }

        [HttpPost]
        public void Post([FromBody] Comment value)
        {
            commentLogic.AddNewComment(value);
        }

        [HttpPut]
        public void Put([FromBody] Comment value)
        {
            commentLogic.UpdateComment(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            commentLogic.DeleteComment(id);
        }
    }
}
