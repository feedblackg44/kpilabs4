using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.ClassesForData;

namespace Lab1
{
    public class Queries
    {   
        public Data Data { get; private set; } = new Data();
        public IEnumerable<Worker> QueryAllWorkers()
        {
            var query = from x in Data.workersTable
                        select x;
            return query;
        }
        public IEnumerable<string> QueryAllNames()
        {
            var query = Data.workersTable.Select(x => x.FullName);
            return query;
        }
        public IEnumerable<WorkerSalaryList> QueryNewObj()
        {
            var query = from x in Data.workersTable
                        select new WorkerSalaryList
                        {
                            PersonnelId = x.PersonnelId,
                            Name = x.FullName
                        };
            return query;
        }
        public IEnumerable<Worker> QueryWhere()
        {
            var query = from x in Data.workersTable
                        where x.WorkStartDate > new DateTime(2021, 11, 1) &&
                              x.Education == EduLevel.High
                        select x;
            return query;
        }
        public IOrderedEnumerable<Worker> QuerySort()
        {
            var query = Data.workersTable.Where((x) =>
            {
                return x.WorkStartDate < new DateTime(2022, 1, 1) &&
                       (x.Education == EduLevel.None || x.Education == EduLevel.Middle);
            }).OrderByDescending(x => x.Surname);
            return query;
        }
        public IEnumerable<TestClass> QueryCartesian()
        {
            var query = from x in Data.specialitiesTable
                        from y in Data.workersTable
                        select new TestClass()
                        { 
                            Param1 = x.Name, 
                            Param2 = y.FullName 
                        };
            return query;
        }
        public IEnumerable<SalaryOfWorker> QueryInnerJ()
        {
            var query = Data.workersTable.Join(
                                Data.salaryTable22,
                                x => x.Cardnum,
                                y => y.Cardnum,
                                (x, y) => new SalaryOfWorker()
                                {
                                    Year = y.Year,
                                    Month = y.Month,
                                    Surname = x.Surname,
                                    Salary = y.Salary
                                });
            return query;
        }
        public IEnumerable<WorkerSalaryList> QueryGroupJ()
        {
            var query = from x in Data.workersTable
                        join y in Data.salaryTable22
                            on x.Cardnum equals y.Cardnum into tempTable
                        select new WorkerSalaryList()
                        { 
                            PersonnelId = x.PersonnelId, 
                            Name = x.FullName,
                            Table = tempTable
                        };
            return query;
        }
        public IEnumerable<SpecsOfWorkers> QueryCrossJ()
        {
            var query = from x in Data.specialitiesTable
                        join y in Data.linksTable
                            on x.Number equals y.Specnum into temp1
                        from t1 in temp1
                        join z in Data.workersTable
                            on t1.Cardnum equals z.Cardnum into temp2
                        from t2 in temp2
                        orderby t2.Name, x.Name
                        select new SpecsOfWorkers()
                        {
                            Worker = t2.Name,
                            Spec = x.Name 
                        };
            return query;
        }
        public IEnumerable<SalaryOfWorker> QueryOuterJ()
        {
            var query = from x in Data.workersTable
                        join y in Data.salaryTable21
                            on x.Cardnum equals y.Cardnum into temp
                        from t in temp.DefaultIfEmpty()
                        select new SalaryOfWorker()
                        {
                            Surname = x.Surname,
                            Salary = ((t == null) ? 0 : t.Salary)
                        };
            return query;
        }
        public IEnumerable<string> QueryDistinct()
        {
            var query = (from x in Data.workersTable
                         select x.WorkStartDate.ToShortDateString()).Distinct();
            return query;
        }
        public IEnumerable<SalaryByMonth> QueryUnion()
        {
            var query = Data.salaryTable21.Union(Data.salaryTable22, 
                                                 new SalaryComparer())
                                          .OrderBy(x => x.Year)
                                          .ThenBy(x => x.Month);
            return query;
        }
        public IOrderedEnumerable<SalaryByMonth> QueryConcat()
        {
            var query = from x in Data.salaryTable21.Concat(Data.salaryTable22)
                        orderby x.Year, x.Month
                        select x;
            return query;
        }
        public IOrderedEnumerable<SalaryByMonth> QueryIntersect()
        {
            var query = from x in Data.salaryTable21.Intersect(Data.salaryTable22,
                                                               new SalaryComparer())
                        orderby x.Year, x.Month
                        select x;
            return query;
        }
        public IEnumerable<SalarySum> QueryGrouping()
        {
            var query = from x in Data.salaryTable22
                        group x by x.Cardnum into g
                        select new SalarySum()
                        {
                            Key = g.Key,
                            Values = g,
                            Sum = g.Sum(t => (t == null) ? 0 : t.Salary),
                        };
            return query;
        }
    }
}
