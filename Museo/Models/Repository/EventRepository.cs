using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EventRepository : IEventRepository
    {
        ApplicationDBContext context;
        public EventRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Event AddEntity(Event entity)
        {
            var r = context.Events.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Event Delete(object Id)
        {
            var even = context.Events.FirstOrDefault(x => x.Id == (int)Id);
            if(even != null)
             context.Events.Remove(even);
            context.SaveChanges();
            return even;
        }

        public IEnumerable<Event> GetAll()
        {
            return context.Events;
        }

        public Event GetById(object Id)
        {
            return context.Events.FirstOrDefault(x => x.Id == (int)Id);
        }

        public IEnumerable<EventOrganizer> Organizers()
        {
            return context.EventOrganizers;
        }

        public IEnumerable<EventPersonality> Personalities()
        {
            return context.EventPersonalities;
        }

        public Event Select(Event entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventThematic> Thematics()
        {
            return context.EventThematics;
        }

        public EventThematic Theme(int themeId)
        {
            return context.EventThematics.FirstOrDefault(x => x.Id == themeId);
        }

        public EventType Type(int typeId)
        {
            return context.EventTypes.FirstOrDefault(x => x.Id == typeId);
        }

        public IEnumerable<EventType> Types()
        {
            return context.EventTypes;
        }

        public Event Update(Event entity)
        {
            var item = context.Events.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Date = entity.Date;
                item.EOs = entity.EOs;
                item.EventDescription = entity.EventDescription;
                item.EventName = entity.EventName;
                item.EventThmatic = entity.EventThmatic;
                item.EventThmaticId = entity.EventThmaticId;
                item.EventType = entity.EventType;
                item.EventTypeId = entity.EventTypeId;
                item.PersonalityInEvents = entity.PersonalityInEvents;
                item.Place = entity.Place;
                item.TotalParticipant = entity.TotalParticipant;
            }
            context.SaveChanges();
            return item;
        }
    }
}
