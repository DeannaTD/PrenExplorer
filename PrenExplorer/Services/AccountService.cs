using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrenExplorer.Models;
using PrenExplorer.UoW;
using PrenExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace PrenExplorer.Services
{
    public class AccountService
    {
        private UserManager<NPUser> _userManager;
        private SignInManager<NPUser> _signInManager;

        public AccountService(UserManager<NPUser> userManager, SignInManager<NPUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> SignPassword(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IList<NPUser>> GetAllUsersInRole(string Role)
        {
            return await _userManager.GetUsersInRoleAsync(Role);
        }

    }
}
