using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class IncidenceRepository : IIncidenceRepository
    {
        ApplicationDBContext context;
        public IncidenceRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Incidence AddEntity(Incidence entity)
        {
            var r = context.Incidences.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public IEnumerable<(Incidence, IncidenceType)> AllIncidenceAndTypes()
        {
            List<(Incidence, IncidenceType)> ret = new List<(Incidence, IncidenceType)>();
            foreach(var x in context.Incidences)
            {
                var i = context.IncidenceTypes.First(p => p.Id == x.IncidenceTypeId);
                ret.Add((x, i));
            }
            return ret;
        }

        public IEnumerable<IncidenceType> AllIncidenceTypes()
        {
            return context.IncidenceTypes;
        }

        public Incidence Delete(object Id)
        {
            var incidence = context.Incidences.FirstOrDefault(x => x.Id == (int)Id);
            if(incidence != null)
                context.Incidences.Remove(incidence);
            context.SaveChanges();
            return incidence;
        }

        public IEnumerable<Incidence> GetAll()
        {
            return context.Incidences;
        }

        public Incidence GetById(object Id)
        {
            return context.Incidences.FirstOrDefault(x => x.Id == (int)Id);
        }

        public Incidence Select(Incidence entity)
        {
            throw new NotImplementedException();
        }

        public Incidence Update(Incidence entity)
        {
            var item = context.Incidences.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Category = entity.Category;
                item.Comment = entity.Comment;
                item.IncidenceType = entity.IncidenceType;
                item.IncidenceTypeId = entity.IncidenceTypeId;
                item.ModifiedBy = entity.ModifiedBy;
                item.ModifiedDate = entity.ModifiedDate;
                item.Place = entity.Place;
                item.RegisterDate = entity.RegisterDate;
                item.RegisteredBy = entity.RegisteredBy;
                item.RegisteredBy = entity.RegisteredBy;
                item.Responsible = entity.Responsible;
                item.State = entity.State;
            }
            context.SaveChanges();
            return item;
        }
    }
}
