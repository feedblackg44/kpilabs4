using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Classes;

namespace Lab2
{
    public class QueryStringCreator
    {
        public Queries _queries;
        public QueryStringCreator(Dictionary<DataNames, string> filenames)
        {
            _queries = new Queries() { Filenames = filenames };
        }
        public string AllWorkers()
        {
            var query = _queries.QueryAllWorkers();
            string output = "";
            foreach (var x in query)
                output += formatWorker(x) + '\n';
            return output;
        }
        public string AllNames()
        {
            var query = _queries.QueryAllNames();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string NewObj()
        {
            var query = _queries.QueryNewObj();
            string output = "";
            foreach (var x in query)
                output += string.Format("( id = {0}, Name = {1} )\n", 
                                        x.Element("personnelid").Value, x.Element("fullname").Value);
            return output;
        }
        public string Where()
        {
            var query = _queries.QueryWhere();
            string output = "";
            foreach (var x in query)
                output += formatWorker(x) + '\n';
            return output;
        }
        public string Sort()
        {
            var query = _queries.QuerySort();
            string output = "";
            foreach (var x in query)
                output += formatWorker(x) + '\n';
            return output;
        }
        public string Cartesian()
        {
            var query = _queries.QueryCartesian();
            string output = "";
            foreach (var x in query)
                output += string.Format("( Param1 = {0}, Param2 = {1} )\n", 
                                        x.Element("param1").Value, x.Element("param2").Value);;
            return output;
        }
        public string InnerJoin()
        {
            var query = _queries.QueryInnerJ();
            string output = "";
            foreach (var x in query)
                output += string.Format("( Year = {0}, Month = {1}, Surname = {2}, Salary = {3} )\n",
                                        x.Element("year").Value, x.Element("month").Value,
                                        x.Element("surname").Value, x.Element("salary").Value);
            return output;
        }
        public string GroupJoin()
        {
            var query = _queries.QueryGroupJ();
            string output = "";
            foreach (var x in query)
            {
                output += string.Format("{0} c персональным номером {1}\n", 
                                        x.Element("name").Value,
                                        x.Element("personnelid").Value);
                foreach (var y in x.Element("table").Elements("salarybymonth"))
                    output += "  " + formatSalary(y) + '\n';
            }
            return output;
        }
        public string CrossJoin()
        {
            var query = _queries.QueryCrossJ();
            string output = "";
            foreach (var x in query)
                output += string.Format("( Worker = {0}, Spec = {1} )\n",
                                        x.Element("worker").Value, x.Element("spec").Value);
            return output;
        }
        public string OuterJoin()
        {
            var query = _queries.QueryOuterJ();
            string output = "";
            foreach (var x in query)
                output += string.Format("( Surname = {0}, Salary = {1} )\n",
                                        x.Element("surname").Value, x.Element("salary").Value);
            return output;
        }
        public string Distinct()
        {
            var query = _queries.QueryDistinct();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Union()
        {
            var query = _queries.QueryUnion();
            string output = "";
            foreach (var x in query)
                output += formatSalary(x) + '\n';
            return output;
        }
        public string Concat()
        {
            var query = _queries.QueryConcat();
            string output = "";
            foreach (var x in query)
                output += formatSalary(x) + '\n';
            return output;
        }
        public string Intersect()
        {
            var query = _queries.QueryIntersect();
            string output = "";
            foreach (var x in query)
                output += formatSalary(x) + '\n';
            return output;
        }
        public string Grouping()
        {
            var query = _queries.QueryGrouping();
            string output = "";
            foreach (var x in query)
                output += "На карту " + x.Element("key").Value +
                          " за весь период было зачислено " + x.Element("sum").Value + '\n';
            return output;
        }
        private string formatWorker(XElement x)
        {
            string curEdu = Tools.ruEduLevel[Tools.EduParse(x.Element("education").Value)];
            string temp = string.Format(
                "- Работник c номером карты {0} -" +
                "\n  ФИО: {1} {2} {3}." +
                "\n  Дата рождения: {4}." +
                "\n  Образование: {5}." +
                "\n  Работает с: {6}." +
                "\n  Уникальный ID: {7}.",
                int.Parse(x.Element("cardnum").Value), x.Element("surname").Value,
                x.Element("name").Value, x.Element("patronymic").Value,
                x.Element("birthdate").Value, curEdu,
                x.Element("workstartdate").Value, x.Element("personnelid").Value);
            return temp;
        }
        private string formatSalary(XElement x)
        {
            string toPrint = string.Format(
                "{0} за {1} {2} на карту номер {3}",
                x.Element("salary").Value, x.Element("month").Value,
                x.Element("year").Value, x.Element("cardnum").Value);
            return toPrint;
        }
    }
}
