using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    public class SalaryComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            return int.Parse(x.Element("salary").Value) == int.Parse(y.Element("salary").Value) &&
                   int.Parse(x.Element("year").Value) == int.Parse(y.Element("year").Value) &&
                   Tools.EduParse(x.Element("month").Value) == Tools.EduParse(y.Element("month").Value);
        }
        public int GetHashCode(XElement obj)
        {
            return int.Parse(obj.Element("cardnum").Value);
        }
    }
}
