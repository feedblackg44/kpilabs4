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
            string toParse = input.Replace(" ", "")
                                  .Replace(".", ",")
                                  .Replace("*-", "$")
                                  .Replace("/-", "&")
                                  .Replace("*+", "*")
                                  .Replace("/+", "/");
            return StringParse(toParse);
        }
        private IExpression StringParse(string input)
        {
            int i = input.LastIndexOf('+');
            if (i != -1)
                return new AddExpression(StringParse(input.Substring(0, i)),
                                         StringParse(input.Substring(i + 1, input.Length - i - 1)));
            i = input.LastIndexOf('-');
            if (i != -1)
                return new SubtractExpression(StringParse(input.Substring(0, i)),
                                              StringParse(input.Substring(i + 1, input.Length - i - 1)));
            i = input.LastIndexOf('$');
            if (i != -1)
                return new MultipExpression(StringParse(input.Substring(0, i)),
                                            StringParse('-' + input.Substring(i + 1, input.Length - i - 1)));
            i = input.LastIndexOf("&");
            if (i != -1)
                return new DivideExpression(StringParse(input.Substring(0, i)),
                                            StringParse('-' + input.Substring(i + 1, input.Length - i - 1)));
            i = input.LastIndexOf('*');
            if (i != -1)
                return new MultipExpression(StringParse(input.Substring(0, i)),
                                            StringParse(input.Substring(i + 1, input.Length - i - 1)));
            i = input.LastIndexOf('/');
            if (i != -1)
                return new DivideExpression(StringParse(input.Substring(0, i)),
                                            StringParse(input.Substring(i + 1, input.Length - i - 1)));
            double.TryParse(input, out double result);
            _context.SetVariable(_counter.ToString(), result);
            return new NumberExpression(_counter++.ToString());
        }
    }
}
