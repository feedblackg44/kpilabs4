using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Enums;

namespace Lab3
{
    public abstract class Car
    {
        public LicenseType License { get; set; }
        public Driver Driver { get; set; }
        public int PeopleLimit { get; set; }
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}
