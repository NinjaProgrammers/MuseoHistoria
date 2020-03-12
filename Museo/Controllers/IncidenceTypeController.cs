using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class IncidenceTypeController : Controller
    {
        public readonly IIncidenceTypeRepository repository;
        public IncidenceTypeController(IIncidenceTypeRepository repository)
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
            return View();
        }

        [HttpPost]
        public IActionResult Add(IncidenceType item)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(item);
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
        public IActionResult Update(IncidenceType item)
        {
            repository.Update(item);
            return RedirectToAction("All");
        }
    }
}
