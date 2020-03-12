using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class IncidenceTypeRepository : IIncidenceTypeRepository
    {
        ApplicationDBContext context;
        public IncidenceTypeRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public IncidenceType AddEntity(IncidenceType entity)
        {
            var r = context.IncidenceTypes.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public IncidenceType Delete(object Id)
        {
            var incidencetype = context.IncidenceTypes.FirstOrDefault(x => x.Id == (int)Id);
            if(incidencetype != null)
                context.IncidenceTypes.Remove(incidencetype);
            context.SaveChanges();
            return incidencetype;
        }

        public IEnumerable<IncidenceType> GetAll()
        {
            return context.IncidenceTypes;
        }

        public IncidenceType GetById(object Id)
        {
            return context.IncidenceTypes.FirstOrDefault(x => x.Id == (int)Id);
        }

        public IncidenceType Select(IncidenceType entity)
        {
            throw new NotImplementedException();
        }

        public IncidenceType Update(IncidenceType entity)
        {
            var item = context.IncidenceTypes.FirstOrDefault(x => x.Id == entity.Id);
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
