using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public interface IIncidenceRepository:IRepository<Incidence>
    {
        public IEnumerable<(Incidence, IncidenceType)> AllIncidenceAndTypes();
        public IEnumerable<IncidenceType> AllIncidenceTypes();
        public IEnumerable<(IncidenceType, int)> IncidencesByDay(int year, int month, int day);
        public IEnumerable<(int, int)> IncidencesByMonth(int year, int month);
        public IEnumerable<(int, int)> IncidencesByYear(int year);


    }
}
