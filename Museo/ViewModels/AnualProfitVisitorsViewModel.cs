using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AnualProfitVisitorsViewModel
    {

        public int Total { get; set; }
        public string AdultExt { get; set; }
        public string AdultNac { get; set; }
        public string ChildAlone { get; set; }
        public string ChildCom { get; set; }
        public string ChildExt { get; set; }
        public string Residents { get; set; }
        public int Year { get; set; }
        public string Stacked { get; set; }
    }
}
