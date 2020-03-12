using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class ReportsController : Controller
    {
        public ViewResult AllReports()
        {
            return View();
        }

        public ViewResult MonthVisitors()
        {
            return View();
        }
        public ViewResult TypeVisitors()
        {
            return View();
        }
        public ViewResult Earnings()
        {
            return View();
        }
        public ViewResult WorkersActivities()
        {
            return View();
        }

    }
}
