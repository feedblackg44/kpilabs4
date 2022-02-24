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
    public class SalaryByMonth
    {
        private decimal _salary;
        private uint _cardnum;
        private Months _month;
        private uint _year;

        public decimal Salary { get => _salary; }
        public uint Cardnum { get => _cardnum; }
        public Months Month { get => _month; }
        public uint Year { get => _year; }

        public SalaryByMonth(decimal salary, uint cardnum, Months month, uint year) 
        {
            _salary = salary;
            _cardnum = cardnum;
            _month = month;
            _year = year;
        }
    }
}
