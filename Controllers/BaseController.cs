using Microsoft.AspNetCore.Mvc;
using SolidarityFund.Data;
using Microsoft.Extensions.DependencyInjection;
using SolidarityFund.Repositories;
using SolidarityFund.Models.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SolidarityFund.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private ApplicationDbContext Context;
        private UserManager<User> UserManager;
        private PriestRepository PriestRepository;
        private SignInManager<User> SignInManager;
        private DioceseRepository DioceseRepository;
        private PensionRepository PensionRepository;
        private RoleManager<IdentityRole> RoleManager;
        private ContributionRepository ContributionRepository;

        protected ApplicationDbContext _context => Context ??= HttpContext.RequestServices.GetService<ApplicationDbContext>();
        protected UserManager<User> _userManager => UserManager ??= HttpContext.RequestServices.GetService<UserManager<User>>();
        protected PriestRepository _priestRepository => PriestRepository ??= HttpContext.RequestServices.GetService<PriestRepository>();
        protected SignInManager<User> _signInManager => SignInManager ??= HttpContext.RequestServices.GetService<SignInManager<User>>();
        protected PensionRepository _pensionRepository => PensionRepository ??= HttpContext.RequestServices.GetService<PensionRepository>();
        protected DioceseRepository _dioceseRepository => DioceseRepository ??= HttpContext.RequestServices.GetService<DioceseRepository>();
        protected RoleManager<IdentityRole> _roleManager => RoleManager ??= HttpContext.RequestServices.GetService<RoleManager<IdentityRole>>();
        protected ContributionRepository _contributionRepository => ContributionRepository ??= HttpContext.RequestServices.GetService<ContributionRepository>();

        protected async Task<User> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return user;
        }
    }
}