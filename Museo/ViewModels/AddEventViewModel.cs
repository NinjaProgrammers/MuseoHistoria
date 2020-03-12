using Microsoft.AspNetCore.Mvc.Rendering;
using Museo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {

        }
        public AddEventViewModel(IEnumerable<EventPersonality> eventPersonalities, IEnumerable<EventOrganizer> eOs, IEnumerable<EventThematic> thematics, IEnumerable<EventType> eventTypes)
        {
            personalities = new List<SelectListItem>();
            organizers = new List<SelectListItem>();
            themes = new List<SelectListItem>();
            types = new List<SelectListItem>();
            foreach (var item in eventPersonalities)
            {
                personalities.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            foreach (var item in eOs)
            {
                organizers.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            foreach (var item in thematics)
            {
                themes.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Thematic });
            }
            foreach (var item in eventTypes)
            {
                types.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
        } 

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "A lo sumo 50 caracteres permitidos")]
        public string Place { get; set; }

        public string EventDescription { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El total de participantes debe ser mayor que cero")]
        public int TotalParticipant { get; set; }


        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public List<EventType> EventTypes { get; set; }
        public List<SelectListItem> types { get; set; }



        public List<SelectListItem> organizers { get; set; }
        public List<int> OrganizerIds { get; set; }
        public List<EO> EOs { get; set; }



        public List<SelectListItem>  personalities { get; set; }
        public List<PersonalityInEvent> PersonalityInEvents { get; set; }
        public List<int> PersonalityIds { get; set; }


        public List<SelectListItem> themes { get; set; }
        public int EventThmaticId { get; set; }
        public EventThematic EventThmatic { get; set; }

    }
}
