﻿using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class AnualPlanController : Controller
    {
        public readonly IAnualPlanRepository repository;
        public AnualPlanController(IAnualPlanRepository repository)
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
        public IActionResult Add(AnualPlan anualplan)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(anualplan);
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
            var anualplan = repository.GetById(Id);
            return View(anualplan);
        }
        [HttpPost]
        public IActionResult Update(AnualPlan anualplan)
        {
            repository.Update(anualplan);
            return RedirectToAction("All");
        }
    }
}
