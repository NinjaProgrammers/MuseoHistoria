using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class EventPersonalityController : Controller
    {
        public readonly IEventPersonalityRepository repository;
        public EventPersonalityController(IEventPersonalityRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult All()
        {
            var list = repository.GetAll();
            return View(list.ToList());
        }

        public ViewResult Add(int path)
        {
            if (path > 0)
                ViewBag.Path = 1;
            return View();
        }

        [HttpPost]
        public IActionResult Add(EventPersonality item, int path)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(item);
            if (path > 0)
                return RedirectToAction("Add", "Event");
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
        public IActionResult Update(EventPersonality item)
        {
            repository.Update(item);
            return RedirectToAction("All");
        }
    }
}
