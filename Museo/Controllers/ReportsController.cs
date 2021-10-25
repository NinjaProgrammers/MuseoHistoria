using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Museo.Models.Repository;
using Museo.Models.Repository.Interfaces;
using Museo.ViewModels;
using System.Text.Json;
using Newtonsoft.Json;
using Museo.Models;

namespace Museo.Controllers
{
    public class ReportsController : Controller
    {

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }

            public Point(int x,int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class StackedPoint
        {
            public int x { get; set; }
            public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
            public int d { get; set; }
            public int e { get; set; }
            public int f { get; set; }

            public StackedPoint(int x,int a,int b, int c,int d, int e, int f)
            {
                this.x = x;
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;
                this.e = e;
                this.f = f;
            }
        }

        private readonly IVisitRepository visitRepository;
        private readonly IActivityRepository activityRepository;
        private readonly IUserRepository userRepository;
        private readonly IAreaRepository areaRepository;
        private readonly IPositionRepository positionRepository;

        public ReportsController(IVisitRepository visitRepository, IActivityRepository activityRepository, IUserRepository userRepository,
            IAreaRepository areaRepository, IPositionRepository positionRepository)
        {
            this.visitRepository = visitRepository;
            this.activityRepository = activityRepository;
            this.userRepository = userRepository;
            this.areaRepository = areaRepository;
            this.positionRepository = positionRepository;
        } 
        public ViewResult AllReports()
        {
            return View();
        }

        /// <summary>
        /// Devuelve una tupla de (ganancia por mes, total, visitantes por mes)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private (Point[],float,VisitAux[]) AnualFlow(int year)
        {

            float total = 0;
            Point[] months = new Point[12];
            VisitAux[] visitors = new VisitAux[12];
            for (int i = 1; i <= 12; i++)
            {
                var monthProfit = visitRepository.MonthProfit(i, year);
                visitors[i - 1] = monthProfit.Item2;
                months[i - 1] = new Point(i, (int)monthProfit.Item1);
                total += monthProfit.Item1;
            }

            return (months, total,visitors);

        }

        public ViewResult AnualProfit(int year = 0)
        {

            year = year == 0 ? DateTime.Now.Year : year;

            //var anualProfit = visitRepository.AnualProfit(year);

            (Point[], float, VisitAux[]) tuple = AnualFlow(year);
            Point[] months = tuple.Item1;
            float total = tuple.Item2;

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };


            AnualProfitViewModel viewModel = new AnualProfitViewModel()
            {
                Total = total,
                Year = year,
                AnualProfit = JsonConvert.SerializeObject(months, serializerSettings)
            };

            return View(viewModel);
        }

        public ViewResult AnualProfitVisitors(int year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : year;

            (Point[], float, VisitAux[]) tuple = AnualFlow(year);
            Point[] months = tuple.Item1;
            float total = tuple.Item2;
            VisitAux[] visits = tuple.Item3;
            Point[] AdultExt = new Point[12];
            Point[] AdultNac = new Point[12];
            Point[] ChildAlone = new Point[12];
            Point[] ChildCom = new Point[12];
            Point[] ChildExt = new Point[12];
            Point[] Residents = new Point[12];
            Tuple<int, int, int, int, int, int> prices = visitRepository.Prices();
            StackedPoint[] stackedPoints = new StackedPoint[12];

            for (int i = 0; i < 12; i++)
            {
                AdultExt[i] = new Point(i+1,visits[i].adultExt * prices.Item1);
                AdultNac[i] = new Point(i + 1, visits[i].adultNac * prices.Item2);
                ChildAlone[i] = new Point(i + 1, visits[i].childAlone * prices.Item3);
                ChildCom[i] = new Point(i + 1, visits[i].childCom * prices.Item4);
                ChildExt[i] = new Point(i + 1, visits[i].childExt * prices.Item5);
                Residents[i] = new Point(i + 1, visits[i].resident * prices.Item6);
                stackedPoints[i] = new StackedPoint(i + 1, visits[i].adultExt * prices.Item1, visits[i].adultNac * prices.Item2,
                    visits[i].childAlone * prices.Item3, visits[i].childCom * prices.Item4,
                    visits[i].childExt * prices.Item5 , visits[i].resident * prices.Item6);
            }

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            AnualProfitVisitorsViewModel viewModel = new AnualProfitVisitorsViewModel()
            {
                Total = (int)total,
                AdultExt = JsonConvert.SerializeObject(AdultExt, serializerSettings),
                AdultNac = JsonConvert.SerializeObject(AdultNac, serializerSettings),
                ChildAlone = JsonConvert.SerializeObject(ChildAlone, serializerSettings),
                ChildCom = JsonConvert.SerializeObject(ChildCom, serializerSettings),
                ChildExt = JsonConvert.SerializeObject(ChildExt, serializerSettings),
                Residents = JsonConvert.SerializeObject(Residents, serializerSettings),
                Stacked = JsonConvert.SerializeObject(stackedPoints,serializerSettings),
                Year = year
            };

            return View(viewModel);
        }

        private (Point[], Point[],Point[],Point[],Point[],Point[],Point[],int) MonthFlow(int month, int year)
        {
            Point[] days = new Point[31];
            Point[] daysAdultExt = new Point[31];
            Point[] daysAdultNac = new Point[31];
            Point[] daysChildAlone = new Point[31];
            Point[] daysChildCom = new Point[31];
            Point[] daysChildExt = new Point[31];
            Point[] daysResident = new Point[31];
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                days = new Point[30];
                daysAdultExt = new Point[30];
                daysAdultNac = new Point[30];
                daysChildCom = new Point[30];
                daysChildAlone = new Point[30];
                daysChildExt = new Point[30];
                daysResident = new Point[30];
            }
            else if (month == 2 && year % 4 != 0)
            {
                days = new Point[28];
                daysAdultExt = new Point[28];
                daysAdultNac = new Point[28];
                daysChildCom = new Point[28];
                daysChildAlone = new Point[28];
                daysChildExt = new Point[28];
                daysResident = new Point[28];
            }
            else if (month == 2)
            {
                days = new Point[29];
                daysAdultExt = new Point[29];
                daysAdultNac = new Point[29];
                daysChildCom = new Point[29];
                daysChildAlone = new Point[29];
                daysChildExt = new Point[29];
                daysResident = new Point[29];
            }

            int[] result = new int[31];
            int total = 0;
            VisitAux[] visits = new VisitAux[32];

            (result, visits) = visitRepository.DailyProfit(month, year);


            for (int i = 0; i < days.Length; i++)
            {
                days[i] = new Point(i + 1, result[i]);
                daysAdultExt[i] = new Point(i + 1, visits[i].adultExt);
                daysAdultNac[i] = new Point(i + 1, visits[i].adultNac);
                daysChildAlone[i] = new Point(i + 1, visits[i].childAlone);
                daysChildCom[i] = new Point(i + 1, visits[i].childCom);
                daysChildExt[i] = new Point(i + 1, visits[i].childExt);
                daysResident[i] = new Point(i + 1, visits[i].resident);
                total += result[i];
            }

            return (days, daysAdultExt, daysAdultNac, daysChildAlone, daysChildCom, daysChildExt, daysResident,total);
        }


        public IActionResult MonthProfit(int month = 0, int year = 0)
        {
            month = month == 0 ? DateTime.Now.Month : month;
            year = year == 0 ? DateTime.Now.Year : year;

            var x = MonthFlow(month, year);

            Tuple<int, int, int, int, int, int> prices = visitRepository.Prices();



            for (int i = 0; i < x.Item1.Length; i++)
            {
                x.Item2[i].y *= prices.Item1;
                x.Item3[i].y *= prices.Item2;
                x.Item4[i].y *= prices.Item3;
                x.Item5[i].y *= prices.Item4;
                x.Item6[i].y *= prices.Item5;
                x.Item7[i].y *= prices.Item6;
                x.Item1[i].y = x.Item2[i].y + x.Item3[i].y + x.Item4[i].y + x.Item5[i].y + x.Item6[i].y + x.Item7[i].y;
            }

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            MonthProfitViewModel viewModel = new MonthProfitViewModel()
            {
                Year = year,
                Month = month,
                Total = x.Item8,
                Profit = JsonConvert.SerializeObject(x.Item1, serializerSettings),
                AdultExt = JsonConvert.SerializeObject(x.Item2, serializerSettings),
                AdultNac = JsonConvert.SerializeObject(x.Item3, serializerSettings),
                ChildAlone = JsonConvert.SerializeObject(x.Item4, serializerSettings),
                ChildCom = JsonConvert.SerializeObject(x.Item5, serializerSettings),
                ChildExt = JsonConvert.SerializeObject(x.Item6, serializerSettings),
                Resident = JsonConvert.SerializeObject(x.Item7, serializerSettings)
            };        


            return View(viewModel);
        }

        public ViewResult AnualVisitors(int year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : year;

            Tuple<float, VisitAux> x = visitRepository.AnualProfit(year);

            var total = x.Item2.adultExt + x.Item2.adultNac + x.Item2.childAlone + x.Item2.childCom + x.Item2.childExt + x.Item2.resident;
            var adultExt = Math.Round((x.Item2.adultExt * 100.0) / total, 2);
            var adultNac = Math.Round((x.Item2.adultNac * 100.0) / total, 2);
            var childAlo = Math.Round((x.Item2.childAlone * 100.0) / total, 2);
            var childCom = Math.Round((x.Item2.childCom * 100.0) / total, 2);
            var childExt = Math.Round((x.Item2.childExt * 100.0) / total, 2);
            var resident = Math.Round((x.Item2.resident * 100.0) / total, 2);


            AnualVisitorsViewModel viewModel = new AnualVisitorsViewModel()
            {
                Total = total,
                AdultExtPer = adultExt,
                AdultNacPer = adultNac,
                ChildAloPer = childAlo,
                ChildComPer = childCom,
                ChildExtPer = childExt,
                ResidentPer = resident,
                Year = year
            };

            return View(viewModel);
        }

        public ViewResult MonthVisitors(int year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : year;

            var x = AnualFlow(year);

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            Point[] AdultExt = new Point[12];
            Point[] AdultNac = new Point[12];
            Point[] ChildAlone = new Point[12];
            Point[] ChildCom = new Point[12];
            Point[] ChildExt = new Point[12];
            Point[] Resident = new Point[12];
            Point[] TotalVisitors = new Point[12];
            var total = 0;

            for (int i = 0; i < 12; i++)
            {
                var count = 0;
                AdultExt[i] = new Point(i + 1, x.Item3[i].adultExt);
                count += x.Item3[i].adultExt;
                AdultNac[i] = new Point(i + 1, x.Item3[i].adultNac);
                count += x.Item3[i].adultNac;
                ChildAlone[i] = new Point(i + 1, x.Item3[i].childAlone);
                count += x.Item3[i].childAlone;
                ChildCom[i] = new Point(i + 1, x.Item3[i].childCom);
                count += x.Item3[i].childCom;
                ChildExt[i] = new Point(i + 1, x.Item3[i].childExt);
                count += x.Item3[i].childExt;
                Resident[i] = new Point(i + 1, x.Item3[i].resident);
                count += x.Item3[i].resident;
                TotalVisitors[i] = new Point(i + 1, count);
                total += count;
            }

            MonthVisitorsViewModel viewModel = new MonthVisitorsViewModel()
            {
                AdultExt = JsonConvert.SerializeObject(AdultExt, serializerSettings),
                AdultNac = JsonConvert.SerializeObject(AdultNac, serializerSettings),
                ChildAlone = JsonConvert.SerializeObject(ChildAlone, serializerSettings),
                ChildComp = JsonConvert.SerializeObject(ChildCom, serializerSettings),
                ChildExt = JsonConvert.SerializeObject(ChildExt, serializerSettings),
                Resident = JsonConvert.SerializeObject(Resident, serializerSettings),
                Total = total,
                Year = year,
                TotalVisitors = JsonConvert.SerializeObject(TotalVisitors, serializerSettings)
            };

            return View(viewModel);
        }


        public IActionResult DailyVisitors(int month = 0, int year = 0)
        {
            month = month == 0 ? DateTime.Now.Month : month;
            year = year == 0 ? DateTime.Now.Year : year;

            var x = MonthFlow(month, year);

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };


            DailyVisitorsViewModel viewModel = new DailyVisitorsViewModel()
            {
                AdultExt = JsonConvert.SerializeObject(x.Item2, serializerSettings),
                AdultNac = JsonConvert.SerializeObject(x.Item3, serializerSettings),
                ChildAlone = JsonConvert.SerializeObject(x.Item4, serializerSettings),
                ChildExt = JsonConvert.SerializeObject(x.Item5, serializerSettings),
                ChildCom = JsonConvert.SerializeObject(x.Item6, serializerSettings),
                Resident = JsonConvert.SerializeObject(x.Item7, serializerSettings),
                Days = JsonConvert.SerializeObject(x.Item1, serializerSettings),
                Month = month,
                Year = year,
                Total = x.Item8
            };

            return View(viewModel);
        }


        public ViewResult WorkersActivities()
        {
            //Hacer para mostrar la cantidad deseada
            var x = userRepository.MoreActivitiesWorker();

            List<(int, User)> table = new List<(int, User)>();

            foreach (var item in x)
            {
                User user = userRepository.GetById(item.Item2);
                user.Area = areaRepository.GetById(user.AreaId);
                user.Position = positionRepository.GetById(user.PositionId);
                table.Add((item.Item1,user ));
            }
            
            return View(table);
        }



    }
}
