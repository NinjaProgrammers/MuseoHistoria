using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EventThematicRepository : IEventThematicRepository
    {
        ApplicationDBContext context;
        public EventThematicRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public EventThematic AddEntity(EventThematic entity)
        {
            var r = context.EventThematics.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public EventThematic Delete(object Id)
        {
            var eventhematic = context.EventThematics.FirstOrDefault(x => x.Id == (int)Id);
            if (eventhematic != null)
                context.EventThematics.Remove(eventhematic);
            context.SaveChanges();
            return eventhematic;
        }

        public IEnumerable<EventThematic> GetAll()
        {
            return context.EventThematics;
        }

        public EventThematic GetById(object Id)
        {
            return context.EventThematics.FirstOrDefault(x => x.Id == (int)Id);
        }

        public EventThematic Select(EventThematic entity)
        {
            throw new NotImplementedException();
        }

        public EventThematic Update(EventThematic entity)
        {
            var item = context.EventThematics.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Description = entity.Description;
                item.Thematic = entity.Thematic;               
            }
            context.SaveChanges();
            return item;
        }
    }
}
