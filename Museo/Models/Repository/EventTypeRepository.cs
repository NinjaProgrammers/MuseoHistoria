using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EventTypeRepository : IEventTypeRepository
    {
        ApplicationDBContext context;
        public EventTypeRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public EventType AddEntity(EventType entity)
        {
            var r = context.EventTypes.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public EventType Delete(object Id)
        {
            var eventtype = context.EventTypes.FirstOrDefault(x => x.Id == (int)Id);
            if(eventtype != null)
                context.EventTypes.Remove(eventtype);
            context.SaveChanges();
            return eventtype;
        }

        public IEnumerable<EventType> GetAll()
        {
            return context.EventTypes;
        }

        public EventType GetById(object Id)
        {
            return context.EventTypes.FirstOrDefault(x => x.Id == (int)Id);
        }

        public EventType Select(EventType entity)
        {
            throw new NotImplementedException();
        }

        public EventType Update(EventType entity)
        {
            var item = context.EventTypes.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Description = entity.Description;
                item.Type = entity.Type;
            }
            context.SaveChanges();
            return item;
        }
    }
}
