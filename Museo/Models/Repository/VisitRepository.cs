using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository
{
    public class VisitRepository : IVisitRepository
    {
        ApplicationDBContext context;

        public VisitRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Visit AddEntity(Visit entity)
        {
            entity.Active = true;
            var r = context.Visits.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Visit Delete(object Id)
        {
            var visit = context.Visits.FirstOrDefault(x => x.Active && x.Id == (int)Id);
            if (visit != null)
                visit.Active = false;
            context.SaveChanges();
            return visit;
        }

        public IEnumerable<Visit> GetAll()
        {
            return context.Visits.Where(x => x.Active);
        }

        public Visit GetById(object Id)
        {
            return context.Visits.FirstOrDefault(x => x.Active && x.Id == (int)Id);
        }

        public Visit Select(Visit entity)
        {
            throw new NotImplementedException();
        }

        public Visit Update(Visit entity)
        {
            var item = context.Visits.FirstOrDefault(x => x.Active && x.Id == entity.Id);
            if (item != null)
            {
                item.AdultExt = entity.AdultExt;
                item.AdultNac = entity.AdultNac;
                item.ChildAlone = entity.ChildAlone;
                item.ChildExt = entity.ChildExt;
                item.ChildsCom = entity.ChildsCom;
                item.Date = entity.Date;
                item.ResidentVisits = entity.ResidentVisits;
                item.User = entity.User;
                item.UserId = entity.UserId;
            }
            context.SaveChanges();
            return item;
        }
    }
}
