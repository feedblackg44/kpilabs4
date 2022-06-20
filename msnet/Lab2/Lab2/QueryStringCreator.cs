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
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(FormatWorker(x) + '\n');
            return output.ToString();
        }
        public string AllNames()
        {
            var query = _queries.QueryAllNames();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string NewObj()
        {
            var query = _queries.QueryNewObj();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( id = {0}, Name = {1} )\n", 
                                        x.Element("personnelid").Value, x.Element("fullname").Value));
            return output.ToString();
        }
        public string Where()
        {
            var query = _queries.QueryWhere();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(FormatWorker(x) + '\n');
            return output.ToString();
        }
        public string Sort()
        {
            var query = _queries.QuerySort();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(FormatWorker(x) + '\n');
            return output.ToString();
        }
        public string Cartesian()
        {
            var query = _queries.QueryCartesian();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Param1 = {0}, Param2 = {1} )\n", 
                                        x.Element("param1").Value, x.Element("param2").Value));
            return output.ToString();
        }
        public string InnerJoin()
        {
            var query = _queries.QueryInnerJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Year = {0}, Month = {1}, Surname = {2}, Salary = {3} )\n",
                                        x.Element("year").Value, x.Element("month").Value,
                                        x.Element("surname").Value, x.Element("salary").Value));
            return output.ToString();
        }
        public string GroupJoin()
        {
            var query = _queries.QueryGroupJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
            {
                output.Append(string.Format("{0} c персональным номером {1}\n", 
                                        x.Element("name").Value,
                                        x.Element("personnelid").Value));
                foreach (var y in x.Element("table").Elements("salarybymonth"))
                    output.Append("  " + FormatSalary(y) + '\n');
            }
            return output.ToString();
        }
        public string CrossJoin()
        {
            var query = _queries.QueryCrossJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Worker = {0}, Spec = {1} )\n",
                                        x.Element("worker").Value, x.Element("spec").Value));
            return output.ToString();
        }
        public string OuterJoin()
        {
            var query = _queries.QueryOuterJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Surname = {0}, Salary = {1} )\n",
                                        x.Element("surname").Value, x.Element("salary").Value));
            return output.ToString();
        }
        public string Distinct()
        {
            var query = _queries.QueryDistinct();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Union()
        {
            var query = _queries.QueryUnion();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(FormatSalary(x) + '\n');
            return output.ToString();
        }
        public string Concat()
        {
            var query = _queries.QueryConcat();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(FormatSalary(x) + '\n');
            return output.ToString();
        }
        public string Intersect()
        {
            var query = _queries.QueryIntersect();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(FormatSalary(x) + '\n');
            return output.ToString();
        }
        public string Grouping()
        {
            var query = _queries.QueryGrouping();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append("На карту " + x.Element("key").Value +
                          " за весь период было зачислено " + x.Element("sum").Value + '\n');
            return output.ToString();
        }
        private string FormatWorker(XElement x)
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
        private string FormatSalary(XElement x)
        {
            string toPrint = string.Format(
                "{0} за {1} {2} на карту номер {3}",
                x.Element("salary").Value, x.Element("month").Value,
                x.Element("year").Value, x.Element("cardnum").Value);
            return toPrint;
        }
    }
}
