using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models.Repository.Interfaces
{
    public interface IResidentVisitRepository:IRepository<ResidentVisit>
    {
        public IEnumerable<Resident> GetByVisitId(int id);
    }
}
