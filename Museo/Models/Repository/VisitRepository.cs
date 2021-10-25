using Museo.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
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
            context = con;
            SetPrices();

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
            return context.Visits;
        }

        public Visit GetById(object Id)
        {
            return context.Visits.FirstOrDefault(x => x.Active && x.Id == (int)Id);
        }

        public Visit Select(Visit entity)
        {
            throw new NotImplementedException();
        }

        public Tuple<int,int,int,int,int,int> Prices()
        {
            return new Tuple<int, int, int, int, int, int>(AdultExtPrice, AdultNacPrice, ChildAlonePrice, ChildCompPrice, ChildExtPrice, ResidentPrice);
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
        public VisitAux VisitFlow_Month(int m, int year = 2020)
        {
            var visits = context.Visits.ToList();
            int total = 0;
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
            total = adultExt_Month + adultNac_Month + childAlone_Month + childCom_Month + childExt_Mont + resident_Month;
            var a = new VisitAux();
            a.adultExt = adultExt_Month;
            a.adultNac = adultNac_Month;
            a.childAlone = childAlone_Month;
            a.childCom = childCom_Month;
            a.childExt = childExt_Mont;
            a.resident = resident_Month;

            return a;
        }

        public VisitAux[] DailyVisit(int m, int year = 2020)
        {
            VisitAux[] days = new VisitAux[32];
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = new VisitAux();
            }
            var visits = context.Visits.ToList();
            foreach (var item in visits)
            {
                if (item.Date.Month == m && item.Date.Year == year)
                {
                    days[item.Date.Day].adultExt += item.AdultExt;
                    days[item.Date.Day].adultNac += item.AdultNac;
                    days[item.Date.Day].childAlone += item.ChildAlone;
                    days[item.Date.Day].childCom += item.ChildsCom;
                    days[item.Date.Day].childExt += item.ChildExt;
                }
            }
            var r_visits = context.ResidentVisits.ToList();
            var query = (from r in context.ResidentVisits
                         join v in context.Visits on r.VisitId equals v.Id
                         select v.Date).ToList();

            foreach (var item in query)
            {
                if (item.Month == m && item.Year == year)
                    days[item.Day].resident += 1;
            }
            return days;
        }
        public (int[], VisitAux[]) DailyProfit(int m, int year = 2020)
        {
            var visits = DailyVisit(m, year);
            int[] result = new int[32];
            for (int i = 0; i < visits.Length; i++)
            {
                result[i] = visits[i].adultExt + visits[i].adultNac  + visits[i].childAlone + visits[i].childCom  + visits[i].childExt  + visits[i].resident ;
            }
            return (result,visits);
        }
        

        public void SetPrices(int adulNac = 5, int adultExt = 7, int childAlone = 1, int childCom = 3, int childExt = 5, int resident = 5)
        {
            adultNacPrice = adulNac;
            adultExtPrice = adultExt;
            childAlonePrice = childAlone;
            childExtPrice = childExt;
            childComPrice = childCom;
            residentPrice = resident;
        }

        public Tuple<float, VisitAux> MonthProfit(int month,int year)
        {
            var a = VisitFlow_Month(month, year);
            var value = a.adultExt * AdultExtPrice + a.adultNac * adultNacPrice + a.childAlone * ChildAlonePrice + a.childCom * ChildCompPrice + a.childExt * ChildExtPrice + a.resident * residentPrice;
            return new Tuple<float, VisitAux>(value, a);
        }

        public Tuple<float, VisitAux> AnualProfit(int year)
        {
            var a = VisitFlow_Month(0, year);
            var value =  a.adultExt * AdultExtPrice + a.adultNac * adultNacPrice + a.childAlone * ChildAlonePrice + a.childCom * ChildCompPrice + a.childExt * ChildExtPrice + a.resident * residentPrice;
            return new Tuple<float, VisitAux>(value, a);
        }



    }
    public class VisitAux
    {

        public int adultExt { get; set; }
        public int adultNac { get; set; }
        public int childAlone { get; set; }
        public int childCom { get; set; }
        public int childExt { get; set; }
        public int resident { get; set; }
        public int total { get { return adultNac + adultExt + childAlone + childCom + childExt + resident; } }
    }
}
