using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Museo.Models;
using Museo.Models.Repository.Interfaces;

namespace Museo.Controllers
{
    public class AreaController : Controller
    {
        public IAreaRepository repository { get; set; }
        public AreaController(IAreaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Area area)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(area);
            return RedirectToAction("All");
        }

        public ViewResult All()
        {
            return View(repository.GetAll());
        }
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("All");
        }
        [HttpGet]
        public ViewResult Update(int Id)
        {
            var area = repository.GetById(Id);
            return View(area);
        }
        [HttpPost]
        public IActionResult Update(Area area)
        {
            repository.Update(area);
            return RedirectToAction("All");
        }

    }
}
