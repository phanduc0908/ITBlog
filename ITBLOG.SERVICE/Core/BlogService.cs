using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Infrastructure;
using ITBLOG.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.SERVICE.Core
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetBlogs();
        IEnumerable<Blog> GetThreeBlog();
        IEnumerable<Blog> GetLastestBlog();
        IEnumerable<Blog> BlogsSearch(string query);
        IEnumerable<Blog> GetBlogByTagName(string tagName);

        Blog GetBlogById(int Id);
        Blog GetNextBlog(int currentBlogId);
        Blog GetPreBlog(int currentBlogId);
        int GetLastBlogId();
        int GetFirstBlogId();
        int GetNumberBlog();

        void CreateBlog(Blog blog);
        void Save();
        void UpdateBlog(Blog blog);
        void DeleteBlog(int BlogId);
    }
    public class BlogService : IBlogService
    {

        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateBlog(Blog blog)
        {
            _blogRepository.AddBlog(blog);
        }

        public void DeleteBlog(int BlogId)
        {
            _blogRepository.DeleteBlogById(BlogId);
        }

        public Blog GetBlogById(int Id)
        {
            return _blogRepository.GetBlogById(Id);
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _blogRepository.GetAllBlogs();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateBlog(Blog blog)
        {
            _blogRepository.UpdateBlog(blog);
        }

        public IEnumerable<Blog> GetThreeBlog()
        {
            return _blogRepository.GetTopThree();
        }

        public Blog GetNextBlog(int currentBlogId)
        {
            return _blogRepository.GetNextBlog(currentBlogId);
        }

        public int GetLastBlogId()
        {
            return _blogRepository.GetLastBlogId();
        }

        public int GetFirstBlogId()
        {
            return _blogRepository.GetFirstBlogId();
        }

        public Blog GetPreBlog(int currentBlogId)
        {
            return _blogRepository.getPreBlog(currentBlogId);
        }

        public IEnumerable<Blog> BlogsSearch(string query)
        {
            return _blogRepository.BlogsSearch(query);
        }

        public int GetNumberBlog()
        {
            return _blogRepository.GetNumberBlog();
        }

        public IEnumerable<Blog> GetLastestBlog()
        {
            return _blogRepository.GetLastestBlog();
        }

        public IEnumerable<Blog> GetBlogByTagName(string tagName)
        {
            return _blogRepository.GetBlogByTagName(tagName);
        }
    }
}
