using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.ViewModels
{
    public class ContributionReportViewModel
    {
        public int? StartMonth { get; set; }
        public int? StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public GroupBy? GroupBy { get; set; }
    }

    public class ContributionReportResultViewModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<Contribution> Contributions { get; set; }
    }

    public class ContributionReportGroupByPriestResultViewModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<IGrouping<Priest, Contribution>> Contributions { get; set; }
    }

    public class ContributionReportGroupByDioceseResultViewModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<IGrouping<Diocese, Contribution>> Contributions { get; set; }
    }
}
