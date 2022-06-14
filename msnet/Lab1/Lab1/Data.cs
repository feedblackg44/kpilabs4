using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Lab1
{
    public class Data
    {
        public List<Speciality> specialitiesTable = new List<Speciality>()
        {
            new Speciality() { Number = 121, 
                               Name = "Инженерия программного обеспечения" },
            new Speciality() { Number = 122, 
                               Name = "Компьютерные науки" },
            new Speciality() { Number = 123, 
                               Name = "Компьютерная инженерия" },
            new Speciality() { Number = 124, 
                               Name = "Системный анализ" },
            new Speciality() { Number = 125, 
                               Name = "Кибербезопасность" },
            new Speciality() { Number = 126, 
                               Name = "Информационные системы и технологии" }
        };
        public List<Worker> workersTable = new List<Worker>()
        {
            new Worker() { Name = "Илья", 
                           Surname = "Плостак", 
                           Patronymic = "Михайлович",
                           Birthdate = new DateTime(2002, 12, 3), 
                           Cardnum = 1,
                           WorkStartDate = new DateTime(2021, 11, 21), 
                           Education = EduLevel.Middle },
            new Worker() { Name = "Руслан",
                           Surname = "Неженец",
                           Patronymic = "Андреевич",
                           Birthdate = new DateTime(2002, 11, 1),
                           Cardnum = 2,
                           WorkStartDate = new DateTime(2021, 11, 21),
                           Education = EduLevel.High },
            new Worker() { Name = "Елизавета",
                           Surname = "Черкасова",
                           Patronymic = "Андреевна",
                           Birthdate = new DateTime(2002, 5, 22),
                           Cardnum = 3,
                           WorkStartDate = new DateTime(2022, 2, 1),
                           Education = EduLevel.High },
            new Worker() { Name = "Арагорн",
                           Surname = "Элессар",
                           Patronymic = "Араторнович",
                           Birthdate = new DateTime(1977, 6, 18),
                           Cardnum = 4,
                           WorkStartDate = new DateTime(2021, 9, 19),
                           Education = EduLevel.None },
        };
        public List<SalaryByMonth> salaryTable21 = new List<SalaryByMonth>()
        {
            new SalaryByMonth() { Cardnum = 1, Month = Months.November, 
                                  Year = 2021, Salary = 900 },
            new SalaryByMonth() { Cardnum = 1, Month = Months.December, 
                                  Year = 2021, Salary = 3100 },
            new SalaryByMonth() { Cardnum = 1, Month = Months.January, 
                                  Year = 2022, Salary = 3100},
            
            new SalaryByMonth() { Cardnum = 2, Month = Months.November,
                                  Year = 2021, Salary = 1350 },
            new SalaryByMonth() { Cardnum = 2, Month = Months.December,
                                  Year = 2021, Salary = 4650 },
            new SalaryByMonth() { Cardnum = 2, Month = Months.January,
                                  Year = 2022, Salary = 4650 },

            new SalaryByMonth() { Cardnum = 4, Month = Months.September,
                                  Year = 2021, Salary = 770 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.October,
                                  Year = 2021, Salary = 2170 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.November,
                                  Year = 2021, Salary = 2100 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.December,
                                  Year = 2021, Salary = 2170 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.January,
                                  Year = 2022, Salary = 2170 }
        };
        public List<SalaryByMonth> salaryTable22 = new List<SalaryByMonth>()
        {
            new SalaryByMonth() { Cardnum = 1, Month = Months.January,
                                  Year = 2022, Salary = 3100 },
            new SalaryByMonth() { Cardnum = 1, Month = Months.February,
                                  Year = 2022, Salary = 2800 },
            new SalaryByMonth() { Cardnum = 1, Month = Months.March,
                                  Year = 2022, Salary = 3100 },
            new SalaryByMonth() { Cardnum = 1, Month = Months.April,
                                  Year = 2022, Salary = 2400 },

            new SalaryByMonth() { Cardnum = 2, Month = Months.January,
                                  Year = 2022, Salary = 4650 },
            new SalaryByMonth() { Cardnum = 2, Month = Months.February,
                                  Year = 2022, Salary = 4200 },
            new SalaryByMonth() { Cardnum = 2, Month = Months.March,
                                  Year = 2022, Salary = 4650 },
            new SalaryByMonth() { Cardnum = 2, Month = Months.April,
                                  Year = 2022, Salary = 3600 },

            new SalaryByMonth() { Cardnum = 3, Month = Months.February,
                                  Year = 2022, Salary = 4200 },
            new SalaryByMonth() { Cardnum = 3, Month = Months.March,
                                  Year = 2022, Salary = 4650 },
            new SalaryByMonth() { Cardnum = 3, Month = Months.April,
                                  Year = 2022, Salary = 3600 },

            new SalaryByMonth() { Cardnum = 4, Month = Months.January,
                                  Year = 2022, Salary = 2170 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.February,
                                  Year = 2022, Salary = 1960 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.March,
                                  Year = 2022, Salary = 2170 },
            new SalaryByMonth() { Cardnum = 4, Month = Months.April,
                                  Year = 2022, Salary = 1680 },
        };
        public List<WorkerSpecLink> linksTable = new List<WorkerSpecLink>()
        {
            new WorkerSpecLink() { Cardnum = 1, Specnum = 122 },
            new WorkerSpecLink() { Cardnum = 1, Specnum = 126 },

            new WorkerSpecLink() { Cardnum = 2, Specnum = 121 },
            new WorkerSpecLink() { Cardnum = 2, Specnum = 123 },
            new WorkerSpecLink() { Cardnum = 2, Specnum = 126 },

            new WorkerSpecLink() { Cardnum = 3, Specnum = 124 },
            new WorkerSpecLink() { Cardnum = 3, Specnum = 125 },

            new WorkerSpecLink() { Cardnum = 4, Specnum = 121 },
            new WorkerSpecLink() { Cardnum = 4, Specnum = 122 },
            new WorkerSpecLink() { Cardnum = 4, Specnum = 126 },
        };
    }
}
