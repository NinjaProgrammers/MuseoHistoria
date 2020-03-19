using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Museo.Models.Repository;
using Museo.Models.Repository.Interfaces;

namespace Museo.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IVisitRepository visitRepository;

        public ReportsController(IVisitRepository visitRepository)
        {
            this.visitRepository = visitRepository;
        } 
        public ViewResult AllReports()
        {
            return View();
        }

        public ViewResult MonthVisitors()
        {
            float total = 0;
            string month = "";
            Tuple<int, int, int, int, int, int, int>[] flow = new Tuple<int, int, int, int, int, int, int>[12];
            int[] monthprofit = new int[12];
            for (int i = 1; i < 12; i++)
            {
                Tuple<int, Tuple<int, int, int, int, int, int, int>> temp = visitRepository.MonthProfit(i);
                monthprofit[i - 1] = temp.Item1;
                month += temp.Item1.ToString() + (i == 11 ? "" : ",");
                flow[i - 1] = temp.Item2;
                total += temp.Item1;
            }
            return View(month);
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
