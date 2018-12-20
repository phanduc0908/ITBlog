using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITBLOG.INFRA.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentByBlogId(int BlogId);
        int GetNumberComment(int BlogId);
        void AddComment(Comment comment);
        void Delete(int CommentId);
        Comment GetCommentById(int CommentID);
    }
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void AddComment(Comment comment)
        {
            using(var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Comments.Add(comment);
                    DbContext.SaveChanges();
                    transaction.Commit();
                }catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(int CommentId)
        {
            var comment = this.DbContext.Comments
                .Where(c => c.CommnentId == CommentId).SingleOrDefault();
            using(var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    this.DbContext.Comments.Remove(comment);
                    this.DbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public IEnumerable<Comment> GetCommentByBlogId(int BlogId)
        {
            var CommentByBlogId = this.DbContext.Comments
                .Where(c => c.BlogId == BlogId).ToList();
            return CommentByBlogId;
        }

        public Comment GetCommentById(int CommentID)
        {
            var comment = this.DbContext.Comments
                .Where(c => c.CommnentId == CommentID).SingleOrDefault();
            return comment;
        }

        public int GetNumberComment(int BlogId)
        {
            int numberComment = (from c in this.DbContext.Comments
                                 where c.BlogId == BlogId
                                 select c
                                 ).Count();
            return numberComment;
        }
    }
}
