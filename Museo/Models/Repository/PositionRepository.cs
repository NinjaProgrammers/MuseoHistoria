using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository
{
    public class PositionRepository : IPositionRepository
    {
        ApplicationDBContext context;

        public PositionRepository(ApplicationDBContext con)
        {
            context = con;
        }
        public Position AddEntity(Position entity)
        {
            var r = context.Positions.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Position Delete(object Id)
        {
            var position = context.Positions.FirstOrDefault(x => x.Id == (int)Id);
            if(position != null)
                context.Positions.Remove(position);
            context.SaveChanges();
            return position;
        }

        public IEnumerable<Position> GetAll()
        {
            return context.Positions;
        }

        public Position GetById(object Id)
        {
            return context.Positions.FirstOrDefault(x => x.Id == (int)Id);
        }

        public Position Select(Position entity)
        {
            throw new NotImplementedException();
        }

        public Position Update(Position entity)
        {
            var item = context.Positions.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Description = entity.Description;
                item.Name = entity.Name;                
            }
            context.SaveChanges();
            return item;
        }
    }
}
