using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITBLOG.CORE.Models;
using ITBLOG.SERVICE.Core;
using ITBLOG.WEBUI.Models;
using AutoMapper;

namespace ITBLOG.WEBUI.Controllers
{

    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddComment()
        {
            CommentModel model = new CommentModel();
            return PartialView("_AddComment", model);
        }
        [HttpPost]
        public IActionResult AddComment(CommentModel model)
        {
            int CurrentBlogId = (int)HttpContext.Session.GetInt32("CurrentBlogId");
            if (ModelState.IsValid)
            {
                Comment comment = new Comment
                {
                    Name = model.Name,
                    Content = model.Content,
                    BlogId = CurrentBlogId
                };
                _commentService.AddComment(comment);
                return RedirectToAction("Detail", "Blog", new { id = CurrentBlogId });
            }
            return RedirectToAction("Detail", "Blog", new { id = CurrentBlogId });
        }
    }
}