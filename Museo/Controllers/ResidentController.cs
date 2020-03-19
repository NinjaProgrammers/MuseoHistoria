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
    public class ResidentController : Controller
    {
        public readonly IResidentRepository repository;
        private readonly IResidentVisitRepository residentVisitRepository;

        public ResidentController(IResidentRepository repository, IResidentVisitRepository residentVisitRepository)
        {
            this.repository = repository;
            this.residentVisitRepository = residentVisitRepository;
        }

        public ViewResult All()
        {
            var list = repository.GetAll();
            return View(list.ToList());
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Resident item)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(item);
            return RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult AddInVisit(AddVisitViewModel viewModel)
        {
            if (viewModel.Identifier == null || viewModel.Country == null)
                return RedirectToAction("Add", "Visit", viewModel);
            Resident item = new Resident
            {
                Identifier = viewModel.Identifier,
                Country = viewModel.Country,
            };
            repository.AddEntity(item);
            viewModel.residents.Add(item);
            return View("~/Views/Visit/Add.cshtml", viewModel);
        }

        [HttpPost]
        public IActionResult RemoveInVisit(AddVisitViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Add", "Visit", viewModel);

            int id = viewModel.residents[viewModel.RemoveIndex - 1].Id;
            repository.Delete(id);
            viewModel.residents.RemoveAt(viewModel.RemoveIndex - 1);
            return View("~/Views/Visit/Add.cshtml", viewModel);
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
        public IActionResult Update(Resident item)
        {
            repository.Update(item);
            return RedirectToAction("All");
        }
    }
}
