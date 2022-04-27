using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SalaryByMonth
    {
        private decimal _salary;
        private int _cardnum;
        private Months _month;
        private int _year;

        public decimal Salary { get => _salary; }
        public int Cardnum { get => _cardnum; }
        public Months Month { get => _month; }
        public int Year { get => _year; }

        public SalaryByMonth(int cardnum, Months month, int year, decimal salary) 
        {
            _salary = salary;
            _cardnum = cardnum;
            _month = month;
            _year = year;
        }
        public override string ToString()
        {
            string toPrint = string.Format(
                "{0} за {1} {2} на карту номер {3}",
                this._salary, this._month, this._year, this._cardnum);
            return toPrint;
        }
    }
}
