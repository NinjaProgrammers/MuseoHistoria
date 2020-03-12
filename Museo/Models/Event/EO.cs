using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class EO
    {
        public int EventId { get; set; }

        public int EventOrganizerId { get; set; }

        public EventOrganizer EventOrganizer { get; set; }

        public Event Event { get; set; }
    }
}
