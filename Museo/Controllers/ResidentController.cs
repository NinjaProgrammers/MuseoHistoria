﻿using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class ResidentController : Controller
    {
        public readonly IResidentRepository repository;
        public ResidentController(IResidentRepository repository)
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
        public IActionResult Add(Resident item)
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
        public IActionResult Update(Resident item)
        {
            repository.Update(item);
            return RedirectToAction("All");
        }
    }
}
