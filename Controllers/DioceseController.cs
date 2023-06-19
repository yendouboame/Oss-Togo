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
    [Authorize(Permissions.Dioceses.Access)]
    public class DioceseController : BaseController
    {
        [Authorize(Permissions.Dioceses.Access)]
        public IActionResult Index()
        {            
            return View(_dioceseRepository.GetAll());
        }

        [HttpPost]
        [Authorize(Permissions.Dioceses.Create)]
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
        [Authorize(Permissions.Dioceses.Edit)]
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
        [Authorize(Permissions.Dioceses.Delete)]
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

        [HttpPost]
        [Authorize(Permissions.Dioceses.ImportData)]
        public IActionResult ImportData(int dioceseId)
        {
            return View();
        }
    }
}