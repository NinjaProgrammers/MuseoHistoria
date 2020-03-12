using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class IncidenceViewModel
    {
        public IncidenceViewModel(List<(Incidence, IncidenceType)> incidences)
        {
            this.incidences = incidences;
        }
        public List<(Incidence, IncidenceType)> incidences;
    }
}
