using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public interface IPersonalityInEventRepository :IRepository<PersonalityInEvent>
    {
        public IEnumerable<EventPersonality> PersonalitiesInEvent(int eventid);

    }
}
