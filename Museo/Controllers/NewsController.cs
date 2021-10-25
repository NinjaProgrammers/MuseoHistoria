using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class NewsController : Controller
    {

        public readonly INewsRepository repository;
        public NewsController(INewsRepository repository)
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
        public IActionResult Add(News news)
        {
            if (!ModelState.IsValid)
                return View();
            if (news.Link != null && news.Link.StartsWith("http://"))
            {
                news.Link = news.Link.Remove(0, 7);
            }
            repository.AddEntity(news);
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
        public IActionResult Update(News news)
        {
            repository.Update(news);
            return RedirectToAction("All");
        }

    }
}
