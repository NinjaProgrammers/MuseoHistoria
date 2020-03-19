using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository.Interfaces
{
    public interface IVisitRepository: IRepository<Visit>
    {
        public Tuple<int, Tuple<int, int, int, int, int, int, int>> MonthProfit(int month);
        public int AnualProfit(int year);
        public void SetPrices(int adulNac = 10, int adultExt = 75, int childAlone = 5, int childCom = 3, int childExt = 50, int resident = 30);
        public Tuple<int, int, int, int, int, int, int> VisitFlow_Month(int m, int year = 2020);
        
    }
}
