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
    public class ContributionsController : BaseController
    {
        [Authorize(Permissions.Contributions.ViewAll)]
        public IActionResult Index()
        {
            return View(_contributionRepository.GetAll());
        }

        [Authorize(Permissions.Contributions.Add)]
        public IActionResult Add()
        {
            GetMonthSelectList();
            GetEligiblePriestForContributionSelectList();
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

            try
            { 
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
            catch
            {
                TempData["StatusMessage"] = $"Erreur: Veuillez d'abord paramétrer les frais de cotisations.";
                return RedirectToAction("Index", "Diocese");
            }
        }

        [Authorize(Permissions.Contributions.ImportData)]
        public IActionResult ImportData()
        {
            GetDioceseSelectList();
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
                _contributionRepository.ImportData(file, dioceseId);
                message = "Cotisations enregistrées avec succès.";
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Erreur lors de l'importation des données: {ex.Message}";
                return RedirectToAction(nameof(ImportData));
            }

            TempData["StatusMessage"] = message;
            return RedirectToAction(nameof(Index));
        }        
    }
}
