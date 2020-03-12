using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Introduzca un nombre de usuario")]
        [MaxLength(20, ErrorMessage = "Caracteres máximos excedidos")]
        [Remote(action: "IsUsernameInUse", controller: "Account")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Introduzca su nombre")]
        [MaxLength(60, ErrorMessage = "Caracteres máximos excedidos")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Introduzca su contraseña")] 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Introduzca su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña no coincide")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Introduzca su dirección de correo")]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        public IFormFile Photo { get; set; }
    }
}
