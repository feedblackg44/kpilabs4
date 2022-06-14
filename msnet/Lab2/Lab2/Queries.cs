using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Xml.Linq;

namespace Lab2
{
    public class Queries
    {
        public Dictionary<DataNames, string> Filenames { get; set; }
        public IEnumerable<XElement> QueryAllWorkers()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = workersXml.Root.Elements("worker");
            return query;
        }
        public IEnumerable<string> QueryAllNames()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = workersXml.Root.Elements("worker").Select(x => x.Element("fullname").Value);
            return query;
        }
        public IEnumerable<XElement> QueryNewObj()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = workersXml.Root.Elements("worker").Select(x =>
                            new XElement("workerperid",
                                new XElement("personnelid", x.Element("personnelid").Value),
                                new XElement("fullname", x.Element("fullname").Value))
                        );
            return query;
        }
        public IEnumerable<XElement> QueryWhere()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = from x in workersXml.Root.Elements("worker")
                        where DateTime.Parse(x.Element("workstartdate").Value) > new DateTime(2021, 11, 1) &&
                              Tools.EduParse(x.Element("education").Value) == EduLevel.High
                        select x;
            return query;
        }
        public IOrderedEnumerable<XElement> QuerySort()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = workersXml.Root.Elements("worker").Where((x) =>
            {
                return DateTime.Parse(x.Element("workstartdate").Value) < new DateTime(2022, 1, 1) &&
                       (Tools.EduParse(x.Element("education").Value) == EduLevel.None ||
                        Tools.EduParse(x.Element("education").Value) == EduLevel.Middle);
            }).OrderByDescending(x => x.Element("surname").Value);
            return query;
        }
        public IEnumerable<XElement> QueryCartesian()
        {
            XDocument specialitiesXml = XDocument.Load(Filenames[DataNames.Specialities]);
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = from x in specialitiesXml.Root.Elements("speciality")
                        from y in workersXml.Root.Elements("worker")
                        select new XElement("test",
                                    new XElement("param1", x.Element("name").Value),
                                    new XElement("param2", y.Element("fullname").Value));
            return query;
        }
        public IEnumerable<XElement> QueryInnerJ()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            XDocument salary22Xml = XDocument.Load(Filenames[DataNames.Salary22]);
            var query = workersXml.Root.Elements("worker").Join(
                                salary22Xml.Root.Elements("salarybymonth"),
                                x => x.Element("cardnum").Value,
                                y => y.Element("cardnum").Value,
                                (x, y) => new XElement("salaryofworker",
                                    new XElement("year", y.Element("year").Value),
                                    new XElement("month", y.Element("month").Value),
                                    new XElement("surname", x.Element("surname").Value),
                                    new XElement("salary", y.Element("salary").Value)));
            return query;
        }
        public IEnumerable<XElement> QueryGroupJ()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            XDocument salary22Xml = XDocument.Load(Filenames[DataNames.Salary22]);
            var query = from x in workersXml.Root.Elements("worker")
                        join y in salary22Xml.Root.Elements("salarybymonth")
                            on x.Element("cardnum").Value equals y.Element("cardnum").Value into tempTable
                        select new XElement("salaryofworker",
                                    new XElement("personnelid", x.Element("personnelid").Value),
                                    new XElement("name", x.Element("fullname").Value),
                                    new XElement("table", tempTable));
            return query;
        }
        public IEnumerable<XElement> QueryCrossJ()
        {
            XDocument specialitiesXml = XDocument.Load(Filenames[DataNames.Specialities]);
            XDocument linksXml = XDocument.Load(Filenames[DataNames.Links]);
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = from x in specialitiesXml.Root.Elements("speciality")
                        join y in linksXml.Root.Elements("workerspeclink")
                            on x.Element("number").Value equals y.Element("specnum").Value into temp1
                        from t1 in temp1
                        join z in workersXml.Root.Elements("worker")
                            on t1.Element("cardnum").Value equals z.Element("cardnum").Value into temp2
                        from t2 in temp2
                        orderby t2.Element("name").Value, x.Element("name").Value
                        select new XElement("specsofworkers",
                                    new XElement("worker", t2.Element("name").Value),
                                    new XElement("spec", x.Element("name").Value));
            return query;
        }
        public IEnumerable<XElement> QueryOuterJ()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            XDocument salary21Xml = XDocument.Load(Filenames[DataNames.Salary21]);
            var query = from x in workersXml.Root.Elements("worker")
                        join y in salary21Xml.Root.Elements("salarybymonth")
                            on x.Element("cardnum").Value equals y.Element("cardnum").Value into temp
                        from t in temp.DefaultIfEmpty()
                        select new XElement("salaryofworker",
                                    new XElement("surname", x.Element("surname").Value),
                                    new XElement("salary", (t == null) ? 0 : int.Parse(t.Element("salary").Value)));
            return query;
        }
        public IEnumerable<string> QueryDistinct()
        {
            XDocument workersXml = XDocument.Load(Filenames[DataNames.Workers]);
            var query = workersXml.Root.Elements("worker").Select(x => x.Element("workstartdate").Value).Distinct();
            return query;
        }
        public IEnumerable<XElement> QueryUnion()
        {
            XDocument salary21Xml = XDocument.Load(Filenames[DataNames.Salary21]);
            XDocument salary22Xml = XDocument.Load(Filenames[DataNames.Salary22]);
            var query = salary21Xml.Root.Elements("salarybymonth").Union(salary22Xml.Root.Elements("salarybymonth"))
                                                                  .OrderByDescending(x => x.Element("year").Value)
                                                                  .ThenBy(x => x.Element("month").Value)
                                                                  .Distinct(new SalaryComparer());
            return query;
        }
        public IOrderedEnumerable<XElement> QueryConcat()
        {

            XDocument salary21Xml = XDocument.Load(Filenames[DataNames.Salary21]);
            XDocument salary22Xml = XDocument.Load(Filenames[DataNames.Salary22]);
            var query = from x in salary21Xml.Root.Elements("salarybymonth").Concat(salary22Xml.Root.Elements("salarybymonth"))
                        orderby x.Element("year").Value descending, x.Element("month").Value
                        select x;
            return query;
        }
        public IOrderedEnumerable<XElement> QueryIntersect()
        {
            XDocument salary21Xml = XDocument.Load(Filenames[DataNames.Salary21]);
            XDocument salary22Xml = XDocument.Load(Filenames[DataNames.Salary22]);
            var query = salary21Xml.Root.Elements("salarybymonth").Intersect(salary22Xml.Root.Elements("salarybymonth"), new SalaryComparer())
                                                                  .OrderByDescending(x => x.Element("year").Value)
                                                                  .ThenBy(x => x.Element("month").Value);
            return query;
        }
        public IEnumerable<XElement> QueryGrouping()
        {
            XDocument salary22Xml = XDocument.Load(Filenames[DataNames.Salary22]);
            var query = from x in salary22Xml.Root.Elements("salarybymonth")
                        group x by x.Element("cardnum").Value into g
                        select new XElement("salaryofworker",
                                    new XElement("key", g.Key),
                                    new XElement("values", g),
                                    new XElement("sum", g.Sum(t => (t == null) ? 0 : int.Parse(t.Element("salary").Value))));
            return query;
        }
    }
}
