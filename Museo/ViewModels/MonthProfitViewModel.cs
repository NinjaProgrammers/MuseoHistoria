using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class MonthProfitViewModel
    {
        public int Year { get; set; }
        [Range(1,12,ErrorMessage = "Inserte un mes válido")]
        public int Month { get; set; }
        public string Profit { get; set; }
        public string AdultExt { get; set; }
        public string AdultNac { get; set; }
        public string ChildAlone { get; set; }
        public string ChildCom { get; set; }
        public string ChildExt { get; set; }
        public string Resident { get; set; }
        public int Total { get; set; }
    }
}
