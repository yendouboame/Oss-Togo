using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.ViewModels
{
    public class PriestReportViewModel
    {
        public DateTime? DoBStartDate { get; set; }
        public DateTime? DoBEndDate { get; set; }
        public PriestAgeInterval? Age { get; set; }
        public SuspensionReason? SuspensionReason { get; set; }
        public DateTime? OrdinationStartDate { get; set; }
        public DateTime? OrdinationEndDate { get; set; }
    }

    public class PriestReportResultViewModel
    {
        public DateTime? DoBStartDate { get; set; }
        public DateTime? DoBEndDate { get; set; }
        public string Age { get; set; }
        public string SuspensionReason { get; set; }
        public DateTime? OrdinationStartDate { get; set; }
        public DateTime? OrdinationEndDate { get; set; }
        public IList<Priest> Priests { get; set; }
    }
}