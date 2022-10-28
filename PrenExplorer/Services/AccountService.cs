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
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<NPUser> _signInManager;
        private IHttpContextAccessor _contextAccessor;
        private UnitOfWork _unitOfWork;

        public AccountService(UserManager<NPUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<NPUser> signInManager, IHttpContextAccessor contextAccessor, UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
        }

        private async Task<IdentityResult> AssingToRole(NPUser user, string Role)
        {
            return await _userManager.AddToRoleAsync(user, Role);
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
