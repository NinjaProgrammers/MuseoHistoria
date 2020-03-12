using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class AreaRepository : IAreaRepository
    {
        ApplicationDBContext context;

        public AreaRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Area AddEntity(Area entity)
        {
            var r = context.Areas.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Area Delete(object Id)
        {
            var area = context.Areas.FirstOrDefault(x => x.Id == (int)Id);
            if(area != null)
                context.Areas.Remove(area);
            context.SaveChanges();
            return area;
        }

        public IEnumerable<Area> GetAll()
        {
            return context.Areas;
        }

        public Area GetById(object Id)
        {
            return context.Areas.FirstOrDefault(x => x.Id == (int)Id);
        }

        public Area Select(Area entity)
        {
            throw new NotImplementedException();
        }

        public Area Update(Area entity)
        {
            var item = context.Areas.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Acronym = entity.Acronym;
                item.Name = entity.Name;
            }
            context.SaveChanges();
            return item;
        }
    }
}
