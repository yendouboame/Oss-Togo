using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    [Authorize(Permissions.Priests.Access)]
    public class PriestController : BaseController
    {
        private void GetSelectList()
        {
            ViewBag.Dioceses = new SelectList(_dioceseRepository.GetAll(), "Id", "Name");
            ViewBag.Priests = new SelectList(_priestRepository.GetAll(), "Id", "FullName");
        }

        [Authorize(Permissions.Priests.Access)]
        public IActionResult Index()
        {
            return View(_priestRepository.GetAll());
        }

        [Authorize(Permissions.Priests.Create)]
        public IActionResult Create()
        {
            GetSelectList();
            return View();
        }

        [HttpPost]
        [Authorize(Permissions.Priests.Create)]
        public IActionResult Create(Priest priest)
        {
            string message = string.Empty;

            try
            {
                _priestRepository.Create(priest);
                message = "Prêtre enregistré avec succès.";
            }
            catch (Exception ex)
            {
                message = $"Erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Permissions.Priests.Edit)]
        public IActionResult Edit(int priestId)
        {
            GetSelectList();
            return View(_priestRepository.Details(priestId));
        }

        [HttpPost]
        [Authorize(Permissions.Priests.Edit)]
        public IActionResult Edit(Priest priest)
        {
            try
            {
                _priestRepository.Edit(priest);

                TempData["StatusMessage"] = $"Informations mises à jour avec succès.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur: {ex.Message}";
                return View(priest);
            }
        }

        [HttpPost]
        [Authorize(Permissions.Priests.Delete)]
        public IActionResult Delete(int priestId)
        {
            string message = string.Empty;

            try
            {
                _priestRepository.Delete(priestId);
                message = "Informations supprimées avec succès.";
            }
            catch (Exception ex)
            {
                message = $"Erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Permissions.Priests.Suspend)]
        public IActionResult Suspend()
        {
            GetSelectList();
            return View();
        }

        [HttpPost]
        [Authorize(Permissions.Priests.Suspend)]
        public IActionResult Suspend(SuspendPriestViewModel viewModel)
        {
            try
            {
                _priestRepository.SuspendPriest(viewModel);

                TempData["StatusMessage"] = "Fin des actions enregistrée avec succès.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur: {ex.Message}";
                return RedirectToAction(nameof(Suspend));
            }
        }
    }
}
