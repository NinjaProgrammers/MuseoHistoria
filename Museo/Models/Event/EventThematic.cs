using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EventThematic
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Thematic { get; set; }

        public string Description { get; set; }
    }
}
