using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Lab1
{
    public static class Data
    {
        public static List<Speciality> specialitiesTable = new List<Speciality>()
        {
            new Speciality(121, "Инженерия программного обеспечения"),
            new Speciality(122, "Компьютерные науки"),
            new Speciality(123, "Компьютерная инженерия"),
            new Speciality(124, "Системный анализ"),
            new Speciality(125, "Кибербезопасность"),
            new Speciality(126, "Информационные системы и технологии"),
        };
        public static List<Worker> workersTable = new List<Worker>()
        {
            new Worker("Илья", "Плостак", "Михайлович", 
                       new DateTime(2002, 12, 3), 1,
                       EduLevel.Middle, new DateTime(2021, 11, 21)),
            new Worker("Руслан", "Неженец", "Андреевич", 
                       new DateTime(2002, 11, 1), 2,
                       EduLevel.High, new DateTime(2021, 11, 21)),
            new Worker("Елизавета", "Черкасова", "Андреевна", 
                       new DateTime(2002, 5, 22), 3,
                       EduLevel.High, new DateTime(2022, 2, 1)),
            new Worker("Арагорн", "Элессар", "Араторнович", 
                       new DateTime(1977, 6, 18), 4,
                       EduLevel.None, new DateTime(2021, 9, 19))
        };
        public static List<SalaryByMonth> salaryTable21 = new List<SalaryByMonth>()
        {
            new SalaryByMonth(1, Months.November, 2021, 900),
            new SalaryByMonth(1, Months.December, 2021, 3100),
            new SalaryByMonth(1, Months.January,  2022, 3100),

            new SalaryByMonth(2, Months.November, 2021, 1350),
            new SalaryByMonth(2, Months.December, 2021, 4650),
            new SalaryByMonth(2, Months.January,  2022, 4650),

            new SalaryByMonth(4, Months.September, 2021, 770),
            new SalaryByMonth(4, Months.October,   2021, 2170),
            new SalaryByMonth(4, Months.November,  2021, 2100),
            new SalaryByMonth(4, Months.December,  2021, 2170),
            new SalaryByMonth(4, Months.January,  2022, 2170)
        };
        public static List<SalaryByMonth> salaryTable22 = new List<SalaryByMonth>()
        {
            new SalaryByMonth(1, Months.January,  2022, 3100),
            new SalaryByMonth(1, Months.February, 2022, 2800),
            new SalaryByMonth(1, Months.March,    2022, 3100),
            new SalaryByMonth(1, Months.April,    2022, 2400),

            new SalaryByMonth(2, Months.January,  2022, 4650),
            new SalaryByMonth(2, Months.February, 2022, 4200),
            new SalaryByMonth(2, Months.March,    2022, 4650),
            new SalaryByMonth(2, Months.April,    2022, 3600),

            new SalaryByMonth(3, Months.February, 2022, 4200),
            new SalaryByMonth(3, Months.March,    2022, 4650),
            new SalaryByMonth(3, Months.April,    2022, 3600),

            new SalaryByMonth(4, Months.January,  2022, 2170),
            new SalaryByMonth(4, Months.February, 2022, 1960),
            new SalaryByMonth(4, Months.March,    2022, 2170),
            new SalaryByMonth(4, Months.April,    2022, 1680),
        };
        public static List<WorkerSpecLink> linksTable = new List<WorkerSpecLink>()
        {
            new WorkerSpecLink(1, 122),
            new WorkerSpecLink(1, 126),

            new WorkerSpecLink(2, 121),
            new WorkerSpecLink(2, 123),
            new WorkerSpecLink(2, 126),

            new WorkerSpecLink(3, 124),
            new WorkerSpecLink(3, 125),

            new WorkerSpecLink(4, 121),
            new WorkerSpecLink(4, 122),
            new WorkerSpecLink(4, 126),
        };
    }
}
