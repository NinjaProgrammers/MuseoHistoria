using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class ResidentVisitRepository : IResidentVisitRepository
    {
        ApplicationDBContext context;

        public ResidentVisitRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public ResidentVisit AddEntity(ResidentVisit entity)
        {
            entity.Active = true;
            var r = context.ResidentVisits.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public ResidentVisit Delete(object Id)
        {
            var id = (Tuple<int, int>)Id;
            var residentvisit = context.ResidentVisits.FirstOrDefault(x => x.Active && x.ResidentId == id.Item1 && x.VisitId == id.Item1);
            if (residentvisit != null)
                residentvisit.Active = false;
            context.SaveChanges();
            return residentvisit;
        }

        public IEnumerable<ResidentVisit> GetAll()
        {
            return context.ResidentVisits.Where(x => x.Active);
        }

        public ResidentVisit GetById(object Id)
        {
            var id = (Tuple<int, int>)Id;
            return context.ResidentVisits.FirstOrDefault(x => x.Active && x.ResidentId == id.Item1 && x.VisitId == id.Item2);
        }

        public IEnumerable<Resident> GetByVisitId(int id)
        {
            foreach(var item in context.ResidentVisits.Where(x => x.VisitId == id))
            {
                yield return context.Residents.FirstOrDefault(x => x.Id == item.ResidentId);
            }
        }

        public ResidentVisit Select(ResidentVisit entity)
        {
            throw new NotImplementedException();
        }

        public ResidentVisit Update(ResidentVisit entity)
        {
            var item = context.ResidentVisits.FirstOrDefault(x => x.Active && x.ResidentId == entity.ResidentId && x.VisitId == entity.VisitId);
            if (item != null)
            {
                item.Resident = entity.Resident;
                item.ResidentId = entity.ResidentId;
                item.Visit = entity.Visit;
                item.VisitId = entity.VisitId;
            }
            context.SaveChanges();
            return item;
        }
    }
}
