using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EORepository : IEORepository
    {
        ApplicationDBContext context;
        public EORepository(ApplicationDBContext con)
        {
            context = con;
        }
        public EO AddEntity(EO entity)
        {
            var r = context.EOs.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public EO Delete(object Id)
        {
            var id = (Tuple<int, int>)Id;
            var eo = context.EOs.FirstOrDefault(x => x.EventId == id.Item1 && x.EventOrganizerId == id.Item2);
            if(eo != null)
                context.EOs.Remove(eo);
            context.SaveChanges();
            return eo;
        }

        public IEnumerable<EO> GetAll()
        {
            return context.EOs;
        }

        public EO GetById(object Id)
        {
            var id = (Tuple<int, int>)Id;
            return context.EOs.FirstOrDefault(x => x.EventId == id.Item1 && x.EventOrganizerId == id.Item2);
        }

        public IEnumerable<EventOrganizer> OrganizersInEvent(int eventid)
        {
            foreach (var item in context.EOs)
            {
                if (item.EventId == eventid) yield return context.EventOrganizers.FirstOrDefault(x => x.Id == item.EventOrganizerId);
            }
        }

        public EO Select(EO entity)
        {
            throw new NotImplementedException();
        }

        public EO Update(EO entity)
        {
            var item = context.EOs.FirstOrDefault(x => x.EventId == entity.EventId && x.EventOrganizerId == entity.EventOrganizerId);
            if (item != null)
                context.EOs.Remove(item);
            context.EOs.Add(entity);
            context.SaveChanges();
            return item;
        }
    }
}
