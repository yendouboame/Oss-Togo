using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    [Authorize(Permissions.Settings.ManageCosts)]
    public class CostController : BaseController
    {
        [Authorize(Permissions.Settings.ManageCosts)]
        public IActionResult Index()
        {
            return View(_costRepository.GetCosts());
        }

        [HttpPost]
        [Authorize(Permissions.Settings.ManageCosts)]
        public IActionResult Update(Cost cost)
        {
            string message = string.Empty;

            try
            {
                _costRepository.UpdateCosts(cost);

                message = "Frais mis à jour avec succès.";
            }
            catch (Exception ex)
            {
                message = $"Erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }
    }
}
