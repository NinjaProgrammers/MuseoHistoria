using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Museo.Models;

namespace Museo.Controllers
{
    public class LoginController: Controller
    {
        public ViewResult Login()
        {
            ViewBag.Title = "Login";
            return View("Login");
        }

        public ViewResult Register()
        {
            ViewBag.Title = "Registrar Usuario";
            ViewBag.UserValidation = "no funciono";
            return View();
        }

        [HttpPost]
        public ViewResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View();
            ViewBag.UserValidation = "hola si funciono";
            return View();
        }

        [HttpGet]
        public ViewResult ForgetPassword()
        {
            return View();
        }
    }
}
