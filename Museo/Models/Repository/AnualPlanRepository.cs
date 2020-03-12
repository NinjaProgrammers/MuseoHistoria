using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class AnualPlanRepository : IAnualPlanRepository
    {
        ApplicationDBContext context; 
        public AnualPlanRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public AnualPlan AddEntity(AnualPlan entity)
        {
            var r = context.AnualPlans.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public AnualPlan Delete(object Id)
        {
            var anualplan = context.AnualPlans.FirstOrDefault(x => x.Id == (int)Id);
            if(anualplan != null)
                context.AnualPlans.Remove(anualplan);
            context.SaveChanges();
            return anualplan;
        }

        public IEnumerable<AnualPlan> GetAll()
        {
            return context.AnualPlans;
        }

        public AnualPlan GetById(object Id)
        {
            return context.AnualPlans.FirstOrDefault(x => x.Id == (int)Id);
        }

        public AnualPlan Select(AnualPlan entity)
        {
            throw new NotImplementedException();
        }

        public AnualPlan Update(AnualPlan entity)
        {
            var item = context.AnualPlans.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Month = entity.Month;
                item.Value = entity.Value;
                item.Year = entity.Year;
            }
            context.SaveChanges();
            return item;
        }
    }
}
