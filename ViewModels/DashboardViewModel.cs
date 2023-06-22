using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.ViewModels
{
    public class DashboardViewModel
    {
        public int DioceseCount { get; set; }
        public int PriestCount { get; set; }
        public double ContributingPriest { get; set; }
        public double BeneficiaryPriest { get; set; }
        public double CurrentMonthContribution { get; set; }
        public double CurrentMonthPension { get; set; }
        public double CurrentMonthExpectedContribution { get; set; }
        public double CurrentMonthExpectedPension { get; set; }
        public List<Contribution> LastContributions { get; set; }
        public List<Pension> LastPensions { get; set; }
    }
}
