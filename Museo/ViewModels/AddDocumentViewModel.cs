using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AddDocumentViewModel
    {
        public AddDocumentViewModel(){}

        public AddDocumentViewModel(IEnumerable<DocumentCategory> categories)
        {
            documentCategories = new List<SelectListItem>();
            foreach (var item in categories)
            {
                documentCategories.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Category });
            }
            DateTime dateTime = new DateTime();
            Date = dateTime.Date;
        }
        public DateTime Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere un nombre")]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere un autor")]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Author { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere una fecha")]
        public DateTime PublicationDate { get; set; }

        //[Required]
        public IFormFile Manager { get; set; }
        public List<SelectListItem> documentCategories { get; set; }

        public int DocumentCategoryId { get; set; }

        public DocumentCategory DocumentCategory { get; set; }

    }
}
