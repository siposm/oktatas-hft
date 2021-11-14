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
        void AddNewComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
    }

    public class CommentLogic : ICommentLogic
    {
        ICommentRepository commentRepo;

        public CommentLogic(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public void AddNewComment(Comment comment)
        {
            commentRepo.AddNewComment(comment);
        }

        public void DeleteComment(int id)
        {
            commentRepo.DeleteCommentById(id);
        }

        public IList<Comment> GetAllComments()
        {
            return commentRepo.GetAll().ToList();
        }

        public Comment GetCommentById(int id)
        {
            return commentRepo.GetOne(id);
        }

        public void UpdateComment(Comment comment)
        {
            commentRepo.UpdateComment(comment);
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
