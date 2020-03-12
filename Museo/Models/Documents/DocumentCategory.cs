using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class DocumentCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Category { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "A lo sumo 100 caracteres permitidos")]
        public string Description { get; set; }
    }
}
