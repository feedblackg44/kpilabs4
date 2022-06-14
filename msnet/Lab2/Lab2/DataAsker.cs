using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Classes;

namespace Lab2
{
    public enum DataNames
    {
        Specialities = 0,
        Workers = 1,
        Salary21 = 2,
        Salary22 = 3,
        Links = 4
    }
    public class DataAsker
    {
        private delegate void CreateMethod(string fullname);
        private DataCreator _creator;
        private Dictionary<DataNames, CreateMethod> _createMethods;
        public DataAsker()
        { 
            _creator = new DataCreator();
            _createMethods = new Dictionary<DataNames, CreateMethod>() {
                { DataNames.Specialities, new CreateMethod(CreateSpecs) },
                { DataNames.Workers, new CreateMethod(CreateWorkers) },
                { DataNames.Salary21, new CreateMethod(CreateSalaries) },
                { DataNames.Salary22, new CreateMethod(CreateSalaries) },
                { DataNames.Links, new CreateMethod(CreateLinks) },
            };
        }
        public Dictionary<DataNames, string> CreateXmls()
        {
            Dictionary<DataNames, string> filenames = new Dictionary<DataNames, string>();
            filenames.Clear();
            Console.WriteLine("Необходимо создать все необходимые файлы. \nСоздадим таблицу специальностей.\n");
            filenames.Add(DataNames.Specialities, CreateFile("specialities", DataNames.Specialities) + ".xml");
            Console.WriteLine("Cоздадим таблицу работников.\n");
            filenames.Add(DataNames.Workers, CreateFile("workers", DataNames.Workers) + ".xml");
            Console.WriteLine("Cоздадим таблицу зарплат за 2021 год.\n");
            filenames.Add(DataNames.Salary21, CreateFile("salary21", DataNames.Salary21) + ".xml");
            Console.WriteLine("Cоздадим таблицу зарплат за 2022 год.\n");
            filenames.Add(DataNames.Salary22, CreateFile("salary22", DataNames.Salary22) + ".xml");
            Console.WriteLine("Создадим таблицу связей между работниками и специальностями.\n");
            filenames.Add(DataNames.Links, CreateFile("links", DataNames.Links) + ".xml");
            return filenames;
        }
        private string CreateFile(string defname, DataNames type)
        {
            string filename = defname;
            string fullname = string.Format("{0}.xml", filename);
            while (true)
            {
                string toCreate = "start";
                if (File.Exists(fullname))
                {
                    while (toCreate != "y" && toCreate != "n")
                    {
                        Console.WriteLine("Файл {0} уже существует:", filename);
                        PrintXml(fullname);
                        Console.WriteLine("Хотите создать новый? (y/n)");
                        toCreate = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                }
                if (toCreate == "n")
                    return filename;
                _createMethods[type](filename);
            }
        }
        private void CreateSpecs(string filename)
        {
            Console.WriteLine("Введите нужное количество специальностей: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Clear();
            List<Speciality> specialitiesTable = new List<Speciality>();
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Специальность номер {0}", i+1);
                Speciality speciality = new Speciality();
                Console.WriteLine("Введите название специальности: ");
                speciality.Name = Console.ReadLine();
                Console.WriteLine("Введите номер специальности: ");
                speciality.Number = int.Parse(Console.ReadLine());
                specialitiesTable.Add(speciality);
                Console.Clear();
                Console.WriteLine("Специальность успешно добавлена!\n");
            }
            _creator.CreateSpecialities(specialitiesTable, filename);
        }
        private void CreateWorkers(string filename)
        {
            Console.WriteLine("Введите нужное количество работников: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Clear();
            List<Worker> workersTable = new List<Worker>();
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Работник номер {0}", i+1);
                Worker worker = new Worker();
                Console.WriteLine("Введите имя: ");
                worker.Name = Console.ReadLine();
                Console.WriteLine("Введите фамилию: ");
                worker.Surname = Console.ReadLine();
                Console.WriteLine("Введите отчество: ");
                worker.Patronymic = Console.ReadLine();
                Console.WriteLine("Введите дату рождения (гггг-мм-дд): ");
                worker.Birthdate = DateTime.Parse(Console.ReadLine());
                worker.Cardnum = i + 1;
                Console.WriteLine("Введите дату начала работы сотрудника (гггг-мм-дд): ");
                worker.WorkStartDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите уровень образования (0 - None, 1 - Middle, 2 - High): ");
                worker.Education = (EduLevel)int.Parse(Console.ReadLine());
                workersTable.Add(worker);
                Console.Clear();
                Console.WriteLine("Работник успешно добавлен!\n");
            }
            _creator.CreateWorkers(workersTable, filename);
        }
        private void CreateSalaries(string filename)
        {
            Console.WriteLine("Введите нужное количество записей зарплат: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Clear();
            List<SalaryByMonth> salaryTable = new List<SalaryByMonth>();
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Запись номер {0}", i+1);
                SalaryByMonth salaryByMonth = new SalaryByMonth();
                Console.WriteLine("Введите номер карты: ");
                salaryByMonth.Cardnum = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите месяц: ");
                salaryByMonth.Month = (Months)int.Parse(Console.ReadLine());
                Console.WriteLine("Введите год: ");
                salaryByMonth.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите зарплату: ");
                salaryByMonth.Salary = int.Parse(Console.ReadLine());
                salaryTable.Add(salaryByMonth);
                Console.Clear();
                Console.WriteLine("Запись успешно добавлена!\n");
            }
            _creator.CreateSalary(salaryTable, filename);
        }
        private void CreateLinks(string filename)
        {
            Console.WriteLine("Введите нужное количество записей в связывающей таблице: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Clear();
            List<WorkerSpecLink> linksTable = new List<WorkerSpecLink>();
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Запись номер {0}", i + 1);
                WorkerSpecLink link = new WorkerSpecLink();
                Console.WriteLine("Введите номер карты: ");
                link.Cardnum = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите номер специальности: ");
                link.Specnum = int.Parse(Console.ReadLine());
                linksTable.Add(link);
                Console.Clear();
                Console.WriteLine("Запись успешно добавлена!\n");
            }
            _creator.CreateLinks(linksTable, filename);
        }
        private void PrintXml(string fullname)
        {
            Console.WriteLine("-----");
            IEnumerable<string> lines = File.ReadLines(fullname);
            foreach (string line in lines)
                Console.WriteLine(line);
            Console.WriteLine("-----");
        }
    }
}
