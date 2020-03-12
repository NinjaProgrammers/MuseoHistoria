using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class PersonalityInEvent
    {
        public int EventId { get; set; }
        public int EventPersonalityId { get; set; }

        public Event Event { get; set; }
        public EventPersonality EventPersonality{ get; set; }
    }
}
