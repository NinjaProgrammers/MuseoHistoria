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
    }
}
