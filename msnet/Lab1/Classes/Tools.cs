using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    public enum EduLevel
    {
        None = 0,
        Middle = 1,
        High = 2
    }
    public static class Tools
    {
        public static string ruEduLevel(EduLevel eduLevel)
        {
            if (eduLevel == EduLevel.High)
                return "Высшее";
            else if (eduLevel == EduLevel.Middle)
                return "Среднее";
            else
                return "Без образования";
        }
    }
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
