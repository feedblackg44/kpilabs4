using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public abstract class Component
    {
        public abstract int Size { get; }
        public abstract string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public abstract string Info(int spaces = 0);
    }
}
