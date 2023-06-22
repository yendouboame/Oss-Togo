using Microsoft.AspNetCore.Identity;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.Models.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<User> userManager)
        {
            var basicUser = new User
            {
                UserName = "basic",
                LastName = "Basic",
                FirstName = "User",
                Email = "basicuser@domain.com",
                EmailConfirmed = true,
                IsActive = true
            };

            var user = await userManager.FindByNameAsync(basicUser.UserName)
                ?? await userManager.FindByEmailAsync(basicUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(basicUser, "P@ssword123");
                await userManager.AddToRoleAsync(basicUser, Roles.Basic.ToString());
            }
        }

        public static async Task SeedSuperAdminUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var saUser = new User
            {
                UserName = "aime",
                LastName = "WOAGOU",
                FirstName = "Yendouboame Aimé",
                Email = "aimewoagou@gmail.com",
                EmailConfirmed = true,
                IsActive = true
            };

            var user = await userManager.FindByNameAsync(saUser.UserName)
                ?? await userManager.FindByEmailAsync(saUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(saUser, "P@ssword123");
                await userManager.AddToRoleAsync(saUser, Roles.SuperAdmin.ToString());
            }

            await roleManager.SeedClaimsForSuperAdminUser();
        }

        private static async Task SeedClaimsForSuperAdminUser(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
            {
                await roleManager.AddPermissionClaims(adminRole, module.ToString());
            }
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsList(module);

            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(c => c.Type == "Permission" && c.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}
