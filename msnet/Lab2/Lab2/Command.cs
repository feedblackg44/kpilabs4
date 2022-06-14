using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Command
    {
        public delegate string QueryPrint();
        public QueryPrint queryPrint { get; set; }
        public void Execute()
        {
            Console.WriteLine(queryPrint());
        }
    }
}
