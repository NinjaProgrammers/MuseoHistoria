using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string EventName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Place { get; set; }

        public string EventDescription { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El total de participantes debe ser mayor que cero")]
        public int TotalParticipant { get; set; }


        public int EventTypeId { get; set; }

        public EventType EventType { get; set; }

        public int EventThmaticId { get; set; }
       
        public EventThematic EventThmatic { get; set; }

        public List<PersonalityInEvent> PersonalityInEvents { get; set; }

        public List<EO> EOs { get; set; }



    }
}
