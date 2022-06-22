using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Parser
    {
        private int _counter;
        private Context _context;
        public IExpression StringToTree(string input, out Context context)
        { 
            context = _context = new Context();
            _counter = 0;
            string toParse = input.Replace(" ", "").Replace(".", ",");
            return StringParse(toParse);
        }
        private IExpression StringParse(string input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == '+')
                    return new AddExpression(StringParse(input.Substring(0, i)),
                                             StringParse(input.Substring(i + 1, input.Length - i - 1)));
                else if (input[i] == '-')
                    return new SubtractExpression(StringParse(input.Substring(0, i)),
                                                  StringParse(input.Substring(i + 1, input.Length - i - 1)));
            }
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == '*')
                    return new MultipExpression(StringParse(input.Substring(0, i)),
                                                StringParse(input.Substring(i + 1, input.Length - i - 1)));
                else if (input[i] == '/')
                    return new DivideExpression(StringParse(input.Substring(0, i)),
                                                StringParse(input.Substring(i + 1, input.Length - i - 1)));
            }
            _context.SetVariable(_counter.ToString(), double.Parse(input));
            return new NumberExpression(_counter++.ToString());
        }
    }
}
