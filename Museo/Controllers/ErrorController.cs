using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            switch (StatusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Lo sentimos, su pepido no puede ser procesado";
                    break;
            }
            return View("ErrorPage");
        }

         
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {

            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View();
        }

    }
}
