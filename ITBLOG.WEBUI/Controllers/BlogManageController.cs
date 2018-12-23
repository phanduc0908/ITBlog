using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ITBLOG.CORE.AdminView;
using ITBLOG.CORE.Models;
using ITBLOG.CORE.ViewModels;
using ITBLOG.SERVICE.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITBLOG.WEBUI.Controllers
{
    [Authorize]
    public class BlogManageController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        public BlogManageController(IBlogService blogService, ICommentService commentService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listAllBlog = _blogService.GetBlogs();
            var BlogsView = _mapper.Map<IEnumerable<BlogIndex>>(listAllBlog);
            return View(BlogsView);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            BlogViewItem model = new BlogViewItem();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddBlog(BlogViewItem model)
        {
            if (ModelState.IsValid)
            {
                var blog = _mapper.Map<Blog>(model);
                _blogService.CreateBlog(blog);
                return RedirectToAction("Index", "BlogManage");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int Id)
        {
            var blogDetail = _blogService.GetBlogById(Id);
            var blogView = _mapper.Map<BlogViewItem>(blogDetail);
            blogView.NumberComments = _commentService.GetNumberComment(Id);
            return View(blogView);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var blog = _blogService.GetBlogById(Id);
            var model = _mapper.Map<BlogViewItem>(blog);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(BlogViewItem model)
        {
            if (ModelState.IsValid)
            {
                // Cần đặt một hidden input bên view  để có thể lấy được Id của model
                var blog = _mapper.Map<Blog>(model);
                _blogService.UpdateBlog(blog);
                return RedirectToAction("Index", "BlogManage");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var blog = _blogService.GetBlogById(Id);
            var blogView = _mapper.Map<BlogViewItem>(blog);
            return View(blogView);
        }

        [HttpPost]
        public IActionResult Delete(int Id, string query)
        {
            _blogService.DeleteBlog(Id);
            return RedirectToAction("Index", "BlogManage");
        }
    }
}