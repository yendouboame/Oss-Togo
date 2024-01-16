using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Repositories
{
    public class ContributionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly CostRepository _costRepository;

        public ContributionRepository(ApplicationDbContext context)
        {
            _context = context;
            _costRepository = new CostRepository(context);
        }

        public IEnumerable<Contribution> GetAllPartial()
        {
            var contributions = GetCurrentYearContributions();

            // Si aucune contribution n'est trouvée pour l'année en cours, essayez l'année précédente
            if (!contributions.Any())
            {
                int year = DateTime.Now.AddYears(-1).Year;
                contributions = _context.Contributions
                    .Include(c => c.Priest.Diocese)
                    .Where(c => !c.IsDeleted && c.Year == year)
                    .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                    .ToList();
            }

            return contributions;
        }

        public IEnumerable<Contribution> GetCurrentYearContributions()
        {
            int year = DateTime.Now.Year;
            var contributions = _context.Contributions
                .Include(c => c.Priest.Diocese)
                .Where(c => !c.IsDeleted && c.Year == year)
                .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                .ToList();

            return contributions;
        }

        public IEnumerable<Contribution> GetAll()
        {
            var contributions = _context.Contributions
                .Include(c => c.Priest.Diocese)
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                .ToList();
            return contributions;
        }


        public void Add(Contribution contribution)
        {
            if (contribution.Amount == 0)
            {
                throw new Exception("Veuillez paramétrer les frais de cotisation avant tout enregistrement.");
            }
            if (!Exists(contribution))
            {
                _context.Contributions.Add(contribution);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cette cotisation a déjà été enregistrée");
            }
        }

        public bool Exists(Contribution contribution)
        {
            return _context.Contributions
                .Any(c => !c.IsDeleted && c.PriestId == contribution.PriestId
                 && c.Month == contribution.Month && c.Year == contribution.Year && c.Amount == contribution.Amount);
        }

        public void ImportData(IFormFile file, int dioceseId)
        {
            if (file == null) { throw new Exception("Fichier non disponible."); }
            var cost = _costRepository.GetCosts();
            var contributions = new List<Contribution>();

            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    try
                    {
                        var sheetName = worksheet.Name;
                        var year = GetContributionYear(sheetName);
                        var month = GetContributionMonth(sheetName);

                        int startRow = FindStartRow(worksheet);
                        if (startRow == -1)
                            throw new Exception("Erreur de fichier.");

                        for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                        {
                            var cell2 = worksheet.Cells[row, 2];
                            var cell2Value = cell2.Value?.ToString();

                            if (cell2Value == null) break;

                            var priest = _context.Priests.FirstOrDefault(p => p.FullName == cell2Value);

                            if (priest.DioceseId != dioceseId)
                                throw new Exception("Ces prêtres n'appartiennent pas au diocèse sélectionné.");

                            var contribution = new Contribution();
                            contribution.PriestId = priest.Id;
                            contribution.Month = month;
                            contribution.Year = year;
                            contribution.Amount = cost.Contribution;

                            if (Exists(contribution))
                            {
                                throw new Exception("Certaines de ces cotisations ont déjà été enregistrées. Veuillez mettre à jour le fichier.");
                            }

                            contributions.Add(contribution);
                        }
                    }
                    catch (Exception ex)
                    {
                        var message = new Exception($"Erreur dans la feuille {worksheet.Name}: {ex.Message}");
                        throw message;
                    }
                }

                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    _context.Contributions.AddRange(contributions);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
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

        private int GetContributionYear(string sheetName)
        {
            // Vérifiez si sheetName est null ou sa longueur est inférieure à 4
            if (string.IsNullOrEmpty(sheetName) || sheetName.Length < 4)
            {
                throw new ArgumentException("Le nom de la feuille est invalide.");
            }

            // Extrait les quatre derniers caractères
            string yearPart = sheetName.Substring(sheetName.Length - 4);

            // Essayez de convertir cette partie en un entier
            if (int.TryParse(yearPart, out int year))
            {
                return year;
            }
            else
            {
                throw new ArgumentException("L'année extraite du nom de la feuille n'est pas un nombre valide.");
            }
        }

        private int GetContributionMonth(string sheetName)
        {
            if (string.IsNullOrEmpty(sheetName) || sheetName.Length < 8)
            {
                throw new ArgumentException("Le nom de la feuille est invalide.");
            }

            // Extrait la partie du mois
            string monthPart = sheetName.Substring(0, sheetName.Length - 4);
            monthPart = RemoveDiacritics(monthPart.Trim()).ToLower();

            // Obtient les noms des mois en français
            var frenchCultureInfo = new CultureInfo("fr-FR");
            var monthNames = frenchCultureInfo.DateTimeFormat.MonthNames;

            // Parcourt les noms des mois pour trouver une correspondance
            for (int i = 0; i < monthNames.Length; i++)
            {
                string formattedMonthName = RemoveDiacritics(monthNames[i].ToLower());
                if (formattedMonthName.StartsWith(monthPart))
                {
                    return i + 1; // Les mois commencent à 1, donc ajoutez 1 à l'index
                }
            }

            throw new ArgumentException("Le mois extrait n'est pas reconnu.");
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public ContributionReportResultViewModel ReportFilter(ContributionReportViewModel vm)
        {
            var model = new ContributionReportResultViewModel();
            var startMonthName = vm.StartMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.StartMonth.Value) : string.Empty;
            var startYear = vm.StartYear.HasValue ? vm.StartYear.Value.ToString() : string.Empty;
            model.StartDate = $"{startMonthName} {startYear}".Trim();

            var endMonthName = vm.EndMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.EndMonth.Value) : string.Empty;
            var endYear = vm.EndYear.HasValue ? vm.EndYear.Value.ToString() : string.Empty;
            model.EndDate = $"{endMonthName} {endYear}".Trim();

            model.Contributions = ApplyFilter(vm).ToList();
            return model;
        }

        public ContributionReportGroupByPriestResultViewModel ReportFilterGroupByPriest(ContributionReportViewModel vm)
        {
            var model = new ContributionReportGroupByPriestResultViewModel();
            var startMonthName = vm.StartMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.StartMonth.Value) : string.Empty;
            var startYear = vm.StartYear.HasValue ? vm.StartYear.Value.ToString() : string.Empty;
            model.StartDate = $"{startMonthName} {startYear}".Trim();

            var endMonthName = vm.EndMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.EndMonth.Value) : string.Empty;
            var endYear = vm.EndYear.HasValue ? vm.EndYear.Value.ToString() : string.Empty;
            model.EndDate = $"{endMonthName} {endYear}".Trim();

            model.Contributions = ApplyFilter(vm).GroupBy(c => c.Priest);
            return model;
        }

        public ContributionReportGroupByDioceseResultViewModel ReportFilterGroupByDiocese(ContributionReportViewModel vm)
        {
            var model = new ContributionReportGroupByDioceseResultViewModel();
            var startMonthName = vm.StartMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.StartMonth.Value) : string.Empty;
            var startYear = vm.StartYear.HasValue ? vm.StartYear.Value.ToString() : string.Empty;
            model.StartDate = $"{startMonthName} {startYear}".Trim();

            var endMonthName = vm.EndMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.EndMonth.Value) : string.Empty;
            var endYear = vm.EndYear.HasValue ? vm.EndYear.Value.ToString() : string.Empty;
            model.EndDate = $"{endMonthName} {endYear}".Trim();

            var result = ApplyFilter(vm);

            model.Contributions = result.GroupBy(c => c.Priest.Diocese);
            return model;
                
        }

        private IEnumerable<Contribution> ApplyFilter(ContributionReportViewModel vm)
        {
            var contributions = _context.Contributions
                .Include(c => c.Priest.Diocese)
                .Where(c =>
                    (!vm.StartMonth.HasValue || c.Month >= vm.StartMonth.Value) &&
                    (!vm.StartYear.HasValue || c.Year >= vm.StartYear.Value) &&
                    (!vm.EndMonth.HasValue || c.Month <= vm.EndMonth.Value) &&
                    (!vm.EndYear.HasValue || c.Year <= vm.EndYear.Value))
                .OrderBy(c => c.Year).ThenBy(c => c.Month)
                .ToList();
                
            return contributions;
        }


        public Priest ReportByPriestFilter(ContributionReportByPriestViewModel vm)
        {
            var priest = _context.Priests
                .Include(p => p.Contributions.Where(con =>
                    (!vm.StartMonth.HasValue || con.Month >= vm.StartMonth.Value) &&
                    (!vm.StartYear.HasValue || con.Year >= vm.StartYear.Value) &&
                    (!vm.EndMonth.HasValue || con.Month <= vm.EndMonth.Value) &&
                    (!vm.EndYear.HasValue || con.Year <= vm.EndYear.Value)))
                .FirstOrDefault(p => p.Id == vm.PriestId);

            return priest;
        }

        public IEnumerable<Contribution> ReportByDioceseFilter(ContributionReportByDioceseViewModel vm)
        {
            var query = _context.Contributions
                .AsNoTracking() // Si vous ne modifiez pas ces entités
                .Include(c => c.Priest.Diocese)
                .Where(c => c.Priest.DioceseId == vm.DioceseId &&
                            (!vm.StartMonth.HasValue || c.Month >= vm.StartMonth.Value) &&
                            (!vm.StartYear.HasValue || c.Year >= vm.StartYear.Value) &&
                            (!vm.EndMonth.HasValue || c.Month <= vm.EndMonth.Value) &&
                            (!vm.EndYear.HasValue || c.Year <= vm.EndYear.Value));

            return query.ToList();
        }
    }
}
