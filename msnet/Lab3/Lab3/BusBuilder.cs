using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Enums;
using Lab3.Interfaces;
using Lab3.Exceptions;

namespace Lab3
{
    public class BusBuilder : IAutoBuilder
    {
        private Bus _bus;
        public void Reset()
        {
            _bus = new Bus();
        }
        public void SetLicense(LicenseType license)
        {
            _bus.License = license;
        }
        public void SetLimit(int num)
        {
            _bus.PeopleLimit = num;
        }
        public void AddDriver(Driver driver)
        {
            if (_bus.Driver != null)
                throw new InvalidOperationException("В автобусе может быть только один водитель!");
            if (driver.License != LicenseType.D)
                throw new InvalidLicenseException("Водитель должен иметь лицензию категории D!");
            _bus.Driver = driver;
        }
        public void AddPassenger(Passenger passenger)
        {
            if (_bus.Passengers.Count >= _bus.PeopleLimit)
                throw new PeopleOverflowException("Автобус заполнен!");
            _bus.Money += _bus.Prices[passenger.Benefit];
            _bus.Passengers.Add(passenger);
        }
        public Bus GetResult()
        {
            if (_bus.Driver == null)
                throw new InvalidOperationException("В автобусе должен быть водитель!");
            if (_bus.Passengers.Count == 0)
                throw new InvalidOperationException("В автобусе должны быть пассажиры!");
            return _bus;
        }
    }
}
