using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    [Authorize(Permissions.Contributions.Access)]
    public class ContributionController : BaseController
    {
        [Authorize(Permissions.Contributions.ViewAll)]
        public IActionResult Index()
        {
            return View(_contributionRepository.GetAll());
        }

        [Authorize(Permissions.Contributions.Add)]
        public IActionResult Add()
        {
            ViewBag.Priests = new SelectList(_priestRepository.GetEligibleForContribution(), "Id", "FullName");
            ViewBag.ContributionCosts = _costRepository.GetCosts()?.Contribution;

            return View();
        }

        [HttpPost]
        [Authorize(Permissions.Contributions.Add)]
        public IActionResult Add(Contribution contribution)
        {
            try
            {
                _contributionRepository.Add(contribution);

                TempData["StatusMessage"] = "Cotisation enregistrée avec succès";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur: {ex.Message}";
                return RedirectToAction(nameof(Add));
            }
        }
    }
}
