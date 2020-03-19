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
    public class UsersController : Controller
    {
        private readonly IUserRepository repository;
        private readonly IAreaRepository areaRepository;
        private readonly IPositionRepository positionRepository;

        public UsersController(IUserRepository repository, IAreaRepository areaRepository, IPositionRepository positionRepository)
        {
            this.repository = repository;
            this.areaRepository = areaRepository;
            this.positionRepository = positionRepository;
        }

        public ViewResult All()
        {
            List<AllUsersViewModel> viewModels = new List<AllUsersViewModel>();
            foreach (var item in repository.GetAll())
            {
                AllUsersViewModel model = new AllUsersViewModel()
                {
                    Id = item.Id,
                    Area = areaRepository.GetById(item.AreaId).Name,
                    Position = positionRepository.GetById(item.PositionId).Name,
                    UserName = item.UserName,
                    FullName = item.FullName,
                    Email = item.Email,
                    Active = item.Active
                };
                viewModels.Add(model);
            }
            return View(viewModels);
        }


        [HttpGet]
        public IActionResult OrderByUsername()
        {
            return PartialView("_UsersListPartial", repository.GetAll().OrderByDescending(x => x.UserName));
        }




        //public ViewResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add(User user)
        //{
        //    if (!ModelState.IsValid)
        //        return View();
        //    repository.AddEntity(user);
        //    return RedirectToAction("All");
        //}
        //public IActionResult Delete(int Id)
        //{
        //    repository.Delete(Id);
        //    return RedirectToAction("All");
        //}

        //[HttpGet]
        //public ViewResult Update(int Id)
        //{
        //    var anualplan = repository.GetById(Id);
        //    return View(anualplan);
        //}
        //[HttpPost]
        //public IActionResult Update(User user)
        //{
        //    repository.Update(user);
        //    return RedirectToAction("All");
        //}
    }
}
