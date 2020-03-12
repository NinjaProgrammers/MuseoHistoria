using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class AnualPlan
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Mes inválido")]
        public int Month { get; set; }

        [Required]
        [Range(2000, 2500, ErrorMessage = "Año inválido")]
        public int Year { get; set; }

        [Required]
        [Range(0,double.MaxValue,ErrorMessage = "El valor debe ser mayor que cero")]
        public double Value { get; set; }

    }
}
