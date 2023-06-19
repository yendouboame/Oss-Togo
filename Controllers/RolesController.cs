﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Controllers
{
    public class RolesController : BaseController
    {
        public IActionResult Index()
        {
            var roles = _roleManager.Roles
                .Where(r => r.Name != Roles.SuperAdmin.ToString())
                .OrderBy(r => r.Name)
                .ToList();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string roleName)
        {
            string message = string.Empty;

            if (await _roleManager.RoleExistsAsync(roleName))
            {
                message = "Erreur: Ce rôle existe déjà.";
            }
            else
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
                message = "Rôle créé avec succès.";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null) return NotFound();

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allClaims = Permissions.GenerateAllPermissions();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();

            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(c => c == permission.DisplayValue))
                {
                    permission.IsSelected = true;
                }
            }

            var viewModel = new PermissionsFormViewModel
            {
                RoleId = roleId,
                RoleName = role.Name,
                RoleClaims = allPermissions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePermissions(PermissionsFormViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null) return NotFound();

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }

            var selectedClaims = model.RoleClaims.Where(c => c.IsSelected).ToList();

            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));
            }

            TempData["StatusMessage"] = "Habilitations mises à jour avec succès.";
            return RedirectToAction(nameof(Index));
        }
    }
}