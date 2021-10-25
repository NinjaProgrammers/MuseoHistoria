using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Museo.Models;
using Museo.Models.Repository;
using Museo.Models.Repository.Interfaces;
using Museo.ViewModels;

namespace Museo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActivityRepository activityRepository;
        private readonly IVisitRepository visitRepository;
        private readonly IIncidenceRepository incidenceRepository;
        private readonly INewsRepository newsRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly IUserRepository userRepository;
        private readonly IAreaRepository areaRepository;

        public HomeController(ILogger<HomeController> logger, IActivityRepository activityRepository,IVisitRepository visitRepository,
            IIncidenceRepository incidenceRepository,INewsRepository newsRepository,IDocumentRepository documentRepository, 
            IUserRepository userRepository)
        {
            _logger = logger;
            this.activityRepository = activityRepository;
            this.visitRepository = visitRepository;
            this.incidenceRepository = incidenceRepository;
            this.newsRepository = newsRepository;
            this.documentRepository = documentRepository;
            this.userRepository = userRepository;
            this.areaRepository = areaRepository;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Documents = documentRepository.GetAll().OrderByDescending(x => x.Date).Take(3);
            viewModel.News = newsRepository.GetAll().OrderByDescending(x => x.Date).Take(3);
            viewModel.Activities = activityRepository.ActivityProfit(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year).Item1;



            var aux = visitRepository.DailyProfit(DateTime.Now.Month, DateTime.Now.Year);
            viewModel.Visitors = aux.Item1[DateTime.Now.Day];
            var temp = aux.Item2[DateTime.Now.Day];
            var prices = visitRepository.Prices();
            var profit = temp.adultExt * prices.Item1 + temp.adultNac * prices.Item2 + temp.childAlone * prices.Item3 +
                temp.childCom * prices.Item4 + temp.childExt * prices.Item5 + temp.resident * prices.Item6;
            var total = temp.adultExt + temp.adultNac + temp.childAlone + temp.childCom  + temp.childExt + temp.resident;
            viewModel.Earnings = profit;

            var adultExt = Math.Round((temp.adultExt * 100.0) / total, 2);
            var adultNac = Math.Round((temp.adultNac * 100.0) / total, 2);
            var childAlo = Math.Round((temp.childAlone * 100.0) / total, 2);
            var childCom = Math.Round((temp.childCom * 100.0) / total, 2);
            var childExt = Math.Round((temp.childExt * 100.0) / total, 2);
            var resident = Math.Round((temp.resident * 100.0) / total, 2);

            AnualVisitorsViewModel anual = new AnualVisitorsViewModel()
            {
                Total = total,
                AdultExtPer = adultExt,
                AdultNacPer = adultNac,
                ChildAloPer = childAlo,
                ChildComPer = childCom,
                ChildExtPer = childExt,
                ResidentPer = resident,
                Year = DateTime.Now.Year
            };

            viewModel.VisitorsPer = anual;


            var x = userRepository.MoreActivitiesWorker().Take(4);

            List<(int, User)> table = new List<(int, User)>();

            foreach (var item in x)
            {
                User user = userRepository.GetById(item.Item2);
                table.Add((item.Item1, user));
            }

            viewModel.WorkersActivities = table;


            var incidences = incidenceRepository.IncidencesByDay(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            viewModel.Incidences = incidences.Sum(x => x.Item2);


            return View(viewModel);


            

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
