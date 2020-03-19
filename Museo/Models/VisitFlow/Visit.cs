using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class Visit
    {
        public int  Id { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de adultos extranjeros debe ser mayor que cero")]
        public int AdultExt { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de adultos nacionales debe ser mayor que cero")]
        public int AdultNac { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de niños acompañados debe ser mayor que cero")]
        public int ChildsCom { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de niños extranjeros debe ser mayor que cero")]
        public int ChildExt { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de niños solos debe ser mayor que cero")]
        public int ChildAlone { get; set; }

        public bool Active { get; set; }
        public string UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<ResidentVisit> ResidentVisits { get; set; }

        public User User { get; set; }
    }
}
