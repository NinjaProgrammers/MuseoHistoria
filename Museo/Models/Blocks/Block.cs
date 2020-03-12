using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class Block
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres")]
        public string State { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de intentos debe ser mayor que cero")]
        public int TotalIntents { get; set; }
    }
}
