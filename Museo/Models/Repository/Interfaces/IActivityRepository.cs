using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository.Interfaces
{
    public interface IActivityRepository: IRepository<Activity>
    {
        public (int, int) ActivityProfit(int month, int day = 0, int year = 2020);

        public IEnumerable<(int, int)> ActivitiesByUserAndYear(int year, string user);
        public IEnumerable<(int, int)> ActivitiesByUserAndMonth(int year, int month, string user);
        public IEnumerable<(TypeAct, int)> ActivitiesByUserAndDay(int year, int month, int day, string user);
    }
}
