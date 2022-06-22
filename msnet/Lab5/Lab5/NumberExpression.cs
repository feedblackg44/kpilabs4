using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class NumberExpression : IExpression
    {
        private string _name;
        public NumberExpression(string varName)
        {
            _name = varName;
        }
        public double Interpret(Context context)
        {
            return context.GetVariable(_name);
        }
    }
}
