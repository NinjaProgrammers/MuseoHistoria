using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {

        }

        public RegisterViewModel(IEnumerable<Area> areas, IEnumerable<Position> positions)
        {
            this.areas = new List<SelectListItem>();
            this.positions = new List<SelectListItem>();
            foreach (var item in areas)
            {
                this.areas.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            foreach (var item in positions)
            {
                this.positions.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
        }

        [Required(ErrorMessage = "Introduzca un nombre de usuario")]
        [MaxLength(20, ErrorMessage = "Caracteres máximos excedidos")]
        [Remote(action: "IsUsernameInUse", controller: "Account")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Introduzca su nombre")]
        [MaxLength(60, ErrorMessage = "Caracteres máximos excedidos")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Introduzca su primer apellido")]
        [MaxLength(60, ErrorMessage = "Caracteres máximos excedidos")]
        public string First { get; set; }

        [Required(ErrorMessage = "Introduzca su segundo apellido")]
        [MaxLength(60, ErrorMessage = "Caracteres máximos excedidos")]
        public string Last { get; set; }

        [Required(ErrorMessage = "Introduzca su edad")]
        [MaxLength(8, ErrorMessage = "Caracteres máximos excedidos")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Introduzca su teléfono")]
        [Range(18, 80, ErrorMessage = "Edad no válida")]
        public int Age { get; set; }

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

        public List<SelectListItem> areas { get; set; }
        public List<SelectListItem> positions { get; set; }
        public int AreaId { get; set; }
        public int PositionId { get; set; }

    }
}
