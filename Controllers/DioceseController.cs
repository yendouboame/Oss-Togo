using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class DioceseController : BaseController
    {
        public IActionResult Index()
        {            
            return View(_dioceseRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Diocese diocese)
        {
            string message = string.Empty;

            try
            {
                _dioceseRepository.Create(diocese);
                message = "Diocèse ajouté avec succès";
            }
            catch (Exception ex)
            {
                message = $"Erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int dioceseId)
        {
            return Ok(_dioceseRepository.Details(dioceseId));
        }

        [HttpPost]
        public IActionResult Edit(Diocese diocese)
        {
            string message = string.Empty;
            try
            {
                _dioceseRepository.Edit(diocese);

                message = $"Informations mises à jour avec succès";
            }
            catch (Exception ex)
            {
                message = $"Erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int dioceseId)
        {
            string message = string.Empty;

            try
            {
                _dioceseRepository.Delete(dioceseId);
                message = "Informations supprimées avec succès";
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
