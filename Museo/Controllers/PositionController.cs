﻿using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class PositionController : Controller
    {
        public readonly IPositionRepository repository;
        public PositionController(IPositionRepository repository)
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
        public IActionResult Add(Position position)
        {
            if (!ModelState.IsValid)
                return View();
            repository.AddEntity(position);
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
        public IActionResult Update(Position position)
        {
            repository.Update(position);
            return RedirectToAction("All");
        }
    }
}
