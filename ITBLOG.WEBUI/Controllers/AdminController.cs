using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITBLOG.CORE.AdminView;
using ITBLOG.CORE.Models;
using ITBLOG.CORE.ViewModels;
using ITBLOG.SERVICE.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITBLOG.WEBUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IBlogService _blogService;
        public AdminController(IAdminService adminService, IBlogService blogService)
        {
            _adminService = adminService;
            _blogService = blogService;
        }
        [Authorize]
        public IActionResult Index()
        {
            BlogAdmin model = new BlogAdmin
            {
                NumberBlog = _blogService.GetNumberBlog()
            };
            return View(model);
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin model)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Admin");
                }
                var admin = _adminService.GetAdmin(model.Username, model.Password);
                if (admin != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                        new Claim(ClaimTypes.Name, admin.Username),
                        new Claim(ClaimTypes.GivenName, admin.Password),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ErrorLogin = "Tên đăng nhập hoặc tài khoản không chính xác";
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Index", "Admin");
        }

    }
}