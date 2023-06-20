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
    [Authorize(Permissions.Pensions.Access)]
    public class PensionController : BaseController
    {
        [Authorize(Permissions.Pensions.ViewAll)]
        public IActionResult Index()
        {
            return View(_pensionRepository.GetAll());
        }

        [Authorize(Permissions.Pensions.Add)]
        public IActionResult EligiblePriests()
        {
            return View(_priestRepository.GetEligibleForPension());
        }

        [HttpPost]
        [Authorize(Permissions.Pensions.Add)]
        public IActionResult New(Pension pension)
        {
            try
            {
                _pensionRepository.New(pension);

                TempData["StatusMessage"] = "Pension enregistrée avec succès";
                return RedirectToAction(nameof(EligiblePriests));
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur: {ex.Message}";
                return RedirectToAction(nameof(New));
            }
        }
    }
}
