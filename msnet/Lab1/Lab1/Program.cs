using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] menu = new string[] {
                "Простая выборка элементов",
                "Выборка отдельного поля (проекция)",
                "Создание нового объекта анонимного типа",
                "Условия",
                "Сортировка с использованием расширяющих методов",
                "Декартовое произведение",
                "Inner Join",
                "Group Join",
                "Cross Join",
                "Outer Join",
                "Distinct",
                "Union - объединение без дубликатов",
                "Concat - объединение с дубликатами",
                "Intersect - пересечение",
                "Группирование с функциями агрегирования"
            };

            bool stay = true;
            int choice = 0;
            while (stay)
            {
                bool toChoose = true;
                bool printAgain = true;
                while (toChoose)
                {
                    if (printAgain)
                    {
                        Console.Clear();
                        Console.WriteLine("\n");
                        Console.WriteLine(new String('-', 10) +
                                          " Меню " +
                                          new String('-', 10));
                        Console.WriteLine("\n");
                        for (int i = 0; i < menu.Length; i++)
                        {
                            if (i == choice)
                                Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Запрос номер {0}: {1}.", i + 1, menu[i]);
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Выберите запрос стрелочками вверх и вниз.\n" +
                                          "Нажмите Esc чтобы выйти.");
                    }
                    else
                        printAgain = true;

                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            toChoose = false;
                            break;
                        case ConsoleKey.DownArrow:
                            choice += 1;
                            if (choice >= menu.Length)
                                choice = 0;
                            break;
                        case ConsoleKey.UpArrow:
                            choice -= 1;
                            if (choice < 0)
                                choice = menu.Length - 1;
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        default:
                            printAgain = false;
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine(menu[choice] + "\n");
                switch (choice)
                {
                    case 0:
                        var query1 = from x in Data.workersTable
                                     select x;
                        foreach (var x in query1)
                            Console.WriteLine(x);
                        break;
                    case 1:
                        var query2 = from x in Data.workersTable
                                     select x.FullName;
                        foreach (var x in query2)
                            Console.WriteLine(x);
                        break;
                    case 2:
                        var query3 = from x in Data.workersTable
                                     select new { id = x.PersonnelId, name = x.FullName };
                        foreach (var x in query3)
                            Console.WriteLine(x);
                        break;
                    case 3:
                        var query4 = from x in Data.workersTable
                                     where x.WorkStartDate > new DateTime(2021, 11, 1) && 
                                           x.Education == EduLevel.High
                                     select x;
                        foreach (var x in query4)
                            Console.WriteLine(x);
                        break;
                    case 4:
                        var query5 = Data.workersTable.Where((x) =>
                        {
                            return x.WorkStartDate < new DateTime(2022, 1, 1) && 
                                   (x.Education == EduLevel.None || x.Education == EduLevel.Middle);
                        }).OrderByDescending(x => x.Surname);
                        foreach (var x in query5)
                            Console.WriteLine(x);
                        break;
                    case 5:
                        var query6 = from x in Data.specialitiesTable
                                     from y in Data.workersTable
                                     select new { param1 = x.Name, param2 = y.FullName };
                        foreach (var x in query6)
                            Console.WriteLine(x);
                        break;
                    case 6:
                        var query7 = from x in Data.workersTable
                                     join y in Data.salaryTable22 
                                         on x.Cardnum equals y.Cardnum
                                     select new { y.Year,
                                                  y.Month,
                                                  x.Surname,
                                                  y.Salary };
                        foreach (var x in query7)
                            Console.WriteLine(x);
                        break;
                    case 7:
                        var query8 = from x in Data.workersTable
                                     join y in Data.salaryTable22
                                         on x.Cardnum equals y.Cardnum into tempTable
                                     select new {x.PersonnelId, x.FullName, tempTable };
                        foreach (var x in query8)
                        {
                            Console.WriteLine(x.PersonnelId + ". " + x.FullName);
                            foreach (var y in x.tempTable)
                                Console.WriteLine("  " + y);
                        }
                        break;
                    case 8:
                        var query9 = from x in Data.specialitiesTable
                                     join y in Data.linksTable
                                         on x.Number equals y.Specnum into temp1
                                     from t1 in temp1
                                     join z in Data.workersTable
                                         on t1.Cardnum equals z.Cardnum into temp2
                                     from t2 in temp2
                                     orderby t2.Name, x.Name
                                     select new {worker = t2.Name, spec = x.Name};
                        foreach (var x in query9)
                            Console.WriteLine(x);
                        break;
                    case 9:
                        var query10 = from x in Data.workersTable
                                      join y in Data.salaryTable21 
                                          on x.Cardnum equals y.Cardnum into temp
                                      from t in temp.DefaultIfEmpty()
                                      select new { x.Surname,
                                                   Salary = ((t == null) ? 0 : t.Salary) };
                        foreach (var x in query10)
                            Console.WriteLine(x);
                        break;
                    case 10:
                        var query11 = (from x in Data.workersTable 
                                       select x.WorkStartDate.ToShortDateString()).Distinct();
                        foreach (var x in query11)
                            Console.WriteLine(x);
                        break;
                    case 11:
                        var query12 = (from x in Data.salaryTable21.Union(Data.salaryTable22)
                                      orderby x.Year, x.Month
                                      select x).Distinct(new SalaryComparer());
                        foreach (var x in query12)
                            Console.WriteLine(x);
                        break;
                    case 12:
                        var query13 = from x in Data.salaryTable21.Concat(Data.salaryTable22)
                                      orderby x.Year, x.Month
                                      select x;
                        foreach (var x in query13)
                            Console.WriteLine(x);
                        break;
                    case 13:
                        var query14 = from x in Data.salaryTable21.Intersect(Data.salaryTable22, 
                                                                             new SalaryComparer())
                                      orderby x.Year, x.Month
                                      select x;
                        foreach (var x in query14)
                            Console.WriteLine(x);
                        break;
                    case 14:
                        var query15 = from x in Data.salaryTable22
                                      group x by x.Cardnum into g
                                      select new
                                      {
                                          g.Key,
                                          Values = g,
                                          sum = g.Sum(t => (t == null) ? 0 : t.Salary),
                                      };
                        foreach (var x in query15)
                        {
                            Console.WriteLine("На карту {0} за весь период было зачислено {1}",
                                              x.Key, x.sum);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\n\nНажмите любую клавишу для возвращения в главное меню...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
