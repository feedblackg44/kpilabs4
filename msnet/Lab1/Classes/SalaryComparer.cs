using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SalaryComparer : IEqualityComparer<SalaryByMonth>
    {
        public bool Equals(SalaryByMonth x, SalaryByMonth y)
        {
            return x.Salary == y.Salary &&
                   x.Year == y.Year &&
                   x.Month == y.Month;
        }
        public int GetHashCode(SalaryByMonth obj)
        {
            return obj.Cardnum;
        }
    }
}
