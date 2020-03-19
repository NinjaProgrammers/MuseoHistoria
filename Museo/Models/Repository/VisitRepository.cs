using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository
{
    public class VisitRepository : IVisitRepository
    {
        public int AdultNacPrice { get { return adultNacPrice; } }
        int adultNacPrice;
        public int AdultExtPrice { get { return adultExtPrice; } }
        int adultExtPrice;
        public int ChildAlonePrice { get { return childAlonePrice; } }
        int childAlonePrice;

        public int ChildExtPrice { get { return childExtPrice; } }
        int childExtPrice;
        public int ChildCompPrice { get { return childComPrice; } }

        public int ResidentPrice { get { return residentPrice; } }
        int residentPrice;

        int childComPrice;
        ApplicationDBContext context;

        public VisitRepository(ApplicationDBContext con)
        {
            SetPrices();
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

        //si se le pasa cero es para coger todos los meses del anno
        public Tuple<int, int, int, int, int, int, int> VisitFlow_Month(int m, int year = 2020)
        {
            var visits = context.Visits.ToList();
            int adultExt_Month = 0;
            int adultNac_Month = 0;
            int childAlone_Month = 0;
            int childCom_Month = 0;
            int childExt_Mont = 0;
            int resident_Month = 0;
            List<int> match_visit = new List<int>();

            foreach (var item in visits)
            {
                if ((item.Date.Month == m || m == 0) && item.Date.Year == year)
                {
                    adultExt_Month += item.AdultExt;
                    adultNac_Month += item.AdultNac;
                    childAlone_Month += item.ChildAlone;
                    childExt_Mont += item.ChildExt;
                    childCom_Month += item.ChildsCom;
                    match_visit.Add(item.Id);
                }
            }
            //residentes 
            var r_visits = context.ResidentVisits.ToList();
            foreach (var item in r_visits)
            {
                if (match_visit.Contains(item.VisitId))
                    resident_Month += 1;
            }
            int total = adultExt_Month + adultNac_Month + childAlone_Month + childCom_Month + childExt_Mont + resident_Month;

            return new Tuple<int, int, int, int, int, int, int>(total, adultExt_Month, adultNac_Month, childAlone_Month, childCom_Month, childExt_Mont, resident_Month);
        }


        public void SetPrices(int adulNac = 10, int adultExt = 75, int childAlone = 5, int childCom = 3, int childExt = 50, int resident = 30)
        {
            adultNacPrice = adulNac;
            adultExtPrice = adultExt;
            childAlonePrice = childAlone;
            childExtPrice = childExt;
            childComPrice = childCom;
            residentPrice = resident;
        }

        public Tuple<int,Tuple<int,int,int,int,int,int,int>> MonthProfit(int month)
        {
            var a = VisitFlow_Month(month);
            var value = a.Item2 * AdultExtPrice + a.Item3 * adultNacPrice + a.Item4 * ChildAlonePrice + a.Item5 * ChildCompPrice + a.Item6 * ChildExtPrice + a.Item7 * residentPrice ;
            return new Tuple<int, Tuple<int, int, int, int, int, int,int>>(value, a);
        }

        public int AnualProfit(int year)
        {
            var a = VisitFlow_Month(0, year);
            return a.Item2 * AdultExtPrice + a.Item3 * adultNacPrice + a.Item4 * ChildAlonePrice + a.Item5 * ChildCompPrice + a.Item6 * ChildExtPrice + a.Item7 * residentPrice;
        }
    }
}
