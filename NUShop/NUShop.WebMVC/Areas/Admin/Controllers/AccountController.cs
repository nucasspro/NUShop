﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NUShop.Data.Entities;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Admin/Login/Index");
        }
    }
}