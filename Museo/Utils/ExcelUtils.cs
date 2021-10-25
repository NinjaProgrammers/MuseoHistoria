using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Museo.Utils
{
    public class ExcelUtils
    {
        private IEnumerable<string> TableNames { get; }
        public ExcelUtils(IEnumerable<string> TableNames)
        {
            this.TableNames = TableNames;
        }

    }
}
