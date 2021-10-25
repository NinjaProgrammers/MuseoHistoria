using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class AllVisitViewModel
    {
        public int AdultExt { get; set; }
        public int AdultNac { get; set; }
        public int ChildsCom { get; set; }
        public int ChildExt { get; set; }
        public int ChildAlone { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Resident { get; set; }
        public User User { get; set; }
        public int TotalVisitors { get; set; }
        public int Earning { get; set; }
    }
}
