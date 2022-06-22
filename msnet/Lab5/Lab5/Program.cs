using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Console.WriteLine("Введите алгебраическое выражение:");
            string input = Console.ReadLine();
            IExpression expression2 = parser.StringToTree(input, out Context context2);
            double result2 = expression2.Interpret(context2);
            Console.WriteLine("Результат: {0}", result2);
            Console.ReadKey();
        }
    }
}
