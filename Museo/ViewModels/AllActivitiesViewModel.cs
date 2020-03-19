using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AllActivitiesViewModel
    {
        public AllActivitiesViewModel()
        {
            list = new List<(Activity, TypeAct, User)>();
        }
        public List<(Activity, TypeAct, User)> list;
    }
}
