using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolidarityFund.Models.Entities;
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
                    return View(nameof(ContributionReportGroupByPriest), _contributionRepository.ReportFilterGroupByPriest(contributionReport));
                }
                else
                {
                    return View(nameof(ContributionReportGroupByDiocese), _contributionRepository.ReportFilterGroupByDiocese(contributionReport));
                }
            }
            else
            {
                return View(_contributionRepository.ReportFilter(contributionReport));
            }
        }

        [HttpPost]
        public IActionResult ContributionReportGroupByPriest(IEnumerable<IGrouping<Priest, Contribution>> groupedByPriest)
        {
            return View(groupedByPriest);
        }

        [HttpPost]
        public IActionResult ContributionReportGroupByDiocese(IEnumerable<IGrouping<Diocese, Contribution>> groupedByDiocese)
        {
            return View(groupedByDiocese);
        }

        public IActionResult ContributionReportByPriestFilter()
        {
            var priests = new SelectList(_priestRepository.GetAll(), "Id", "FullName");
            return View(priests);
        }

        [HttpPost]
        public IActionResult ContributionReportByPriest(ContributionReportByPriestViewModel contributionReport)
        {
            return View(_contributionRepository.ReportByPriestFilter(contributionReport));
        }

        public IActionResult ContributionReportByDioceseFilter()
        {
            var dioceses = new SelectList(_dioceseRepository.GetAll(), "Id", "Name");
            return View(dioceses);
        }

        [HttpPost]
        public IActionResult ContributionReportByDiocese(ContributionReportByDioceseViewModel contributionReport)
        {
            return View(_contributionRepository.ReportByDioceseFilter(contributionReport));
        }

        public IActionResult PensionReportFilter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PensionReport(PensionReportViewModel pensionReport)
        {
            if (pensionReport.GroupBy != null)
            {
                return View(nameof(PensionReportGroupByPriest), _pensionRepository.ReportFilterGroupByPriest(pensionReport));
            }
            else
            {
                return View(_pensionRepository.ReportFilter(pensionReport));
            }
        }

        [HttpPost]
        public IActionResult PensionReportGroupByPriest(IEnumerable<IGrouping<Priest, Pension>> groupedByPriest)
        {
            return View(groupedByPriest);
        }

        public IActionResult PensionReportByPriestFilter()
        {
            var priests = new SelectList(_priestRepository.GetAll(), "Id", "FullName");
            return View(priests);
        }

        [HttpPost]
        public IActionResult PensionReportByPriest(PensionReportByPriestViewModel pensionReport)
        {
            return View(_pensionRepository.ReportByPriestFilter(pensionReport));
        }
    }
}
