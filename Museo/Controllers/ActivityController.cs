using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.ViewModels;
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
        private readonly IUserRepository userRepository;
        private readonly ITypeActRepository typeActRepository;

        public ActivityController(IActivityRepository repository, IUserRepository userRepository, ITypeActRepository typeActRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.typeActRepository = typeActRepository;
        }

        [HttpGet]
        public ViewResult Add()
        {
            AddActivityViewModel viewModel = new AddActivityViewModel(typeActRepository.GetAll());
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(AddActivityViewModel activity)
        {
            if (!ModelState.IsValid)
                return View();
            Activity item = new Activity()
            {
                Active = true,
                AdultExt = activity.AdultExt,
                AdultNac = activity.AdultNac,
                ChildExt = activity.ChildExt,
                ChildNac = activity.ChildNac,
                Comment = activity.Comment,
                Date = activity.Date,
                Place = activity.Place,
                State = activity.State,
                TypeActId = activity.TypeActId,
                UserId = userRepository.GetByUsername(activity.Username).Id,
            };
            repository.AddEntity(item);
            return RedirectToAction("All");
        }
        public ViewResult All()
        {
            AllActivitiesViewModel viewModel = new AllActivitiesViewModel();
            foreach (var item in repository.GetAll())
            {
                TypeAct type = typeActRepository.GetById(item.TypeActId);
                User user = userRepository.GetById(item.UserId);
                viewModel.list.Add((item, type, user));
            }
            return View(viewModel);
        }
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public ViewResult Update(int Id)
        {
            Activity activity =  repository.GetById(Id);
            AddActivityViewModel viewModel = new AddActivityViewModel(typeActRepository.GetAll())
            {
                Active = true,
                AdultExt = activity.AdultExt,
                AdultNac = activity.AdultNac,
                ChildExt = activity.ChildExt,
                ChildNac = activity.ChildNac,
                Comment = activity.Comment,
                Date = activity.Date,
                Id = activity.Id,
                Place = activity.Place,
                State = activity.State,
                TypeActId = activity.TypeActId,
                UserId = activity.UserId,
                Username = User.Identity.Name
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(AddActivityViewModel activity)
        {
            if (!ModelState.IsValid)
                return View();
            Activity item = new Activity()
            {
                Active = true,
                Id = activity.Id,
                AdultExt = activity.AdultExt,
                AdultNac = activity.AdultNac,
                ChildExt = activity.ChildExt,
                ChildNac = activity.ChildNac,
                Comment = activity.Comment,
                Date = activity.Date,
                Place = activity.Place,
                State = activity.State,
                TypeActId = activity.TypeActId,
                UserId = activity.UserId
            };
            repository.Update(item);
            return RedirectToAction("All");
        }

    }
}
