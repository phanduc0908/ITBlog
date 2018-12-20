using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ITBLOG.CORE.Models;
using ITBLOG.SERVICE.Core;
using Microsoft.AspNetCore.Mvc;
using ITBLOG.WEBUI.Models;
using AutoMapper;
using ITBLOG.CORE.ViewModels;
using ITBLOG.WEBUI.Paging;

namespace ITBLOG.WEBUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService clogService, ICommentService commentService, ITagService tagService, IMapper mapper)
        {
            _blogService = clogService;
            _commentService = commentService;
            _tagService = tagService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var TopThreeBlogs = _blogService.GetThreeBlog();
            var mappedTopThreeBlog = _mapper.Map<IEnumerable<BlogViewItem>>(TopThreeBlogs);
            return View(mappedTopThreeBlog);
        }
        [HttpGet]
        public IActionResult GetAllBlog(string Tag = null)
        {
            Tag = HttpContext.Request.Query["Tag"].ToString();
            Pagination pg = new Pagination();
            int offset = 1, page = 1, take = 4;
            int total = _blogService.GetNumberBlog();
            if (Convert.ToInt32(HttpContext.Request.Query["Page"]) > 1)
            {
                page = Convert.ToInt32(HttpContext.Request.Query["Page"]);
            }
            int skip = 0;
            if (page == 1)
                skip = 0;
            else
                skip = ((page - 1) * take);

            string paging = pg.PagedList(total, page, take, offset, "GetAllBlog", "", "");
            ViewBag.Paging = paging;
            //
            IEnumerable<Blog> Blogs = null;
            if (String.IsNullOrEmpty(Tag))
            {
                Blogs = _blogService.GetBlogs().Skip(skip).Take(take);
            }
            else
            {
                Blogs = _blogService.GetBlogByTagName(Tag).Skip(skip).Take(take);
            }
            var LastBlogs = _blogService.GetLastestBlog();
            var ListTagNames = _tagService.GetAllTagNames();
            BlogComment model = new BlogComment
            {
                Blogs = _mapper.Map<IEnumerable<BlogViewItem>>(Blogs),
                LastBlogs = _mapper.Map<IEnumerable<LastestBlog>>(LastBlogs),
                ListTagNames = _mapper.Map<IEnumerable<TagViewItem>>(ListTagNames)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult GetAllBlog(string Query = null, string Tag = null)
        {


            Pagination pg = new Pagination();
            int offset = 1, page = 1, take = 4;
            int total = _blogService.GetNumberBlog();
            if (Convert.ToInt32(HttpContext.Request.Query["Page"]) > 1)
            {
                page = Convert.ToInt32(HttpContext.Request.Query["Page"]);
            }

            int skip = 0;
            if (page == 1)
                skip = 0;
            else
                skip = ((page - 1) * take);

            string paging = pg.PagedList(total, page, take, offset, "GetAllBlog", "", "");
            ViewBag.Paging = paging;
            //
            IEnumerable<Blog> Blogs = null;
            if (String.IsNullOrEmpty(Query))
            {
                Blogs = _blogService.GetBlogs().Skip(skip).Take(take);
            }
            else
            {
                Blogs = _blogService.BlogsSearch(Query).Skip(skip).Take(take);
            }

            var LastBlogs = _blogService.GetLastestBlog();
            var ListTagNames = _tagService.GetAllTagNames();
            BlogComment model = new BlogComment
            {
                Blogs = _mapper.Map<IEnumerable<BlogViewItem>>(Blogs),
                LastBlogs = _mapper.Map<IEnumerable<LastestBlog>>(LastBlogs),
                ListTagNames = _mapper.Map<IEnumerable<TagViewItem>>(ListTagNames)
            };
            return View(model);
        }

        public IActionResult Detail(int Id)
        {
            HttpContext.Session.SetInt32("CurrentBlogId", Id);
            var CommentByBlogId = _commentService.GetCommentByBlogId(Id);
            var BlogById = _blogService.GetBlogById(Id);
            var NumberComments = _commentService.GetNumberComment(Id);
            var LastThreeBlog = _blogService.GetLastestBlog();
            var ListTagNames = _tagService.GetAllTagNames();
            int LastBlogId = _blogService.GetLastBlogId();
            int FirstBlogId = _blogService.GetFirstBlogId();
            Blog NextBlog = null;
            Blog PreviousBlog = null;

            if (LastBlogId > Id)
            {
                NextBlog = _blogService.GetNextBlog(Id);
            }
            if (FirstBlogId < Id)
            {
                PreviousBlog = _blogService.GetPreBlog(Id);
            }
            var blogComment = new BlogComment
            {
                blog = BlogById,
                Comments = _mapper.Map<IEnumerable<CommentView>>(CommentByBlogId),
                NumberComments = NumberComments,
                LastBlogs = _mapper.Map<IEnumerable<LastestBlog>>(LastThreeBlog),
                ListTagNames = _mapper.Map<IEnumerable<TagViewItem>>(ListTagNames),
                nextBlog = _mapper.Map<ChangeBlog>(NextBlog),
                lastBlogId = LastBlogId,
                firstBlogId = FirstBlogId,
                previousBlog = _mapper.Map<ChangeBlog>(PreviousBlog)
            };
            return View(blogComment);
        }

        public IActionResult Search(string TagName = null)
        {
            return View();
        }
    }
}