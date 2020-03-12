using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Title { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Author { get; set; }

        public string Link { get; set; }

    }
}
