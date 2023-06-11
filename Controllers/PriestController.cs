using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class PriestController : BaseController
    {
        private void GetSelectList()
        {
            ViewBag.Dioceses = new SelectList(_dioceseRepository.GetAll().ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            GetSelectList();
            return View(_priestRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Priest priest)
        {
            string message = string.Empty;

            try
            {
                _priestRepository.Create(priest);
                message = "Prêtre enregistré avec succès";
            }
            catch (Exception ex)
            {
                message = $"Erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int priestId)
        {
            GetSelectList();
            return View(_priestRepository.Details(priestId));
        }

        [HttpPost]
        public IActionResult Edit(Priest priest)
        {
            try
            {
                _priestRepository.Edit(priest);

                TempData["StatusMessage"] = $"Informations mises à jour avec succès";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur: {ex.Message}";
                return View(priest);
            }
        }

        [HttpPost]
        public IActionResult Delete(int priestId)
        {
            string message = string.Empty;

            try
            {
                _priestRepository.Delete(priestId);
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
