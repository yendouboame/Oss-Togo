using Microsoft.AspNetCore.Mvc;
using SolidarityFund.Data;
using Microsoft.Extensions.DependencyInjection;
using SolidarityFund.Repositories;

namespace SolidarityFund.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext Context;
        private PriestRepository PriestRepository;
        private DioceseRepository DioceseRepository;
        private ContributionRepository ContributionRepository;

        protected ApplicationDbContext _context => Context ??= HttpContext.RequestServices.GetService<ApplicationDbContext>();
        protected PriestRepository _priestRepository => PriestRepository ??= HttpContext.RequestServices.GetService<PriestRepository>();
        protected DioceseRepository _dioceseRepository => DioceseRepository ??= HttpContext.RequestServices.GetService<DioceseRepository>();
        protected ContributionRepository _contributionRepository => ContributionRepository ??= HttpContext.RequestServices.GetService<ContributionRepository>();
    }
}