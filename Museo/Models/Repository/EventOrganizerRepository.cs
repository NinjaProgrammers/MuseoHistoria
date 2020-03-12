using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EventOrganizerRepository : IEventOrganizerRepository
    {
        ApplicationDBContext context;
        public EventOrganizerRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public EventOrganizer AddEntity(EventOrganizer entity)
        {
            var r = context.EventOrganizers.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public EventOrganizer Delete(object Id)
        {
            var eventorganizer = context.EventOrganizers.FirstOrDefault(x => x.Id == (int)Id);
            if(eventorganizer != null)
                context.EventOrganizers.Remove(eventorganizer);
            context.SaveChanges();
            return eventorganizer;
        }

        public IEnumerable<EventOrganizer> GetAll()
        {
            return context.EventOrganizers;
        }

        public EventOrganizer GetById(object Id)
        {
            return context.EventOrganizers.FirstOrDefault(x => x.Id == (int)Id);
        }

        public EventOrganizer Select(EventOrganizer entity)
        {
            throw new NotImplementedException();
        }

        public EventOrganizer Update(EventOrganizer entity)
        {
            var item = context.EventOrganizers.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.EOs = entity.EOs;
                item.Name = entity.Name;
            }
            context.SaveChanges();
            return item;
        }
    }
}
