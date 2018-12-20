using System;
using System.Collections.Generic;
using System.Text;
using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Repositories;
using ITBLOG.INFRA.Infrastructure;

namespace ITBLOG.SERVICE.Core
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetCommentByBlogId(int BlogId);
        int GetNumberComment(int BlogId);
        void AddComment(Comment comment);
        void Delete(int CommentId);
        Comment GetCommentById(int CommentID);
    }
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddComment(Comment comment)
        {
            _commentRepository.AddComment(comment);
        }

        public void Delete(int CommentId)
        {
            _commentRepository.Delete(CommentId);
        }

        public Comment GetCommentById(int CommentID)
        {
            return _commentRepository.GetCommentById(CommentID);
        }

        public int GetNumberComment(int BlogId)
        {
            int numberComment = _commentRepository.GetNumberComment(BlogId);
            return numberComment;
        }

        IEnumerable<Comment> ICommentService.GetCommentByBlogId(int BlogId)
        {
            var comments = _commentRepository.GetCommentByBlogId(BlogId);
            return comments;
        }
    }
}
