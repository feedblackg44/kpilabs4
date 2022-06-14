using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ClassesForData
{
    public class SalarySum
    {
        public int Key { get; set; }
        public IGrouping<int, SalaryByMonth> Values { get; set; }
        public decimal Sum { get; set; }
    }
}
