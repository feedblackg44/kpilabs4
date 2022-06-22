using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public abstract class NonTermExpression : IExpression
    {
        protected IExpression _leftExpression;
        protected IExpression _rightExpression;
        public NonTermExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public abstract double Interpret(Context context);
    }
}
