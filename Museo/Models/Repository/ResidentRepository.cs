using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository
{
    public class ResidentRepository : IResidentRepository
    {

        ApplicationDBContext context;

        public ResidentRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Resident AddEntity(Resident entity)
        {
            entity.Active = true;
            var r = context.Residents.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Resident Delete(object Id)
        {
            var resident = context.Residents.FirstOrDefault(x => x.Id == (int)Id);
            if (resident != null)
                resident.Active = false;
            context.SaveChanges();
            return resident;
        }

        public IEnumerable<Resident> GetAll()
        {
            return context.Residents.Where(x => x.Active);
        }

        public Resident GetById(object Id)
        {
            return context.Residents.FirstOrDefault(x => x.Active && x.Id == (int)Id);
        }

        public Resident Select(Resident entity)
        {
            throw new NotImplementedException();
        }

        public Resident Update(Resident entity)
        {
            var item = context.Residents.FirstOrDefault(x => x.Active && x.Id == entity.Id);
            if (item != null)
            {
                item.Country = entity.Country;
                item.ResidentVisits = entity.ResidentVisits;
            }
            context.SaveChanges();
            return item;
        }
    }
}
