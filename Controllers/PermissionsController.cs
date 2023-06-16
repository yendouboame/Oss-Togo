using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Controllers
{
    public class PermissionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
