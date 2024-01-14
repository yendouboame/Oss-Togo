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

        public IEnumerable<Priest> GetUnsuspended()
        {
            return _context.Priests
                .Include(p => p.Diocese)
                .Where(p => !p.IsDeleted && p.SuspensionReason == null)
                .OrderBy(p => p.FullName)
                .ToList();
        }

        public IEnumerable<Priest> GetSuspended()
        {
            return _context.Priests
                .Include(p => p.Diocese)
                .Where(p => !p.IsDeleted && p.SuspensionReason != null)
                .OrderBy(p => p.FullName)
                .ToList();
        }

        public bool Exists(Priest priest)
        {
            return _context.Priests.Any(p =>
            !p.IsDeleted && p.FullName == priest.FullName 
            && p.DateOfBirth == priest.DateOfBirth && p.OrdinationDate == priest.OrdinationDate);
        }

        public void Create(Priest priest)
        {
            if (!Exists(priest))
            { 
                _context.Priests.Add(priest);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Ce prêtre est déjà enregistré");
            }
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
            old.IsIncardinated = priest.IsIncardinated;

            _context.SaveChanges();
        }

        public void Delete(int priestId)
        {
            var priest = _context.Priests.Find(priestId);

            priest.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Priest> GetEligibleForContribution()
        {
            var currentDate = DateTime.Now;
            var eligiblePriests = new List<Priest>();

            foreach (var priest in GetAll())
            {
                bool isEligible = false;

                if (priest.Age < 70)
                {
                    if (priest.IsIncardinated)
                    {
                        isEligible = true;
                    }
                    else if (currentDate >= priest.OrdinationDate.AddMonths(1))
                    {
                        isEligible = true;
                    }
                }
                else if (priest.Age == 70 && currentDate < priest.DateOfBirth.AddYears(70).AddMonths(1))
                {
                    isEligible = true;
                }

                if (isEligible)
                {
                    eligiblePriests.Add(priest);
                }
            }

            return eligiblePriests;
        }

        public IEnumerable<Priest> GetEligibleForPension()
        {
            var currentDate = DateTime.Now;
            var eligiblePriests = new List<Priest>();

            var allPriests = _context.Priests
                .Include(p => p.Pensions)
                .Where(p => !p.IsDeleted && p.SuspensionReason == null)
                .OrderBy(p => p.FullName)
                .ToList();

            foreach (var priest in allPriests)
            {
                if (priest.Age >= 70 && currentDate >= priest.DateOfBirth.AddYears(70).AddMonths(1))
                {
                    priest.Pensions = _context.Pensions
                        .Where(p => p.PriestId == priest.Id)
                        .OrderByDescending(p => p.Year).ThenByDescending(p => p.Month)
                        .Take(1)
                        .ToList();

                    eligiblePriests.Add(priest);
                }
            }

            return eligiblePriests;
        }

        public void UpdateLastPensionPaymentDate(int priestId, DateTime paymentDate)
        {
            var priest = _context.Priests.SingleOrDefault(p => p.Id == priestId);
            if (priest == null)
            {
                throw new Exception("Prêtre introuvable.");
            }

            // Mettez à jour la date seulement si elle est plus récente
            if (priest.LastPensionPaymentDate == null || priest.LastPensionPaymentDate < paymentDate)
            {
                priest.LastPensionPaymentDate = paymentDate;
            }
        }


        public PriestReportResultViewModel ReportFilter(PriestReportViewModel vm)
        {
            var model = new PriestReportResultViewModel();
            model.DoBStartDate = vm.DoBStartDate;
            model.DoBEndDate = vm.DoBEndDate;
            if (vm.Age.HasValue)
            {
                switch (vm.Age)
                {
                    case PriestAgeInterval.LessThanSeventy:
                        model.Age = "Moins de 70 ans";
                        break;
                    case PriestAgeInterval.Seventy:
                        model.Age = "70 ans";
                        break;
                    case PriestAgeInterval.MoreThanSeventy:
                        model.Age = "Plus de 70 ans";
                        break;
                    default:
                        model.Age = string.Empty;
                        break;
                }
            }
            if (vm.SuspensionReason.HasValue)
            {
                switch (vm.SuspensionReason)
                {
                    case SuspensionReason.Death:
                        model.SuspensionReason = "Décès";
                        break;
                    case SuspensionReason.Resignation:
                        model.SuspensionReason = "Démission";
                        break;
                    case SuspensionReason.Excardination:
                        model.SuspensionReason = "Excardination";
                        break;
                    default:
                        model.SuspensionReason = string.Empty;
                        break;
                }
            }
            model.OrdinationStartDate = vm.OrdinationStartDate;
            model.OrdinationEndDate = vm.OrdinationEndDate;

            var priests = _context.Priests
                .Include(p => p.Diocese)
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.FullName)
                .ToList();

            priests = priests
                .Where(p =>
                    (!vm.DoBStartDate.HasValue || p.DateOfBirth >= vm.DoBStartDate.Value) &&
                    (!vm.DoBEndDate.HasValue || p.DateOfBirth <= vm.DoBEndDate.Value) &&
                    (!vm.Age.HasValue ||
                        (vm.Age == PriestAgeInterval.LessThanSeventy && p.Age < 70) ||
                        (vm.Age == PriestAgeInterval.Seventy && p.Age == 70) ||
                        (vm.Age == PriestAgeInterval.MoreThanSeventy && p.Age > 70)) &&
                    (!vm.SuspensionReason.HasValue ||
                        (vm.SuspensionReason == SuspensionReason.Death && p.SuspensionReason == SuspensionReason.Death) ||
                        (vm.SuspensionReason == SuspensionReason.Resignation && p.SuspensionReason == SuspensionReason.Resignation) ||
                        (vm.SuspensionReason == SuspensionReason.Excardination && p.SuspensionReason == SuspensionReason.Resignation)) &&
                    (!vm.OrdinationStartDate.HasValue || p.OrdinationDate >= vm.OrdinationStartDate.Value) &&
                    (!vm.OrdinationEndDate.HasValue || p.OrdinationDate <= vm.OrdinationEndDate.Value)
                )
                .ToList();

            model.Priests = priests;
            return model;
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

        public void SuspendPriest(SuspendPriestViewModel viewModel)
        {
            var priest = _context.Priests.Find(viewModel.PriestId);

            priest.SuspensionReason = viewModel.Reason;
            priest.SuspensionDate = viewModel.SuspensionDate;

            _context.SaveChanges();
        }
    }
}
