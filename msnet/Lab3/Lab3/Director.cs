using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Interfaces;
using Lab3.Enums;

namespace Lab3
{
    public class Director
    {
        public void MakeTaxi(IAutoBuilder builder)
        {
            builder.Reset();
            builder.SetLicense(LicenseType.A);
            builder.SetLimit(4);
        }
        public void MakeBus(IAutoBuilder builder)
        {
            builder.Reset();
            builder.SetLicense(LicenseType.D);
            builder.SetLimit(30);
        }
    }
}
