using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // Déterminez d'abord l'année pour laquelle récupérer les contributions
            int year = DateTime.Now.Year;
            var pensions = _context.Pensions
                .Include(c => c.Priest.Diocese)
                .Where(c => !c.IsDeleted && c.Year == year)
                .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                .ToList();

            // Si aucune contribution n'est trouvée pour l'année en cours, essayez l'année précédente
            if (!pensions.Any())
            {
                year = DateTime.Now.AddYears(-1).Year;
                pensions = _context.Pensions
                    .Include(c => c.Priest.Diocese)
                    .Where(c => !c.IsDeleted && c.Year == year)
                    .OrderByDescending(c => c.Year).ThenByDescending(c => c.Month)
                    .ToList();
            }

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

        public IEnumerable<Pension> ReportFilter(PensionReportViewModel pensionReport)
        {
            var pensions = GetAll().ToList();

            pensions = pensions
                .Where(p => !pensionReport.StartDate.HasValue || p.Date >= pensionReport.StartDate.Value)
                .Where(p => !pensionReport.EndDate.HasValue || p.Date <= pensionReport.EndDate.Value)
                .ToList();

            return pensions;
        }

        public IEnumerable<IGrouping<Priest, Pension>> ReportFilterGroupByPriest(PensionReportViewModel pensionReport)
        {
            var pensions = GetAll().ToList();

            pensions = pensions
                .Where(p => !pensionReport.StartDate.HasValue || p.Date >= pensionReport.StartDate.Value)
                .Where(p => !pensionReport.EndDate.HasValue || p.Date <= pensionReport.EndDate.Value)
                .ToList();

            var groupedByPriest = pensions.GroupBy(p => p.Priest);

            return groupedByPriest;
        }

        public IEnumerable<Pension> ReportByPriestFilter(PensionReportByPriestViewModel pensionReport)
        {
            var pensions = GetAll()
                .Where(p => p.PriestId == pensionReport.PriestId)
                .Where(p => !pensionReport.StartDate.HasValue || p.Date >= pensionReport.StartDate.Value)
                .Where(p => !pensionReport.EndDate.HasValue || p.Date <= pensionReport.EndDate.Value)
                .ToList();

            return pensions;
        }
    }
}
