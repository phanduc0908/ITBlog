using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using ITBLOG.CORE.ViewModels;
using AutoMapper;
using System;

namespace ITBLOG.INFRA.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog GetBlogById(int BlogId);
        Blog GetNextBlog(int currentBlogId);
        Blog getPreBlog(int currentBlogId);

        int GetLastBlogId();
        int GetFirstBlogId();
        int GetNumberBlog();

        IEnumerable<Blog> GetAllBlogs();
        IEnumerable<Blog> GetTopThree();
        IEnumerable<Blog> BlogsSearch(string query);
        IEnumerable<Blog> GetLastestBlog();
        IEnumerable<Blog> GetBlogByTagName(string tagName);

        void DeleteBlogById(int BlogId);
        void AddBlog(Blog blog);
        void UpdateBlog(Blog blog);
    }

    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void AddBlog(Blog blog)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Blogs.Add(blog);
                    DbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public IEnumerable<Blog> BlogsSearch(string query)
        {
            var BlogsSearch = this.DbContext.Blogs
                .Where(b => b.Title.Contains(query))
                .ToList();
            return BlogsSearch;
        }

        public void DeleteBlogById(int BlogId)
        {
            var comments = DbContext.Comments
                .Where(c => c.BlogId == BlogId).ToList();
            var tags = DbContext.Tags
                .Where(t => t.BlogId == BlogId).ToList();
            var blog = DbContext.Blogs
                .Where(b => b.BlogId == BlogId).SingleOrDefault();
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in comments)
                    {
                        DbContext.Comments.Remove(item);
                    }
                    foreach (var item in tags)
                    {
                        DbContext.Tags.Remove(item);
                    }
                    DbContext.Blogs.Remove(blog);
                    DbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public Blog EditBlog(Blog blog)
        {
            var TemBlog = this.DbContext.Blogs
                .Where(b => b.BlogId == blog.BlogId).SingleOrDefault();
            return TemBlog;
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            var blogs = this.DbContext.Blogs.ToList();
            return blogs;
        }

        public Blog GetBlogById(int blogId)
        {
            var blog = this.DbContext.Blogs
                .Where(b => b.BlogId == blogId).SingleOrDefault();

            return blog;
        }

        public IEnumerable<Blog> GetBlogByTagName(string tagName)
        {
            var query =
                (from blog in DbContext.Blogs
                 join tag in DbContext.Tags on blog.BlogId equals tag.BlogId
                 where tag.TagName == tagName
                 select blog).ToList();
            return query;
        }

        public int GetFirstBlogId()
        {
            var blog = this.DbContext.Blogs
                            .OrderBy(b => b.BlogId)
                            .FirstOrDefault();
            return blog.BlogId;
        }

        public int GetLastBlogId()
        {
            var blog = this.DbContext.Blogs
                .OrderByDescending(b => b.BlogId)
                .FirstOrDefault();
            return blog.BlogId;
        }

        public IEnumerable<Blog> GetLastestBlog()
        {
            var LastestBlog = this.DbContext.Blogs
                .OrderByDescending(b => b.ReleaseDay)
                .Take(3).ToList();
            return LastestBlog;
        }

        public Blog GetNextBlog(int currentBlogId)
        {
            var nextBlog = this.DbContext.Blogs
                .ToList()
                .SkipWhile(b => b.BlogId != currentBlogId)
                .Skip(1)
                .First();
            return nextBlog;
        }

        public int GetNumberBlog()
        {
            var NumberBlog = this.DbContext.Blogs
                .ToList().Count();
            return NumberBlog;
        }

        public Blog getPreBlog(int currentBlogId)
        {
            var preBlog = this.DbContext.Blogs
                            .OrderBy(b => b.BlogId)
                            .Where(b => b.BlogId < currentBlogId)
                            .Last();
            return preBlog;
        }

        public IEnumerable<Blog> GetTopThree()
        {
            var TopThreeBlog = this.DbContext.Blogs
                .Take(3).ToList();
            return TopThreeBlog;
        }

        public void UpdateBlog(Blog blog)
        {
            var preBlog = DbContext.Blogs
                .Where(b => b.BlogId == blog.BlogId).SingleOrDefault();
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {

                    preBlog.BlogId = blog.BlogId;
                    preBlog.Author = blog.Author;
                    preBlog.Title = blog.Title;
                    preBlog.Image = blog.Image;
                    preBlog.ReleaseDay = blog.ReleaseDay;
                    preBlog.Genre = blog.Genre;
                    preBlog.ContentHeader = blog.ContentHeader;
                    preBlog.Content = blog.Content;

                    DbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

        }
    }


}
