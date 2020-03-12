using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EventPersonalityRepository : IEventPersonalityRepository
    {
        ApplicationDBContext context;
        public EventPersonalityRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public EventPersonality AddEntity(EventPersonality entity)
        {
            var r = context.EventPersonalities.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public EventPersonality Delete(object Id)
        {
            var eventpresonality = context.EventPersonalities.FirstOrDefault(x => x.Id == (int)Id);
            if(eventpresonality != null)
                context.EventPersonalities.Remove(eventpresonality);
            context.SaveChanges();
            return eventpresonality;
        }

        public IEnumerable<EventPersonality> GetAll()
        {
            return context.EventPersonalities;
        }

        public EventPersonality GetById(object Id)
        {
            return context.EventPersonalities.FirstOrDefault(x => x.Id == (int)Id);
        }

        public EventPersonality Select(EventPersonality entity)
        {
            throw new NotImplementedException();
        }

        public EventPersonality Update(EventPersonality entity)
        {
            var item = context.EventPersonalities.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                item.PersonalityInEvents = entity.PersonalityInEvents;                
            }
            context.SaveChanges();
            return item;
        }
    }
}
