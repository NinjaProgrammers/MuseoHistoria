using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class ResidentVisit
    {
        public int VisitId{ get; set; }

        public int ResidentId { get; set; }

        public Visit Visit { get; set; }

        public Resident Resident { get; set; }

        public bool Active { get; set; }

    }
}
