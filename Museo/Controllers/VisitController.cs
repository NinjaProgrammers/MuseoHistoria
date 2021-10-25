using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.Models.Repository.Interfaces;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class VisitController : Controller
    {
        public readonly IVisitRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IResidentVisitRepository residentVisitRepository;

        public VisitController(IVisitRepository repository, IUserRepository userRepository, IResidentVisitRepository residentVisitRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.residentVisitRepository = residentVisitRepository;
        }

        public ViewResult All()
        {
            var list = repository.GetAll().OrderByDescending(x => x.Date);
            List<AllVisitViewModel> viewModel = new List<AllVisitViewModel>();
            foreach (var item in list)
            {
                AllVisitViewModel x = new AllVisitViewModel()
                {
                    Active = item.Active,
                    AdultExt = item.AdultExt,
                    AdultNac = item.AdultNac,
                    ChildAlone = item.ChildAlone,
                    ChildExt = item.ChildExt,
                    ChildsCom = item.ChildsCom,
                    Date = item.Date,
                    User = userRepository.GetById(item.UserId)
                };
                foreach (var r in residentVisitRepository.GetByVisitId(item.Id))
                {
                    x.Resident++;
                }
                x.TotalVisitors = x.AdultExt + x.AdultNac + x.ChildAlone + x.ChildExt + x.ChildsCom + x.Resident;
                var prices = repository.Prices();
                x.Earning = x.AdultExt * prices.Item1 + x.AdultNac * prices.Item2 + x.ChildAlone * prices.Item3 + x.ChildExt * prices.Item4 + x.ChildsCom * prices.Item5
                    + x.Resident * prices.Item6;
                viewModel.Add(x);
            }

            return View(viewModel);
        }

        public ViewResult Add()
        {
            AddVisitViewModel viewModel = new AddVisitViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddVisitViewModel item)
        {
            if (!ModelState.IsValid)
                return View(item);
            Visit visit = new Visit()
            {
                Active = true,
                AdultExt = item.AdultExt,
                AdultNac = item.AdultNac,
                ChildAlone = item.ChildAlone,
                ChildExt = item.ChildExt,
                ChildsCom = item.ChildsCom,
                Date = item.Date,
                UserId = userRepository.GetByUsername(User.Identity.Name).Id          
            };

            repository.AddEntity(visit);

            foreach (var res in item.residents)
            {
                ResidentVisit residentVisit = new ResidentVisit()
                {
                    ResidentId = res.Id,
                    VisitId = visit.Id,
                    Active = true
                };
            }

            return RedirectToAction("All");
        }

        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public ViewResult Update(int Id)
        {
            var item = repository.GetById(Id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Update(Visit item)
        {
            repository.Update(item);
            return RedirectToAction("All");
        }
    }
}
