using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Interfaces;
using Lab3.Enums;
using Lab3.Exceptions;

namespace Lab3
{
    public class TaxiBuilder : IAutoBuilder
    {
        private Taxi _taxi;
        public void Reset()
        {
            _taxi = new Taxi();
        }
        public void SetLicense(LicenseType license)
        { 
            _taxi.License = license;
        }
        public void SetLimit(int num)
        {
            _taxi.PeopleLimit = num;
        }
        public void AddDriver(Driver driver)
        {
            if (_taxi.Driver != null)
                throw new InvalidOperationException("В такси может быть только один водитель!");
            if (driver.License != LicenseType.B)
                throw new InvalidLicenseException("Водитель должен иметь лицензию категории B!");
            _taxi.Driver = driver;
        }
        public void AddPassenger(Passenger passenger)
        {
            if (_taxi.Passengers.Count >= _taxi.PeopleLimit)
                throw new PeopleOverflowException("Такси заполнено!");
            if (passenger.Benefit == BenefitType.Child)
                _taxi.ChildSeats++;
            _taxi.Passengers.Add(passenger);
        }
        public Taxi GetResult()
        {
            if (_taxi.Driver == null)
                throw new InvalidOperationException("В такси должен быть водитель!");
            if (_taxi.Passengers.Count == 0)
                throw new InvalidOperationException("В такси должны быть пассажиры!");
            return _taxi;
        }
    }
}
