using Museo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {

        }

        public EventViewModel(Event @event)
        {
            EventName = @event.EventName;
            Place = @event.Place;
            EventDescription = @event.EventDescription;
            Date = @event.Date;
            TotalParticipant = @event.TotalParticipant;
            EventTypeId = @event.EventTypeId;
            EventThmaticId = @event.EventThmaticId;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string EventName { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Place { get; set; }


        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El total de participantes debe ser mayor que cero")]
        public int TotalParticipant { get; set; }


        public int EventTypeId { get; set; }

        public EventType EventType { get; set; }

        public int EventThmaticId { get; set; }

        public EventThematic EventThmatic { get; set; }

        public List<PersonalityInEvent> PersonalityInEvents { get; set; }
        public List<EventPersonality> Personalities { get; set; }
        public List<EventOrganizer> Organizers { get; set; }

        public List<EO> EOs { get; set; }
    }
}
