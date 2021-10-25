using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AnualVisitorsViewModel
    {
        public int Total { get; set; }
        public double AdultExtPer { get; set; }
        public double AdultNacPer { get; set; }
        public double ChildAloPer { get; set; }
        public double ChildExtPer { get; set; }
        public double ChildComPer { get; set; }
        public double ResidentPer { get; set; }
        public int Year { get; set; }
    }
}
