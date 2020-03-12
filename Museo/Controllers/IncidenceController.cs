using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class IncidenceController : Controller
    {
        public readonly IIncidenceRepository repository;
        public IncidenceController(IIncidenceRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult All()
        {
            var list = repository.AllIncidenceAndTypes();
            IncidenceViewModel viewModel = new IncidenceViewModel(list.ToList());
            return View(viewModel);
        }

        public ViewResult Add()
        {
            AddIncidenceViewModel viewModel = new AddIncidenceViewModel(repository.AllIncidenceTypes().ToList());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(Incidence incidence)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(incidence);
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
            AddIncidenceViewModel viewModel = new AddIncidenceViewModel(repository.AllIncidenceTypes().ToList());
            var x = repository.GetById(Id);
            viewModel.Category = x.Category;
            viewModel.Comment = x.Comment;
            viewModel.IncidenceTypeId = x.IncidenceTypeId;
            viewModel.ModifiedBy = x.ModifiedBy;
            viewModel.ModifiedDate = x.ModifiedDate;
            viewModel.RegisterDate = x.RegisterDate;
            viewModel.RegisteredBy = x.RegisteredBy;
            viewModel.State = x.State;
            viewModel.Responsible = x.Responsible;
            viewModel.Place = x.Place;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(Incidence incidence)
        {
            repository.Update(incidence);
            return RedirectToAction("All");
        }
    }
}
