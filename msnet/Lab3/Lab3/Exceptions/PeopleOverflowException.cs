using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exceptions
{
    public class PeopleOverflowException : Exception
    {
        public PeopleOverflowException() { }

        public PeopleOverflowException(string message)
            : base(message) { }

        public PeopleOverflowException(string message, Exception inner)
            : base(message, inner) { }
    }
}
