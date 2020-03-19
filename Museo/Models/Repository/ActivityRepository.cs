using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class ActivityRepository : IActivityRepository
    {
        ApplicationDBContext context;

        public ActivityRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public Activity AddEntity(Activity entity)
        {
            entity.Active = true;
            var r = context.Activities.Add(entity).Entity;
            context.SaveChanges();
            return r;
        }

        public Activity Delete(object Id)
        {
            var activity = context.Activities.FirstOrDefault(x => x.Active && x.Id == (int)Id);
            if(activity != null)
                activity.Active = false;
            context.SaveChanges();
            return activity;
        }

        public IEnumerable<Activity> GetAll()
        {
            return context.Activities.Where(x => x.Active);
        }

        public Activity GetById(object Id)
        {
            return context.Activities.FirstOrDefault(x => x.Active && x.Id == (int)Id);
        }

        public Activity Select(Activity entity)
        {
            throw new NotImplementedException();
        }
        
        public Activity Update(Activity entity)
        {
            var item = context.Activities.FirstOrDefault(x => x.Id == entity.Id);
            if (item != null)
            {
                item.Active = entity.Active;
                item.AdultExt = entity.AdultExt;
                item.AdultNac = entity.AdultNac;
                item.ChildExt = entity.ChildExt;
                item.ChildNac = entity.ChildNac;
                item.Comment = entity.Comment;
                item.Date = entity.Date;
                item.Place = entity.Place;
                item.State = entity.State;
                item.TypeAct = entity.TypeAct;
                item.TypeActId = entity.TypeActId;
                item.User = entity.User;
                item.UserId = entity.UserId;                
            }
            context.SaveChanges();
            return item;
        }

        public int ActivityProfit(int month, int year = 2020)
        {
            var activities = context.Activities.ToList();
            var typeAct = context.TypeActs.ToList();
            int profit = 0;
            foreach (var item in activities)
            {
                if ((item.Date.Month == month || month == 0) && item.Date.Year == year)
                {

                    int cover = typeAct.First(x => x.Id == item.TypeActId).CoverPrice;
                    profit += (item.AdultExt + item.AdultNac + item.ChildExt + item.ChildNac) * cover;
                }
            }
            return profit;
        }
    }
}
