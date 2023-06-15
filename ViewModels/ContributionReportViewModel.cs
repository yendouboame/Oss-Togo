using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Enums;

namespace SolidarityFund.ViewModels
{
    public class ContributionReportViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public GroupBy? GroupBy { get; set; }
    }
}
