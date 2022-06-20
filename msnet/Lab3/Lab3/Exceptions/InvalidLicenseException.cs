using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exceptions
{
    public class InvalidLicenseException : Exception
    {
        public InvalidLicenseException() { }

        public InvalidLicenseException(string message)
            : base(message) { }

        public InvalidLicenseException(string message, Exception inner)
            : base(message, inner) { }
    }
}
