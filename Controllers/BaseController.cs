using Microsoft.AspNetCore.Mvc;
using SolidarityFund.Data;
using Microsoft.Extensions.DependencyInjection;
using SolidarityFund.Repositories;
using SolidarityFund.Models.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Globalization;
using System.Linq;

namespace SolidarityFund.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private ApplicationDbContext Context;
        private CostRepository CostRepository;
        private UserManager<User> UserManager;
        private PriestRepository PriestRepository;
        private SignInManager<User> SignInManager;
        private DioceseRepository DioceseRepository;
        private PensionRepository PensionRepository;
        private RoleManager<IdentityRole> RoleManager;
        private ContributionRepository ContributionRepository;

        protected ApplicationDbContext _context => Context ??= HttpContext.RequestServices.GetService<ApplicationDbContext>();
        protected CostRepository _costRepository => CostRepository ??= HttpContext.RequestServices.GetService<CostRepository>();
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

        protected void GetDioceseSelectList()
        {
            var dioceses = _dioceseRepository.GetAll();
            ViewBag.Dioceses = new SelectList(dioceses, "Id", "Name");
        }

        protected void GetPriestSelectList()
        {
            var priests = _priestRepository.GetAll();
            ViewBag.Priests = new SelectList(priests, "Id", "FullName");
        }

        protected void GetSuspendedPriestSelectList()
        {
            var priests = _priestRepository.GetSuspended();
            ViewBag.Priests = new SelectList(priests, "Id", "FullName");
        }

        protected void GetUnsuspendedPriestSelectList()
        {
            var priests = _priestRepository.GetUnsuspended();
            ViewBag.Priests = new SelectList(priests, "Id", "FullName");
        }

        protected void GetEligiblePriestForContributionSelectList()
        {
            var priests = _priestRepository.GetEligibleForContribution();
            ViewBag.Priests = new SelectList(priests, "Id", "FullName");
        }

        protected void GetMonthSelectList()
        {
            var currentMonth = DateTime.Now.Month;
            var monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            ViewBag.Months = new SelectList(monthNames
                .Select((name, index) => new { Value = index + 1, Text = name })
                .Where(m => !string.IsNullOrEmpty(m.Text)), "Value", "Text", currentMonth);
        }
    }
}