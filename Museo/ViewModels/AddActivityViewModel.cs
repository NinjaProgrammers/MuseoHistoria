using Microsoft.AspNetCore.Mvc.Rendering;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AddActivityViewModel
    {
        public AddActivityViewModel()
        {

        }
        public AddActivityViewModel(IEnumerable<TypeAct> types)
        {
            TypeActs = new List<SelectListItem>();
            foreach (var item in types)
            {
                TypeActs.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
        }
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de adultos extranjeros debe ser mayor que cero")]
        public int AdultExt { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de adultos nacionales debe ser mayor que cero")]
        public int AdultNac { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de niños extranjeros debe ser mayor que cero")]
        public int ChildExt { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de niños nacionales debe ser mayor que cero")]
        public int ChildNac { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string State { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Place { get; set; }
        public string Comment { get; set; }

        public bool Active { get; set; }
        public string UserId { get; set; }
        public int TypeActId { get; set; }

        public User User { get; set; }
        public string Username { get; set; }

        public List<SelectListItem> TypeActs { get; set; }
    }
}
