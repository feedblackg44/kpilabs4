using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class QueryStringCreator
    {
        public Queries queries = new Queries();
        public string AllWorkers()
        {
            var query = queries.QueryAllWorkers();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string AllNames()
        {
            var query = queries.QueryAllNames();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string NewObj()
        {
            var query = queries.QueryNewObj();
            string output = "";
            foreach (var x in query)
                output += String.Format("( id = {0}, Name = {1} )\n", 
                                        x.PersonnelId.ToString(), x.Name);
            return output;
        }
        public string Where()
        {
            var query = queries.QueryWhere();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Sort()
        {
            var query = queries.QuerySort();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Cartesian()
        {
            var query = queries.QueryCartesian();
            string output = "";
            foreach (var x in query)
                output += String.Format("( Param1 = {0}, Param2 = {1} )\n", 
                                        x.Param1, x.Param2);
            return output;
        }
        public string InnerJoin()
        {
            var query = queries.QueryInnerJ();
            string output = "";
            foreach (var x in query)
                output += String.Format("( Year = {0}, Month = {1}, Surname = {2}, Salary = {3} )\n",
                                        x.Year, x.Month, x.Surname, x.Salary);
            return output;
        }
        public string GroupJoin()
        {
            var query = queries.QueryGroupJ();
            string output = "";
            foreach (var x in query)
            {
                output += x.Name + " c персональным номером " + x.PersonnelId.ToString() + '\n';
                foreach (var y in x.Table)
                    output += "  " + y.ToString() + '\n';
            }
            return output;
        }
        public string CrossJoin()
        {
            var query = queries.QueryCrossJ();
            string output = "";
            foreach (var x in query)
                output += String.Format("( Worker = {0}, Spec = {1} )\n",
                                        x.Worker, x.Spec);
            return output;
        }
        public string OuterJoin()
        {
            var query = queries.QueryOuterJ();
            string output = "";
            foreach (var x in query)
                output += String.Format("( Surname = {0}, Salary = {1} )\n",
                                        x.Surname, x.Salary);
            return output;
        }
        public string Distinct()
        {
            var query = queries.QueryDistinct();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Union()
        {
            var query = queries.QueryUnion();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Concat()
        {
            var query = queries.QueryConcat();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Intersect()
        {
            var query = queries.QueryIntersect();
            string output = "";
            foreach (var x in query)
                output += x.ToString() + '\n';
            return output;
        }
        public string Grouping()
        {
            var query = queries.QueryGrouping();
            string output = "";
            foreach (var x in query)
                output += "На карту " + x.Key.ToString() +
                          " за весь период было зачислено " + x.Sum.ToString() + '\n';
            return output;
        }
    }
}
