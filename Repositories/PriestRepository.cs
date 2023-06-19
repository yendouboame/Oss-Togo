using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using SolidarityFund.Helpers;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Repositories
{
    public class PriestRepository
    {
        private readonly ApplicationDbContext _context;

        public PriestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Priest> GetAll()
        {
            return _context.Priests
                .Include(p => p.Diocese)
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.FullName)
                .ToList();
        }

        public void Create(Priest priest)
        {
            _context.Priests.Add(priest);
            _context.SaveChanges();
        }

        public Priest Details(int priestId)
        {
            return _context.Priests
                .FirstOrDefault(p => p.Id == priestId);
        }

        public void Edit(Priest priest)
        {
            var old = _context.Priests.Find(priest.Id);

            old.FullName = priest.FullName;
            old.DateOfBirth = priest.DateOfBirth;
            old.OrdinationDate = priest.OrdinationDate;
            old.DioceseId = priest.DioceseId;

            _context.SaveChanges();
        }

        public void Delete(int priestId)
        {
            var priest = _context.Priests.Find(priestId);

            priest.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Priest> GetEligiblePriestsForContribution()
        {
            var allPriests = GetAll();
            var eligiblePriests = new List<Priest>();

            foreach (var priest in allPriests)
            {
                if (priest.Age < 70 && DateTime.Now >= priest.OrdinationDate.AddMonths(1))
                {
                    eligiblePriests.Add(priest);
                }
                else if (priest.Age == 70 && DateTime.Now < priest.DateOfBirth.AddYears(70).AddMonths(1))
                {
                    eligiblePriests.Add(priest);
                }
            }

            return eligiblePriests;
        }

        public IEnumerable<Priest> GetEligiblePriestsForPension()
        {
            var allPriests = _context.Priests
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.FullName)
                .ToList();

            foreach (var priest in allPriests)
            {
                priest.Pensions = _context.Pensions
                    .Where(p => p.PriestId == priest.Id)
                    .OrderByDescending(p => p.Date)
                    .Take(1)
                    .ToList();
            }

            var eligiblePriests = allPriests.Where(priest =>
                priest.Age >= 70 &&
                DateTime.Now >= priest.DateOfBirth.AddYears(70).AddMonths(1)
            ).ToList();

            return eligiblePriests;
        }


        /*public IEnumerable<Priest> GetEligiblePriestsForPension()
        {
            var allPriests = GetAll();
            var eligiblePriests = new List<Priest>();

            foreach (var priest in allPriests)
            {
                int age = CalculateAge(priest.DateOfBirth);

                if (age == 70 && DateTime.Now > priest.DateOfBirth.AddYears(70).AddMonths(1))
                {
                    eligiblePriests.Add(priest);
                }
                else if (age > 70)
                {
                    eligiblePriests.Add(priest);
                }
            }

            return eligiblePriests;
        }*/

        //public IEnumerable<Priest> ReportFilter(PriestReportViewModel priestReport)
        //{
        //    var priests = GetAll().ToList();

        //    if (priestReport.DoBStartDate.HasValue)
        //    {
        //        priests = priests.Where(p => p.DateOfBirth >= priestReport.DoBStartDate.Value).ToList();
        //    }

        //    if (priestReport.DoBEndDate.HasValue)
        //    {
        //        priests = priests.Where(p => p.DateOfBirth <= priestReport.DoBEndDate.Value).ToList();
        //    }

        //    if (priestReport.Age.HasValue)
        //    {
        //        var age = priestReport.Age.Value;

        //        priests = age switch
        //        {
        //            Enums.PriestAgeInterval.LessThanSeventy => priests.Where(p => CalculateAge(p.DateOfBirth) < 70).ToList(),
        //            Enums.PriestAgeInterval.Seventy => priests.Where(p => CalculateAge(p.DateOfBirth) == 70).ToList(),
        //            _ => priests.Where(p => CalculateAge(p.DateOfBirth) > 70).ToList()
        //        };
        //    }

        //    if (priestReport.OrdinationStartDate.HasValue)
        //    {
        //        priests = priests.Where(p => p.OrdinationDate >= priestReport.OrdinationStartDate.Value).ToList();
        //    }

        //    if (priestReport.OrdinationEndDate.HasValue)
        //    {
        //        priests = priests.Where(p => p.OrdinationDate <= priestReport.OrdinationEndDate.Value).ToList();
        //    }

        //    return priests;
        //}

        public IEnumerable<Priest> ReportFilter(PriestReportViewModel priestReport)
        {
            var priests = GetAll().ToList();

            priests = priests
                .Where(p => !priestReport.DoBStartDate.HasValue || p.DateOfBirth >= priestReport.DoBStartDate.Value)
                .Where(p => !priestReport.DoBEndDate.HasValue || p.DateOfBirth <= priestReport.DoBEndDate.Value)
                .Where(p => !priestReport.Age.HasValue ||
                    (priestReport.Age == PriestAgeInterval.LessThanSeventy && p.Age < 70) ||
                    (priestReport.Age == PriestAgeInterval.Seventy && p.Age == 70) ||
                    (priestReport.Age == PriestAgeInterval.MoreThanSeventy && p.Age > 70))
                .Where(p => !priestReport.OrdinationStartDate.HasValue || p.OrdinationDate >= priestReport.OrdinationStartDate.Value)
                .Where(p => !priestReport.OrdinationEndDate.HasValue || p.OrdinationDate <= priestReport.OrdinationEndDate.Value)
                .ToList();

            return priests;
        }

        public IEnumerable<IGrouping<Diocese, Priest>> ReportByDioceseFilter(List<CheckBoxViewModel> dioceses)
        {
            var selectedDioceses = dioceses
                .Where(d => d.IsSelected)
                .Select(d => d.ValueCode)
                .ToList();

            var priests = _context.Priests
                .Include(p => p.Diocese)
                .Where(p => !p.IsDeleted && selectedDioceses.Contains(p.Diocese.Id))
                .ToList();

            var groupedByDiocese = priests.GroupBy(p => p.Diocese);

            return groupedByDiocese;
        }
    }
}
