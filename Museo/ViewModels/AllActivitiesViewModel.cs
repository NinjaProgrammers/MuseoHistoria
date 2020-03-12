using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AllActivitiesViewModel
    {
        public List<Tuple<Activity, TypeAct, User>> list;
    }
}
