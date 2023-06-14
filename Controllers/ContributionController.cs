using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class ContributionController : BaseController
    {
        public IActionResult Index()
        {
            return View(_contributionRepository.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Priests = new SelectList(_priestRepository.GetEligiblePriestsForContribution(), "Id", "FullName");
            return View();
        }

        [HttpPost]
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
