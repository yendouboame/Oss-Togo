using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
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
            var file = Request.Form.Files.FirstOrDefault();
            string message = string.Empty;

            try
            { 
                using (var package = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var priests = new List<Priest>();

                    int startRow = FindStartRow(worksheet);

                    if (startRow == -1)
                        throw new Exception("Erreur de fichier.");

                    for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                    {
                        // Accédez aux cellules et récupérez les valeurs
                        var cell2Value = worksheet.Cells[row, 2].Value?.ToString(); // Exemple : valeur de la deuxième colonne
                        var cell3Value = worksheet.Cells[row, 3].GetValue<DateTime>(); // Exemple : valeur de la troisième colonne en tant que date
                        var cell4Value = worksheet.Cells[row, 4].GetValue<DateTime>(); // Exemple : valeur de la quatrième colonne en tant que date

                        var priest = new Priest
                        {
                            FullName = cell2Value,
                            DateOfBirth = cell3Value,
                            OrdinationDate = cell4Value,
                            DioceseId = dioceseId
                        };
                        priests.Add(priest);
                    }

                    _context.Priests.AddRange(priests);
                    _context.SaveChanges();

                    message = "Importation effectuée avec succès.";
                }
            }
            catch (Exception ex)
            { 
                message = $"Erreur lors de l'importation des données. Message d'erreur: {ex.Message}";
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }


        private int FindStartRow(ExcelWorksheet worksheet)
        {
            const string expectedHeaderText = "N°";
            int startRow = -1; // Par défaut, commencez à la première ligne

            for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                var cellValue = worksheet.Cells[row, 1].Value?.ToString();
                if (cellValue == expectedHeaderText)
                {
                    startRow = row + 1; // La ligne suivante est la ligne de départ des données
                    break;
                }
            }

            return startRow;
        }
    }
}