using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Permissions;

namespace SolidarityFund.Repositories
{
    public class PensionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly PriestRepository _priestRepository;

        public PensionRepository(ApplicationDbContext context)
        {
            _context = context;
            _priestRepository = new PriestRepository(context);
        }

        public IEnumerable<Pension> GetAllPartial()
        {
            var pensions = GetCurrentYearPensions();

            // Si aucune contribution n'est trouvée pour l'année en cours, essayez l'année précédente
            if (!pensions.Any())
            {
                int year = DateTime.Now.AddYears(-1).Year;
                pensions = _context.Pensions
                    .Include(c => c.Priest.Diocese)
                    .Where(c => !c.IsDeleted && c.Year == year)
                    .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                    .ToList();
            }

            return pensions;
        }

        public IEnumerable<Pension> GetCurrentYearPensions()
        {
            int year = DateTime.Now.Year;
            var pensions = _context.Pensions
                .Include(c => c.Priest.Diocese)
                .Where(c => !c.IsDeleted && c.Year == year)
                .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                .ToList();

            return pensions;
        }

        public IEnumerable<Pension> GetAll()
        {
            return _context.Pensions
                .Include(p => p.Priest.Diocese)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Year).ThenByDescending(p => p.Month)
                .ToList();
        }

        public void Add(Pension pension)
        {
            if (pension.Amount == 0)
            {
                throw new Exception("Veuillez paramétrer les frais d'allocation avant tout enregistrement.");
            }
            if (!Exists(pension))
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    _priestRepository.UpdateLastPensionPaymentDate(pension.PriestId, pension.Date);
                    _context.Pensions.Add(pension);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            else
            {
                throw new Exception("Cette allocation a déjà été versée.");
            }
        }

        private bool Exists(Pension pension)
        {
            return _context.Pensions
                .Any(p => !p.IsDeleted && p.PriestId == pension.PriestId
                 && p.Year == pension.Year && p.Month == pension.Month && p.Amount == pension.Amount);
        }

        public PensionReportResultViewModel ReportFilter(PensionReportViewModel vm)
        {
            var model = new PensionReportResultViewModel();
            var startMonthName = vm.StartMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.StartMonth.Value) : string.Empty;
            var startYear = vm.StartYear.HasValue ? vm.StartYear.Value.ToString() : string.Empty;
            model.StartDate = $"{startMonthName} {startYear}".Trim();

            var endMonthName = vm.EndMonth.HasValue ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(vm.EndMonth.Value) : string.Empty;
            var endYear = vm.EndYear.HasValue ? vm.EndYear.Value.ToString() : string.Empty;
            model.EndDate = $"{endMonthName} {endYear}".Trim();
            
            model.Pensions = ApplyFilter(vm).ToList();

            return model;
        }

        private IEnumerable<Pension> ApplyFilter(PensionReportViewModel vm)
        {
            var pensions = _context.Pensions.Include(p => p.Priest.Diocese)
                .Where(p => !vm.StartMonth.HasValue || p.Month >= vm.StartMonth.Value)
                .Where(p => !vm.StartYear.HasValue || p.Year >= vm.StartYear.Value)
                .Where(p => !vm.EndMonth.HasValue || p.Month <= vm.EndMonth.Value)
                .Where(p => !vm.EndYear.HasValue || p.Year <= vm.EndYear.Value)
                .OrderBy(p => p.Year).ThenBy(p => p.Month);

            return pensions;
        }

        public IEnumerable<Priest> ReportFilterGroupByPriest(PensionReportViewModel vm)
        {
            var priestsEligibleForPension = _priestRepository.GetEligibleForPension();

            var priestsWithPensions = _context.Priests
                .Include(p => p.Diocese)
                .Include(p => p.Pensions.Where(pen =>
                    (!vm.StartMonth.HasValue || pen.Month >= vm.StartMonth.Value) &&
                    (!vm.StartYear.HasValue || pen.Year >= vm.StartYear.Value) &&
                    (!vm.EndMonth.HasValue || pen.Month <= vm.EndMonth.Value) &&
                    (!vm.EndYear.HasValue || pen.Year <= vm.EndYear.Value)))
                .Where(p => priestsEligibleForPension.Contains(p))
                .ToList();


            return priestsWithPensions;
        }

        public Priest ReportByPriestFilter(PensionReportByPriestViewModel vm)
        {
            var priestWithPensions = _context.Priests
                .Include(p => p.Pensions.Where(pen =>
                    (!vm.StartMonth.HasValue || pen.Month >= vm.StartMonth.Value) &&
                    (!vm.StartYear.HasValue || pen.Year >= vm.StartYear.Value) &&
                    (!vm.EndMonth.HasValue || pen.Month <= vm.EndMonth.Value) &&
                    (!vm.EndYear.HasValue || pen.Year <= vm.EndYear.Value)))
                .FirstOrDefault(p => p.Id == vm.PriestId);

            return priestWithPensions;
        }
    }
}
