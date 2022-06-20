using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Interfaces;

namespace Lab3
{
    internal class Tester
    {
        public void Begin(IAutoBuilder builder, List<Driver> drivers, List<Passenger> people)
        {
            Console.WriteLine("-- Список водителей --");
            for (int i = 0; i < drivers.Count; i++)
            {
                Console.WriteLine("Водитель номер {0}:", i + 1);
                Console.WriteLine("  {0}", drivers[i]);
            }
            Console.WriteLine("\n-- Список пассажиров --");
            for (int i = 0; i < people.Count; i++)
                Console.WriteLine("  {0}", people[i]);

            Console.Write("\nДля отправки нужен водитель." +
                          "\nВведите номер желаемого водителя: ");
            string str = Console.ReadLine();
            if (!string.IsNullOrEmpty(str))
            {
                if (!int.TryParse(str, out int result1))
                    result1 = 2;
                if (result1 > drivers.Count || result1 < 0)
                    result1 = 2;
                builder.AddDriver(drivers[result1 - 1]);
            }
            Console.WriteLine("Проверить добавление второго водителя? Yes - Enter/No - Escape");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);
            }
            if (key.Key == ConsoleKey.Enter)
                builder.AddDriver(drivers[0]);
            Console.Write("Для отправки также нужны пассажиры." +
                          "\nВведите желаемое количество пассажиров: ");
            str = Console.ReadLine();
            if (!string.IsNullOrEmpty(str))
            {
                if (!int.TryParse(str, out int result1))
                    result1 = 1;
                if (result1 > people.Count || result1 < 0)
                    result1 = 1;
                for (int i = 0; i < result1; i++)
                    builder.AddPassenger(people[i]);
            }
        }
    }
}
