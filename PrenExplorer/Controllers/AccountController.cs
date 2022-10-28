using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrenExplorer.Models;
using PrenExplorer.Services;
using PrenExplorer.ViewModels;

namespace PrenExplorer.Controllers
{
    public class AccountController : Controller
    {
        AccountService _service;
        UserManager<NPUser> _userManager;
        IWebHostEnvironment _webHost;

        public AccountController(AccountService accountService, UserManager<NPUser> userManager, IWebHostEnvironment webHost)
        {
            _service = accountService;
            _userManager = userManager;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Login/Logout
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.SignPassword(model);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        public IActionResult SessionExpired()
        {
            return View("LoginError");
        }

    }
}
