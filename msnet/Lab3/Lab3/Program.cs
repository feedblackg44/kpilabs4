using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Enums;
using Lab3.Interfaces;

namespace Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Driver> drivers = new List<Driver>()
            {
                new Driver()
                {
                    Age = 24,
                    Name = "Vanya",
                    Surname = "Pupkin",
                    License = LicenseType.B
                },
                new Driver()
                {
                    Age = 25,
                    Name = "Vasya",
                    Surname = "Pupkin",
                    License = LicenseType.D
                }
            };
            List<Passenger> people = new List<Passenger>();
            for (int i = 0; i < 35; i++)
            {
                BenefitType benefit = BenefitType.None;
                if (i % 5 == 0)
                    benefit = BenefitType.Child;
                else if (i % 4 == 1)
                    benefit = BenefitType.Special;
                
                people.Add(new Passenger()
                {
                    Age = i % 5 + 15,
                    Name = "Name" + i.ToString(),
                    Surname = "Surname" + i.ToString(),
                    Benefit = benefit
                });
            }
            Director director = new Director();
            Tester tester = new Tester();

            // Bus //
            BusBuilder bBuilder = new BusBuilder();
            director.MakeBus(bBuilder);
            Bus bus;
            try
            {
                tester.Begin(bBuilder, drivers, people);
                bus = bBuilder.GetResult();
                Console.WriteLine("Перед отправкой пассажиры заплатили {0} гривен.", bus.Money);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

            // Taxi //
            Console.Clear();

            TaxiBuilder tBuilder = new TaxiBuilder();
            director.MakeTaxi(bBuilder);
            Taxi taxi;
            try
            {
                tester.Begin(tBuilder, drivers, people);
                taxi = tBuilder.GetResult();
                Console.WriteLine("Перед отправкой пассажирам потребовалось {0} детских сидений.", taxi.ChildSeats);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
