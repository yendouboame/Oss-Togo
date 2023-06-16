using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Enums;

namespace SolidarityFund.Data.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        }
    }
}
