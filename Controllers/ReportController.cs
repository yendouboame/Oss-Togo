using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.ViewModels;
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
        
        [HttpPost]
        public IActionResult PriestReport(PriestReportViewModel priestReport)
        {
            return View(_priestRepository.ReportFilter(priestReport));
        }

        public IActionResult PriestReportByDioceseFilter()
        {
            return View(_dioceseRepository.DioceseCheckBox());
        }

        [HttpPost]
        public IActionResult PriestReportByDiocese(List<CheckBoxViewModel> dioceses)
        {
            return View(_priestRepository.ReportByDioceseFilter(dioceses));
        }

        public IActionResult DioceseReport()
        {
            return View(_dioceseRepository.GetAll());
        }

        public IActionResult ContributionReportFilter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContributionReport(ContributionReportViewModel contributionReport)
        {
            if (contributionReport.GroupBy != null)
            {
                if (contributionReport.GroupBy == Helpers.Enums.GroupBy.Priest)
                {
                    return View(_contributionRepository.ReportFilterGroupByPriest(contributionReport));
                }
                else
                {
                    return View(_contributionRepository.ReportFilterGroupByDiocese(contributionReport));
                }
            }
            else
            {
                return View(_contributionRepository.ReportFilter(contributionReport));
            }
        }
    }
}
