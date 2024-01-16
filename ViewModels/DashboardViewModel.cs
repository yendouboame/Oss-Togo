﻿using SolidarityFund.Models.Entities;
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
        public decimal Contributions { get; set; }
        public decimal Pensions { get; set; }
        public int PriestsDeceased { get; set; }
        public int PriestsResigned { get; set; }
        public int PriestsExcardinated { get; set; }


        public List<Contribution> LastContributions { get; set; }
        public List<Pension> LastPensions { get; set; }
    }
}
