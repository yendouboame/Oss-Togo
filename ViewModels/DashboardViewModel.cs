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
        public double ContributionTotal { get; set; }
        public double PensionTotal { get; set; }
        public List<Contribution> LastContributions { get; set; }
        public List<Pension> LastPensions { get; set; }
    }
}
