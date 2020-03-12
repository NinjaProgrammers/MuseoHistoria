using Microsoft.AspNetCore.Mvc.Rendering;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AddIncidenceViewModel
    {
        public AddIncidenceViewModel(){}
        public AddIncidenceViewModel(IEnumerable<IncidenceType> incidenceTypes)
        {
            this.incidenceTypes = new List<SelectListItem>();
            foreach (var item in incidenceTypes)
            {
                this.incidenceTypes.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Place { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Responsible { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Category { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string State { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string RegisteredBy { get; set; }

        public DateTime RegisterDate { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Comment { get; set; }

        public List<SelectListItem> incidenceTypes { get; set; }
        public int IncidenceTypeId { get; set; }
    }
}
