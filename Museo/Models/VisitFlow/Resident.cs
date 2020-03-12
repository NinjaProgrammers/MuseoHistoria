using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class Resident
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Country { get; set; }

        public List<ResidentVisit> ResidentVisits{ get; set; }

        public bool Active { get; set; }
    }
}
