using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class Document
    {
        public int Id { get; set; }

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
        public string Manager { get; set; }

        public int DocumentCategoryId { get; set; }

        public DocumentCategory DocumentCategory { get; set; }
    }
}
