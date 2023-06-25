using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Controllers
{
    [Authorize(Permissions.Users.Access)]
    public class UsersController : BaseController
    {
        [Authorize(Permissions.Users.Access)]
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();

            var users = _userManager.Users
                .Where(a => a.Id != currentUser.Id && a.UserName != "aime")
                .OrderBy(u => u.UserName)
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Roles = _userManager.GetRolesAsync(user).Result
                }).ToList();

            return View(users);
        }

        [Authorize(Permissions.Users.Create)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Permissions.Users.Create)]
        public async Task<IActionResult> Create(User user, string password)
        {
            var appUser = await _userManager.FindByNameAsync(user.UserName)
                ?? await _userManager.FindByEmailAsync(user.Email);

            if (appUser == null)
            {
                user.EmailConfirmed = true;
                user.IsActive = true;
                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
            }

            TempData["StatusMessage"] = "Utilisateur ajouté avec succès.";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Permissions.Users.ManageRoles)]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) return NotFound();

            var roles = _roleManager.Roles.Where(r => r.Name != Roles.SuperAdmin.ToString()).ToList();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserFullName = user.FullName,
                Roles = roles.Select(role => new CheckBoxViewModel
                {
                    DisplayValue = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Permissions.Users.ManageRoles)]
        public async Task<IActionResult> UpdateRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected).Select(r => r.DisplayValue));

            TempData["StatusMessage"] = "Rôles mis à jour avec succès.";
            return RedirectToAction(nameof(Index));
        }
    }
}