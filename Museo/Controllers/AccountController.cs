using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.Models.Repository.Interfaces;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IAreaRepository areaRepository;
        private readonly IPositionRepository positionRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, 
            IWebHostEnvironment hostingEnvironment,IAreaRepository areaRepository, IPositionRepository positionRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
            this.areaRepository = areaRepository;
            this.positionRepository = positionRepository;
        }

        //[Authorize(Policy = "AddUserPolicy")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel viewModel = new RegisterViewModel(areaRepository.GetAll(), positionRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "AddUserPolicy")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                    string folder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    if (!System.IO.File.Exists(folder))
                        Directory.CreateDirectory(folder);
                    uniqueFileName = model.UserName + ".jpg";
                    model.Photo.CopyTo(new FileStream(Path.Combine(folder, uniqueFileName), FileMode.Create));
                }
                var user = new User
                {
                    UserName = model.UserName,
                    FullName = model.FullName,
                    Email = model.Email,
                    Photo = uniqueFileName,
                    PositionId = model.PositionId,
                    AreaId = model.AreaId,
                    Active = true
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)               
                    return RedirectToAction("ListUsers", "Administration");
                
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, model.RememberMe, false    
                );
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        return LocalRedirect(ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Intento de entrar inválido");
            }
            
            return View(model);
        }
        [HttpGet][HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return Json(true);
            return Json($"Email {email} is already in use");
        }
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
                return Json(true);
            return Json($"Username {username} is already in use");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
