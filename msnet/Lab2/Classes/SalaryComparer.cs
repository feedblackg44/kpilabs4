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
            bool Result = false;
            if (int.Parse(x.Element("salary").Value) == int.Parse(y.Element("salary").Value) &&
                int.Parse(x.Element("year").Value) == int.Parse(y.Element("year").Value) &&
                int.Parse(x.Element("cardnum").Value) == int.Parse(y.Element("cardnum").Value) &&
                Tools.EduParse(x.Element("month").Value) == Tools.EduParse(y.Element("month").Value))
                Result = true;
            return Result;
        }
        public int GetHashCode(XElement obj)
        {
            return int.Parse(obj.Element("cardnum").Value);
        }
    }
}
