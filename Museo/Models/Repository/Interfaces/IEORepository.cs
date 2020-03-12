using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public interface IEORepository:IRepository<EO>
    {
        public IEnumerable<EventOrganizer> OrganizersInEvent(int eventid);
    }
}
