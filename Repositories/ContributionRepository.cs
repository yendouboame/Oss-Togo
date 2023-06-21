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
    public class ContributionRepository
    {
        private readonly ApplicationDbContext _context;

        public ContributionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contribution> GetAll()
        {
            return _context.Contributions
                .Include(c => c.Priest).ThenInclude(p => p.Diocese)
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.Date)
                .ToList();
        }

        public void Add(Contribution contribution)
        {
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

        private bool Exists(Contribution contribution)
        {
            return _context.Contributions
                .Any(c => !c.IsDeleted && c.PriestId == contribution.PriestId
                 && c.Date == contribution.Date && c.Ammount == contribution.Ammount);
        }

        public IEnumerable<Contribution> ReportFilter(ContributionReportViewModel contributionReport)
        {
            var contributions = GetAll().ToList();

            contributions = contributions
                .Where(c => !contributionReport.StartDate.HasValue || c.Date >= contributionReport.StartDate.Value)
                .Where(c => !contributionReport.EndDate.HasValue || c.Date <= contributionReport.EndDate.Value)
                .ToList();

            return contributions;
        }

        public IEnumerable<IGrouping<Priest, Contribution>> ReportFilterGroupByPriest(ContributionReportViewModel contributionReport)
        {
            var contributions = GetAll().ToList();

            contributions = contributions
                .Where(c => !contributionReport.StartDate.HasValue || c.Date >= contributionReport.StartDate.Value)
                .Where(c => !contributionReport.EndDate.HasValue || c.Date <= contributionReport.EndDate.Value)
                .OrderByDescending(c => c.Date)
                .ToList();
            
            var groupedByPriest = contributions.GroupBy(c => c.Priest);

            return groupedByPriest;
        }

        public IEnumerable<IGrouping<Diocese, Contribution>> ReportFilterGroupByDiocese(ContributionReportViewModel contributionReport)
        {
            var contributions = _context.Contributions
                .Include(c => c.Priest).ThenInclude(p => p.Diocese)
                .Where(c => !c.IsDeleted)
                .ToList();

            contributions = contributions
                .Where(c => !contributionReport.StartDate.HasValue || c.Date >= contributionReport.StartDate.Value)
                .Where(c => !contributionReport.EndDate.HasValue || c.Date <= contributionReport.EndDate.Value)
                .OrderByDescending(c => c.Date)
                .ToList();

            var groupedByDiocese = contributions.GroupBy(c => c.Priest.Diocese);

            return groupedByDiocese;
        }

        public IEnumerable<Contribution> ReportByPriestFilter(ContributionReportByPriestViewModel contributionReport)
        {
            var contributions = GetAll()
                .Where(c => c.PriestId == contributionReport.PriestId)
                .Where(c => !contributionReport.StartDate.HasValue || c.Date >= contributionReport.StartDate.Value)
                .Where(c => !contributionReport.EndDate.HasValue || c.Date <= contributionReport.EndDate.Value)
                .ToList();

            return contributions;
        }

        public IEnumerable<Contribution> ReportByDioceseFilter(ContributionReportByDioceseViewModel contributionReport)
        {
            var contributions = GetAll()
                .Where(c => c.Priest.DioceseId == contributionReport.DioceseId)
                .Where(c => !contributionReport.StartDate.HasValue || c.Date >= contributionReport.StartDate.Value)
                .Where(c => !contributionReport.EndDate.HasValue || c.Date <= contributionReport.EndDate.Value)
                .ToList();

            return contributions;
        }
    }
}
