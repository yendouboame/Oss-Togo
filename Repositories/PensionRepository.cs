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

        public PensionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pension> GetAll()
        {
            return _context.Pensions
                .Include(p => p.Priest)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Date)
                .ToList();
        }

        public void New(Pension pension)
        {
            if (!Exists(pension))
            {
                _context.Pensions.Add(pension);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cette pension a déjà été allouée");
            }
        }

        public bool Exists(Pension pension)
        {
            return _context.Pensions
                .Any(p => !p.IsDeleted && p.PriestId == pension.PriestId
                 && p.Date == pension.Date && p.Amount == pension.Amount);
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
