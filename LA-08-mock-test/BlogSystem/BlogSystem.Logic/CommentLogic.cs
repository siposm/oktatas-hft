using BlogSystem.Data;
using BlogSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Logic
{
    public interface ICommentLogic
    {
        Comment GetCommentById(int id);
        void UpdateCommentContentById(int id, string newContent);
        IList<Comment> GetAllComments();
    }

    public class CommentLogic : ICommentLogic
    {
        ICommentRepository commentRepo;

        public CommentLogic(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public IList<Comment> GetAllComments()
        {
            return commentRepo.GetAll().ToList();
        }

        public Comment GetCommentById(int id)
        {
            return commentRepo.GetOne(id);
        }

        public void UpdateCommentContentById(int id, string newContent)
        {
            if (newContent == "")
                throw new Exception("[ERR] Content can't be empty!");

            if (newContent.Contains("ALMA"))
                throw new Exception("[ERR] Content can't contains forbidden words!");
            // TODO add blacklist-based approach to check for words.

            commentRepo.UpdateContent(id, newContent);
        }
    }
}
