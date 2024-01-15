using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using SolidarityFund.Models.Entities;
using SolidarityFund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

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
            return new ViewAsPdf(_priestRepository.ReportFilter(priestReport));
        }

        public IActionResult PriestReportByDioceseFilter()
        {
            return View(_dioceseRepository.DioceseCheckBox());
        }

        [HttpPost]
        public IActionResult PriestReportByDiocese(List<CheckBoxViewModel> dioceses)
        {
            return new ViewAsPdf(_priestRepository.ReportByDioceseFilter(dioceses));
        }

        public IActionResult DioceseReport()
        {
            return new ViewAsPdf(_dioceseRepository.GetAll());
        }

        public IActionResult ContributionReportFilter()
        {
            GetEmptyMonthSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult ContributionReport(ContributionReportViewModel contributionReport)
        {
            if (contributionReport.GroupBy != null)
            {
                if (contributionReport.GroupBy == GroupBy.Priest)
                {
                    return new ViewAsPdf(nameof(ContributionReportGroupByPriest), _contributionRepository.ReportFilterGroupByPriest(contributionReport));
                }
                else
                {
                    return new ViewAsPdf(nameof(ContributionReportGroupByDiocese), _contributionRepository.ReportFilterGroupByDiocese(contributionReport));
                }
            }
            else
            {
                return new ViewAsPdf(_contributionRepository.ReportFilter(contributionReport));
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
            return new ViewAsPdf(_contributionRepository.ReportByPriestFilter(contributionReport));
        }

        public IActionResult ContributionReportByDioceseFilter()
        {
            var dioceses = new SelectList(_dioceseRepository.GetAll(), "Id", "Name");
            return View(dioceses);
        }

        [HttpPost]
        public IActionResult ContributionReportByDiocese(ContributionReportByDioceseViewModel contributionReport)
        {
            return new ViewAsPdf(_contributionRepository.ReportByDioceseFilter(contributionReport));
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
                return new ViewAsPdf(nameof(PensionReportGroupByPriest), _pensionRepository.ReportFilterGroupByPriest(pensionReport));
            }
            else
            {
                return new ViewAsPdf(_pensionRepository.ReportFilter(pensionReport));
            }
        }

        [HttpPost]
        public IActionResult PensionReportGroupByPriest(IEnumerable<IGrouping<Priest, Pension>> groupedByPriest)
        {
            return new ViewAsPdf(groupedByPriest);
        }

        public IActionResult PensionReportByPriestFilter()
        {
            var priests = new SelectList(_priestRepository.GetAll(), "Id", "FullName");
            return View(priests);
        }

        [HttpPost]
        public IActionResult PensionReportByPriest(PensionReportByPriestViewModel pensionReport)
        {
            return new ViewAsPdf(_pensionRepository.ReportByPriestFilter(pensionReport));
        }
    }
}
