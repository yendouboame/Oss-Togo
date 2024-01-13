using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.ViewModels
{
    public class SuspendPriestViewModel
    {
        public int PriestId { get; set; }
        public DateTime? SuspensionDate { get; set; }
        public SuspensionReason Reason { get; set; }
    }
}
