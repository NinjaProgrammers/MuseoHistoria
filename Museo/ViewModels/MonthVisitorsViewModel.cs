using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class MonthVisitorsViewModel
    {
        public int Year { get; set; }
        public string TotalVisitors { get; set; }
        public string AdultExt { get; set; }
        public string AdultNac { get; set; }
        public string Resident { get; set; }
        public string ChildExt { get; set; }
        public string ChildAlone { get; set; }
        public string ChildComp { get; set; }
        public float Total { get; set; }
    }
}
