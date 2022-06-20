using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Enums;

namespace Lab3.Interfaces
{
    public interface IAutoBuilder
    {
        void Reset();
        void SetLicense(LicenseType license);
        void SetLimit(int num);
        void AddDriver(Driver driver);
        void AddPassenger(Passenger passenger);
    }
}
