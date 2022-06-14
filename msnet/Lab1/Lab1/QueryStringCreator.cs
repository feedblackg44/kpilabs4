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
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string AllNames()
        {
            var query = queries.QueryAllNames();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string NewObj()
        {
            var query = queries.QueryNewObj();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( id = {0}, Name = {1} )\n", 
                                        x.PersonnelId.ToString(), x.Name));
            return output.ToString();
        }
        public string Where()
        {
            var query = queries.QueryWhere();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Sort()
        {
            var query = queries.QuerySort();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Cartesian()
        {
            var query = queries.QueryCartesian();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Param1 = {0}, Param2 = {1} )\n", 
                                        x.Param1, x.Param2));
            return output.ToString();
        }
        public string InnerJoin()
        {
            var query = queries.QueryInnerJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Year = {0}, Month = {1}, Surname = {2}, Salary = {3} )\n",
                                        x.Year, x.Month, x.Surname, x.Salary));
            return output.ToString();
        }
        public string GroupJoin()
        {
            var query = queries.QueryGroupJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
            {
                output.Append(x.Name + " c персональным номером " + x.PersonnelId.ToString() + '\n');
                foreach (var y in x.Table)
                    output.Append("  " + y.ToString() + '\n');
            }
            return output.ToString();
        }
        public string CrossJoin()
        {
            var query = queries.QueryCrossJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Worker = {0}, Spec = {1} )\n",
                                            x.Worker, x.Spec));
            return output.ToString();
        }
        public string OuterJoin()
        {
            var query = queries.QueryOuterJ();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(string.Format("( Surname = {0}, Salary = {1} )\n",
                                            x.Surname, x.Salary));
            return output.ToString();
        }
        public string Distinct()
        {
            var query = queries.QueryDistinct();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Union()
        {
            var query = queries.QueryUnion();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Concat()
        {
            var query = queries.QueryConcat();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Intersect()
        {
            var query = queries.QueryIntersect();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append(x.ToString() + '\n');
            return output.ToString();
        }
        public string Grouping()
        {
            var query = queries.QueryGrouping();
            StringBuilder output = new StringBuilder();
            foreach (var x in query)
                output.Append("На карту " + x.Key.ToString() +
                              " за весь период было зачислено " + x.Sum.ToString() + '\n');
            return output.ToString();
        }
    }
}
