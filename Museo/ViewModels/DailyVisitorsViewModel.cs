using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class DailyVisitorsViewModel
    {
        public string Days { get; set; }
        public string  AdultExt { get; set; }
        public string  AdultNac { get; set; }
        public string  ChildAlone { get; set; }
        public string  ChildCom { get; set; }
        public string  ChildExt { get; set; }
        public string  Resident { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Total { get; set; }

    }
}
