using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.ViewModels
{
    public class PensionReportViewModel
    {
        public int? StartMonth { get; set; }
        public int? StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public GroupBy? GroupBy { get; set; }
    }

    public class PensionReportResultViewModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<Pension> Pensions { get; set; }
    }
}
