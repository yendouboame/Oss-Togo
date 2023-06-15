using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class ReportController : BaseController
    {
        public IActionResult PriestReportFilter()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
