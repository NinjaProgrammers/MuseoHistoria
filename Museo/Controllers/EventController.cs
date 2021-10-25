using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Museo.Controllers
{
    internal class EventView
    {
        public string start { get; set; }
        public string title { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string url { get; set; }

    }
    public class EventController : Controller
    {

        public readonly IEventRepository repository;
        private readonly IEventOrganizerRepository organizerRepository;
        private readonly IPersonalityInEventRepository personalityRepository;
        private readonly IEORepository eORepository;

        public EventController(IEventRepository repository, IEventOrganizerRepository organizerRepository, IPersonalityInEventRepository personalityRepository,
            IEORepository eORepository)
        {
            this.repository = repository;
            this.organizerRepository = organizerRepository;
            this.personalityRepository = personalityRepository;
            this.eORepository = eORepository;
        }


        public IActionResult Event(int id)
        {
            var item = repository.GetById(id);
            EventViewModel e = new EventViewModel(item);
            e.Personalities = personalityRepository.PersonalitiesInEvent(item.Id).ToList();
            e.Organizers = eORepository.OrganizersInEvent(item.Id).ToList();
            e.EventThmatic = repository.Theme(item.EventThmaticId);
            e.EventType = repository.Type(item.EventTypeId);

            return View(e);
        }

        public ViewResult Calendar()
        {
            string[] Colors = { "#ef172c", "#4285F4", "#25d5f2", "#ff407b", "#ffc108" };

            Random r = new Random();

            List<EventView> list = new List<EventView>();
            foreach (var item in repository.GetAll())
            {
                var month = item.Date.Month.ToString().Length == 1 ? "0" + item.Date.Month.ToString() : item.Date.Month.ToString();
                var day = item.Date.Day.ToString().Length == 1 ? "0" + item.Date.Day.ToString() : item.Date.Day.ToString();
                EventView eventView = new EventView()
                {
                    backgroundColor = Colors[r.Next(0, 5)],
                    start = item.Date.Year.ToString() + "-" + month + "-" + day,
                    title = item.EventName,
                    url = Url.Action("Event", "Event", new { id = item.Id})
                };
                eventView.borderColor = eventView.backgroundColor;
                list.Add(eventView);
            }
            JsonSerializerSettings jsonSerializer = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            CalendarViewModel viewModel = new CalendarViewModel()
            {
                DefaultDate = JsonConvert.SerializeObject(DateTime.Now.Date),
                Events = JsonConvert.SerializeObject(list, jsonSerializer)
            };
            return View(viewModel);
        }
        public ViewResult All()
        {
            List<EventViewModel> viewModels = new List<EventViewModel>();
            var events = repository.GetAll();
            foreach (var item in events)
            {
                EventViewModel e = new EventViewModel(item);
                e.Personalities = personalityRepository.PersonalitiesInEvent(item.Id).ToList();
                e.Organizers = eORepository.OrganizersInEvent(item.Id).ToList();
                e.EventThmatic = repository.Theme(item.EventThmaticId);
                e.EventType = repository.Type(item.EventTypeId);
                viewModels.Add(e);
            }
            return View(viewModels);
        }

        public ViewResult Add()
        {
            AddEventViewModel viewModel = new AddEventViewModel(repository.Personalities(), repository.Organizers(), repository.Thematics(), repository.Types());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel eventx)
        {
            if (!ModelState.IsValid)
            {
                return View(eventx);
            }

            Event e = new Event();
            e.Date = eventx.Date;
            e.EventDescription = eventx.EventDescription;
            e.EventName = eventx.EventName;
            e.EventThmaticId = eventx.EventThmaticId;
            e.EventTypeId = eventx.EventTypeId;
            e.Place = eventx.Place;
            e.TotalParticipant = eventx.TotalParticipant;
            Event inserted = repository.AddEntity(e);

            if (eventx.PersonalityIds != null)
            {
                foreach (var item in eventx.PersonalityIds)
                {
                    PersonalityInEvent p = new PersonalityInEvent()
                    {
                        EventId = inserted.Id,
                        EventPersonalityId = item
                    };
                    personalityRepository.AddEntity(p);
                }
            }
            if (eventx.OrganizerIds != null)
            {
                foreach (var item in eventx.OrganizerIds)
                {
                    EO o = new EO()
                    {
                        EventId = inserted.Id,
                        EventOrganizerId = item
                    };
                    eORepository.AddEntity(o);
                }
            }
            return RedirectToAction("All");
        }
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public ViewResult Update(int Id)
        {
            var anualplan = repository.GetById(Id);
            return View(anualplan);
        }
        [HttpPost]
        public IActionResult Update(Event eventx)
        {
            repository.Update(eventx);
            return RedirectToAction("All");
        }
    }
}
