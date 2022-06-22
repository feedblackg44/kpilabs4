using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Context
    {
        private IDictionary<string, double> _vars;
        public Context()
        {
            _vars = new Dictionary<string, double>();
        }
        public double GetVariable(string name)
        {
            return _vars[name];
        }
        public void SetVariable(string name, double value)
        {
            if (_vars.ContainsKey(name))
                _vars[name] = value;
            else
                _vars.Add(name, value);
        }
    }
}
