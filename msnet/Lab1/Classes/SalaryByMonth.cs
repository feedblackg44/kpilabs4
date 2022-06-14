using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SalaryByMonth
    {
        public decimal Salary { get; set; }
        public int Cardnum { get; set; }
        public Months Month { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            string toPrint = string.Format(
                "{0} за {1} {2} на карту номер {3}",
                this.Salary, this.Month, this.Year, this.Cardnum);
            return toPrint;
        }
    }
}
