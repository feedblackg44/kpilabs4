using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ClassesForData
{
    public class WorkerSalaryList
    {
        public Guid PersonnelId { get; set; }
        public string Name { get; set; }
        public IEnumerable<SalaryByMonth> Table { get; set; }
    }
}
