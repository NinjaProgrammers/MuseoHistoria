using Museo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.ViewModels
{
    public class IndexViewModel
    {
        public int Earnings { get; set; }
        public int Visitors { get; set; }
        public int Incidences { get; set; }
        public int Activities { get; set; }
        public List<(int,User)> WorkersActivities { get; set; }
        public AnualVisitorsViewModel VisitorsPer { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Document> Documents { get; set; }

    }
}
