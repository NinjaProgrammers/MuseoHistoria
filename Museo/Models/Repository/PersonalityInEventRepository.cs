using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class PersonalityInEventRepository : IPersonalityInEventRepository
    {
        ApplicationDBContext context;
        public PersonalityInEventRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public PersonalityInEvent AddEntity(PersonalityInEvent entity)
        {
            var r = context.PersonalityInEvents.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public PersonalityInEvent Delete(object Id)
        {
            var id = (Tuple<int, int>)Id;
            var personalityinevent = context.PersonalityInEvents.FirstOrDefault(x => x.EventId == id.Item1 && x.EventPersonalityId == id.Item1);
            if(personalityinevent != null)
                context.PersonalityInEvents.Remove(personalityinevent);
            context.SaveChanges();
            return personalityinevent;
        }

        public IEnumerable<PersonalityInEvent> GetAll()
        {
            return context.PersonalityInEvents;
        }

        public PersonalityInEvent GetById(object Id)
        {
            var id = (Tuple<int, int>)Id;
            return context.PersonalityInEvents.FirstOrDefault(x => x.EventId == id.Item1 && x.EventPersonalityId == id.Item2);
        }

        public IEnumerable<EventPersonality> PersonalitiesInEvent(int eventid)
        {
            foreach (var item in context.PersonalityInEvents)
            {
                if (item.EventId == eventid) yield return context.EventPersonalities.FirstOrDefault(x => x.Id == item.EventPersonalityId);
            }
        }

        public PersonalityInEvent Select(PersonalityInEvent entity)
        {
            throw new NotImplementedException();
        }

        public PersonalityInEvent Update(PersonalityInEvent entity)
        {
            var item = context.PersonalityInEvents.FirstOrDefault(x => x.EventId == entity.EventId && x.EventPersonalityId == entity.EventPersonalityId);
            if (item != null)
            {
                item.Event = entity.Event;
                item.EventId = entity.EventId;
                item.EventPersonality = entity.EventPersonality;
                item.EventPersonalityId = entity.EventPersonalityId;
            }
            context.SaveChanges();
            return item;
        }
    }
}
