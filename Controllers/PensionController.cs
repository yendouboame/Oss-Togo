using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class PensionController : BaseController
    {
        public IActionResult Index()
        {
            return View(_pensionRepository.GetAll());
        }

        public IActionResult New()
        {
            ViewBag.Priests = new SelectList(_priestRepository.GetEligiblePriestsForPension(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult New(Pension pension)
        {
            try
            {
                _pensionRepository.New(pension);

                TempData["StatusMessage"] = "Pension enregistrée avec succès";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur: {ex.Message}";
                return RedirectToAction(nameof(New));
            }
        }
    }
}
