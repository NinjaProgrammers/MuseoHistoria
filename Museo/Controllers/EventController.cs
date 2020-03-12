using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class EventController : Controller
    {

        public readonly IEventRepository repository;
        private readonly IEventOrganizerRepository organizerRepository;
        private readonly IPersonalityInEventRepository personalityRepository;
        private readonly IEORepository eORepository;

        public EventController(IEventRepository repository, IEventOrganizerRepository organizerRepository, IPersonalityInEventRepository personalityRepository, IEORepository eORepository)
        {
            this.repository = repository;
            this.organizerRepository = organizerRepository;
            this.personalityRepository = personalityRepository;
            this.eORepository = eORepository;
        }

        public ViewResult EventCalendar()
        {
            string events = "[";
            var list = repository.GetAll();

            foreach (var x in list)
            {
                events = "{";
                events += $"title: '{x.EventName},start: '{x.Date}, backgroundColor: '#ffc108'";
                events += "}";
            }
            events += "]";

            //string s = "[{       title: 'All Day Event',start: '2018-03-01',},{title: 'Long Event',start: '2018-03-07'," +
            //    "                    end: '2018-03-10'},{id: 999,title: 'Repeating Event',start: '2018-03-09T16:00:00',backgroundColor: '#ffc108',borderColor: '#ffc108'                },   " +
            //    "             {id: 999,title: 'Repeating Event',start: '2018-03-16T16:00:00',backgroundColor: '#ffc108',borderColor: '#ffc108'},{title: 'Conference',                    start: '2018-03-11',                    end: '2018-03-13'," +
            //    "                    backgroundColor: '#ff407b',borderColor: '#ff407b'},{title: 'Meeting',start: '2018-03-12T10:30:00;end: '2018-03-12T12:30:00',borderColor: '#25d5f2'                },                {                    title: 'Lunch'," +
            //    "                    start: '2018-03-12T12:00:00',                    backgroundColor: '#ff407b',                    borderColor: '#ff407b'                }," +
            //    "               {                    title: 'Meeting',                    start: '2018-03-12T14:30:00',                    backgroundColor: '#25d5f2'," +
            //    "                                borderColor: '#25d5f2'                },                {                    title: 'Happy Hour'," +
            //    "                    start: '2018-03-12T17:30:00'                },                {                    title: 'Dinner'," +
            //    "                    start: '2018-03-12T20:00:00'                },                {                    title: 'Birthday Party'," +
            //    "                    start: '2018-03-13T07:00:00',                    backgroundColor: '#ef172c',                    borderColor: '#ef172c'" +
            //    "                },                {                    title: 'Click for Google',                    url: 'http://google.com/',             " +
            //    "       start: '2018-03-28',                    backgroundColor: '#4285F4',                    borderColor: '#4285F4'                }            ]";
            var j = Json(events);
            return View("All", list.ToList());
            //return View(list.ToList());
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

            foreach (var item in eventx.PersonalityIds)
            {
                PersonalityInEvent p = new PersonalityInEvent()
                {
                    EventId = inserted.Id,
                    EventPersonalityId = item
                };
                personalityRepository.AddEntity(p);
            }
            foreach (var item in eventx.OrganizerIds)
            {
                EO o = new EO()
                {
                    EventId = inserted.Id,
                    EventOrganizerId = item
                };
                eORepository.AddEntity(o);
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
