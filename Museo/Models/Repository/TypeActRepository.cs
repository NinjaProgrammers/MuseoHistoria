using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class TypeActRepository : ITypeActRepository
    {
        ApplicationDBContext context;

        public TypeActRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public TypeAct AddEntity(TypeAct entity)
        {
            var r = context.TypeActs.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public TypeAct Delete(object Id)
        {
            var typeact = context.TypeActs.FirstOrDefault(x => x.Id == (int)Id);
            if(typeact != null)
                context.TypeActs.Remove(typeact);
            context.SaveChanges();
            return typeact;
        }

        public IEnumerable<TypeAct> GetAll()
        {
            return context.TypeActs;
        }

        public TypeAct GetById(object Id)
        {
            return context.TypeActs.FirstOrDefault(x => x.Id == (int)Id);
        }

        public TypeAct Select(TypeAct entity)
        {
            throw new NotImplementedException();
        }

        public TypeAct Update(TypeAct entity)
        {
            var item = context.TypeActs.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Cost = entity.Cost;
                item.Description = entity.Description;                
            }
            context.SaveChanges();
            return item;
        }
    }
}
