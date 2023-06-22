using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SolidarityFund.Helpers.Constants;
using SolidarityFund.Helpers.Functions;
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

        [Authorize(Permissions.Contributions.DownloadFile)]
        public ActionResult DownloadExcelFile(int dioceseId)
        {
            var diocese = _context.Dioceses.Find(dioceseId);
            var priests = _priestRepository.GetEligibleForContribution().Where(p => p.DioceseId == dioceseId).ToList();
            var cost = _costRepository.GetCosts();

            // Create a new Excel package
            using (ExcelPackage package = new ExcelPackage())
            {
                // Add a worksheet to the package
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Fiche de cotisations");

                // Add header text
                string headerText = $"Fiche de cotisations du {diocese.Name}";
                worksheet.Cells["A1"].Value = headerText;
                worksheet.Cells["A1:C1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Bold = true;

                // Set the range for the header text
                ExcelRange headerRange = worksheet.Cells["A1:C1"];
                headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                headerRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Add data to the worksheet
                worksheet.Cells["A3"].Value = "Date de la cotisation (JJ/MM/AAAA)";
                worksheet.Cells["B3"].Value = "Nom et prénom(s) du prêtre";
                worksheet.Cells["C3"].Value = "Montant de la cotisation";

                // Set the range for the data
                ExcelRange dataRange = worksheet.Cells["A3:C3"];
                dataRange.Style.Font.Bold = true;
                dataRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                dataRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                dataRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                // Add data to the worksheet starting from row 4
                int startRow = 4;
                for (int i = 0; i < priests.Count; i++)
                {
                    var priest = priests[i];
                    int row = startRow + i;

                    worksheet.Cells["B" + row].Value = priest.FullName;
                    worksheet.Cells["C" + row].Value = $"{StringHelpers.FormatNumberWithSpaces(cost.Contribution)} XOF";
                    // Auto-fit the columns
                    worksheet.Cells["B" + row].AutoFitColumns();
                }

                // Set the range for the data
                ExcelRange priestRange = worksheet.Cells[startRow, 1, startRow + priests.Count - 1, 3];
                dataRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                // Set the default font style and size for the entire workbook
                worksheet.Cells[worksheet.Dimension.Address].Style.Font.Name = "Times New Roman";
                worksheet.Cells[worksheet.Dimension.Address].Style.Font.Size = 16;

                // Auto-fit the columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Convert the package to a byte array
                byte[] fileBytes = package.GetAsByteArray();

                // Determine the content type of the Excel file
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                // Set the desired file name
                string fileName = $"cotisations_{DateTime.Now:MMMM_yyyy}.xlsx";

                // Return the Excel file as a download
                return File(fileBytes, contentType, fileName);
            }
        }

        [Authorize(Permissions.Contributions.ImportData)]
        public IActionResult ImportData()
        {
            ViewBag.Dioceses = new SelectList(_dioceseRepository.GetAll(), "Id", "Name");
            return View();
        }

        [Authorize(Permissions.Contributions.ImportData)]
        [HttpPost]
        public IActionResult ImportData(int dioceseId)
        {
            var file = Request.Form.Files.FirstOrDefault();
            string message = string.Empty;

            try
            {
                using (var package = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var cost = _costRepository.GetCosts();
                    var contributions = new List<Contribution>();

                    int startRow = FindStartRow(worksheet);
                    if (startRow == -1)
                        throw new Exception("Erreur de fichier.");

                    for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var cell1 = worksheet.Cells[row, 1];
                        var cell2 = worksheet.Cells[row, 2];

                        var cell1Value = cell1.GetValue<DateTime>();
                        var cell2Value = cell2.Value?.ToString();

                        if (cell1Value == DateTime.MinValue)
                            throw new Exception($"La valeur de la cellule {cell1.Address} est vide.");

                        var priest = _context.Priests.FirstOrDefault(p => p.FullName == cell2Value);

                        if (row == startRow && priest.DioceseId != dioceseId)
                            throw new Exception("Ces prêtres n'appartiennent pas au diocèse sélectionné.");

                        var contribution = new Contribution
                        {
                            Date = cell1Value,
                            PriestId = priest.Id,
                            Amount = cost.Contribution
                        };

                        if (_contributionRepository.Exists(contribution))
                            throw new Exception("Certaines de ces cotisations ont déjà été enregistrées. Veuillez mettre à jour le fichier.");

                        contributions.Add(contribution);
                    }

                    _context.Contributions.AddRange(contributions);
                    _context.SaveChanges();

                    message = "Importation effectuée avec succès.";
                }
            }
            catch (Exception ex)
            {
                message = $"Erreur lors de l'importation des données. Message d'erreur: {ex.Message}";
                TempData["StatusMessage"] = message;
                return RedirectToAction(nameof(ImportData), new { dioceseId = dioceseId });
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }


        private int FindStartRow(ExcelWorksheet worksheet)
        {
            const string expectedHeaderText = "Date de la cotisation (JJ/MM/AAAA)";
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
