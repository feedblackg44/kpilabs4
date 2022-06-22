using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class AddExpression : NonTermExpression
    {
        public AddExpression(IExpression left, IExpression right) : base(left, right) { }
        public override double Interpret(Context context)
        {
            return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
        }
    }
}
