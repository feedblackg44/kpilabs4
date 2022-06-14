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
            bool Result = false;
            if (x.Salary == y.Salary &&
                x.Year == y.Year &&
                x.Cardnum == y.Cardnum &&
                x.Month == y.Month)
                Result = true;
            return Result;
        }
        public int GetHashCode(SalaryByMonth obj)
        {
            return obj.Cardnum;
        }
    }
}
