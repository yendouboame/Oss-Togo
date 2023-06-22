using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolidarityFund.Models;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cost = _costRepository.GetCosts();

            var dioceses = _context.Dioceses.Where(d => !d.IsDeleted).ToList();
            var priests = _context.Priests.Where(p => !p.IsDeleted && p.SuspensionReason == null).ToList();
            var contributingPriests = _priestRepository.GetEligibleForContribution().ToList();
            var beneficiaryPriests = _priestRepository.GetEligibleForPension().ToList();

            var contributions = _context.Contributions.Include(c => c.Priest).Where(c => !c.IsDeleted).ToList();
            var pensions = _context.Pensions.Include(p => p.Priest).Where(p => !p.IsDeleted).ToList();
            
            var currentMonthContribution = contributions
                .Where(c => c.Date.Year == DateTime.Now.Year && c.Date.Month == DateTime.Now.Month)
                .Sum(c => c.Amount);
            var currentMonthPension = pensions
                .Where(p => p.Date.Year == DateTime.Now.Year && p.Date.Month == DateTime.Now.Month)
                .Sum(p => p.Amount);
            
            var expectedContribution = contributingPriests.Count * cost.Contribution;
            var expectedPension = beneficiaryPriests.Count * cost.Pension;

            var viewModel = new DashboardViewModel
            {
                DioceseCount = dioceses.Count,
                PriestCount = priests.Count,
                ContributingPriest = contributingPriests.Count,
                BeneficiaryPriest = beneficiaryPriests.Count,
                CurrentMonthContribution = currentMonthContribution,
                CurrentMonthExpectedContribution = expectedContribution,
                CurrentMonthPension = currentMonthPension,
                CurrentMonthExpectedPension = expectedPension,
                LastContributions = contributions.OrderByDescending(c => c.Date).Take(5).ToList(),
                LastPensions = pensions.OrderByDescending(p => p.Date).Take(5).ToList()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
