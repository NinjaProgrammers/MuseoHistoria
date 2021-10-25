using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository.Interfaces
{
    public interface IVisitRepository: IRepository<Visit>
    {
        public Tuple<float, VisitAux> AnualProfit(int year);
        public Tuple<float, VisitAux> MonthProfit(int month,int year);
        public Tuple<int, int, int, int, int, int> Prices();
        public (int[], VisitAux[]) DailyProfit(int m, int year = 2020);
    }
}
