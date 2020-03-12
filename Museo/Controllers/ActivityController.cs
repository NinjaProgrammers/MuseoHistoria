using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository repository;

        public ActivityController(IActivityRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Activity activity)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(activity);
            return RedirectToAction("All");
        }
        public ViewResult All()
        {
            return View();
        }
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public ViewResult Update(int Id)
        {
            var act = repository.GetById(Id);
            return View(act);
        }
        [HttpPost]
        public IActionResult Update(Activity activity)
        {
            repository.Update(activity);
            return RedirectToAction("All");
        }

    }
}
