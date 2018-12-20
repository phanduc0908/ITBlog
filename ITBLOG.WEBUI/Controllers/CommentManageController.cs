using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ITBLOG.CORE.ViewModels;
using ITBLOG.SERVICE.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITBLOG.WEBUI.Controllers
{
    [Authorize]
    public class CommentManageController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentManageController(ICommentService commentService,IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public IActionResult Index(int Id)
        {
            var comments = _commentService.GetCommentByBlogId(Id);
            var model = _mapper.Map<IEnumerable<CommentView>>(comments);
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            var model = _commentService.GetCommentById(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int Id, string query)
        {
            _commentService.Delete(Id);
            return RedirectToAction("Index", "BlogManage");
        }
    }
}