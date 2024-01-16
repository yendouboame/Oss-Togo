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
using static SolidarityFund.Helpers.Constants.Enumerations;

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

            var dioceses = _dioceseRepository.GetAll().ToList();
            var priests = _priestRepository.GetAll().ToList();
            var contributions = _contributionRepository.GetCurrentYearContributions().ToList();
            var pensions = _pensionRepository.GetCurrentYearPensions().ToList();


            var contributingPriests = _priestRepository.GetEligibleForContribution().ToList();
            var beneficiaryPriests = _priestRepository.GetEligibleForPension().ToList();

            
            var currentMonthContribution = contributions
                .Where(c => c.Date.Year == DateTime.Now.Year && c.Date.Month == DateTime.Now.Month)
                .Sum(c => c.Amount);
            var currentMonthPension = pensions
                .Where(p => p.Date.Year == DateTime.Now.Year && p.Date.Month == DateTime.Now.Month)
                .Sum(p => p.Amount);
            
            var expectedContribution = contributingPriests.Count * (cost?.Contribution ?? 0);
            var expectedPension = beneficiaryPriests.Count * (cost?.Pension ?? 0);

            var viewModel = new DashboardViewModel
            {
                DioceseCount = dioceses.Count,
                PriestCount = priests.Count,
                Contributions = contributions.Sum(c => c.Amount),
                Pensions = pensions.Sum(p => p.Amount),
                PriestsDeceased = priests.Count(p => p.SuspensionReason == SuspensionReason.Death),
                PriestsResigned = priests.Count(p => p.SuspensionReason == SuspensionReason.Resignation),
                PriestsExcardinated = priests.Count(p => p.SuspensionReason == SuspensionReason.Excardination)

                //BeneficiaryPriest = beneficiaryPriests.Count,
                //CurrentMonthContribution = currentMonthContribution,
                //CurrentMonthExpectedContribution = expectedContribution,
                //CurrentMonthPension = currentMonthPension,
                //CurrentMonthExpectedPension = expectedPension,
                //LastContributions = contributions.OrderByDescending(c => c.Date).Take(5).ToList(),
                //LastPensions = pensions.OrderByDescending(p => p.Date).Take(5).ToList()
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
