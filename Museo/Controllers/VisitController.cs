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
        public VisitController(IVisitRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult All()
        {
            var list = repository.GetAll();
            return View(list.ToList());
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
                UserId = item.UserId
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
